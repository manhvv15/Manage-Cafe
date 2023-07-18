using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project_PRN_WinApp.DataAccess;

namespace Project_PRN_WinApp.Controllers
{
    public class AccountProfileController : Controller
    {
        

        // GET: AccountProfileController
        public ActionResult AccProfile(string userName, string password, string newpassword, string confirmpassword, string btn)
        {
            using var context = new QuanlyQuanCafe9Context();
            var accountProfile = context.Accounts.
                    Where(acc => acc.UserName == userName && acc.Password == password).
                FirstOrDefault();
            string userNameExit = userName;
            string passwordExit = password;
            if (btn != null && btn.Equals("Update"))
            {
                if (accountProfile != null)
                {
                    if(!newpassword.IsNullOrEmpty() && !newpassword.IsNullOrEmpty())
                    {
                        if (newpassword.Equals(confirmpassword))
                        {
                            accountProfile.Password = newpassword;
                            context.SaveChanges();
                            return RedirectToAction("Login", "Login");
                        }
                        else
                        {
                            ViewBag.MessageProfile = ("New password not similar");
                            ViewBag.userName = accountProfile.UserName;
                            ViewBag.nickName = accountProfile.DisplayName;
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.MessageProfile = ("Invalid newPassword or 2nd NewPassword");
                        ViewBag.userName = accountProfile.UserName;
                        ViewBag.nickName = accountProfile.DisplayName;
                        return View();
                    }
                }
                else
                {
                    ViewBag.MessageProfile = ("Password was not correct.");
                    ViewBag.userName = accountProfile.UserName;
                    ViewBag.nickName = accountProfile.DisplayName;
                    return View();
                }
            }else if (btn != null && btn.Equals("Exit"))
            {
                return RedirectToAction("ViewManage", "Manage", new { userNameLogin = userNameExit, passwordLogin = passwordExit});
            }
            else
            {
                ViewBag.userName = accountProfile.UserName;
                ViewBag.nickName = accountProfile.DisplayName;
                return View();
            }
        }

        // GET: AccountProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountProfileController/Create
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

        // GET: AccountProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountProfileController/Edit/5
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

        // GET: AccountProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountProfileController/Delete/5
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
