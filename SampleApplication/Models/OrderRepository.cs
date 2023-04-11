namespace BethanysPieShop.Models
{
    public class OrderRepository : IOrderReposiitory
    {
        private readonly BethanysPieDbContext _bethanysPieDbContext;
        private readonly IShoppingCart _shoppingCart;
        public OrderRepository(BethanysPieDbContext bethanysPieDbContext, IShoppingCart shoppingCart)
        {
            _bethanysPieDbContext = bethanysPieDbContext;
            _shoppingCart = shoppingCart;
        }


        public void createOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = shoppingCartItems;

            order.OrderDetails = new List<OrderDetail>();
            foreach(ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var OrderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };
                order.OrderDetails.Add(OrderDetail);
            }
            _bethanysPieDbContext.Orders.Add(order);
            _bethanysPieDbContext.SaveChanges();
        }
    }
}
