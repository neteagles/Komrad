namespace Komrad.Features.Users.JunctionPoints.User
{
    using System.Web.Mvc;

    public class UserController : Controller
    {
        [HttpGet]
        [ActionName("Profile")]
        public ActionResult UserProfile()
        {
            var viewModel = new ProfileViewModel();
            return View(viewModel);
        }
    }
}