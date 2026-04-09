using E_Commerce_Website.Models.MVVM;

namespace E_Commerce_Website.Models.Concrete
{
    public class OrderRepository
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string? MyCart { get; set; }
        public decimal UnitPrice { get; set; }
        public string? ProductName { get; set; }
        public string? PhotoPath { get; set; }
        public int Kdv { get; set; }



        webContext context = new webContext();
        public bool AddToMyCart(string id)
        {
            bool exist = false;
            if (MyCart == "")
            {
                MyCart = id + "=" + Quantity;
            }
            else
            {
                string[] MyCartArray = MyCart.Split('&');

                for (int i = 0; i < MyCartArray.Length; i++)
                {
                    string[] MyCartArrayLoop = MyCartArray[i].Split('=');
                    if (MyCartArrayLoop[0] == id)
                    {
                        exist = true;
                    }
                }
                if (exist == false) // ürün daha önce eklenmemiş sepetin sonuna ekle
                {
                    MyCart = MyCart + "&" + id.ToString() + "=1";
                }
            }
            return exist;
        }

        public void DeleteFromMyCart(string id)
        {
            int count = 1;
            string NewMyCart = "";

            string[] MyCartArray = MyCart.Split('&');
            for (int i = 0; i < MyCartArray.Length; i++)
            {
                string[] MyCartArrayLoop = MyCartArray[i].Split('=');
                string ProductID = MyCartArrayLoop[0];
                string Quantity = MyCartArrayLoop[1];

                if (ProductID != id)
                {
                    if (count == 1)
                    {
                        NewMyCart = ProductID + "=" + MyCartArrayLoop[1];
                        count++;
                    }
                    else
                    {
                        NewMyCart += "&" + ProductID + "=" + Quantity;
                    }
                }
            }
            MyCart = NewMyCart;
        }

        public List<OrderRepository> SelectMyCart()
        {
            // MyCart = "1=2&3=4&5=6"
            List<OrderRepository> list = new List<OrderRepository>();
            string[] MyCartArray = MyCart.Split('&');

            if (MyCart != "") //sepette ürün varken foru yapsın
            {
                for (int i = 0; i < MyCartArray.Length; i++)
                {
                    string[] MyCartArrayLoop = MyCartArray[i].Split("=");
                    int ProductID = Convert.ToInt32(MyCartArrayLoop[0]);
                    int Quantity = Convert.ToInt32(MyCartArrayLoop[1]);

                    //product icinde veritabanındanki verilerin kayıtları var bunları proplara yazdırıyorum
                    Product? product = context.Products.FirstOrDefault(p => p.ProductID == ProductID);

                    OrderRepository orderRepository = new OrderRepository();
                    orderRepository.ProductID = product.ProductID;
                    orderRepository.Quantity = Convert.ToInt32(Quantity);
                    orderRepository.UnitPrice = Convert.ToDecimal(product.UnitPrice);
                    orderRepository.ProductName = product.ProductName;
                    orderRepository.PhotoPath = product.PhotoPath;
                    orderRepository.Kdv = product.Kdv;
                    list.Add(orderRepository);

                }
            }
            return list;

        }

        public string Add(string Email)
        {
            List<OrderRepository> List = SelectMyCart();

            DateTime OrderDate = DateTime.Now;
            string OrderGroupGUID = DateTime.Now.ToString().Replace(":", "").Replace(" ", "").Replace(".", "");
            foreach (var item in List)
            {
                Order order = new Order();

                order.OrderDate = OrderDate;
                order.OrderGroupGUID = OrderGroupGUID;
                order.UserID = context.Users.FirstOrDefault(u => u.Email == Email).UserID;
                order.ProductID = item.ProductID;
                order.Quantity = item.Quantity;

                context.Orders.Add(order);
                context.SaveChanges();
            }
            return OrderGroupGUID;
        }

        public List<Vw_MyOrder> GetMyOrders(string Email)
        {
            int UserID = context.Users.FirstOrDefault(u => u.Email == Email).UserID;

            List<Vw_MyOrder> myOrders = context.Vw_MyOrders.Where(o => o.UserID == UserID).ToList();

            return myOrders;
        }
    }
}
