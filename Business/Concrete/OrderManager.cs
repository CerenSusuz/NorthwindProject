using Business.Abstract;
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
    public class OrderManager : IOrderService
    {
        IOrderDAL _orderDAL;
        public OrderManager(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }
        [ValidationAspect(typeof(OrderValidator))]
        public IResult Add(Order Order)
        {
            _orderDAL.Add(Order);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(Order Order)
        {
            _orderDAL.Delete(Order);
            return new SuccessResult(Messages.Deleted);
        }
        public IResult Update(Order Order)
        {
            _orderDAL.Update(Order);
            return new SuccessResult(Messages.Updated);
        }
        public IDataResult<Order> GetById(int id)
        {
            return new SuccessDataResult<Order>(_orderDAL.Get(o => o.OrderID == id));
        }
        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDAL.GetAll(), Messages.Listed);
        }
    }
}
