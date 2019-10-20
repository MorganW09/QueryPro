using System;
using System.Collections.Generic;
using System.Text;

namespace QueryPro
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
