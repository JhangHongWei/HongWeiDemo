using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewDemo.ViewModel;
using InterviewDemo.Logic;
namespace InterviewDemo.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerLogic _CustomerLogic;
        public CustomerController()
        {
            this._CustomerLogic = new CustomerLogic();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var Customers = this._CustomerLogic.GetCustomers();

            CustomerViewModel viewdata = new CustomerViewModel();
            viewdata.Customers = Customers;

            return View(viewdata);
        }

        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(InsertCustomerViewModel data)
        {
            var isInsert = this._CustomerLogic.InsertCustomer(data);

            if (string.IsNullOrWhiteSpace(isInsert))
            {
                return RedirectToAction("Index", "Customer");
            }

            TempData["message"] = isInsert;
            return View();
        }

        public ActionResult Update(int id)
        {
            var Customers = this._CustomerLogic.GetCustomer(id);
            return View(Customers);
        }
        [HttpPost]
        public ActionResult Update(UpdateCustomerViewModel data)
        {
            var isUpdate = this._CustomerLogic.UpdateCustomer(data);

            if (string.IsNullOrWhiteSpace(isUpdate))
            {
                return RedirectToAction("Index", "Customer");
            }

            TempData["message"] = isUpdate;
            return View();
        }

        public ActionResult Delete(int id)
        {
            var isDelete = this._CustomerLogic.DeleteCustomer(id);
            if (!isDelete)
            {
                TempData["message"] = "刪除失敗";
            }
            return RedirectToAction("Index", "Customer");
        }
    }
}