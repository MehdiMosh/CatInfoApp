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
