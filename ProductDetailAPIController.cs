using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSample.Model.Data;

namespace TestSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailAPIController : ControllerBase
    {
        private readonly ShoppingCartContext _context;

        public ProductDetailAPIController(ShoppingCartContext context)
        {
            _context = context;
        }

        // GET: api/values  

        [HttpGet]
        [Route("GetProductDetails")]
        public IEnumerable<ProductDetail> GetProductDetails()
        {
            return _context.ProductDetail.ToList();

        }

        [HttpGet]
        [Route("GetProductDetails/{itemId}")]
        public IEnumerable<ProductDetail> GetProductDetails(int itemId)
        {
            return _context.ProductDetail.Where(i => i.ProductDetailId==itemId).ToList();
        }

        [HttpGet]
        [Route("GetProductDetailsByName/{ItemName}")]
        public IEnumerable<ProductDetail> GetProductDetailsByName(string ItemName)
        {
            return _context.ProductDetail.Where(i => i.ProductName.Contains(ItemName)).ToList();
        }

        [HttpPost]
        [Route("AddItem")]
        public int AddItem(ProductDetail data)
        {
            try
            {
                ProductDetail objData = new ProductDetail();

                objData.ProductName = data.ProductName;
                objData.Price = data.Price;
                objData.Description = data.Description;
                objData.Url = data.Url;

                this._context.ProductDetail.Add(objData);
                this._context.SaveChanges();

            }
            catch (Exception ex)
            {
                return 0;
            }

            return 1;
        }

        [HttpDelete]
        [Route("RemoveItem/{id}")]
        public bool RemoveItem(int id)
        {   
            try
            {
                var data = _context.ProductDetail.FirstOrDefault(x => x.ProductDetailId ==id);
                _context.ProductDetail.Remove(data);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

    }
}
