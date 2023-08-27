using AutoMapper;
using CommentAndReply.Core.Domain.Dto;
using CommentAndReply.Core.Domain.Entities;

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
