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
            CreateMap<Comment, CreateCommentDetailDto>().ReverseMap();
            CreateMap<Comment, ShowCommentDetailDto>().ReverseMap();
            CreateMap<ReplyComment, CreateCommentReplyDetailDto>().ReverseMap();
            CreateMap<ReplyComment, ShowAllCommentReplyDetailDto >().ReverseMap();
        }
    }
}
