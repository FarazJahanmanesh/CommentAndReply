using CommentAndReply.Contracts;
using CommentAndReply.Dto;
using CommentAndReply.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CommentAndReply.Repository
{
    public class CommentAndReplyRepository : ICommentAndReplyRepository
    {
        private readonly CommentAndReplyDbcontext _commentAndReplyDbcontext;
        public CommentAndReplyRepository(CommentAndReplyDbcontext commentAndReplyDbcontext)
        {
            _commentAndReplyDbcontext = commentAndReplyDbcontext;
        }
        public void MakeComment(Comment comment)
        {
            _commentAndReplyDbcontext.Add(new Comment
            {
                Id = comment.Id,
                CommentText = comment.CommentText,
                CommentDate = comment.CommentDate,
                Name = comment.Name,
                PhoneNumber = comment.PhoneNumber,
                ReplyComments = comment.ReplyComments
            });
            _commentAndReplyDbcontext.SaveChanges();
        }
        public void MakeReplyComment(ReplyComment replyComment)
        {
            _commentAndReplyDbcontext.Add(new ReplyComment
            {
                Id = replyComment.Id,
                CommentId = replyComment.CommentId,
                CommentText = replyComment.CommentText,
                CommentDate = replyComment.CommentDate,
                Name = replyComment.Name,
                PhoneNumber = replyComment.PhoneNumber
            }); 
            _commentAndReplyDbcontext.SaveChanges();
        }
        public List<CommentDetailDto> ShowAllComment()
        {
            List<CommentDetailDto> Comments = new List<CommentDetailDto>();
            List<Comment> comments = _commentAndReplyDbcontext.Comments.ToList();
            foreach(var item in comments)
            {
                Comments.Add(new CommentDetailDto
                {
                    Id=item.Id,
                    CommentDate=item.CommentDate,
                    CommentText=item.CommentText,
                    Name = item.Name,
                    PhoneNumber=item.PhoneNumber,
                    CountReply = CountReply(item.Id)
                });
            }
            return Comments;
        }
        int CountReply(int id)
        {
            var CountReply = _commentAndReplyDbcontext.ReplyComments.Count(c => c.CommentId == id);
            return CountReply;
        }
        public Comment ShowComment(int id)
        {
            Comment comment = _commentAndReplyDbcontext.Comments.Where(c => c.Id == id).FirstOrDefault();
            return comment;
        }
        public List<ReplyComment> ShowAllReply(int id)
        {
            List<ReplyComment> Replys = _commentAndReplyDbcontext.ReplyComments.Where(c => c.CommentId == id).ToList();
            return Replys;
        }
    }
}
