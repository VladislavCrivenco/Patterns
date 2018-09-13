using System;

namespace Factory_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            ResourceManager localManager = new LocalResourceManager(@"E:\UTM\Teoria Sistemelor");
            
            Console.WriteLine("Local Files");
            foreach (var item in localManager.GetFiles())
            {
                Console.WriteLine(item);
                Console.WriteLine("File Size : " + localManager.GetFileSize(item));
                Console.WriteLine("Last modified date :" + localManager.GetLastModifiedDate(item));

                Console.WriteLine();
            }


            Console.WriteLine("Remote Files");
            ResourceManager remoteManager = new RemoteResourceManager("vlad", "alexei");
            
            foreach (var item in localManager.GetFiles())
            {
                Console.WriteLine(item);
                Console.WriteLine("File Size : " + localManager.GetFileSize(item));
                Console.WriteLine("Last modified date :" + localManager.GetLastModifiedDate(item));

                Console.WriteLine();
            }
        }
    }
}
