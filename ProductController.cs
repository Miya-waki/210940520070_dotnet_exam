using Rahul_giri_070_jh.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rahul_giri_070_jh.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> list = new List<Product>();
            SqlConnection Conn = new SqlConnection();

            Conn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Rahul_giri_070;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;";
            Conn.Open();
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = Conn;
            insertCommand.CommandType = System.Data.CommandType.Text;
            insertCommand.CommandText = "select * from Products";
            SqlDataReader cmdReader = insertCommand.ExecuteReader();
            while (cmdReader.Read())
            {
                Product product = new Product();
                product.ProductId = (int)cmdReader["ProductId"];
                product.ProductName = cmdReader["ProductName"].ToString();
                product.Rate = (decimal)cmdReader["Rate"];
                product.Description = cmdReader["Description"].ToString();
                product.CategoryName = cmdReader["CategoryName"].ToString();
                list.Add(product);
            }
            Conn.Close();
            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int productId, Product product)
        {
            try
            {
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Rahul_giri_070;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;";
                Conn.Open();
                SqlCommand EditCommand = new SqlCommand();
                EditCommand.Connection = Conn;
                EditCommand.CommandType = System.Data.CommandType.Text;
                EditCommand.CommandText = "Update Products set ProductName = @ProductName, Rate = @Rate, Description = @Description, CategoryName = @CategoryName where ProductId = @ProductId ";
                EditCommand.Parameters.AddWithValue("@ProductId", productId);
                EditCommand.Parameters.AddWithValue("@ProductName", product.ProductName);
                EditCommand.Parameters.AddWithValue("@Rate", product.Rate);
                EditCommand.Parameters.AddWithValue("@Description", product.Description);
                EditCommand.Parameters.AddWithValue("@CategoryName", product.CategoryName);
                EditCommand.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
