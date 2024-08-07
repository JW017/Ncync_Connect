using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NCL.Data;
using NCL.Shared.Entities;

namespace NCL.Controller
{
    [Route("api/Locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly DataContext _context;

        public LocationsController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetLocation()
        {
            return await _context.Locations.ToListAsync();
        }


        [HttpPost("/api/Locations/AddLocations")]
        public async Task<ActionResult<Location>> AddLocations([FromBody] Location addNewLocation)
        {
            _context.Locations.Add(addNewLocation);

            try
            {
                await _context.SaveChangesAsync();
            } catch (Exception ex) {
                System.Diagnostics.Debug.Print(ex.Message.ToString());
            }
            return Ok(addNewLocation);
        }

        [HttpDelete("/api/Locations/DeleteLocationsByID/{ID}")]
        public async Task<IActionResult> DeleteLocationsByID(int ID)
        {
            var result = await _context.Locations.FindAsync(ID);
            if (result == null)
            {
                return Ok("Location not found");
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(result);
        }

    }
}
