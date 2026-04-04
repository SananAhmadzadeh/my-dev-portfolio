using Business.Services.Abstract;
using Entities.Enums.Video;

namespace Business.Factories.Abstract
{
    public interface IVideoProviderFactory
    {
        IVideoProviderService Get(VideoProvider provider);
    }
}
