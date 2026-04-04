using DataAccess.Repositories.Concrete.EfCore;

namespace DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        public IGraduateRepository GraduateRepository { get; }
        public IStatisticsRepository StatisticsRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public IAboutRepository AboutRepository { get; }
        public IEventRepository EventRepository { get; }
        public IRecommendationRepository RecommendationRepository { get; }
        public IFaqRepository FaqRepository { get; }
        public IGraduateReviewRepository GraduateReviewRepository { get; }
        public IPopularCoursesRepository PopularCoursesRepository { get; }
        public IWhyChooseUsRepository WhyChooseUsRepository { get; }
        public IStudentRepository StudentRepository { get; }
        public ITeacherRepository TeacherRepository { get; }
        public IContactRepository ContactRepository { get; }
        public IUserMessageRepository UserMessageRepository { get; }
        public ILessonRepository LessonRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public IVacancyRepository VacancyRepository { get; }
        public IBlogRepository BlogRepository { get; }
        public IGroupRepository EfGroupRepository { get; }
        public ITopicRepository EfTopicRepository { get; }
        public IAppLogRepository AppLogRepository { get; }
        public IRolePermissionRepository RolePermissionRepository { get; }
        public IPermissionRepository PermissionRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public IUserNotificationRepository UserNotificationRepository { get; }
        public IAppUserPermissionRepository AppUserPermissionRepository { get; }
        public IVideoRepository VideoRepository { get; }
        public Task<int> SaveAsync();
    }
}
