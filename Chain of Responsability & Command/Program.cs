using System;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            Kitchen kitchen = new Kitchen();
            client.SetCommand(new PizzaCommand(kitchen));
            client.Order();


            client.SetCommand(new MeatCommand(kitchen));
            client.Order();

        }
    }

    
}