using Business.Factories.Abstract;
using Business.Factories.Concrete;
using Business.Services.Abstract;
using Business.Services.Concrete;
using Business.Services.Concrete.Auth;
using Business.Services.Concrete.Permissions;
using Business.Utilities.Security.Abstract;
using Core.Entities.Concrete.Auth;
using DataAccess.EFCore;
using DataAccess.UnitOfWork.Abstract;
using DataAccess.UnitOfWork.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Reflection;

namespace Business
{
    public static class ConfigurationServices
    {

        public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<ITeacherService, TeacherManager>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var connectionString = config["RedisSettings:ConnectionString"];

                var options = ConfigurationOptions.Parse(connectionString);
                options.AbortOnConnectFail = false;
                options.ConnectRetry = 3;

                return ConnectionMultiplexer.Connect(options);
            });

            services.AddScoped<IGraduateService, GraduateManager>();

            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<EducationDbContext>()
            .AddDefaultTokenProviders();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddScoped<ILessonService, LessonManager>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<IEventService, EventManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<IGraduateReviewService, GraduateReviewManager>();
            services.AddScoped<IRecommendationService, RecommendationManager>();
            services.AddScoped<IStatisticsService, StatisticsManager>();
            services.AddScoped<IWhyChooseUsService, WhyChooseUsManager>();
            services.AddScoped<IFaqService, FaqManager>();
            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<IVacancyService, VacancyManager>();
            services.AddScoped<IPopularCoursesService, PopularCoursesManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IUserMessageService, UserMessageManager>();
            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<IVacancyService, VacancyManager>();
            services.AddScoped<IPopularCoursesService, PopularCoursesManager>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IGroupService, GroupManager>();
            services.AddScoped<ITopicService, TopicManager>();
            services.AddScoped<IPdfService, PdfManager>();
            services.AddScoped<IEmailService, MailManager>();
            services.AddScoped<IResetPasswordService, ResetPasswordManager>();
            services.AddScoped<IPasswordResetWithMailService, PasswordResetWithMailManager>();
            services.AddScoped<IAppLogService, AppLogManager>();
            services.AddScoped<IAuthorizationPermissionService, AuthorizationPermissionManager>();
            services.AddScoped<IPermissionQueryService, PermissionQueryManager>();
            services.AddScoped<IRolePermissionService, RolePermissionManager>();
            services.AddScoped<IAppUserPermissionService, AppUserPermissionManager>();
            services.AddScoped<INotificationService, NotificationManager>();
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserManager>();
            services.AddScoped<IRedisOtpService, RedisOtpManager>();
            services.AddSingleton<IOnlineUserService, OnlineUserManager>();
            services.AddScoped<IVideoService, VideoManager>();
            services.AddHttpClient<VimeoManager>();
            services.AddScoped<IVideoProviderFactory, VideoProviderFactory>();
            return services;
        }
    }
}

