using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDAL _customerDAL;
        public CustomerManager(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            _customerDAL.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            _customerDAL.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            _customerDAL.Update(customer);
            return new SuccessResult(Messages.Updated);
        }

        [CacheAspect]
        public IDataResult<Customer> GetById(string id)
        {
            return new SuccessDataResult<Customer>(_customerDAL.Get(c => c.CustomerID == id));
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDAL.GetAll(), Messages.Listed);
        }
    }
}
