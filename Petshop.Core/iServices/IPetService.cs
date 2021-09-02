using System;
using System.Collections.Generic;
using Petshop.Core.Models;

namespace Petshop.Core.iServices
{
    public interface IPetService
    {
        public List<Pet> GetAllPets();

        void UpdatePetPrice(int idToUpdate, double toDouble);
        void UpdatePetName(int idToUpdate, string? newPetName);
        void UpdatePetType(int idToUpdate, string? newPetType);
        void UpdatePetBirthDate(int idToUpdate, DateTime toDateTime);
        void UpdatePetSoldDate(int idToUpdate, DateTime toDateTime);
        void UpdatePetColor(int idToUpdate, string? newPetColor);
        Pet CreatePet(Pet pet);
        List<Pet> GetPetsByType(string input);
        string Delete(int selectionId);
    }
}