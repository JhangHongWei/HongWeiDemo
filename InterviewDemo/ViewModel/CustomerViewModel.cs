using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace InterviewDemo.ViewModel
{
    public class CustomerViewModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }
    }

    public class InsertCustomerViewModel
    {
        [Display(Name = "名")]
        public string firstname { get; set; }
        [Display(Name = "姓")]
        public string lastname { get; set; }
        [Display(Name = "年齡")]
        public int age { get; set; }
        [Display(Name = "生日")]
        public DateTime birthday { get; set; }
        [Display(Name = "電子郵件")]
        public string email { get; set; }
    }

    public class UpdateCustomerViewModel
    {
        public int id { get; set; }
        [Display(Name = "名")]
        public string firstname { get; set; }
        [Display(Name = "姓")]
        public string lastname { get; set; }
        [Display(Name = "年齡")]
        public ushort age { get; set; }
        [Display(Name = "生日")]
        public DateTime birthday { get; set; }
        [Display(Name = "電子郵件")]
        public string email { get; set; }
    }
}