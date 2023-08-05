using CommentAndReply.Contracts;
using CommentAndReply.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommentAndReply.ViewComponents
{
    public class ReplysViewComponent : ViewComponent
    {
        private readonly ICommentAndReplayServices _commentAndReplayServices;
        public ReplysViewComponent(ICommentAndReplayServices commentAndReplayServices)
        {
            _commentAndReplayServices = commentAndReplayServices;
        }
        public IViewComponentResult Invoke(int Id)
        {
            List<ReplyComment> ReplyComments = _commentAndReplayServices.ShowAllReply(Id);
            return View("Replys", ReplyComments);
        }
    }
}
