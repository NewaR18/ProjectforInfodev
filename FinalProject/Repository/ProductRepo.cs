using FinalProject.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinalProject.Repository
{
    public class ProductRepo:IProductRepo
    {
        private ProductContext _context;
        public ProductRepo(ProductContext context)
        {
            _context=context;
        }
        public void AddProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
        }
        public IEnumerable<Product> GetProducts()
        {
            var mylist=_context.Products.ToList();
            return mylist;
        }
        public Product GetProductById(int id)
        {
            Product myproduct=_context.Products.Find(id);
            return myproduct;
        }
        public Product UpdateProduct(Product p)
        {
            _context.Products.Update(p);
            _context.SaveChanges();
            return p;
        }
        public Product DeleteProduct(Product p)
        {
            _context.Products.Remove(p);
            _context.SaveChanges();
            return p;
        }
        public IEnumerable<Customer> Customers()
        {
            var mylist=_context.Customers.ToList();
            return mylist;
        }
        public void AddCustomer(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }
        public IEnumerable<ForDisplayingOnly> DisplayWholeJoinedTable()
        {
            List<ForDisplayingOnly> d1 = new List<ForDisplayingOnly>();
            using(SqlCommand cmd=new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Display";
                using(SqlConnection conn =new SqlConnection("server= NEWAR-PC; database=finalProject ; Integrated Security=SSPI;"))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            ForDisplayingOnly c1 = new ForDisplayingOnly();
                            c1.id= Convert.ToInt32(rd["CustomerId"]);
                            c1.fname = Convert.ToString(rd["CustomerFirstName"]);
                            c1.mname = Convert.ToString(rd["CustomerMiddleName"]);
                            c1.lname = Convert.ToString(rd["CustomerLastName"]);
                            c1.email = Convert.ToString(rd["CustomerEmail"]);
                            c1.phone = Convert.ToInt64(rd["CustomerPhone"]);
                            c1.Pname = Convert.ToString(rd["ProductName"]);
                            c1.QTY = Convert.ToInt32(rd["QTY"]);
                            c1.price = Convert.ToInt32(rd["TotalPrice"]);
                            d1.Add(c1);
                        }
                    }
                }
            }
            return d1;
        }
        public Customer singlecustomerdetail(int Id)
        {
            Customer d = new Customer();
            d = _context.Customers.Include(s => s.DetailsPurchases).Where(a => a.CustomerId == Id).FirstOrDefault();
            return d;
        }
        public Customer DeleteCustomer(Customer c1)
        {
            _context.Customers.Remove(c1);
            _context.SaveChanges();
            return c1;
        }
    }
}
