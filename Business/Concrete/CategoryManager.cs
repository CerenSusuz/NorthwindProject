using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDAL;
        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;       
        }

        [SecuredOperation("category.add,admin")]
        [CacheRemoveAspect("ICategoryService.Get")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            if (category.CategoryName.Length < 3)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _categoryDAL.Add(category);
            return new SuccessResult();
        }

        [SecuredOperation("category.delete,admin")]
        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Delete(Category category)
        {
            _categoryDAL.Delete(category);
            return new SuccessResult();
        }

        [SecuredOperation("category.update,admin")]
        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Update(Category category)
        {
            _categoryDAL.Update(category);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDAL.Get(c => c.CategoryID == id));
        }

        [CacheAspect]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDAL.GetAll());
        }
    }
}
