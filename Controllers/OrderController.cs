using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {
        private _DbContext db = new _DbContext();
        // GET: Order
        public async Task<ActionResult> CheckOut()
        {
            return View(await db.Items.ToListAsync());
        }

        [HttpPost]/*, ActionName("Delete")*/
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> OrderList(List<OrderDetails> items, Guid customerId, decimal totalCost)
        {
            if (items != null)
            {
                //[Bind(Include = "ItemsId,ItemDesc,ItemCost")]
                decimal orderAmount = totalCost;
                DateTime orderDate = DateTime.Now;
                OrderMaster order= new OrderMaster();
                order.OrderedDate = orderDate;
                order.CustomerID = customerId;
                order.OrderedAmount = orderAmount;
                db.OrderMasters.Add(order);
                await db.SaveChangesAsync();

                OrderMaster get_customerId = await db.OrderMasters.FindAsync(customerId);
                OrderDetails set_orderDetails = new OrderDetails();
                foreach (var item in items)
                {   
                    set_orderDetails.OrderedIDMaster = get_customerId.OrderId;
                    set_orderDetails.Item = item.Item;
                    set_orderDetails.Quantity = item.Quantity;
                    set_orderDetails.Cost = item.Cost;
                    db.OrderDetails.Add(set_orderDetails);
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}