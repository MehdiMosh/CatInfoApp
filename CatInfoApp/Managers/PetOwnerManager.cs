using CatInfoApp.DataProviders.Interfaces;
using CatInfoApp.DTOs.Enums;
using CatInfoApp.Managers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CatInfoApp.Managers
{
    public class PetOwnerManager : IPetOwnerManager
    {
        private readonly IOwnerDataProvider ownerDataProvider;

        public PetOwnerManager(IOwnerDataProvider ownerDataProvider)
        {
            this.ownerDataProvider = ownerDataProvider;
        }


        public Dictionary<Genders, List<string>> GetCatsByOwnerGender()
        {
            var owners = ownerDataProvider.GetPetOwners();
            var results = owners.GroupBy(x => x.Gender).Select(x => new {
                Gender = x.Key,
                CatNames = x.Where(p => p.Pets != null).SelectMany(p => p.Pets).Where(p => p.Type == PetType.Cat).Select(p => p.Name).OrderBy(p => p).ToList()
            }).ToDictionary(x => x.Gender, x => x.CatNames);
            return results;
        }
    }
}
