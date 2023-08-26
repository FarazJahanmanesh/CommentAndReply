using CommentAndReply.Dto;
using CommentAndReply.Models;

namespace CommentAndReply.Contracts
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
