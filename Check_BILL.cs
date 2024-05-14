using Check.Adapter.DataTableAdapters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Check.Model;
using Newtonsoft.Json;

namespace Check.BILL
{
    public class Check_BILL
    {
        public string GetProducts()
        {

            List<Product> productsList = new List<Product>();
            string fld_status = "1";
            string fld_message = "FAIL";
            JObject ReturnObject = new JObject();
            int in_type = 2;
            int fld_id = -1;
            string fld_prod_name = "-1";
            decimal fld_prod_price = -1;
            int fld_prod_qty = -1;
            DataTable DT = sp_get_products(in_type, fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);
            if (DT.Rows.Count > 0)
            {

                if (!DT.Columns.Contains("FLD_ACTION_STATUS"))
                {

                    fld_status = "0";
                    fld_message = "SUCCESS";
                    productsList = (from DataRow dr in DT.Rows
                                    select new Product()
                                    {
                                        fld_id = Convert.ToInt32(dr["fld_id"]),
                                        fld_prod_name = Convert.ToString(dr["fld_prod_name"]),
                                        fld_prod_price = Convert.ToDecimal(dr["fld_prod_price"]),
                                        fld_prod_qty = Convert.ToInt32(dr["fld_prod_qty"]),

                                    }).ToList();

                }
                else
                {
                    fld_status = DT.Rows[0]["FLD_ACTION_STATUS"].ToString();
                    fld_message = DT.Rows[0]["FLD_MESSAGE"].ToString();
                }
            }
            else
            {

                fld_status = "1";
                fld_message = "No DATA FOUND";

            }
            ReturnObject["STATUS"] = fld_status;
            ReturnObject["MESSAGE"] = fld_message;
            ReturnObject["RESULT"] = JsonConvert.SerializeObject(productsList);

            return ReturnObject.ToString();

            

        }

        public string GetProductById(int id)
        {

            Product product = new Product();

            string fld_status = "1";
            string fld_message = "FAIL";
            JObject ReturnObject = new JObject();
            int in_type = 1;
            int fld_id = id;
            string fld_prod_name = "-1";
            decimal fld_prod_price = -1;
            int fld_prod_qty = -1;
            DataTable DT = sp_get_products(in_type, fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);


            if (DT.Rows.Count >0)
            {

                if (!DT.Columns.Contains("FLD_ACTION_STATUS"))
                {
                    fld_status = "0";
                    fld_message = "SUCCESS";
                    product.fld_id = Convert.ToInt32(DT.Rows[0]["fld_id"]);
                    product.fld_prod_name = Convert.ToString(DT.Rows[0]["fld_prod_name"]);
                    product.fld_prod_price = Convert.ToInt32(DT.Rows[0]["fld_prod_qty"]);
                    product.fld_prod_qty = Convert.ToInt32(DT.Rows[0]["fld_prod_qty"]);

                }

                else
                {
                    fld_status = DT.Rows[0]["FLD_ACTION_STATUS"].ToString();
                    fld_message = DT.Rows[0]["FLD_MESSAGE"].ToString();

                }


            }
            else
            {
                fld_status = "1";
                fld_message = "No DATA FOUND";

            }

            ReturnObject["STATUS"] = fld_status;
            ReturnObject["MESSAGE"] = fld_message;
            ReturnObject["RESULT"] = JsonConvert.SerializeObject(product);
            return ReturnObject.ToString();

        }



        public string AddProduct(string fld_prod_name,decimal fld_prod_price,int fld_prod_qty) {

            int in_type = 1;
            string fld_status = "1";
            string fld_message = "FAIL";
            JObject ReturnObject = new JObject();
            DataTable DT = sp_set_products(in_type, -1, fld_prod_name, fld_prod_price, fld_prod_qty);
            if (DT.Columns.Contains("FLD_ACTION_STATUS")) {

                fld_status = DT.Rows[0]["FLD_ACTION_STATUS"].ToString();
                fld_message= DT.Rows[0]["FLD_MESSAGE"].ToString();
            }
            else
            {
                fld_status = DT.Rows[0]["FLD_ACTION_STATUS"].ToString();
                fld_message = DT.Rows[0]["FLD_MESSAGE"].ToString();

            }

            ReturnObject["STATUS"] = fld_status;
            ReturnObject["MESSAGE"] = fld_message;
            return ReturnObject.ToString();
        }




        public string UpdateProduct(int fld_id, string fld_prod_name, decimal fld_prod_price, int fld_prod_qty)
        {

            int in_type = 2;
            string fld_status = "1";
            string fld_message = "FAIL";
            JObject ReturnObject = new JObject();
            DataTable DT = sp_set_products(in_type, fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);

            if (DT.Columns.Contains("FLD_ACTION_STATUS"))
            {

                fld_status = DT.Rows[0]["FLD_ACTION_STATUS"].ToString();
                fld_message = DT.Rows[0]["FLD_MESSAGE"].ToString();
            }
            else
            {
                fld_status = DT.Rows[0]["FLD_ACTION_STATUS"].ToString();
                fld_message = DT.Rows[0]["FLD_MESSAGE"].ToString();

            }

            ReturnObject["STATUS"] = fld_status;
            ReturnObject["MESSAGE"] = fld_message;
            return ReturnObject.ToString();
        }
        public string DeleteProduct(int id) {

            int in_type =3;
            string fld_status = "1";
            string fld_message = "FAIL";
            JObject ReturnObject = new JObject();

            DataTable DT = sp_set_products(in_type, id, "-1", 1, 1);

            if (!DT.Columns.Contains("FLD_ACTION_STATUS"))
            {

                fld_status = DT.Rows[0]["FLD_ACTION_STATUS"].ToString();
                fld_message = DT.Rows[0]["FLD_MESSAGE"].ToString();
            }
            else
            {

                fld_status = DT.Rows[0]["FLD_ACTION_STATUS"].ToString();
                fld_message = DT.Rows[0]["FLD_MESSAGE"].ToString();
            }


            ReturnObject["STATUS"] = fld_status;
            ReturnObject["MESSAGE"] = fld_message;
            return ReturnObject.ToString();

        }



        #region DATABSE
        public DataTable sp_get_products(int in_type, int fld_id, string fld_prod_name, decimal fld_prod_price, int fld_prod_qty)
        {

            try
            {

                return new sp_get_productsTableAdapter().GetData(in_type, fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);

            }
            catch (Exception ex)
            {

                return new DataTable(ex.Message);

            }
        }

        public DataTable sp_set_products(int in_type, int fld_id, string fld_prod_name, decimal fld_prod_price, int fld_prod_qty)
        {

            try
            {

                return new sp_set_productsTableAdapter().GetData(in_type, fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);

            }
            catch (Exception ex)
            {

                return new DataTable(ex.Message);
            }

        }

#endregion
    }
}