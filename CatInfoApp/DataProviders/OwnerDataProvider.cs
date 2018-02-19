using System.Collections.Generic;
using System.Configuration;
using CatInfoApp.DataProviders.Interfaces;
using CatInfoApp.DTOs;

namespace CatInfoApp.DataProviders
{
    public class OwnerDataProvider : BaseProvider, IOwnerDataProvider
    {
        public readonly string apiUrl;

        public OwnerDataProvider()
        {
            apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        }

        public List<PetOwner> GetPetOwners() {
            return Get<List<PetOwner>>(apiUrl);
        }
    }
}
