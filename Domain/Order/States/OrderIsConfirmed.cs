using System;

namespace StatePatternEfCore.Domain.Order.States
{
    public class OrderIsConfirmed : OrderState
    {
        public OrderIsConfirmed(Order order) : base(order)
        {
        }

        protected internal override void Ship(string addressToShip)
        {
            Console.WriteLine($"Shipping order to {addressToShip} ...");

            Become(new OrderIsShipped(Order));
        }
    }
}