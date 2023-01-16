using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToyShopV2.Infrastructure;
using ToyShopV2.Models.ViewModels;
using ToyShopV2.Models;
using Microsoft.AspNetCore.Hosting;
using ToyShopV2.Infrastructure.Interface;
using System.Net.Mail;
using System.Net;
using NuGet.Protocol.Plugins;

namespace ToyShopV2.Controllers
{
    public class OrderController : Controller
    {
        private readonly DataContext dataContext;


        public OrderController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            //int OrderId = 0;
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };

            order.OrderDate = DateTime.Now;
            order.OrderPrice = cartVM.GrandTotal;

            List<OrderDetail> orderDetailList = new List<OrderDetail>();
            foreach (var item in cart)
            {
                OrderDetail orderDetailObj = new OrderDetail();
                orderDetailObj.Price = item.Price;
                orderDetailObj.ToyId = item.ToyId;
                orderDetailObj.Quantity = item.Quantity;
                orderDetailObj.ToyName = item.ToyName;
                orderDetailObj.Order = order;
                orderDetailList.Add(orderDetailObj);
                dataContext.OrderDetail.Add(orderDetailObj);
            }
            order.OrderDetails = orderDetailList;
            if (ModelState.IsValid)
            {
                dataContext.Add(order);
                await dataContext.SaveChangesAsync();
                TempData["Success"] = "Замовлення створено";
                OrderEmail(order);
                return RedirectToAction("Index", "Toys");
            }

            return View(order);
        }

        private void OrderEmail(Order order)
        {
            var senderEmail = new MailAddress("kurasartur25@gmail.com", "Me");
            var receiverEmail = new MailAddress("kurasartur25@gmail.com", "Receiver");
            var password = "yqiseuvvhoyvhhte";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            List<string> orderToys = new List<string>();
            foreach (var item in order.OrderDetails)
            {
                orderToys.Add(item.ToyName +"  Кількість: " 
                    + item.Quantity + " Ціна:" + item.Price);
            }
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = $"Order: {order.Id}",
                Body = $"Замовник:{order.Name}  Номер:{order.PhoneNumber}  Email:{order.Email}\n" +
                $"Ціна Замовлення:{order.OrderPrice}   Дата Замовлення:{order.OrderDate}\n\n" +
                $"Замовлення:\n" +
                $"{string.Join("\n", orderToys)}\n"+
                $"Коментар: {order.Comment}"
            })
            {
                smtp.Send(mess);
            }
            
        }
    }
}
