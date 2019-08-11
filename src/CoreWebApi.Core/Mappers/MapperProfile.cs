using AutoMapper;
using CoreWebApi.Core.Dtos;
using CoreWebApi.Core.Entities;

namespace CoreWebApi.Core.Configurations
{
    public class MapperProfile : Profile 
    {
        public MapperProfile()
        {
            CreateMap<BlogDto, Blog>();
            CreateMap<Blog, BlogDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<Comment, CommentDto>();
            CreateMap<EntryDto, Entry>();
            CreateMap<Entry, EntryDto>();
        }
    }
}