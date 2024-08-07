using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace pet_hotel.Models;

public enum Petbreed
{
  Shepherd,
  Poodle,
  Beagle,
  Bulldog,
  Terrier,
  Boxer,
  Labrador,
  Retriever
}

public enum Petcolor
{
  White,
  Black,
  Golden,
  Tricolor,
  Spotted
}
public class Pet
{
  //   {
  //   "name": "Fido",
  //   "color": "White",
  //   "checkedInAt": "2020-07-21T03:17:58.917069",
  //   "petOwnerid": 1,
  //   "id": 1,
  //   "breed": "Beagle",
  //   "petOwner": {
  //     "id": 1,
  //     "petCount": 1,
  //     "email": "asdf@asdf.com",
  //     "name": "blaine"
  //   }
  // Fields go here.
  // Hint: nullable types are a thing in c#, you will need to google
  // this so that `checkedInAt` can accept `null` as a value
  public int id { get; set; }

  [Required]
  public string name { get; set; }

  [Required]
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public Petcolor petColor { get; set; }

  public DateTime? checkedInAt { get; set; }

  

  [Required]
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public Petbreed petBreed { get; set; }

  public PetOwner petOwner { get; set; }

  [Required]
  public int petOwnerId { get; set; }

  public void CheckedInAtReset()
  {
    this.checkedInAt = null;
  }

   public void CheckedInAtSet()
  {
    this.checkedInAt = DateTime.UtcNow;
  }




}