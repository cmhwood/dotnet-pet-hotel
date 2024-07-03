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
    return _context.Pets.Include(pet => pet.PetOwner).OrderBy(pet => pet.Name).ToList();
  }

  
  // GET /{id}
  [HttpGet("{Petid}")]
  public IActionResult GetPetById(int Petid)
  {
    Pet pet = _context.Pets.Include(p => p.PetOwnerId).SingleOrDefault(pet => pet.Id == Petid);
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
    return Created($"/api/pets/{newPet.Id}", null); 
  }
   // PUT /{id}
  [HttpPut("{petId}")]
  public IActionResult UpdatePetsById(int petId, [FromBody] Pet updatedPet)
  {
    Pet pet = _context.Pets.SingleOrDefault(pet => pet.Id == petId);
    if (pet == null) return NotFound();

    pet.Name = updatedPet.Name;
    pet.PetBreed = updatedPet.PetBreed;
    pet.PetColor = updatedPet.PetColor;
    pet.CheckedInAt = updatedPet.CheckedInAt;


    _context.Pets.Update(pet);
    _context.SaveChanges();

    return Ok(pet);
  }

    // DELETE /{id}
  [HttpDelete("{petId}")]
  public IActionResult DeleteBreadById(int petId)
  {
    Pet pet = _context.Pets.SingleOrDefault(pet => pet.Id == petId);
    if (pet == null) return NotFound(); // 404 response

    _context.Pets.Remove(pet); // queue a delete of this bread
    _context.SaveChanges(); // actually do the deletion

    return NoContent(); // 204 no content
  }
    [HttpPut("{petId}/checkout")] // double check URL
  public IActionResult SellBread(int petId)
  {
    Pet pet = _context.Pets.SingleOrDefault(pet => pet.Id == petId);
    pet.CheckedInAtReset();
    _context.Pets.Update(pet);
    _context.SaveChanges();
    return Ok(pet);
  }
   // routes go here
}