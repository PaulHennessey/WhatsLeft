using System;
using System.Web.Mvc;
using WhatsLeft.Domain;
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
            BankAccountsViewModel model = new BankAccountsViewModel();

            model.BankAccounts = repo.GetAccounts();

            return View(model);
        }


        [HttpGet]
        public ViewResult CreateAccount()
        {
            BankAccountViewModel model = new BankAccountViewModel()
            {
                Name = String.Empty,
                Balance = 0,
            };

            return View(model);
        }

        [HttpGet]
        public ViewResult CreateFund(int id)
        {
            BankAccount account = repo.GetAccountById(id);
            FundViewModel model = new FundViewModel()
            {
                Name = String.Empty,
                Balance = 0,
            };

            return View(model);
        }

        //[HttpPost]
        //public ActionResult Create(ProductViewModel productViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = _userServices.GetUser(User.Identity.Name);

        //        Product product = Mapper.Map<ProductViewModel, Product>(productViewModel);
        //        _productServices.CreateProduct(product, user.Id);

        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(productViewModel);
        //    }
        //}



    }
}