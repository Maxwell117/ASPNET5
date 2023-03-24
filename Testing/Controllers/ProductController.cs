using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }


        public IActionResult Index()
        {
            var products = _repository.GetAllProducts();

            return View(products);
        }
    }
}
