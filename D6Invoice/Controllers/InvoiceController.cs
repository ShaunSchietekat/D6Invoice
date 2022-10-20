using D6Invoice.Data;
using D6Invoice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace D6Invoice.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly D6DbContext _context;

        public InvoiceController(D6DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Invoice> invoices = new List<Invoice>();
            invoices = _context.Invoices.Where(x=>x.IsDeleted == false).ToList();
            return View(invoices);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceItems.Add(new InvoiceItem() { InvoiceItemId = 1 });


            ViewBag.Customers = GetCustomers();


            return View(invoice);
        }

        private List<SelectListItem> GetCustomers()
        {
            var lstItems = new List<SelectListItem>();

            List<Customer> items = _context.Customers.Where(x=>x.IsDeleted == false).ToList();
            lstItems = items.Select(ut => new SelectListItem()
            {
                Value = ut.CustomerID.ToString(),
                Text = ut.CustomerName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Customer----"
            };

            lstItems.Insert(0, defItem);

            return lstItems;
        }


        [HttpPost]
        public IActionResult Create(Invoice invoice)
        {
            foreach(InvoiceItem item in invoice.InvoiceItems)
            {
                if(item.Description == null || item.Description.Length == 0)
                {
                    invoice.InvoiceItems.Remove(item); 
                }
            }

            _context.Add(invoice);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Invoice invoice = _context.Invoices.Include(x => x.InvoiceItems).Where(x => x.Id == Id).FirstOrDefault();
            return View(invoice);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Invoice invoice = _context.Invoices.Include(x => x.InvoiceItems).Where(x => x.Id == Id).FirstOrDefault();
            return View(invoice);
        }

        [HttpPost]
        public IActionResult Delete(Invoice invoice)
        {
            Invoice invoiceDelete = new Invoice();
            invoiceDelete = invoice;
            invoiceDelete.IsDeleted = true;

            _context.Attach(invoiceDelete);
            _context.Entry(invoice).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
