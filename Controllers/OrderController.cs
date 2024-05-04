using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
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
        public async Task<ActionResult> OrderList(List<OrderDetails> items, string customerId, decimal totalCost)
        {
            try
            {
                if (items != null && ModelState.IsValid)
                {
                    //[Bind(Include = "ItemsId,ItemDesc,ItemCost")]
                    decimal orderAmount = totalCost;
                    OrderMaster order = new OrderMaster();
                    order.OrderedDate = DateTime.Now;
                    order.CustomerID = customerId;
                    order.OrderedAmount = orderAmount;

                    db.OrderMasters.Add(order);
                    await db.SaveChangesAsync();

                    //OrderMaster get_customerId = await db.OrderMasters.FindAsync(customerId);
                    OrderMaster get_customerId = await db.OrderMasters.FirstOrDefaultAsync(o => o.CustomerID == customerId);

                    foreach (var item in items)
                    {
                        OrderDetails set_orderDetails = new OrderDetails();
                        set_orderDetails.OrderedIDMaster = get_customerId.OrderId;
                        set_orderDetails.Item = item.Item;
                        set_orderDetails.Quantity = item.Quantity;
                        set_orderDetails.Cost = item.Cost;
                        db.OrderDetails.Add(set_orderDetails);
                    }
                    await db.SaveChangesAsync();
                    return Json(new { success = true });
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }

            return Json(new { success = false, errorMessage = "Error occurred while placing order." });
        }
    }
}