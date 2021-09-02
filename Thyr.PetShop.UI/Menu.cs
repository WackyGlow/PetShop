using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Petshop.Core.iServices;
using Petshop.Core.Models;

namespace Thyr.PetShop.UI
{
    public class Menu : IMenu
    {
        private IPetService _petService;

        public Menu(IPetService petService)
        {
            _petService = petService;
        }

        public void Start()
        {
            StartLoop();
        }

        public int GetMainMenuSelection()
        {
            ShowMainMenu();
            var selectionString = Console.ReadLine();
            if (int.TryParse(selectionString, out var selection))
            {
                return selection;
            }

            return -1;
        }

        private void ShowMainMenu()
        {
            Console.WriteLine(Constants.WelcomeGreeting);
            Console.WriteLine(Constants.PrintPetListText);
            Console.WriteLine(Constants.SearchByPetTypeText);
            Console.WriteLine(Constants.CreateNewPetText);
            Console.WriteLine(Constants.DeletePetText);
            Console.WriteLine(Constants.UpdatePetInfoText);
            Console.WriteLine(Constants.ExitConsoleText);
        }

        private void StartLoop()
        {

            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                switch (choice.ToString())
                {
                    case "1":
                        GetAllPets();
                        break;
                    case "2":
                        SearchByPetType();
                        break;
                    case "3":
                        CreateNewPet();
                        break;
                    
                    case "4":
                        DeletePet();
                        break;
                    
                    case "5":
                        EditPet();
                        break;
                    
                    default:
                        Console.Clear();
                        Console.WriteLine("Please make a valid selection");
                        Console.WriteLine("");
                        break;
                }
            }

            if (choice == 0)
            {
                Console.Clear();
                Console.WriteLine("See ya Sucka");
            }
        }

        private void SearchByPetType()
        {
            Console.Clear();
            Console.WriteLine(Constants.SearchPetTypeByNameText);
            string input = Console.ReadLine()?.ToLower();
            List<Pet> tempPetList = _petService.GetPetsByType(input);
            if (tempPetList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine(Constants.SeachResultEqualsZero);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(Constants.HereIsAListOfMatchingPets);
                Console.WriteLine("");
                Console.WriteLine($"{"ID:",-5}" + "| " +
                                  $"{"Name:",-20}"+ "| " +
                                  $"{"Type:",-10}"+ "| " +
                                  $"{"Birth Date:",-11}"+ "| " +
                                  $"{"Sold Date:",-11}"+ "| " +
                                  $"{"Color:",-10}"+ "| " +
                                  $"{"Price:",-10}");
                Console.WriteLine($"{"-----",-5}" + "|-" +
                                  $"{"--------------------",-20}"+ "|-" +
                                  $"{"----------",-10}"+ "|-" +
                                  $"{"-----------",-11}"+ "|-" +
                                  $"{"-----------",-11}"+ "|-" +
                                  $"{"----------",-10}"+ "|-" +
                                  $"{"----------",-10}");
                foreach (var pet in tempPetList)
                {
                    Console.WriteLine($"{pet.Id,-5}"+ "| " +
                                      $"{pet.Name,-20}"+ "| " +
                                      $"{pet.Type.Name,-10}"+ "| " +
                                      $"{pet.BirthDate.ToString("dd-MM-yyyy"),-11}"+ "| " +
                                      $"{pet.SoldDate.ToString("dd-MM-yyyy"),-11}"+ "| " +
                                      $"{pet.Color,-10}"+ "| " +
                                      $"{pet.Price,-10}");
                }
                Console.WriteLine("");
            }
        }

        private void UpdatePet()
        {
            throw new NotImplementedException();
        }

        private void CreateNewPet()
        {
            //Pet Name
            Console.Clear();
            Console.WriteLine(Constants.PleaseEnterPetName);
            var petName = Console.ReadLine();
            if (String.IsNullOrEmpty(petName))
            {
                Console.Clear();
                Console.WriteLine(Constants.ValueCannotBeNullText);
                return;
            } 
            if (petName.Any(char.IsDigit))
            {
                Console.Clear();
                Console.WriteLine(Constants.NamesCannotContainNumbersText);
                return;
            }
            //Type
            Console.WriteLine(Constants.PleaseEnterPetType);
            PetType newPetType = new PetType();
            var petType = Console.ReadLine();
            newPetType.Name = petType;
            if (String.IsNullOrEmpty(petType))
            {
                Console.Clear();
                Console.WriteLine(Constants.ValueCannotBeNullText);
                return;
            }
            if (petType.Any(char.IsDigit))
            {
                Console.Clear();
                Console.WriteLine(Constants.TypesCannotContainNumbersText);
                return;
            }
            
            //Birthday
            Console.WriteLine(Constants.PleaseEnterPetBirthDay);
            var petBirthDay = Console.ReadLine();
            if (String.IsNullOrEmpty(petBirthDay))
            {
                Console.Clear();
                Console.WriteLine(Constants.ValueCannotBeNullText);
                return;
            }
            if (petBirthDay.Any(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine(Constants.DatesCannotContainLettersText);
                return;
            }
            if(!DateTime.TryParseExact(petBirthDay, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempOne))
            {
                Console.Clear();
                Console.WriteLine(Constants.DateWrittenWrongText);
                return;
            }
            //Sold Date
            Console.WriteLine(Constants.PleaseEnterPetSoldDate);
            var petSoldDate = Console.ReadLine();
            if (String.IsNullOrEmpty(petSoldDate))
            {
                Console.Clear();
                Console.WriteLine(Constants.ValueCannotBeNullText);
                return;
            }
            if (petSoldDate.Any(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine(Constants.DatesCannotContainLettersText);
                return;
            }
            if(!DateTime.TryParseExact(petSoldDate,"dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempTwo))
            {
                Console.Clear();
                Console.WriteLine(Constants.DateWrittenWrongText);
                return;
            }
            //Color
            Console.WriteLine(Constants.PleaseEnterPetColor);
            var petColor = Console.ReadLine();
            if (String.IsNullOrEmpty(petColor))
            {
                Console.Clear();
                Console.WriteLine(Constants.ValueCannotBeNullText);
                return;
            }
            if (petColor.Any(char.IsDigit))
            {
                Console.Clear();
                Console.WriteLine(Constants.ColorsCannotContainNumbersText);
                return;
            }
            //Price
            Console.WriteLine(Constants.PleaseEnterPetPrice);
            var petPrice = Console.ReadLine();
            if (String.IsNullOrEmpty(petPrice))
            {
                Console.Clear();
                Console.WriteLine(Constants.ValueCannotBeNullText);
                return;
            }
            if (petPrice.Any(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine(Constants.PricesCannotContainLettersText);
                return;
            }
            if(!Double.TryParse(petPrice, out var tempThree))
            {
                Console.Clear();
                Console.WriteLine(Constants.NumberWrittenWrongText);
                return;
            }

            var pet = new Pet()
            {
                Name = petName,
                Type = newPetType,
                BirthDate = Convert.ToDateTime(petBirthDay),
                SoldDate = Convert.ToDateTime(petSoldDate),
                Color = petColor,
                Price = Convert.ToDouble(petPrice)
            };
            pet = _petService.CreatePet(pet);
            Console.Clear();
            Console.WriteLine(Constants.PetHasBeenCreatedText);
            Console.WriteLine(Constants.PetHasBeenCreatedText);
            Console.WriteLine($"{"ID:",-5}" + "| " +
                              $"{"Name:",-20}"+ "| " +
                              $"{"Type:",-10}"+ "| " +
                              $"{"Birth Date:",-11}"+ "| " +
                              $"{"Sold Date:",-11}"+ "| " +
                              $"{"Color:",-10}"+ "| " +
                              $"{"Price:",-10}");
            Console.WriteLine($"{"-----",-5}" + "|-" +
                              $"{"--------------------",-20}"+ "|-" +
                              $"{"----------",-10}"+ "|-" +
                              $"{"-----------",-11}"+ "|-" +
                              $"{"-----------",-11}"+ "|-" +
                              $"{"----------",-10}"+ "|-" +
                              $"{"----------",-10}");
            Console.WriteLine($"{pet.Id,-5}"+ "| " +
                              $"{pet.Name,-20}"+ "| " +
                              $"{pet.Type.Name,-10}"+ "| " +
                              $"{pet.BirthDate.ToString("dd-MM-yyyy"),-11}"+ "| " +
                              $"{pet.SoldDate.ToString("dd-MM-yyyy"),-11}"+ "| " +
                              $"{pet.Color,-10}"+ "| " +
                              $"{pet.Price,-10}");
            Console.WriteLine("");
        }

        private void GetAllPets()
        {
            Console.Clear();
            List<Pet> allPets = _petService.GetAllPets();
            foreach (var pet in allPets)
            {
                Console.WriteLine($"ID: {pet.Id}, Name: {pet.Name}, Race: {pet.Type.Name} , Birth: {pet.BirthDate}, Sold: {pet.SoldDate}, Color: {pet.Color}, Price: {pet.Price}");
            }
            Console.WriteLine("");
        }
        

        private void DeletePet(){
            Console.WriteLine(Constants.PleaseEnterPetId);
            var petId = Console.ReadLine();
            int selectionId = Int32.Parse(petId);
            if (!Int32.TryParse(petId,out int petIdInt))
            {
                Console.Clear();
                Console.WriteLine(Constants.PleaseTypeANumberInTheField);
            }
            else
            {
                Console.Clear();
                var deletedPetName = _petService.Delete(selectionId);
                Console.WriteLine($"The pet {deletedPetName} with the ID {petId}, has been deleted.");
                Console.WriteLine("");
            }
        }

        private void EditPet()
        {
            GetAllPets();
            Console.WriteLine("");
            Console.WriteLine("Select a pet by entering the ID of the pet:");

            var idString = Console.ReadLine();
            int idToUpdate = 0;
            int id;

            if (int.TryParse(idString, out id))
            {
                idToUpdate = id;
            }
            Console.Clear();
            Console.WriteLine(Constants.PleaseSelectThePetInfoToEdit);
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Pet Type");
            Console.WriteLine("3. Birthdate");
            Console.WriteLine("4. Sold date");
            Console.WriteLine("5. Color");
            Console.WriteLine("6. Price");
            Console.WriteLine("");
            Console.WriteLine("0. Cancel");
            Console.WriteLine("");
            int choice;
            while ((choice = GetUpdateSelection()) != 0)
            {
                if (choice == 1)
                {
                    UpdatePetName(idToUpdate);
                    break;
                }
                if (choice == 2)
                {
                    UpdatePetType(idToUpdate);
                    break;
                }
                if (choice == 3)
                {
                    UpdatePetBirthDate(idToUpdate);
                    break;
                }
                if (choice == 4)
                {
                    UpdatePetSoldDate(idToUpdate);
                    break;
                }
                if (choice == 5)
                {
                    UpdatePetColor(idToUpdate);
                    break;
                }
                if (choice == 6)
                {
                    UpdatePetPrice(idToUpdate);
                    break;
                }
            }
        }
        private void UpdatePetName(int idToUpdate)
        {
            Console.WriteLine("Please write a new pet name:");
            var newPetName = Console.ReadLine();
            if (String.IsNullOrEmpty(newPetName))
            {
                Console.Clear();
                Console.WriteLine(Constants.ValueCannotBeNullText);
                return;
            }
            if (newPetName.Any(char.IsDigit))
            {
                Console.Clear();
                Console.WriteLine(Constants.NamesCannotContainNumbersText);
                return;
            }
            _petService.UpdatePetName(idToUpdate, newPetName);
            Console.Clear();
            Console.WriteLine(Constants.PetNameHasBeenChanged); 
            Console.WriteLine("");
        }
        private void UpdatePetType(int idToUpdate)
        {
            Console.WriteLine("Please write a new pet type:");
            var newPetType = Console.ReadLine();
            if (String.IsNullOrEmpty(newPetType))
            {
                Console.Clear();
                Console.WriteLine(Constants.ValueCannotBeNullText);
                return;
            }
            if (newPetType.Any(char.IsDigit))
            {
                Console.Clear();
                Console.WriteLine(Constants.TypesCannotContainNumbersText);
                return;
            }
            _petService.UpdatePetType(idToUpdate, newPetType);
            Console.Clear();
            Console.WriteLine(Constants.PetTypeHasBeenChanged); 
            Console.WriteLine("");
        }
        private void UpdatePetBirthDate(int idToUpdate)
        {
            Console.WriteLine("Please write a new pet birth date:");
            var newPetBirthDate = Console.ReadLine();
            if (String.IsNullOrEmpty(newPetBirthDate))
            {
                Console.Clear();
                Console.WriteLine(Constants.ValueCannotBeNullText);
                return;
            }
            if (newPetBirthDate.Any(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine(Constants.DatesCannotContainLettersText);
                return;
            }
            if(!DateTime.TryParseExact(newPetBirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var temp))
            {
                Console.Clear();
                Console.WriteLine(Constants.DateWrittenWrongText);
                return;
            }
            _petService.UpdatePetBirthDate(idToUpdate, Convert.ToDateTime(newPetBirthDate));
            Console.Clear();
            Console.WriteLine(Constants.PetBirthDayHasBeenChanged);
            Console.WriteLine("");
        }
        private void UpdatePetSoldDate(int idToUpdate)
        {
            Console.WriteLine("Please write a new pet sold date:");
            var newPetSoldDate = Console.ReadLine();
            if (String.IsNullOrEmpty(newPetSoldDate))
            {
                Console.Clear();
                Console.WriteLine(Constants.ValueCannotBeNullText);
                return;
            }
            if (newPetSoldDate.Any(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine(Constants.DatesCannotContainLettersText);
                return;
            }
            if(!DateTime.TryParseExact(newPetSoldDate,"dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempTwo))
            {
                Console.Clear();
                Console.WriteLine(Constants.DateWrittenWrongText);
                return;
            }
            _petService.UpdatePetSoldDate(idToUpdate, Convert.ToDateTime(newPetSoldDate));
            Console.Clear();
            Console.WriteLine(Constants.PetSoldDateHasBeenChanged);
            Console.WriteLine("");
            
        }
        private void UpdatePetColor(int idToUpdate)
        {
            Console.WriteLine("Please write a new pet color:");
            var newPetColor = Console.ReadLine();
            if (String.IsNullOrEmpty(newPetColor))
            {
                Console.Clear();
                Console.WriteLine(Constants.ValueCannotBeNullText);
                return;
            }
            if (newPetColor.Any(char.IsDigit))
            {
                Console.Clear();
                Console.WriteLine(Constants.ColorsCannotContainNumbersText);
                return;
            }
            _petService.UpdatePetColor(idToUpdate, newPetColor);
            Console.Clear();
            Console.WriteLine(Constants.PetColorHasBeenChanged);
            Console.WriteLine("");
            
        }
        private void UpdatePetPrice(int idToUpdate)
        {
            Console.WriteLine("Please write a new pet price:");
            var newPetPrice = Console.ReadLine();
            if (String.IsNullOrEmpty(newPetPrice))
            {
                Console.Clear();
                Console.WriteLine(Constants.ValueCannotBeNullText);
                return;
            }
            if (newPetPrice.Any(char.IsLetter))
            {
                Console.Clear();
                Console.WriteLine(Constants.PricesCannotContainLettersText);
                return;
            }
            if(!Double.TryParse(newPetPrice, out var tempThree))
            {
                Console.Clear();
                Console.WriteLine(Constants.NumberWrittenWrongText);
                return;
            }
            _petService.UpdatePetPrice(idToUpdate, Convert.ToDouble(newPetPrice));
            Console.Clear();
            Console.WriteLine(Constants.PetPriceHasBeenChanged);
            Console.WriteLine("");
        }
        private int GetUpdateSelection()
        {
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }
    }
}