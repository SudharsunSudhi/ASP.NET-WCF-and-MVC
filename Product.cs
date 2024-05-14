using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Check.Model
{
    public class Product
    {

        public int fld_id { get; set; }
        public string fld_prod_name { get; set; }
        public decimal fld_prod_price { get; set; }
        public int fld_prod_qty { get; set; }
    }
}