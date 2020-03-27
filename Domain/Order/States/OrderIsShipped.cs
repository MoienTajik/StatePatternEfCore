namespace StatePatternEfCore.Domain.Order.States
{
    public class OrderIsShipped : OrderState
    {
        public OrderIsShipped(Order order) : base(order)
        {
        }
    }
}