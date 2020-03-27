using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mirrorPet.Models;

namespace mirrorPet.Services
{
    public class MockPetDataStore : IPetDataStore
    {

        private static readonly List<Pet> mockPets;
        private static int nextPetId;

        static MockPetDataStore()
        {

            mockPets = new List<Pet>
            {
                new Pet { PetId="1",
                   PetName="Pet 1", PetImageUrl="1.ok.png"  },
                new Pet { PetId="2",
                   PetName="Pet 2", PetImageUrl="2.ok.png"  },
                new Pet { PetId="3",
                   PetName="Pet 3", PetImageUrl="3.ok.png"  },
            };

            nextPetId = mockPets.Count;
        }

        // constructor not currently used
        public MockPetDataStore()
        {
        }

        public async Task<string> AddPetAsync(Pet pet)
        {
            lock (this)
            {
                pet.PetId = nextPetId.ToString();
                mockPets.Add(pet);
                nextPetId++;
            }
            return await Task.FromResult(pet.PetId);
        }

        public async Task<Pet> GetPetAsync(string id)
        {
            var _pet = mockPets.FirstOrDefault(pet => pet.PetId == id);

            // Make a copy of the pets to simulate reading from an external datastore
            var returnPet = CopyPet(_pet);
            return await Task.FromResult(returnPet);
        }


        public async Task<IList<Pet>> GetPetsAsync()
        {
            // Make a copy of the pets to simulate reading from an external datastore
            var returnPets = new List<Pet>();
            foreach (var pet in mockPets)
                returnPets.Add(CopyPet(pet));
            return await Task.FromResult(returnPets);
        }


        private static Pet CopyPet(Pet pet)
        {
            return new Pet
            {
                PetId = pet.PetId,
                PetImageUrl = pet.PetImageUrl,
                PetName = pet.PetName
            };
        }
    }

}