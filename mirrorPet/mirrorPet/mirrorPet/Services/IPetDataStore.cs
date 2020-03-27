using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mirrorPet.Models;

namespace mirrorPet.Services
{
    public interface IPetDataStore
    {
        Task<String> AddPetAsync(Pet pet);
        Task<Pet> GetPetAsync(string id);
        Task<IList<Pet>> GetPetsAsync();
    }
}
