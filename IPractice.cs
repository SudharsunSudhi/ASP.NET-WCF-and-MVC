using Check.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Check
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPractice" in both code and config file together.
    [ServiceContract]
    public interface IPractice
    {
        [OperationContract]
         string GetProducts();

        [OperationContract]
        string GetProductById(int id);

        [OperationContract]
        string AddProduct(string fld_prod_name, decimal fld_prod_price, int fld_prod_qty);

        [OperationContract]
        string UpdateProduct(int fld_id, string fld_prod_name, decimal fld_prod_price, int fld_prod_qty);

        [OperationContract]

        string DeleteProduct(int id);
    }
}
