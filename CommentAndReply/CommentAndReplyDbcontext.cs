using CommentAndReply.Models;
using Microsoft.EntityFrameworkCore;

namespace CommentAndReply
{
    public class CommentAndReplyDbcontext: DbContext
    {
        public CommentAndReplyDbcontext(DbContextOptions<CommentAndReplyDbcontext>options):base(options)
        {
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ReplyComment> ReplyComments { get; set; }
    }
}
