using AutoMapper;
using CommentAndReply.Dto;
using CommentAndReply.Models;

namespace CommentAndReply.Helpers
{
    public class CommentAndReplyMapperProfile : Profile
    {
        public CommentAndReplyMapperProfile()
        {
            CreateMap<Comment, CommentDetailDto>().ReverseMap();
        }
    }
}
