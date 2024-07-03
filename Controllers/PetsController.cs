using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
  // [HttpPost]
  // public IActionResult CreatePet([FromBody] Pet newPet)
  // {
  //   _context.Pets.Add(newPet);
  //   _context.SaveChanges();
  //   return Created($"/api/pets/{newPet.id}", newPet); 
  // }

  [HttpPost]
  public ActionResult AddPet(Pet pet)
  {
    _context.Pets.Add(pet);
    _context.SaveChanges();
    Pet CreatedPet = _context.Pets.OrderByDescending(p => p.id).Include(p => p.petOwner).FirstOrDefault();
    return CreatedAtAction(nameof(GetPetById), new { Id = pet.id }, CreatedPet);
  }
   // PUT /{id}
  [HttpPut("{petId}")]
  public IActionResult UpdatePetsById(int petId, [FromBody] Pet newPet)
  {
    Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == petId);
    if (pet == null) return NotFound();

    pet.name = newPet.name;
    pet.petBreed = newPet.petBreed;
    pet.petColor = newPet.petColor;
    pet.checkedInAt = newPet.checkedInAt;


    _context.Pets.Update(pet);
    _context.SaveChanges();

    return Ok(pet);
  }

    // DELETE /{id}
  [HttpDelete("{petId}")]
  public IActionResult DeletePetById(int petId)
  {
    Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == petId);
    if (pet == null) return NotFound(); // 404 response

    _context.Pets.Remove(pet); // queue a delete of this bread
    _context.SaveChanges(); // actually do the deletion

    return NoContent(); // 204 no content
  }
    [HttpPut("{petId}/checkin")]
        public IActionResult CheckIn(int petId)
        {
            Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == petId);
            if (pet == null)
            {
                return NotFound();
            }

            pet.CheckedInAtSet(); // Set current time as checked-in time
            _context.Pets.Update(pet);
            _context.SaveChanges();

            return Ok(pet);
        }
    [HttpPut("{petId}/checkout")]
        public IActionResult CheckOut(int petId)
        {
            Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == petId);
            if (pet == null)
            {
                return NotFound();
            }

            pet.CheckedInAtReset(); // Reset checked-in time to null
            _context.Pets.Update(pet);
            _context.SaveChanges();

            return Ok(pet);
        }
   // routes go here
}