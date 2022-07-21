﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineMagazine.Core.Interfaces;
using OnlineMagazine.Data;
using OnlineMagazine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMagazine.Core.Repository
{
    public class ShopCart : IShopCart
    {
        private readonly AppDbContent appDbConent;
        public ShopCart(AppDbContent appDbConent)
        {
            this.appDbConent = appDbConent;
        }
        public string ShopCartid { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContent>();
            string shopCartId=session.GetString("CardId") ?? Guid.NewGuid().ToString();

            session.SetString("CardId",shopCartId);

            return new ShopCart(context) { ShopCartid=shopCartId};
        }

        public void AddToCard(Car car)
        {
            var test = new ShopCartItem
            {
                Car = car,
                Price = car.Price,
                ShopCart = ShopCartid,
            };
            appDbConent.ShopCartItem.Add(test);

            appDbConent.SaveChanges();
        }

        public List<ShopCartItem> GetShopCartItems()
        {
            return appDbConent.ShopCartItem.Where(c => c.ShopCart == ShopCartid).Include(s => s.Car).ToList();
        }
    }
}
