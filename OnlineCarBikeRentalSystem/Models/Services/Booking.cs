using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCarBikeRentalSystem.Models.Services
{
    public class Booking
    {
            OnlineCarBikeRentalDBEntities storeDB = new OnlineCarBikeRentalDBEntities();
            public string BookingId { get; set; }
            public const string CartSessionKey = "UserId";
            public static Booking GetVehicle(HttpContextBase context)
            {
                var book = new Booking();
                book.BookingId = book.GetUserId(context);
                return book;
            }
            // Helper method to simplify shopping cart calls 
            public static Booking GetVehicle(Controller controller)
            {
                return GetVehicle(controller.HttpContext);
            }

        public void Book(tblBikeCar item/* BookingViewModel bvm*/)
        {
            // Get the matching cart and album instances 
            var bookBikeCar = storeDB.tblBookings.SingleOrDefault(
                c => c.UserId == BookingId
                && c.VehicleId == item.VehicleId);

            if (bookBikeCar == null)
            {
                // Create a new cart item if no cart item exists 
                bookBikeCar = new tblBooking
                {
                    VehicleId = item.VehicleId,
                    UserId = BookingId,
                    //BookingDate = DateTime.Now,
                    //PickUpDate=bvm.PickUpDate,
                    //ReturnDate=bvm.ReturnDate,
                    //Phone=bvm.Phone,
                    //HireDetails=bvm.HireDetails,
                    //Status= "Pending"

                };
                //storeDB.tblBookings.Add(bookBikeCar);
                //storeDB.SaveChanges();
            }


        }

        //public int UpdateCartCount(int id, int cartCount)
        //{
        //    // Get the cart 
        //    var cartItem = storeDB.tblCarts.Single(
        //        cart => cart.CartId == ShoppingCartId
        //        && cart.RecordId == id);

        //    int itemCount = 0;

        //    if (cartItem != null)
        //    {
        //        if (cartCount > 0)
        //        {
        //            cartItem.Count = cartCount;
        //            itemCount = Convert.ToInt32(cartItem.Count);
        //        }
        //        else
        //        {
        //            storeDB.tblCarts.Remove(cartItem);
        //        }
        //        // Save changes 
        //        storeDB.SaveChanges();
        //    }
        //    return itemCount;
        //}

        //public int RemoveFromCart(int id)
        //{
        //    // Get the cart 
        //    var cartItem = storeDB.tblCarts.Single(
        //        cart => cart.CartId == ShoppingCartId
        //        && cart.RecordId == id);

        //    int itemCount = 0;

        //    if (cartItem != null)
        //    {
        //        //if (cartItem.Count > 1)
        //        //{
        //        //    cartItem.Count--;
        //        //    itemCount = cartItem.Count;
        //        //}
        //        //else
        //        //{
        //        storeDB.tblCarts.Remove(cartItem);
        //        //}
        //        // Save changes 
        //        storeDB.SaveChanges();
        //    }
        //    return itemCount;
        //}

        //public void EmptyCart()
        //{
        //    var cartItems = storeDB.tblCarts.Where(
        //        cart => cart.CartId == ShoppingCartId);

        //    foreach (var cartItem in cartItems)
        //    {
        //        storeDB.tblCarts.Remove(cartItem);
        //    }
        //    // Save changes 
        //    storeDB.SaveChanges();
        //}

        //public List<tblCart> GetCartItems()
        //{
        //    return storeDB.tblCarts.Where(
        //        cart => cart.CartId == ShoppingCartId).ToList();
        //    //Forum: if you don't inclde the Album then you get a nullref execption when adding to the cart.
        //    //return storeDB.Carts.Include("Album").Where(
        //    //    c => c.CartId == ShoppingCartId).ToList();
        //}

        //public int GetCount()
        //{
        //    // Get the count of each item in the cart and sum them up 
        //    int? count = (from cartItems in storeDB.tblCarts
        //                  where cartItems.CartId == ShoppingCartId
        //                  select (int?)cartItems.Count).Sum();
        //    // Return 0 if all entries are null 
        //    return count ?? 0;
        //}

        //public decimal GetTotal()
        //{
        //    // Multiply album price by count of that album to get  
        //    // the current price for each of those albums in the cart 
        //    // sum all album price totals to get the cart total 
        //    decimal? total = (from cartItems in storeDB.tblCarts
        //                      where cartItems.CartId == ShoppingCartId
        //                      select (int?)cartItems.Count * cartItems.tblItem.Price).Sum();

        //    return total ?? decimal.Zero;
        //}

        //public int CreateOrder(tblOrder order)
        //{
        //    decimal orderTotal = 0;

        //    var cartItems = GetCartItems();
        //    // Iterate over the items in the cart,  
        //    // adding the order details for each 
        //    foreach (var item in cartItems)
        //    {
        //        var orderDetail = new tblOrderDetail
        //        {
        //            ItemId = item.ItemId,
        //            OrderId = order.OrderId,
        //            UnitPrice = item.tblItem.Price,
        //            Quantity = item.Count
        //        };
        //        // Set the order total of the shopping cart 
        //        orderTotal += Convert.ToDecimal(item.Count * (item.tblItem.Price));

        //        storeDB.tblOrderDetails.Add(orderDetail);

        //    }
        //    // Set the order's total to the orderTotal count 
        //    order.Total = orderTotal;

        //    // Save the order 
        //    storeDB.SaveChanges();
        //    // Empty the shopping cart 
        //    EmptyCart();
        //    // Return the OrderId as the confirmation number 
        //    return order.OrderId;
        //}

        //We're using HttpContextBase to allow access to cookies. 
        public string GetUserId(HttpContextBase context)
            {
                if (context.Session[CartSessionKey] == null)
                {
                    if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                    {
                        context.Session[CartSessionKey] = context.User.Identity.Name;
                    }
                    else
                    {
                        // Generate a new random GUID using System.Guid class 
                        Guid tempCartId = Guid.NewGuid();
                        // Send tempCartId back to client as a cookie 
                        context.Session[CartSessionKey] = tempCartId.ToString();
                    }
                }
                return context.Session[CartSessionKey].ToString();
            }

            // When a user has logged in, migrate their shopping cart to 
            // be associated with their username 
            public void MigrateUser(string userName)
            {
                var user = storeDB.tblBookings.Where(
                    c => c.UserId == BookingId);

                foreach (tblBooking item in user)
                {
                    item.UserId = userName;
                }
                storeDB.SaveChanges();
            }
        }
    }