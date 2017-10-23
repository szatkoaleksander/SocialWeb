using AutoMapper;
using SocialWeb.Core.Domain;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config =  new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Post, PostDto>();
                cfg.CreateMap<Comment, CommentDto>();
            })
            .CreateMapper();

            return config;
        }
    }
}