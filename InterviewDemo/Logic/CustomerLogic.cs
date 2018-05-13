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

        public UpdateCustomerViewModel GetCustomer(int Id)
        {
            UpdateCustomerViewModel reCustomerData = new UpdateCustomerViewModel();
            CustomerModel CustomerData = this._CustomersRepository.GetOneById(Id);
            if(CustomerData != null)
            {
                reCustomerData.id = CustomerData.id;
                reCustomerData.firstname = CustomerData.firstname;
                reCustomerData.lastname = CustomerData.lastname;
                reCustomerData.age = CustomerData.age;
                reCustomerData.email = CustomerData.email;
                reCustomerData.birthday = CustomerData.birthday.ToString("yyyy/MM/dd");
            }

            return reCustomerData;
        }

        public string UpdateCustomer(UpdateCustomerViewModel data)
        {
            string result = string.Empty;
            if (!this._CustomersRepository.Update(data))
            {
                result = "新增失敗";
            }
            return result;
        }

        public bool DeleteCustomer(int Id)
        {
            bool result = this._CustomersRepository.Delete(Id);
            return result;
        }
    }
}