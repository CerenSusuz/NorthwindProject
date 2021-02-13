using Business.Abstract;
using Business.Constants;
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
        public IResult Add(Category category)
        {
            if (category.CategoryName.Length < 3)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _categoryDAL.Add(category);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(Category category)
        {
            _categoryDAL.Delete(category);
            return new SuccessResult(Messages.Deleted);
        }
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
