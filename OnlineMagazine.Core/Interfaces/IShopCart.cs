using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OnlineMagazine.Core.Repository;
using OnlineMagazine.Data;
using OnlineMagazine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMagazine.Core.Interfaces
{
    public interface IShopCart
    {
        static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContent>();
            string shopCartId = session.GetString("CardId") ?? Guid.NewGuid().ToString();

            session.SetString("CardId", shopCartId);

            return new ShopCart(context) { ShopCartid = shopCartId };
        }
        List<ShopCartItem> ListShopItems { get; set; }
        void AddToCard(Car car);
        List<ShopCartItem> GetShopCartItems();
    }
}
