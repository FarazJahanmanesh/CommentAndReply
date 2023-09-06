using AutoMapper;
using CommentAndReply.Core.Domain.Entities;
using CommentAndReply.Core.Domain.Dto;
using CommentAndReply.Core.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace CommentAndReply.Infra.Database.Repository
{
    public class CommentAndReplyRepository : ICommentAndReplyRepository
    {
        private readonly CommentAndReplyDbcontext _commentAndReplyDbcontext;
        private readonly IMapper _mapper;
        public CommentAndReplyRepository(CommentAndReplyDbcontext commentAndReplyDbcontext, IMapper mapper)
        {
            _mapper = mapper;
            _commentAndReplyDbcontext = commentAndReplyDbcontext;
        }
        public async Task CreateComment(CreateCommentDetailDto detailDto)
        {
            //var a = _mapper.Map<List<Comment>>(detailDto);
            await _commentAndReplyDbcontext.AddAsync(_mapper.Map<Comment>(detailDto));
            //await _commentAndReplyDbcontext.AddAsync(new Comment
            //{
            //    CommentText = detailDto.CommentText,
            //    CommentDate = detailDto.CreatedDate,
            //    Name = detailDto.Name,
            //    PhoneNumber = detailDto.PhoneNumber
            //});
            //await _commentAndReplyDbcontext.SaveChangesAsync();
            await SaveChanges();
        }
        public async Task CreateReplyComment(CreateCommentReplyDetailDto detailDto)
        {
            await _commentAndReplyDbcontext.AddAsync(_mapper.Map<ReplyComment>(detailDto));
            //await _commentAndReplyDbcontext.AddAsync(new ReplyComment
            //{
            //    CommentText = detailDto.CommentText,
            //    CommentDate = detailDto.CreatedDate,
            //    Name = detailDto.Name,
            //    PhoneNumber = detailDto.PhoneNumber
            //}); 
            //await _commentAndReplyDbcontext.SaveChangesAsync();
            await SaveChanges();
        }
        public async Task<List<ShowAllCommentDetailDto>> ShowAllComment()
        {
            //List<ShowAllCommentDetailDto> Comments = new List<ShowAllCommentDetailDto>();
            List<Comment> comments = await _commentAndReplyDbcontext.Comments.Where(c => c.IsDeleted == false).ToListAsync();
            //foreach(var item in comments)
            //{
            //    Comments.Add(new ShowAllCommentDetailDto
            //    {
            //        Id=item.Id,
            //        CommentDate=item.CommentDate,
            //        CommentText=item.CommentText,
            //        Name = item.Name,
            //        PhoneNumber=item.PhoneNumber,
            //        CountReply = await CountReply(item.Id)
            //    });
            //}
            foreach (var item in comments)
            {
                item.CountReply = await CountReply(item.Id);
            }
            var Comments = _mapper.Map<List<ShowAllCommentDetailDto>>(comments);
            return Comments;
        }
        private async Task SaveChanges()
        {
            await _commentAndReplyDbcontext.SaveChangesAsync();
        }
        private async Task<int> CountReply(int id)
        {
            var CountReply = await _commentAndReplyDbcontext.ReplyComments.CountAsync(c => c.CommentId == id);
            return CountReply;
        }
        public async Task<ShowCommentDetailDto> ShowComment(int id)
        {
            var comment = await _commentAndReplyDbcontext.Comments.Where(c => c.Id == id&&c.IsDeleted==false).SingleOrDefaultAsync();
            return _mapper.Map<ShowCommentDetailDto>(comment);

            //return new ShowCommentDetailDto 
            //{ 
            //    Name=comment.Name,
            //    CommentText=comment.CommentText,
            //    PhoneNumber=comment.PhoneNumber
            //};
        }
        public async Task<List<ShowAllCommentReplyDetailDto>> ShowAllReply(int id)
        {
            List<ShowAllCommentReplyDetailDto> AllReply = new();
            var replys = await _commentAndReplyDbcontext.ReplyComments.Where(c => c.CommentId == id&&c.IsDeleted == false).ToListAsync();
            //foreach(var item  in replys)
            //{
            //    AllReply.Add(new ShowAllCommentReplyDetailDto
            //    {
            //        CommentText=item.CommentText,
            //        Name=item.Name,
            //        PhoneNumber=item.PhoneNumber
            //    });
            //}
            var a = _mapper.Map<List<ShowAllCommentReplyDetailDto>>(replys);
            return a;
        }
    }
}
