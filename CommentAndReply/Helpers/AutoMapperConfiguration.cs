using AutoMapper;
using CommentAndReply.Dto;
using CommentAndReply.Models;

namespace CommentAndReply.Helpers
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Comment, ShowAllCommentDetailDto>().ReverseMap();
        }
    }
}
