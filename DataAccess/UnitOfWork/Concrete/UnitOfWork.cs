using DataAccess.Repositories.Concrete;

namespace DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationDbContext _context;
        private readonly IGraduateRepository _graduateRepository;
        private readonly IStatisticsRepository? _statisticsRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IAboutRepository _aboutRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IRecommendationRepository _recommendationRepository;
        private readonly IFaqRepository _faqRepository;
        private readonly IGraduateReviewRepository _graduateReviewRepository;
        private readonly IPopularCoursesRepository _popularCoursesRepository;
        private readonly IWhyChooseUsRepository _whyChooseUsRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IUserMessageRepository _userMessageRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IVacancyRepository _vacancyRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IAppLogRepository _appLogRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly IAppUserPermissionRepository _appUserPermissionRepository;
        private readonly IVideoRepository _videoRepository;
        public UnitOfWork(EducationDbContext context)
        {
            _context = context;
        }

        public IGraduateRepository GraduateRepository => _graduateRepository ?? new GraduateRepository(_context);
        public IStatisticsRepository StatisticsRepository => _statisticsRepository ?? new StatisticsRepository(_context);
        public ICourseRepository CourseRepository => _courseRepository ?? new EfCourseRepository(_context);
        public IAboutRepository AboutRepository => _aboutRepository ?? new EfAboutRepository(_context);
        public IEventRepository EventRepository => _eventRepository ?? new EfEventRepository(_context);
        public IRecommendationRepository RecommendationRepository => _recommendationRepository ?? new EfRecommendationRepository(_context);
        public IFaqRepository FaqRepository => _faqRepository ?? new FaqRepository(_context);
        public IGraduateReviewRepository GraduateReviewRepository => _graduateReviewRepository ?? new GraduateReviewRepository(_context);
        public IPopularCoursesRepository PopularCoursesRepository => _popularCoursesRepository ?? new PopularCoursesRepository(_context);
        public IWhyChooseUsRepository WhyChooseUsRepository => _whyChooseUsRepository ?? new WhyChooseUsRepository(_context);
        public IStudentRepository StudentRepository => _studentRepository ?? new EfStudentRepository(_context);
        public ITeacherRepository TeacherRepository => _teacherRepository ?? new EfTeacherRepository(_context);
        public ISkillRepository SkillRepository => _skillRepository ?? new EfSkillRepository(_context);
        public IVacancyRepository VacancyRepository => _vacancyRepository ?? new EfVacancyRepository(_context);
        public IContactRepository ContactRepository => _contactRepository ?? new ContactRepository(_context);
        public IUserMessageRepository UserMessageRepository => _userMessageRepository ?? new UserMessageRepository(_context);
        public ILessonRepository LessonRepository => _lessonRepository ?? new EFLessonRepository(_context);
        public IBlogRepository BlogRepository => _blogRepository ?? new EfBlogRepository(_context);
        public IGroupRepository EfGroupRepository => _groupRepository ?? new EfGroupRepository(_context);
        public ITopicRepository EfTopicRepository => _topicRepository ?? new EfTopicRepository(_context);
        public IAppLogRepository AppLogRepository => _appLogRepository ?? new EfAppLogRepository(_context);
        public IRolePermissionRepository RolePermissionRepository => _rolePermissionRepository ?? new EfRolePermissionRepository(_context);
        public IPermissionRepository PermissionRepository => _permissionRepository ?? new EfPermissionRepository(_context);
        public INotificationRepository NotificationRepository=> _notificationRepository??new NotificationRepository(_context);
        public IUserNotificationRepository UserNotificationRepository=> _userNotificationRepository??new UserNotificationRepository(_context);
        public IAppUserPermissionRepository AppUserPermissionRepository => _appUserPermissionRepository ?? new EfAppUserPermissionRepository(_context);
        public IVideoRepository VideoRepository => _videoRepository ?? new EFVideoRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
