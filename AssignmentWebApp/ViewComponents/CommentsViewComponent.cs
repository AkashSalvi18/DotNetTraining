using Microsoft.AspNetCore.Mvc;
using AssignmentWebApp.Models;
using System.Collections.Generic;
using System.Linq;
namespace AssignmentWebApp.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int postId)
        {
            var comments = new List<CommentViewModel>
            {
                new CommentViewModel { PostId = 1, Id = 1, Name = "id labore ex", Email = "Eliseo@gardner.biz", Body = "laudantium enim quasi est..." },
                new CommentViewModel { PostId = 1, Id = 2, Name = "quo vero reiciendis", Email = "Jayne@sydney.com", Body = "est natus enim nihil est..." }
            };

            var filtered = comments.Where(c => c.PostId == postId).ToList();
            ViewBag.Count = filtered.Count;
            return View(filtered);
        }
    }
}
