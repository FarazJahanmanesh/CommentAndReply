using CommentAndReply.Core.Domain.Dto;
using CommentAndReply.Core.Domain.Entities;

namespace CommentAndReply.Core.Domain.Contracts
{
    public interface ICommentAndReplyRepository
    {
        public Task MakeComment(Comment comment);
        public Task MakeReplyComment(ReplyComment replyComment);
        public Task<List<ShowAllCommentDetailDto>> ShowAllComment();
        public Task<Comment> ShowComment(int id);
        public Task<List<ReplyComment>> ShowAllReply(int id);
    }
}
