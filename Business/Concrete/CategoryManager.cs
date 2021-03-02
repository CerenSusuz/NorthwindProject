using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            if (category.CategoryName.Length < 3)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _categoryDAL.Add(category);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("category.delete,admin")]
        public IResult Delete(Category category)
        {
            _categoryDAL.Delete(category);
            return new SuccessResult(Messages.Deleted);
        }

        [SecuredOperation("category.update,admin")]
        public IResult Update(Category category)
        {
            _categoryDAL.Update(category);
            return new SuccessResult(Messages.Updated);
        }
        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDAL.Get(c => c.CategoryID == id));
        }
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDAL.GetAll(),Messages.Listed);
        }
    }
}
