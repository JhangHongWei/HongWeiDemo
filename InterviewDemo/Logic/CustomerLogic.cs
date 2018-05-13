using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewDemo.Models;
using InterviewDemo.Repository;
namespace InterviewDemo.Logic
{
    public class CustomerLogic
    {
        private CustomersRepository _CustomersRepository = new CustomersRepository();
        public IEnumerable<CustomerModel> GetCustomers()
        {
            return _CustomersRepository.GetAll();
        }
    }
}