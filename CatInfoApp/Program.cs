using CatInfoApp.Bootstrap;
using CatInfoApp.Managers.Interfaces;
using System;

namespace CatInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.ConfigureApplication();
            var petOwnerManager = Bootstrapper.Resolve<IPetOwnerManager>();

            var all = petOwnerManager.GetCatsByOwnerGender();
            if (all == null)
            {
                Console.WriteLine("No Data to display...");
                Environment.Exit(0);
            }
                
            foreach (var item in all)
            {
                Console.WriteLine(item.Key);
                foreach (var catName in item.Value)
                {
                    Console.WriteLine("\t" + catName);
                }
            }
        }
    }
}
