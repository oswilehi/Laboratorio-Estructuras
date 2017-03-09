using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab02_JoseAlvarez_OscarLemus.Extras;
using Lab02_JoseAlvarez_OscarLemus.Models;
using System.IO;

namespace Lab02_JoseAlvarez_OscarLemus.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            BinaryTree<Invoice> InvoiceTree;
            // If there's already a tree, we work on it. Otherwise, we create a new one.
            if (Session["InvoiceTree"] != null)
                InvoiceTree = (BinaryTree<Invoice>)Session["InvoiceTree"];
            else
                InvoiceTree = new BinaryTree<Invoice>();

            // Session["ProductsTree"] will be considered null if there's no item in the tree
            if (InvoiceTree.Size() == 0)
                Session["InvoiceTree"] = null;
            else
                Session["InvoiceTree"] = InvoiceTree;

            return View(Session["ProductsTree"]);
        }



        [HttpPost] //Since user is retrieving data
        public ActionResult ReadInvoice(HttpPostedFileBase uploadedFile)
        {
            BinaryTree<Invoice> InvoiceTree;
            // If there's already a tree, we work on it. Otherwise, we create a new one.
            if (Session["InvoiceTree"] != null)
                InvoiceTree = (BinaryTree<Invoice>)Session["InvoiceTree"];
            else
                InvoiceTree = new BinaryTree<Invoice>();


            if (uploadedFile == null)
                return View("Index");

            StreamReader reader = new StreamReader(uploadedFile.InputStream);
            string line = "";

            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var information = line.Split(',');

                    Invoice InvoiceObj = null;
                    if (information.Length == 7) //means there's specific serial in the parameters
                    {
                        int total = -1;
                        //Data validation
                        try
                        {
                            total = int.Parse(information[6]);
                        }
                        catch (Exception)
                        {
                        }
                        InvoiceObj = new Invoice(information[0], information[1], information[2], information[3], information[4], information[5], total);
                    }
                    else if (information.Length == 6) // means no serial in the parameteres, there will be a random one.
                    {
                        int total = -1;
                        //Data validation
                        try
                        {
                            total = int.Parse(information[7]);
                        }
                        catch (Exception)
                        {
                        }
                        InvoiceObj = new Invoice(information[0], information[1], information[2], information[3], information[4], total);
                    }

                    InvoiceTree.Insert(InvoiceObj, (Invoice x, Invoice y) => (x.serial + x.correlative).CompareTo(y.serial + y.correlative));

                }
            }

            Session["InvoiceTree"] = InvoiceTree;
            return View("Index", Session["InvoiceTree"]);

        }

        public ActionResult Add(string serial, string correlative, string customer, string NIT, string date, string purchaseDescription, int total)
        {

        }



    }






}