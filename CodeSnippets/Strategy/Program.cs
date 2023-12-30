using System;

namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1: ApplePay, 2: GooglePay");

            Console.WriteLine("Pay with?");
            var payWith = Console.ReadLine();

            var shop = new Shop(new CheckOutWithApple());

            switch (payWith)
            {
                case "1":
                    shop.ChangeCheckOut(new CheckOutWithApple());
                    Console.WriteLine(shop.Pay(1.99));
                    break;
                case "2":
                    shop.ChangeCheckOut(new CheckOutWithGoogle());
                    Console.WriteLine(shop.Pay(2.99));
                    break;
                default:
                    break;
            }
        }
    }
}