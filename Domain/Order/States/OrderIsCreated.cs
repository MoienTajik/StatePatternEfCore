using System;

namespace StatePatternEfCore.Domain.Order.States
{
    public class OrderIsCreated : OrderState
    {
        public OrderIsCreated(Order order) : base(order)
        {
        }

        protected internal override void Confirm()
        {
            Console.WriteLine("Order confirmed.");

            Become(new OrderIsConfirmed(Order));
        }
    }
}