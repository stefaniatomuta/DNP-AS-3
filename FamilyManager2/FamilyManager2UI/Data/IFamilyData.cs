using System.Collections;
using System.Collections.Generic;
using Models;

namespace FamilyManager2UI.Data
{
    public interface IFamilyData
    {
        IList<Family> GetFamilies();
        IList<Person> GetPeople();
        void AddFamily(Family family);
        void AddAdult(Adult adult, Family family);
        void AddChild(Child child, Family family);
        void AddPet(Pet pet, Family family);
        void AddPet(Pet pet, Family family, Child child);

        void RemoveFamily(string streetName, int houseNumber);
        Family GetFamily(string streetName, int houseNumber);
        Person GetPersonByIdFirstLastName(int id, string firstname, string lastname);
        Pet GetPet(int petId);
        IList<string> GetEyeColors();
        IList<string> GetHairColors();
    }
}