using System;
using StatePatternEfCore.Domain.Order.States;

namespace StatePatternEfCore.Domain.Order
{
    public abstract class OrderState
    {
        protected Order Order { get; private set; }

        protected OrderState(Order order)
        {
            Order = order;
        }

        public static OrderState New(string stateType, Order order)
        {
            return stateType switch
            {
                nameof(OrderIsConfirmed) => new OrderIsConfirmed(order),
                nameof(OrderIsShipped) => new OrderIsShipped(order),
                _ => new OrderIsCreated(order)
            };
        }

        protected void Become(OrderState next)
        {
            next.Order = Order;
            Order.State = next;
            Order.StateType = next.GetType().Name;
        }

        protected internal virtual void Confirm() => throw new InvalidOperationException();

        protected internal virtual void Ship(string addressToShip) => throw new InvalidOperationException();
    }
}