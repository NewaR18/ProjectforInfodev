using FinalProject.Models;

namespace FinalProject.Repository
{
    public interface IProductRepo
    {
        public void AddProduct(Product p);
        public IEnumerable<Product> GetProducts();
        public Product GetProductById(int id);
        public Product UpdateProduct(Product p);
        public Product DeleteProduct(Product p);
        public IEnumerable<Customer> Customers();
        public void AddCustomer(Customer customer);
        public IEnumerable<ForDisplayingOnly> DisplayWholeJoinedTable();
        public Customer singlecustomerdetail(int Id);
        public Customer DeleteCustomer(Customer c1);
    }
}
