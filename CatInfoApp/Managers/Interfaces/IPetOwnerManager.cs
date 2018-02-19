using CatInfoApp.DTOs.Enums;
using System.Collections.Generic;

namespace CatInfoApp.Managers.Interfaces
{
    public interface IPetOwnerManager
    {
        Dictionary<Genders, List<string>> GetCatsByOwnerGender();
    }
}
