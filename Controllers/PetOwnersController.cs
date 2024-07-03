using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_hotel.Models;

namespace pet_hotel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetOwnersController : ControllerBase
{
   private readonly ApplicationContext _context;
   public PetOwnersController(ApplicationContext context)
   {
      _context = context;
   }

[HttpGet]
public IEnumerable<PetOwner> GetPetOwners()
{
   return _context.PetOwners.Include(PetOwner => PetOwner.Pets).ToList();
}

[HttpGet("{PetOwnerId}")]
public IActionResult GetOwnerById(int PetOwnerId)
{
   PetOwner petOwner = _context.PetOwners.Include(p => p.Pets).SingleOrDefault(petOwner => petOwner.Id == PetOwnerId);
   if (petOwner == null)
   {
      return NotFound();
   }
   return Ok(petOwner);
}

[HttpPost]
public IActionResult CreatePetOwner([FromBody] PetOwner newPetOwner) {
   _context.PetOwners.Add(newPetOwner);
   _context.SaveChanges();
   return CreatedAtAction("/", new { Id = newPetOwner.Id }, newPetOwner);
}

[HttpDelete("{PetOwnerId}")]
public IActionResult DeletePetOwnerById(int PetOwnerId)
{
   PetOwner petOwner = _context.PetOwners.SingleOrDefault(petOwner => petOwner.Id == PetOwnerId);
   if (petOwner == null) return NotFound();

   _context.PetOwners.Remove(petOwner);
   _context.SaveChanges();

   return NoContent();
}  

[HttpPut("{petOwnerId}")]
public IActionResult UpdatePetOwnerById(int petOwnerId, [FromBody] PetOwner updatedPetOwner)
{
   PetOwner petOwner = _context.PetOwners.SingleOrDefault(petOwner => petOwner.Id == petOwnerId);
   if (petOwner ==null) return NotFound();

   petOwner.Name = updatedPetOwner.Name;

   _context.PetOwners.Update(petOwner);
   _context.SaveChanges();
   
   return Ok(petOwner);
}

}