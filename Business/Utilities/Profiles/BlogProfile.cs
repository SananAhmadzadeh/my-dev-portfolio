using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.BlogDTOs;

namespace Business.Utilities.Profiles;
public class BlogProfile: Profile
{
    
    public BlogProfile()
    {
        CreateMap<CreateBlogDTO, Blog>();

        CreateMap<UpdateBlogDTO, Blog>();

        CreateMap<Blog, GetBlogDTO>();

        CreateMap<Blog, GetAllBlogDTO>();
    }
}
