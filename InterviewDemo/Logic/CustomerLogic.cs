using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewDemo.Models;
using InterviewDemo.ViewModel;
using InterviewDemo.Repository;
namespace InterviewDemo.Logic
{
    public class CustomerLogic
    {
        private CustomersRepository _CustomersRepository = new CustomersRepository();
        public IEnumerable<CustomerModel> GetCustomers()
        {
            return this._CustomersRepository.GetAll();
        }

        public string InsertCustomer(InsertCustomerViewModel data)
        {
            string result = string.Empty;
            if (!this._CustomersRepository.Insert(data))
            {
                result = "新增失敗";
            }
            return result;
        }
    }
}