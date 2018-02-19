using CatInfoApp.DTOs.Enums;
using System.Collections.Generic;

namespace CatInfoApp.DTOs
{
    public class PetOwner
    {
        public string Name { get; set; }
        public Genders Gender { get; set; }
        public int Age { get; set; }

        public List<Pet> Pets { get; set; }
    }
}
