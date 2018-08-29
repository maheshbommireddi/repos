using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Sprint_Zero.Models;
using SprintZero.BusinessService.Services;
using SprintZero.Core.Entities;
using SprintZero.Core.Models;
using SprintZero.DataService.Repositories;

namespace Sprint_Zero.Controllers
{
    [RequireHttps]
    public class CustomerController : Controller
    {
        //private  ICustomerListService _service;
        //private CustomerRespository customerRespository= new CustomerRespository();

        private MovieDataBaseEntitie db = new MovieDataBaseEntitie();

        //public CustomerController()
        //{
        //    _service = new CustomerListServie(customerRespository);
        //}
        //// For unit testing
        //public CustomerController(ICustomerListService Service)
        //{
        //    _service = Service;
        //}



        // GET: Customer
        public ActionResult Index()
        {
            //List<CustomerModel> models = _service.GetAllCustomerModel();
            //List<Customer> cust = models.Select(p => new Customer() { FirstName = p.FirstName, LastName = p.LastName, BirthData=p.BirthData
            //,City=p.City,EmailAddress=p.EmailAddress,Id=p.Id, PhoneNumber=p.PhoneNumber, State=p.State, StreetAddress=p.StreetAddress, ZipCode=p.ZipCode}).ToList();
            //return View(cust);
            return View(db.Customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CustomerModel customer = _service.GetCustomerById(id);  //db.Customers.Find(id);
            //Customer cust = new Customer { FirstName=customer.FirstName,
            //    LastName = customer.LastName,
            //    BirthData = customer.BirthData,
            //    City = customer.City,
            //    EmailAddress = customer.EmailAddress,
            //    Id = customer.Id,
            //    PhoneNumber = customer.PhoneNumber,
            //    State = customer.State,
            //    StreetAddress = customer.StreetAddress,
            //    ZipCode = customer.ZipCode
            //};   


            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,StreetAddress,City,State,ZipCode,PhoneNumber,BirthData,EmailAddress")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                // _service.AddCustomer(customer);             
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CustomerModel customer = _service.GetCustomerById(id);
            //Customer cust = new Customer
            //{
            //    FirstName = customer.FirstName,
            //    LastName = customer.LastName,
            //    BirthData = customer.BirthData,
            //    City = customer.City,
            //    EmailAddress = customer.EmailAddress,
            //    Id = customer.Id,
            //    PhoneNumber = customer.PhoneNumber,
            //    State = customer.State,
            //    StreetAddress = customer.StreetAddress,
            //    ZipCode = customer.ZipCode
            //};
            //if (cust == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(cust);
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,StreetAddress,City")] CustomerEntity customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                try
                {
                    //_service.EditCustomerEntity(customer);
                    customer.FirstName = customer.FirstName.Trim();
                    customer.LastName = customer.LastName.Trim();

                }
                catch (DbEntityValidationException e)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(customer);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // CustomerModel customer = _service.DeleteCustomerById(id);
            //CustomerModel customer = _service.GetCustomerById(id);
            //Customer cust = new Customer
            //{
            //    FirstName = customer.FirstName,
            //    LastName = customer.LastName,
            //    BirthData = customer.BirthData,
            //    City = customer.City,
            //    EmailAddress = customer.EmailAddress,
            //    Id = customer.Id,
            //    PhoneNumber = customer.PhoneNumber,
            //    State = customer.State,
            //    StreetAddress = customer.StreetAddress,
            //    ZipCode = customer.ZipCode
            //};

            //if (cust == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(cust);

            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            //CustomerModel customer = _service.GetCustomerById(id);
              //_service.DeleteCustomerById(id);
            db.Customers.Remove(customer);
           db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
