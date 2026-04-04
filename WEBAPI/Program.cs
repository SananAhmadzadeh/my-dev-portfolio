using Business;
using Business.Utilities.ExceptionMiddlewares;
using Business.Validators.Contact;
using Core.Entities.Concrete.Auth;
using Core.Settings;
using DataAccess;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebAPI.Hubs;

var test = Path.Combine(Directory.GetCurrentDirectory(), "..", ".env");
DotNetEnv.Env.Load(test);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining<UserMessageDtoValidator>();
builder.Services.AddDataAccessConfiguration(builder.Configuration);
builder.Services.Configure<MailSettings>(
    builder.Configuration.GetSection("MailSettings"));
builder.Services.AddBusinessConfiguration(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
builder.Configuration
    .AddEnvironmentVariables();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers(options =>
{
    options.Filters.Add<SuccessLoggingFilter>();
});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("Teacher", new OpenApiInfo
    {
        Title = "Teacher API",
        Version = "v1"
    });

    option.SwaggerDoc("All", new OpenApiInfo
    {
        Title = "All APIs",
        Version = "v1"
    });
    option.SwaggerDoc("Student", new OpenApiInfo
    {
        Title = "Student Api",
        Version = "v1"
    });
    option.SwaggerDoc("SuperAdmin", new OpenApiInfo
    {
        Title="SuperAdmin APIs",
        Version = "v1"
    });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    option.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (docName == "All")
            return true;

        return apiDesc.GroupName == docName;
    });
});

TokenOption? tokenOption = builder.Configuration.GetSection("TokenOptions").Get<TokenOption>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenOption?.Issuer,
        ValidAudience = tokenOption?.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(tokenOption.SecurityKey)),
        ClockSkew = TimeSpan.Zero,
    };

    opt.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;

            if (!string.IsNullOrEmpty(accessToken) &&
                (path.StartsWithSegments("/notificationHub") ||
                 path.StartsWithSegments("/onlinehub")))
            {
                context.Token = accessToken;
            }

            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();
builder.Services.AddScoped<IAuthorizationHandler, PermissionHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddSignalR();

var app = builder.Build();

var supportedCultures = new[] { "az", "en", "ru" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("az") 
    .AddSupportedCultures(supportedCultures) 
    .AddSupportedUICultures(supportedCultures); 

app.UseRequestLocalization(localizationOptions);

var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
if (!Directory.Exists(imagesPath))
    Directory.CreateDirectory(imagesPath);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imagesPath),
    RequestPath = "/Images"
});
var pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PDF");
if (!Directory.Exists(pdfPath))
    Directory.CreateDirectory(pdfPath);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(pdfPath),
    RequestPath = "/PDF"
}); 
app.UseDefaultFiles();
app.UseStaticFiles();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint("/swagger/All/swagger.json", "All APIs");
    c.SwaggerEndpoint("/swagger/Teacher/swagger.json", "Teacher APIs");
    c.SwaggerEndpoint("/swagger/Student/swagger.json", "Student APIs");
    c.SwaggerEndpoint("/swagger/SuperAdmin/swagger.json", "SuperAdmin APIs");

});
    

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();
app.MapHub<NotificationHub>("/notificationHub");
app.MapHub<OnlineHub>("/onlinehub");
app.Run();