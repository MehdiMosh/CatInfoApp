using System;
using System.Collections.Generic;
using System.Linq;
using CatInfoApp.DataProviders.Interfaces;
using CatInfoApp.DTOs;
using CatInfoApp.DTOs.Enums;
using CatInfoApp.Managers;
using CatInfoApp.Managers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace CatInfoApp.Test.Managers
{
    [TestClass]
    public class PetOwnerManagerTests
    {
        private IPetOwnerManager petOwnerManager;
        private IOwnerDataProvider ownerDataProviderMock;

        [TestInitialize]
        public void Setup()
        {
            ownerDataProviderMock = MockRepository.GenerateMock<IOwnerDataProvider>();
            petOwnerManager = new PetOwnerManager(ownerDataProviderMock);
        }

        [TestMethod]
        public void NoDataReceived_ReturnsNull()
        {
            ownerDataProviderMock.Expect(x => x.GetPetOwners()).Return(null);
            var result = petOwnerManager.GetCatsByOwnerGender();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void OneOwnerWithDog_ShouldNotReturnPetsForGender()
        {
            ownerDataProviderMock.Expect(x => x.GetPetOwners()).Return(new List<PetOwner> {
                new PetOwner { Gender = Genders.Male, Pets = new List<Pet> { new Pet { Type = PetType.Dog, Name = "Dog1" } } }
            });
            var result = petOwnerManager.GetCatsByOwnerGender();

            Assert.IsTrue(result.ContainsKey(Genders.Male));
            Assert.IsFalse(result[Genders.Male].Any());
        }

        [TestMethod]
        public void OneOwnerWithCat_ShouldReturnOnePetForGender()
        {
            ownerDataProviderMock.Expect(x => x.GetPetOwners()).Return(new List<PetOwner> {
                new PetOwner { Gender = Genders.Male, Pets = new List<Pet> { new Pet { Type = PetType.Cat, Name = "Cat1" } } }
            });
            var result = petOwnerManager.GetCatsByOwnerGender();

            Assert.IsTrue(result.ContainsKey(Genders.Male));
            Assert.AreEqual(1, result[Genders.Male].Count);
        }

        [TestMethod]
        public void MultipleOwnersWithCat_ShouldReturnAll()
        {
            ownerDataProviderMock.Expect(x => x.GetPetOwners()).Return(new List<PetOwner> {
                new PetOwner { Gender = Genders.Male, Pets = new List<Pet> { new Pet { Type = PetType.Cat, Name = "Cat1" } } },
                new PetOwner { Gender = Genders.Male, Pets = new List<Pet> { new Pet { Type = PetType.Cat, Name = "Cat2" }, new Pet { Type = PetType.Dog, Name = "Dog1" } } }
            });
            var result = petOwnerManager.GetCatsByOwnerGender();

            Assert.IsTrue(result.ContainsKey(Genders.Male));
            Assert.AreEqual(2, result[Genders.Male].Count);
        }

        [TestMethod]
        public void ShouldHandleNullPetsGracefully()
        {
            ownerDataProviderMock.Expect(x => x.GetPetOwners()).Return(new List<PetOwner> {
                new PetOwner { Gender = Genders.Male, Pets = null },
                new PetOwner { Gender = Genders.Male, Pets = new List<Pet> { new Pet { Type = PetType.Cat, Name = "Cat2" }, new Pet { Type = PetType.Dog, Name = "Dog1" } } }
            });
            var result = petOwnerManager.GetCatsByOwnerGender();

            Assert.IsTrue(result.ContainsKey(Genders.Male));
            Assert.AreEqual(1, result[Genders.Male].Count);
        }
    }
}
