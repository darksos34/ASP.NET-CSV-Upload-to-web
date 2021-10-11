using System.Web.Mvc;

namespace CVSUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cvs()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Excel()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}