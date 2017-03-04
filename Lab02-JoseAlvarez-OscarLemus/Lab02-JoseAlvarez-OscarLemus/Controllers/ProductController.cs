using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Lab02_JoseAlvarez_OscarLemus.Extras;
using Lab02_JoseAlvarez_OscarLemus.Models;

namespace Lab02_JoseAlvarez_OscarLemus.Controllers
{
    public class ProductController : Controller
    {
        BinaryTree<Product> ProductsTree = new BinaryTree<Product>();

        // GET: Product
        public ActionResult Index()
        {
            Session["ProductsTree"] = Session["ProductsTree"] ?? ProductsTree;
            return View(Session["ProductsTree"]);
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
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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

        [HttpPost] // Porque obtiene datos 
        public ActionResult LeerArchivo(HttpPostedFileBase ArchivoCargado)
        {
            if (ArchivoCargado == null)
            {
                return View("Index");
            }
            StreamReader reader = new StreamReader(ArchivoCargado.InputStream);
            string linea = "";
            //StreamReader reader = new StreamReader(ArchivoCargado.InputStream);
            if (ArchivoCargado != null && ArchivoCargado.ContentLength > 0)
            {
                while ((linea = reader.ReadLine()) != null)
                {
                    var informacion = linea.Split(',');

                    Product ProductObj = new Product(int.Parse(informacion[0]), informacion[1], int.Parse(informacion[2]), int.Parse(informacion[3]));

                    ProductsTree.Insert(ProductObj, delegate (Product x, Product y) { return x.product_key.CompareTo(y.product_key); });
                    
                }

            }

            Session["ProductsTree"] = ProductsTree;
            return View("Index",Session["ProductsTree"]);
        }
    }
}
