using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMVCWCF.Models;

namespace DemoMVCWCF.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {

            Check.PracticeClient obj = new Check.PracticeClient();
            string VALUE = obj.GetProducts();
            JObject TEST1 = JObject.Parse(VALUE);
            List<Product> product = JsonConvert.DeserializeObject<List<Product>>(TEST1["RESULT"].ToString());
            return View(product);
        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Check.PracticeClient obj = new Check.PracticeClient();
            string VALUE = obj.GetProductById(id);
            JObject TEST1 = JObject.Parse(VALUE);
            Product product = JsonConvert.DeserializeObject<Product>(TEST1["RESULT"].ToString());
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            string prod_name = product.fld_prod_name;
            decimal prod_price = product.fld_prod_price;
            int prod_qty = product.fld_prod_qty;
            Check.PracticeClient obj = new Check.PracticeClient();
            string VALUE = obj.AddProduct(prod_name, prod_price, prod_qty);
            JObject TEST1 = JObject.Parse(VALUE);
            product = JsonConvert.DeserializeObject<Product>(TEST1.ToString());
            return RedirectToAction("Index");

        }

        // GET: Product/Edit/5
        public ActionResult  Edit(int id) {


            int fld_id = id;
            Check.PracticeClient obj = new Check.PracticeClient();
            string VALUE = obj.GetProductById(id);
            JObject TEST1 = JObject.Parse(VALUE);
             Product product = JsonConvert.DeserializeObject<Product>(TEST1["RESULT"].ToString());
            return View(product);

        }
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Product product)
        {
            int fld_id =id;
            string prod_name = product.fld_prod_name;
            decimal prod_price = product.fld_prod_price;
            int prod_qty = product.fld_prod_qty;

            Check.PracticeClient obj = new Check.PracticeClient();
            string VALUE = obj.UpdateProduct(fld_id,prod_name,prod_price,prod_qty);
            JObject TEST1 = JObject.Parse(VALUE);
            product = JsonConvert.DeserializeObject<Product>(TEST1.ToString());

            return RedirectToAction("Index");
        }



        //public ActionResult Edit(int fld_id, string prod_name, decimal prod_price, int prod_qty)
        //{



        //    Check.PracticeClient obj = new Check.PracticeClient();
        //    string VALUE = obj.UpdateProduct(fld_id, prod_name, prod_price, prod_qty);
        //    JObject TEST1 = JObject.Parse(VALUE);
        //    Product product = JsonConvert.DeserializeObject<Product>(TEST1.ToString());
        //    return RedirectToAction("Index");

        //}


        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            int fld_id = id;
            Check.PracticeClient obj = new Check.PracticeClient();
            string VALUE = obj.GetProductById(fld_id);
            JObject TEST1 = JObject.Parse(VALUE);
            Product product = JsonConvert.DeserializeObject<Product>(TEST1["RESULT"].ToString());

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Product product)
        {

            int fld_id = id;
            string prod_name = product.fld_prod_name;
            decimal prod_price = product.fld_prod_price;
            int prod_qty = product.fld_prod_qty;
            Check.PracticeClient obj = new Check.PracticeClient();
            string VALUE = obj.DeleteProduct(fld_id);
            JObject TEST1 = JObject.Parse(VALUE);
            product = JsonConvert.DeserializeObject<Product>(TEST1.ToString());

            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int id)
        //{

        //    Check.PracticeClient obj = new Check.PracticeClient();
        //    string VALUE = obj.DeleteProduct(id);
        //    return RedirectToAction("Index");
        //}
    }
}