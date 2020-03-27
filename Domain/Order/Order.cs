using System.ComponentModel.DataAnnotations.Schema;

namespace StatePatternEfCore.Domain.Order
{
    public class Order
    {
        public Order(string name, decimal amount)
        {
            Name = name;
            Amount = amount;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public decimal Amount { get; private set; }

        public string StateType { get; set; }

        private OrderState _orderState;

        [NotMapped]
        public OrderState State
        {
            get => _orderState ??= OrderState.New(StateType, this);
            set => _orderState = value;
        }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Amount: {Amount}, State:{StateType}";
        }
    }
}