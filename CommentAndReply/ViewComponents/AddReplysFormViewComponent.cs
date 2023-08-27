using CommentAndReply.Core.Domain.Contracts;
using CommentAndReply.Core.Domain.Entities;
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
        public async Task<IViewComponentResult> InvokeAsync(int CId)
        {
            var a= new ReplyComment
            {
                CommentId = CId
            };
            return View("AddReplysForm", a);
        }
    }
}
