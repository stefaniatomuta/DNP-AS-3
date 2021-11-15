using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace Models {
public class Family {
    [Required, MaxLength(256)]
    public string StreetName { get; set; }
    
    [Required, MaxLength(32)]
    public int HouseNumber{ get; set; }
    
    public List<Adult> Adults { get; set; }
    public List<Child> Children{ get; set; }
    public List<Pet> Pets{ get; set; }

    public Family() {
        Adults = new List<Adult>();     
    }

    public int GetNumberOfMembers() {
        return Adults.Count + Children.Count;
    }

    public bool HasPets() {
        return Pets.Any();
    }

    public string GetUniqueKey() {
        return $"{StreetName} {HouseNumber}";
    }

    public IList<Person> GetAllMembers() {
        IList<Person> people = new List<Person>();
        foreach (var person in Adults) {
            people.Add(person);
        }
        foreach (var person in Children) {
            people.Add(person);
        }
        return people;
    }
    
}


}