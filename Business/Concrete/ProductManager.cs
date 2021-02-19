using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDAL.Add(product);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(Product product)
        {
            _productDAL.Delete(product);
            return new SuccessResult(Messages.Deleted);
        }
        public IResult Update(Product product)
        {
            _productDAL.Update(product);
            return new SuccessResult(Messages.Updated);
        }
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(),Messages.Listed);
        }
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(p => p.CategoryID == id));
        }
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDAL.Get(p => p.ProductID == id));
        }
        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }
        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDAL.GetProductDetails());
        }
    }
}
