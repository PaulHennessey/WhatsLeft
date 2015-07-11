using System.Web.Mvc;
using WhatsLeft.Models;
using WhatsLeft.Repositories;

namespace WhatsLeft.Controllers
{
    public class WhatsLeftController : Controller
    {
        private WhatsLeftRepository repo = new WhatsLeftRepository();

        // GET: WhatsLeft
        public ActionResult Index()
        {
            AccountsViewModel model = new AccountsViewModel();

            model.Accounts = repo.GetAccounts();

            return View(model);
        }

    }
}