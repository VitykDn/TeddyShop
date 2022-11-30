using ToyShopV2.Infrastructure.Interface;
using ToyShopV2.Models;

namespace ToyShopV2.Infrastructure.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly DataContext dataContext;
        private readonly Cart cart;

        public OrderRepository(DataContext dataContext, Cart cart)
        {
            this.dataContext = dataContext;
            this.cart = cart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPrice = cart.GrandTotal;
            order.OrderDate = DateTime.Now;
            dataContext.Orders.Add(order);

            var items = cart.CartItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ToyId = el.ToyId,
                    OrderId = order.Id,
                    Price = el.Price,
                    Quantity = el.Quantity
                };
                dataContext.OrderDetail.Add(orderDetail);
            }
            dataContext.SaveChanges();
        }
    }
}
