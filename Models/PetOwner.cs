using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using pet_hotel.Controllers;

namespace pet_hotel.Models;

public class PetOwner
{
   public int id { get; set; }

   [Required]
   public string name { get; set; }

   [Required]
   public string email { get; set; }

   [JsonIgnore]
   public ICollection<Pet> pets { get; set; }


   [NotMapped]
   public int petCount
   {
      get
      {
         return (pets != null) ? pets.Count : 0;
      }
   }
}