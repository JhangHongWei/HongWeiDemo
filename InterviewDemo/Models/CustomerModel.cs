﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewDemo.Models
{
    public class CustomerModel
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public DateTime birthday { get; set; }
        public string email { get; set; }
        public DateTime createdate { get; set; }
        public DateTime? updatedate { get; set; }
    }
}