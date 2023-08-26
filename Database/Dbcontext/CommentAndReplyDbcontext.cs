using Microsoft.EntityFrameworkCore;
using CommentAndReply.Core.Domain.Entities;

namespace CommentAndReply.Infra.Database
{
    public class CommentAndReplyDbcontext : DbContext
    {
        public CommentAndReplyDbcontext(DbContextOptions<CommentAndReplyDbcontext> options) : base(options)
        {
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ReplyComment> ReplyComments { get; set; }
    }
}
