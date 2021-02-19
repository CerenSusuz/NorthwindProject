using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.CustomerID).NotNull();
            RuleFor(o => o.EmployeeID).NotNull();
            RuleFor(o => o.ShipCity).MinimumLength(3);
        }
    }
}
