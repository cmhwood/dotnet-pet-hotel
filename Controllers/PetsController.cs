using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_hotel.Models;

namespace pet_hotel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
   private readonly ApplicationContext _context;
   public PetsController(ApplicationContext context)
   {
      _context = context;
   }
   
   [HttpGet]
  public IEnumerable<Pet> GetPets()
  {
    return _context.Pets.Include(pet => pet.petOwner).OrderBy(pet => pet.name).ToList();
  }

  
  // GET /{id}
  [HttpGet("{Petid}")]
  public IActionResult GetPetById(int Petid)
  {
    Pet pet = _context.Pets.Include(p => p.petOwnerId).SingleOrDefault(pet => pet.id == Petid);
    if (pet == null)
    {
      return NotFound();
    }
    return Ok(pet);
  }

  // POST /
  [HttpPost]
  public IActionResult CreatePet([FromBody] Pet newPet)
  {
    _context.Pets.Add(newPet);
    _context.SaveChanges();
    return Created($"/api/pets/{newPet.id}", null); 
  }
   // PUT /{id}
  [HttpPut("{petId}")]
  public IActionResult UpdatePetsById(int petId, [FromBody] Pet updatedPet)
  {
    Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == petId);
    if (pet == null) return NotFound();

    pet.name = updatedPet.name;
    pet.petBreed = updatedPet.petBreed;
    pet.petColor = updatedPet.petColor;
    pet.checkedInAt = updatedPet.checkedInAt;


    _context.Pets.Update(pet);
    _context.SaveChanges();

    return Ok(pet);
  }

    // DELETE /{id}
  [HttpDelete("{petId}")]
  public IActionResult DeleteBreadById(int petId)
  {
    Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == petId);
    if (pet == null) return NotFound(); // 404 response

    _context.Pets.Remove(pet); // queue a delete of this bread
    _context.SaveChanges(); // actually do the deletion

    return NoContent(); // 204 no content
  }
      [HttpPut("{petId}/checkin")] // double check URL
  public IActionResult CheckIn(int petId)
  {
    Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == petId);
    Console.WriteLine('pet',pet);
   pet.CheckedInAtSet();
    _context.Pets.Update(pet);
    _context.SaveChanges();
    return Ok(pet);
  }
    [HttpPut("{petId}/checkout")] // double check URL
  public IActionResult CheckOut(int petId)
  {
    Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == petId);
    pet.CheckedInAtReset();
    _context.Pets.Update(pet);
    _context.SaveChanges();
    return Ok(pet);
  }
   // routes go here
}