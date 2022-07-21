using OnlineMagazine.Data.Interfaces;
using OnlineMagazine.Data.Models;
using System;

namespace OnlineMagazine.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDbContent appDbContent;
        //private readonly ShopCart shopCart;
        private readonly IUnitOfWork unitOfWork;
        public OrderRepository(AppDbContent appDbContent,IUnitOfWork db)//,ShopCart shopCart)
        {
            unitOfWork= db;
            this.appDbContent = appDbContent;
            //this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDbContent.Order.Add(order);

            var items = unitOfWork.ShopCart.ListShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.Car.Id,
                    OrderId = order.Id,
                    Price = el.Car.Price
                };
                appDbContent.OrderDetail.Add(orderDetail);
            }
            appDbContent.SaveChanges();
        }
    }
}
