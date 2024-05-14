using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Check.BILL;
using Check.Model;

namespace Check
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Practice" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Practice.svc or Practice.svc.cs at the Solution Explorer and start debugging.
    public class Practice : IPractice
    {
        Check_BILL obj2 = new Check_BILL();
        public string  GetProducts()
        {

            return obj2.GetProducts();
        }


        public string GetProductById(int id) {

            return obj2.GetProductById(id);

        }

        public string AddProduct(string fld_prod_name, decimal fld_prod_price, int fld_prod_qty) {

            return obj2.AddProduct(fld_prod_name, fld_prod_price, fld_prod_qty);
        }

        public string UpdateProduct(int fld_id, string fld_prod_name, decimal fld_prod_price, int fld_prod_qty) {

            return obj2.UpdateProduct(fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);
        }

        public string DeleteProduct(int id) {

            return obj2.DeleteProduct(id);
        }
    }
}
