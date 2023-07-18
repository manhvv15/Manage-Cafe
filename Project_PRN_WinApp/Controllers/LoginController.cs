using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_PRN_WinApp.DataAccess;

namespace Project_PRN_WinApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Login(string userName, string password)
        {
            using var context = new QuanlyQuanCafe9Context();
            bool checkAccount = context.Accounts.FromSqlRaw("SELECT * FROM Account WHERE UserName " +
                    "COLLATE SQL_Latin1_General_Cp850_CS_AS like {0} " +
                    "AND Password COLLATE SQL_Latin1_General_Cp850_CS_AS like {1}",
                    userName, password).Any();
            if (checkAccount)
            {
                return RedirectToAction("ViewManage","Manage", new { userNameLogin = userName, passwordLogin = password });
            }
            else
            {  
                if(!userName.IsNullOrEmpty() && !password.IsNullOrEmpty())
                {
                    ViewBag.error = "UserName or Password invalid";
                }
                return View();
            }
        }

        // GET: LoginController/Details/5
        public ActionResult Index(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
