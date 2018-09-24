using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MyProducts.BusinessEntities;
using MyProducts.BusinessServices;

namespace MyProducts.API
{
    //NOTE project is using Lazy loading method for loading data from db. this will return loop references. this is undesirable for web api
    //fix: disable lazy loading and use egar loading with include() method for desirable properties  



    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IProductServices _productServices;


        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        // GET: api/Product/getallproducts
        [Route("getallproducts")]
        public HttpResponseMessage GetAllProducts()
        {
            var products = _productServices.GetAllProducts();
            if (products == null || !products.Any())
                return Request.CreateResponse(HttpStatusCode.NotFound, "Products not found");
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        // GET: api/Product/GetProductById/5
        [Route("GetProductById/{id}")]
        [ResponseType(typeof(ProductEntity))]
        public HttpResponseMessage GetProductById(int id)
        {
            var productEntity = _productServices.GetProductById(id);
            if (productEntity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product not found"); ;
            }

            return Request.CreateResponse(HttpStatusCode.OK, productEntity);
        }

        // PUT: api/Product/
        [Route("UpdateProduct/{productEntity}")]
        public HttpResponseMessage UpdateProduct(ProductEntity productEntity)
        {
            try
            {
                _productServices.UpdateProduct(productEntity);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong, product is not updated");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Product has been updated");
        }

        // POST: api/Product
        [Route("CreateProduct/productEntity")]
        public HttpResponseMessage CreateProduct(ProductEntity productEntity)
        {
            try
            {
                _productServices.CreateProduct(productEntity);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong, product is not created");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Product has been created");
        }

        // DELETE: api/Product/5
        [Route("DeleteProduct/{id}")]
        public HttpResponseMessage DeleteProduct(int id)
        {
            try
            {
                _productServices.DeleteProduct(id);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong, product has not been deleted");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Product has been deleted");
        }
    }
}