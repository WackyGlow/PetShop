using System;
using System.Collections.Generic;
using Petshop.Core.iServices;
using Petshop.Core.Models;
using Petshop.Domain.IRepository;

namespace Petshop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _repository;
        private List<Pet> _petList = new List<Pet>();

        public PetService(IPetRepository repository)
        {
            _repository = repository;
        }

        public List<Pet> GetAllPets()
        {
            return _repository.GetAllPets();
        }

        public void UpdatePetPrice(int idToUpdate, double toDouble)
        {
            _repository.UpdatePrice(idToUpdate, toDouble);
        }

        public void UpdatePetName(int idToUpdate, string newPetName)
        {
            _repository.UpdateName(idToUpdate, newPetName);
        }

        public void UpdatePetType(int idToUpdate, string? newPetType)
        {
            _repository.UpdateType(idToUpdate, newPetType);
        }

        public void UpdatePetBirthDate(int idToUpdate, DateTime toDateTime)
        {
            _repository.UpdateBirthDate(idToUpdate, toDateTime);
        }

        public void UpdatePetSoldDate(int idToUpdate, DateTime toDateTime)
        {
            _repository.UpdateSoldDate(idToUpdate, toDateTime);
        }

        public void UpdatePetColor(int idToUpdate, string? newPetColor)
        {
            _repository.UpdateColor(idToUpdate, newPetColor);
        }

        public Pet CreatePet(Pet pet)
        {
           return _repository.CreatePet(pet);
        }

        public List<Pet> GetPetsByType(string input)
        {
            List<Pet> searchedPets = new List<Pet>();
            _petList = GetAllPets();
            foreach (var pet in _petList)
            {
                if (String.Equals(pet.Type.Name, input, StringComparison.CurrentCultureIgnoreCase))
                {
                    searchedPets.Add(pet);
                }
            }
            return searchedPets;
        }

        public string Delete(int selectionId)
        {
            return _repository.DeletePet(selectionId);
        }
    }
}