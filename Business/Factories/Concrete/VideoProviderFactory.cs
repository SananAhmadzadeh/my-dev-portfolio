using Business.Factories.Abstract;
using Business.Services.Abstract;
using Business.Services.Concrete;
using Entities.Enums.Video;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Factories.Concrete
{
    public class VideoProviderFactory : IVideoProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public VideoProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IVideoProviderService Get(VideoProvider provider)
        {
            return provider switch
            {
                VideoProvider.Vimeo =>
                    _serviceProvider.GetRequiredService<VimeoManager>(),
                _ => throw new NotSupportedException()
            };
        }
    }
}
