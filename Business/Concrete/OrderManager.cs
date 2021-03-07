using Business.Abstract;
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
    public class OrderManager : IOrderService
    {
        IOrderDAL _orderDAL;
        public OrderManager(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

        [CacheRemoveAspect("IOrderService.Get")]
        [ValidationAspect(typeof(OrderValidator))]
        public IResult Add(Order Order)
        {
            _orderDAL.Add(Order);
            return new SuccessResult(Messages.Added);
        }

        [CacheRemoveAspect("IOrderService.Get")]
        public IResult Delete(Order Order)
        {
            _orderDAL.Delete(Order);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheRemoveAspect("IOrderService.Get")]
        public IResult Update(Order Order)
        {
            _orderDAL.Update(Order);
            return new SuccessResult(Messages.Updated);
        }

        [CacheAspect]
        public IDataResult<Order> GetById(int id)
        {
            return new SuccessDataResult<Order>(_orderDAL.Get(o => o.OrderID == id));
        }

        [CacheAspect]
        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDAL.GetAll(), Messages.Listed);
        }
    }
}
