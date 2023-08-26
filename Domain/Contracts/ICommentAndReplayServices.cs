using CommentAndReply.Core.Domain.Dto;
using CommentAndReply.Core.Domain.Entities;

namespace CommentAndReply.Core.Domain.Contracts
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
