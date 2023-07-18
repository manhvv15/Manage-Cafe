using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_PRN_WinApp.DataAccess;

namespace Project_PRN_WinApp.Controllers
{
	public class ShowTableInforController : Controller
	{
		// GET: ShowTableInforController
		public ActionResult ShowTableInfor(int tableID)
		{
            
            return RedirectToAction("ViewManage");
        }

		// GET: ShowTableInforController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ShowTableInforController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ShowTableInforController/Create
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

		// GET: ShowTableInforController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ShowTableInforController/Edit/5
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

		// GET: ShowTableInforController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ShowTableInforController/Delete/5
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
