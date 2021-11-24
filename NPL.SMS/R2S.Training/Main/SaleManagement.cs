using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using R2S.Training.Domain;
using R2S.Training.Entities;
namespace R2S.Training
{
    class SaleManagement
    {
       
        static void Main(string[] args)
        {
            //Hàm main chỉ có giá trị test chức năng tạo ra
            //Dữ liệu truyền vào cần phải đúng 

            //Bai 1: Lấy tất cả khách hàng có trong hệ thống
            getAllCustomer();
            Console.WriteLine();

            ////Bai 2: Lấy tất cả thông tin đặt hàng bở khách hàng có id là 1
            //getAllOrderByCustomerId(2);
            //Console.WriteLine();

            ////Bai 3: Lấy thông tin từ thành phần đơn hàng theo mã đơn đặt hàng la 1
            //getAllItemByOrderId(1);
            //Console.WriteLine();

            ////Bai 4: Tính tổng lại đơn hàng theo mã hóa đơn
            //computeOrderTotal(1);
            //Console.WriteLine();

            ////Bai 5: Thêm một khách hàng mới
            //Customer customer = new Customer(8, "Name" + DateTime.Now.Millisecond.ToString());
            //addCutomer(customer);
            //Console.WriteLine();

            ////Bai 6: Xóa 1 khách hàng từ database với mã khách hàng là 1
            //deleteCutomer(1);
            //Console.WriteLine();

            ////Bai 7: Cập nhật thông tin khách hàng
            //Customer customerUpdate = new Customer(7, "Name" + DateTime.Now.Millisecond.ToString());
            //updateCutomer(customerUpdate);
            //Console.WriteLine();

            ////Bai 8: Thêm mới Đơn đặt hàng
            //Order order = new Order(3, DateTime.Now.ToString(), 2, 1, 20000);
            //addOrder(order);
            //Console.WriteLine();

            ////Bai 9: Thêm sản phẩm vào đơn đặt hàng
            //LineItem lineItem = new LineItem(2, 3, 2, 20000);
            //addLineItem(lineItem);
            //Console.WriteLine();

            //Bai 10: Cập nhật tổng giá trị đơn hàng
            updateOrderTotal(3);
            Console.WriteLine();


            Console.ReadKey();

        }

        private static void getAllCustomer()
        {
            Console.WriteLine("Bai 1: ");
            try
            {
                CustomerDomain customerDomain = new CustomerDomain();
                List<Customer> listCustomer = customerDomain.GetAllCustomer();
                if (listCustomer != null)
                {
                    Console.WriteLine("Danh sach khach hang: " + listCustomer.Count);
                    foreach (Customer customer in listCustomer)
                    {
                        Console.WriteLine(" - Ma:" +customer.getCustomerId() +"/ " +customer.getCustomerName());
                    }
                }
                else
                {
                    Console.WriteLine("Danh sach khach hang trong");
                }
            }
            catch
            {
                Console.WriteLine("Loi lay thong tin khach hang tu he thong");
            }
            
        }

        private static void getAllOrderByCustomerId(int customerId)
        {
            Console.WriteLine("Bai 2: ");
            try
            {
                OrderDomain orderDomain = new OrderDomain();
                List<Order> listOrder = orderDomain.getAllOrdersByCustomerId(customerId);
                if(listOrder != null)
                {
                    Console.WriteLine("Thong tin don dat hang (Ma id " + customerId + "): " + listOrder.Count);
                    foreach(Order order in listOrder)
                    {
                        Console.WriteLine("*********************");
                        Console.WriteLine("Ma dat hang: " + order.getOrderId());
                        Console.WriteLine("Ngay dat hang: " + order.getOrderDate());
                        Console.WriteLine("Nhan vien lap: " + order.getEmployeeId());
                        Console.WriteLine("Tong: " + order.getTotal() + " VND");
                    }
                }
                else
                {
                    Console.WriteLine("Thong tin don dat hang (Ma id " + customerId + "): " + 0);
                }
            }
            catch
            {
                Console.WriteLine("Co loi xay ra khi lay thong tin dat hang cua khach hang");
            }
        }

        private static void getAllItemByOrderId(int orderId)
        {
            Console.WriteLine("Bai 3:");
            try
            {
                LineItemDomain lineItemDomain = new LineItemDomain();
                List<LineItem> listLineItem = lineItemDomain.getAllItemByOrderId(1);
                if(listLineItem != null)
                {
                    Console.WriteLine("Thong tin theo don dat hang " + orderId + ": " + listLineItem.Count);
                    foreach(LineItem lineItem in listLineItem)
                    {
                        Console.WriteLine("*********************");
                        Console.WriteLine("Ma don hang: " + lineItem.getProductId());
                        Console.WriteLine("So luong: " + lineItem.getQuantity());
                        Console.WriteLine("Gia: " + lineItem.getPrice());
                    }
                }
                else
                {
                    Console.WriteLine("Thong tin theo don dat hang " + orderId + " trong!!!");
                }
            }
            catch
            {
                Console.WriteLine("Co loi xay ra khi lay thong tin san pham don hang");
            }
        }

        private static void computeOrderTotal(int orderId)
        {
            Console.WriteLine("Bai 4:");
            try
            {
                LineItemDomain lineItemDomain = new LineItemDomain();
                double total = lineItemDomain.computeOrderTotal(orderId);
                Console.WriteLine("Tong don hang voi ma " + orderId + ": "+total+" VND");
            }
            catch
            {
                Console.WriteLine("Loi khi tinh toan tong gia don hang");
            }
        }

        private static void addCutomer(Customer customer)
        {
            try
            {
                Console.WriteLine("Bai 5:");
                Console.WriteLine("Them moi khach hang: " + customer.getCustomerName());
                CustomerDomain customerDomain = new CustomerDomain();
                if (customerDomain.AddCustomer(customer))
                {
                    Console.WriteLine("Them thanh cong");
                }
                else
                {
                    Console.WriteLine("Them that bai");
                }
            }
            catch
            {
                Console.WriteLine("Loi khi them khach hang");
            }
        }

        private static void deleteCutomer(int customerId)
        {
            try
            {
                Console.WriteLine("Bai 6:");
                CustomerDomain customerDomain = new CustomerDomain();
                if (customerDomain.DeleleCustomer(customerId))
                {
                    Console.WriteLine("Xoa thanh cong");
                }
                else
                {
                    Console.WriteLine("Xoa that bai");
                }
            }
            catch
            {
                Console.WriteLine("Loi khi xoa khach hang");
            }
        }

        private static void updateCutomer(Customer customer)
        {
            try
            {
                Console.WriteLine("Bai 7:");
                CustomerDomain customerDomain = new CustomerDomain();
                if (customerDomain.UpdateCustomer(customer))
                {
                    Console.WriteLine("Cap nhat thanh cong");
                }
                else
                {
                    Console.WriteLine("Cap nhat that bai, kiem tra lai ma khach hang");
                }
            }
            catch
            {
                Console.WriteLine("Loi khi cap nhat khach hang");
            }
        }

        private static void addOrder(Order order)
        {
            try
            {
                Console.WriteLine("Bai 8:");
                OrderDomain orderDomain = new OrderDomain();
                if (orderDomain.addOrder(order))
                {
                    Console.WriteLine("Them don dat hang thanh cong");
                }
                else
                {
                    Console.WriteLine("Them don dat hang that bai, kiem tra lai ma khach hang hoac nhan vien ");
                }
            }
            catch
            {
                Console.WriteLine("Loi khi them don dat hang, kiem tra ma nguoi dung");
            }
        }

        private static void addLineItem(LineItem lineItem)
        {
            try
            {
                Console.WriteLine("Bai 9:");
                LineItemDomain lineItemDomain = new LineItemDomain();
                if (lineItemDomain.addLineItem(lineItem))
                {
                    Console.WriteLine("Them chi tiet don dat hang thanh cong");
                }
                else
                {
                    Console.WriteLine("Them chi tiet don dat hang that bai, kiem tra lai ma don dat hang hoac ma san pham");
                }
            }
            catch
            {
                Console.WriteLine("Loi khi them chi tiet don dat hang");
            }
        }

        private static void updateOrderTotal(int orderId)
        {
            try
            {
                Console.WriteLine("Bai 10:");
                OrderDomain orderDomain = new OrderDomain();
                if (orderDomain.updateOrderTotal(orderId))
                {
                    Console.WriteLine("Cap nhat thanh cong");
                }
                else
                {
                    Console.WriteLine("Cap nhat that bai, kiem ttra lai ma don hang");
                }
            }
            catch
            {
                Console.WriteLine("Loi khi cap nhat tong gia tri don hang");
            }
        }
    }
}
