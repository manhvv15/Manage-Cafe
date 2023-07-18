using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_PRN.Models;
using Project_PRN_WinApp.DataAccess;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Project_PRN_WinApp.Controllers
{
    public class ManageController : Controller
    {
        // GET: ManageController
        DAO Dao= new DAO();
        int? gTableID = null;
        public ActionResult ViewManage(int tableID, int switchTableID, int foodID, int quantity, string btn, int discount, int totalPriceCheckout, string userNameLogin, string passwordLogin, string checkAdmin)
        {
            gTableID = tableID;
            var context = new QuanlyQuanCafe9Context();
            List<Food> food = Dao.GetCategoryList();
			ViewBag.FoodCategories = food;
            var listFoodByTable = from bd in context.BillDetails
                                  join b in context.Bills on bd.IdBill equals b.Id
                                  join t in context.Tables on b.IdTable equals t.Id
                                  join f in context.Foods on bd.Idfood equals f.Id
                                  where b.IdTable == tableID && b.Status == 0
                                  select new { b.Id, f.Name, bd.Count, f.Price };
            if(checkAdmin != null)
            {
                ViewBag.checkAdmin = checkAdmin;
            }
            ViewBag.userName = userNameLogin;
            ViewBag.password = passwordLogin;
            if (btn != null && btn.Equals("Checkout"))
            {
                totalPriceCheckout = totalPriceCheckout - totalPriceCheckout * (discount / 100);
                int billID = Dao.getIdBill(tableID);
                Dao.checkoutBill(billID, discount, totalPriceCheckout);
            }
            if (btn != null && btn.Equals("SwitchTable"))
            {
                var checkBooking = context.Bills.Where(b => b.IdTable == switchTableID && b.Status == 0).FirstOrDefault();
                if (checkBooking == null)
                {
                    var switchbillTable = context.Bills.Where(b => b.IdTable == tableID && b.Status == 0).FirstOrDefault();
                    if (switchbillTable != null)
                    {
                        switchbillTable.IdTable = switchTableID;
                        context.SaveChanges();
                        ViewBag.switchMessage = "Switch successful from:  " + " Table " + tableID + " to Table " + switchTableID;
                    }
                    else
                    {
                        ViewBag.switchMessage = "Error switching table";
                    }
                }
                else
                {
                    ViewBag.switchMessage = "Can not switch to table" + switchTableID;
                }

            }
            if (foodID != 0)
            {
                int billID = Dao.getIdBill(tableID);
                BillDetail billDetail = new BillDetail(billID, foodID, quantity);
                if (quantity == 0)
                {
                    ViewBag.UpdateErrorMessage = "Please select the number of items";
                }
                else
                {
                    var foodByTable = context.BillDetails
                        .Where(bd => bd.IdBill == billID && bd.Idfood == foodID)
                        .FirstOrDefault();

                    if (foodByTable != null)//BillDetail exist
                    {
                        if (btn.Equals("Add"))
                        {
                            foodByTable.Count += quantity;
                        }
                        else
                        {
                            foodByTable.Count -= quantity;
                        }
                        
                        context.SaveChanges();
                        if (foodByTable.Count <= 0 && listFoodByTable.Count() == 1)
                        {//Delete the last item in the billDetail

                            var billsDetailToDelete = context.BillDetails.Where(bd => bd.IdBill == billID && bd.Idfood == foodID);
                            context.BillDetails.RemoveRange(billsDetailToDelete);
                            context.SaveChanges();
                            Dao.deleteBill(billID);
                        }
                        else if (foodByTable.Count <= 0)//Delete the item in the billDetail
                        {
                            var billsDetailToDelete = context.BillDetails.Where(bd => bd.IdBill == billID && bd.Idfood == foodID);
                            context.BillDetails.RemoveRange(billsDetailToDelete);
                            context.SaveChanges();
                        }
                    }
                    else//BillDetail not exist
                    {
                        if (btn.Equals("Reduce") && listFoodByTable.Count() == 0)
                        {
                            ViewBag.UpdateErrorMessage = "Error to reduce the items";

                        }
                        else
                        {
                            DateTime currentDateTime = DateTime.Now;
                            int tableBillID = tableID;
                            Bill bill = new Bill(currentDateTime, null, tableBillID);
                            Dao.addBill(billDetail, bill);
                        }
                    }
                }
            }
            List<Table> listTables = Dao.GetTableList();
            foreach (Table table in listTables)
            {
                var foodByTable = context.Bills.Where(b => b.IdTable == table.Id && b.Status == 0).FirstOrDefault();
                if (foodByTable != null)
                {
                    table.Status = "Booking";
                    context.SaveChanges();
                }
            }
            double totalPrice = 0;
            if (tableID != null)
            {
                
                foreach (var item in listFoodByTable)
                {
                    totalPrice += item.Price;
                }
                ViewBag.tableInfor = listFoodByTable.ToList();
                ViewBag.getTableID = tableID;
                ViewBag.TotalPrice = totalPrice;
            }
            
            ViewBag.listTables = listTables;
			return View();
        }

        // GET: ManageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageController/Create
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

        // GET: ManageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageController/Edit/5
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

        // GET: ManageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageController/Delete/5
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
