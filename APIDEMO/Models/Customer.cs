using System;
using System.Collections.Generic;

namespace APIDEMO.Models
{
    public partial class Customer
    {
        public string Customerid { get; set; }
        public string Companyname { get; set; }
        public string Contactname { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
