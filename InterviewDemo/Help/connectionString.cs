using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace InterviewDemo.Help
{
    public class connectionString
    {
        public static string DemoDB { get { return WebConfigurationManager.ConnectionStrings["DemoDB"].ConnectionString; } }
    }
}