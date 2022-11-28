using FinalProject.Models;
using FinalProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepo _repo;
        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }
        //From here I will use Products related things
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Product p)
        {
            _repo.AddProduct(p);
            return RedirectToAction("DisplayAll");
        }
        public IActionResult DisplayAll()
        {
            var pro=_repo.GetProducts();
            return View(pro);
        }
        public IActionResult Displayone(int id)
        {
            var p1=_repo.GetProductById(id);
            return View(p1);
        }
        public IActionResult Update(int id)
        {
            Product product = _repo.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            _repo.UpdateProduct(product);
            return RedirectToAction("DisplayAll");
        }
        public IActionResult Delete(int id)
        {
            var p1=_repo.GetProductById(id);
            return View(p1);
        }
        [HttpPost]
        public IActionResult Delete(Product p1)
        {
            _repo.DeleteProduct(p1);
            return RedirectToAction("DisplayAll");
        }

        //From here I will use Customer reelated things
        public IActionResult Customers()
        {
            var mylist=_repo.Customers();
            return View(mylist);
        }
        public IActionResult InsertCustomer()
        {
            Customer customer = new Customer();
            customer.DetailsPurchases.Add(new DetailsPurchases() { DetailsId=1});
            return View(customer);
        }
        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {
            _repo.AddCustomer(customer);
            return RedirectToAction("Customers");
        }
        public IActionResult ShowAll()
        {
            IEnumerable<ForDisplayingOnly> c1 = _repo.DisplayWholeJoinedTable();
            return View(c1);
        }
        public IActionResult Details(int Id)
        {
            Customer cm1 = _repo.singlecustomerdetail(Id);
            return View(cm1);
        }
        public IActionResult DeleteCustomer1(int Id)
        {
            Customer cm1=_repo.singlecustomerdetail(Id);
            return View(cm1);
        }
        [HttpPost]
        public IActionResult DeleteCustomer1(Customer cm1)
        {
           _repo.DeleteCustomer(cm1);   
            return RedirectToAction("Customers");
        }
    }
}
