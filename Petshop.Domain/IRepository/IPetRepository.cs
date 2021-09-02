using System;
using System.Collections.Generic;
using Petshop.Core.Models;

namespace Petshop.Domain.IRepository
{
    public interface IPetRepository
    {
        List<Pet> GetAllPets();
        Pet CreatePet(Pet pet);
        void UpdateName(int idToUpdate, string newPetName);
        void UpdateType(int idToUpdate, string? newPetType);
        void UpdateBirthDate(int idToUpdate, DateTime toDateTime);
        void UpdateSoldDate(int idToUpdate, DateTime toDateTime);
        void UpdateColor(int idToUpdate, string? newPetColor);
        void UpdatePrice(int idToUpdate, double toDouble);
        string DeletePet(int selectionId);
    }
}