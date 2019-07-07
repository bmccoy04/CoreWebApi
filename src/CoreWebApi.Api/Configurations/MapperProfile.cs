using AutoMapper;
using CoreWebApi.Api.Dtos;
using CoreWebApi.Core.Entities;

namespace CoreWebApi.Api.Configurations
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