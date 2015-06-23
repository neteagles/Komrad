namespace Komrad.Features.Users.JunctionPoints.Account
{
    using System.Web.Mvc;
    using Forms;
    using ViewModels;

    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult SignIn()
        {
            var viewModel = new SignInViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SignIn(SignInForm form)
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            var viewModel = new SignUpViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpForm form)
        {
            return View();
        }
    }
}