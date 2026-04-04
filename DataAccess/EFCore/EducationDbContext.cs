using Core.Entities.Concrete.Auth;
using Core.Logging;
//using Entities.TranslationConcrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DataAccess.EFCore
{
    public class EducationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Graduate> Graduates { get; set; }
        public DbSet<HomeSection> HomeSections { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<UserQuention> UserQuentions { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<WhyChooseUs> WhyChooseUsItems { get; set; }
        public DbSet<GraduateReview> GraduateReviews { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactItem> ContactItems { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<VacancySkill> VacancySkills { get; set; }
        public DbSet<AppLog> AppLogs { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<AppUserPermission> AppUserPermissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        //public DbSet<AboutTranslation> AboutTranslations { get; set; }
        //public DbSet<BlogTranslation> BlogTranslations { get; set; }
        //public DbSet<CourseTranslation> CourseTranslations { get; set; }
        public DbSet<Video> Videos { get; set; }
        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .ToTable("AspNetUsers");

            modelBuilder.Entity<Teacher>()
                .ToTable("Teachers");
            modelBuilder.Entity<Group>()
                .HasOne(g => g.Teacher)
                .WithMany()
                .HasForeignKey(g => g.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
