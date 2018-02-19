using CatInfoApp.DTOs;
using System.Collections.Generic;

namespace CatInfoApp.DataProviders.Interfaces
{
    public interface IOwnerDataProvider
    {
        List<PetOwner> GetPetOwners();
    }
}
