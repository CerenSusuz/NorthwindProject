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
    public class customerManager : ICustomerService
    {
        ICustomerDAL _customerDAL;
        public customerManager(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }
        public IResult Add(Customer customer)
        {
            _customerDAL.Add(customer);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(Customer customer)
        {
            _customerDAL.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }
        public IResult Update(Customer customer)
        {
            _customerDAL.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
        public IDataResult<Customer> GetById(string id)
        {
            return new SuccessDataResult<Customer>(_customerDAL.Get(c => c.CustomerID == id));
        }
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDAL.GetAll(), Messages.Listed);
        }
    }
}
