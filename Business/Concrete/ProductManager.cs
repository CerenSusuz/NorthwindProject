using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDAL _productDAL;

        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public IResult Add(Product product)
        {
            _productDAL.Add(product);
            return new Result(true,"Added Product");
        }

        public List<Product> GetAll()
        {
            return _productDAL.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDAL.GetAll(p => p.CategoryID == id);
        }

        public Product GetById(int id)
        {
            return _productDAL.Get(p => p.ProductID == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDAL.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDAL.GetProductDetails();
        }
    }
}
