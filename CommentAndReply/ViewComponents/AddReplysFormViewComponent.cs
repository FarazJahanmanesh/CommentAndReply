using CommentAndReply.Contracts;
using CommentAndReply.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommentAndReply.ViewComponents
{
    public class AddReplysFormViewComponent : ViewComponent
    {
        private readonly ICommentAndReplayServices _commentAndReplayServices;
        public AddReplysFormViewComponent(ICommentAndReplayServices commentAndReplayServices)
        {
            _commentAndReplayServices = commentAndReplayServices;
        }
        public IViewComponentResult Invoke(int CId)
        {
            var a= new ReplyComment
            {
                CommentId = CId
            };
            return View("AddReplysForm", a);
        }
    }
}
