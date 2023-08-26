using AutoMapper;
using CommentAndReply.Core.Domain.Entities;
using CommentAndReply.Core.Domain.Dto;
using CommentAndReply.Core.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CommentAndReply.Infra.Database.Repository
{
    public class CommentAndReplyRepository : ICommentAndReplyRepository
    {
        private readonly CommentAndReplyDbcontext _commentAndReplyDbcontext;
        private readonly IMapper _mapper;
        public CommentAndReplyRepository(CommentAndReplyDbcontext commentAndReplyDbcontext, IMapper mapper)
        {
            _mapper=mapper;
            _commentAndReplyDbcontext = commentAndReplyDbcontext;
        }
        public async Task MakeComment(Comment comment)
        {
            await _commentAndReplyDbcontext.AddAsync(new Comment
            {
                Id = comment.Id,
                CommentText = comment.CommentText,
                CommentDate = comment.CommentDate,
                Name = comment.Name,
                PhoneNumber = comment.PhoneNumber,
                ReplyComments = comment.ReplyComments
            });
            await _commentAndReplyDbcontext.SaveChangesAsync();
        }
        public async Task MakeReplyComment(ReplyComment replyComment)
        {
            await _commentAndReplyDbcontext.AddAsync(new ReplyComment
            {
                Id = replyComment.Id,
                CommentId = replyComment.CommentId,
                CommentText = replyComment.CommentText,
                CommentDate = replyComment.CommentDate,
                Name = replyComment.Name,
                PhoneNumber = replyComment.PhoneNumber
            }); 
            await _commentAndReplyDbcontext.SaveChangesAsync();
        }
        public async Task<List<ShowAllCommentDetailDto>> ShowAllComment()
        {
            List<ShowAllCommentDetailDto> Comments = new List<ShowAllCommentDetailDto>();
            List<Comment> comments = await _commentAndReplyDbcontext.Comments.ToListAsync();
            foreach(var item in comments)
            {
                Comments.Add(new ShowAllCommentDetailDto
                {
                    Id=item.Id,
                    CommentDate=item.CommentDate,
                    CommentText=item.CommentText,
                    Name = item.Name,
                    PhoneNumber=item.PhoneNumber,
                    CountReply = await CountReply(item.Id)
                });
            }
            var a = _mapper.Map<List<ShowAllCommentDetailDto>>(comments);
            return Comments;
        }
        private async Task<int> CountReply(int id)
        {
            var CountReply = await _commentAndReplyDbcontext.ReplyComments.CountAsync(c => c.CommentId == id);
            return CountReply;
        }
        public async Task<Comment> ShowComment(int id)
        {
            Comment comment = await _commentAndReplyDbcontext.Comments.Where(c => c.Id == id).SingleOrDefaultAsync();
            return comment;
        }
        public async Task<List<ReplyComment>> ShowAllReply(int id)
        {
            List<ReplyComment> Replys = await _commentAndReplyDbcontext.ReplyComments.Where(c => c.CommentId == id).ToListAsync();
            return Replys;
        }
    }
}
