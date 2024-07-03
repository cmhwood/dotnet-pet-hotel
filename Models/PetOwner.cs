using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using pet_hotel.Controllers;

namespace pet_hotel.Models;

public class PetOwner
{
   public int Id { get; set; }

   [Required]
   public string Name { get; set; }

   [Required]
   public string Email { get; set; }

   [JsonIgnore]
   public ICollection<Pet> Pets { get; set; }
   

   [NotMapped]
   public int PetCount
   {
      get
      {
         return (Pets != null) ? Pets.Count : 0;
      }
   }
}