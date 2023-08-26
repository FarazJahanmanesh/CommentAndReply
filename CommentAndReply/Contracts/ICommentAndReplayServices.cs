using CommentAndReply.Dto;
using CommentAndReply.Models;

namespace CommentAndReply.Contracts
{
    public interface ICommentAndReplayServices
    {
        public Task MakeComment(Comment comment); 
        public Task<List<ShowAllCommentDetailDto>> ShowAllComment();
        public Task MakeReplyComment(ReplyComment replyComment);
        public Task<Comment> ShowComment(int id);
        public Task<List<ReplyComment>> ShowAllReply(int id);
    }
}
