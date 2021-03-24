using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDAL _productDAL;
        ICategoryService _categoryService;

        public ProductManager(IProductDAL productDAL, ICategoryService categoryService)
        {
            _productDAL = productDAL;
            _categoryService = categoryService;
        }

        //[SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                 ChecktIfProductCountOfCategoryCorrect(product.CategoryID),
                 CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

            _productDAL.Add(product);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("product.delete,admin")]
        public IResult Delete(Product product)
        {
            _productDAL.Delete(product);
            return new SuccessResult();
        }

        [SecuredOperation("product.update,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            _productDAL.Update(product);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(p => p.CategoryID == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDAL.Get(p => p.ProductID == id));
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDAL.GetProductDetails());
        }


        private IResult ChecktIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDAL.GetAll(p => p.CategoryID == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }


        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDAL.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }


        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }


        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);

            if (product.UnitPrice < 15)
            {
                throw new Exception("errorerroer");
            }

            Add(product);

            return null;
        }

    }
}
