using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NCL.Data;
using NCL.Migrations;
using NCL.Shared.Entities;
using System.Linq;
using Moment = NCL.Shared.Entities.Moment;

namespace NCL.Controller
{
    [Route("api/Moments")]
    [ApiController]

    public class MomentsController : ControllerBase
    {
        private readonly DataContext _context;

        public MomentsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/api/Moments/GetMoment")]
        public async Task<ActionResult<List<Moment>>> GetMoment()
        {
            var result = await _context.Moments.OrderBy(i => i.Moment__DateTime).ToListAsync();
            if (result == null)
            {
                return Ok("Empty Moment");
            }

            return result;
        }

        //[HttpGet("/api/Events/GetMomentOnce")]
        //public async Task<ActionResult<List<Moment>>> GetMomentOnce()
        //{
        //    // Filter the events based on the eventType parameter
        //    var query = _context.Events.AsQueryable();

        //    // Fetch the results
        //    var events = await query.OrderBy(i => i.Event__SequenceNo).ToListAsync();

        //    // Remove duplicates based on the EventName property (or any other property)
        //    var distinctEvents = events.DistinctBy(e => e.Event__FolderPathName).ToList();

        //    return Ok(distinctEvents);
        //}

        [HttpPost("/api/Moments/AddMoments")]
        public async Task<ActionResult<Moment>> AddMoments(Moment addNewMoment)
        {
            addNewMoment.Employee = await _context.Employees.FindAsync(addNewMoment.EmployeeEmployee__ID);
            addNewMoment.Moment__DateTime = DateTime.Now;

            _context.Moments.Add(addNewMoment);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                System.Diagnostics.Debug.Print(ex.Message.ToString());
            }
            return Ok(addNewMoment);
        }

        [HttpPost("/api/Moments/addNewMomentsByID")]
        public async Task<ActionResult<Moment>> AddEventsByID(Moment addNewMomentsByID)
        {
            addNewMomentsByID.Employee = await _context.Employees.FindAsync(addNewMomentsByID.EmployeeEmployee__ID);
            
            _context.Moments.Add(addNewMomentsByID);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message.ToString());
            }
            return Ok(addNewMomentsByID);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Moment>> GetMomentsByID(int ID)
        {
            var result = await _context.Events.FindAsync(ID);
            if (result == null)
            {
                return Ok("Moment not found");
            }
            return Ok(result);
        }

        [HttpPut("/api/Moments/UpdateMomentByID/{ID}")]
        public async Task<ActionResult<Moment>> UpdateMomentByID(int ID, Moment updatedMoment)
        {
            var Momentss = await _context.Moments.FindAsync(ID);
            if (Momentss == null)
            {
                return Ok("Moment not found");
            }

            Momentss.Moment__ID = updatedMoment.Moment__ID;
            Momentss.Moment__Title = updatedMoment.Moment__Title;
            Momentss.Moment__Description = updatedMoment.Moment__Description;
            Momentss.Moment__DateTime = updatedMoment.Moment__DateTime;
            Momentss.Moment__FilePath = updatedMoment.Moment__FilePath;

            Momentss.Moment__Status = updatedMoment.Moment__Status;
            Momentss.EmployeeEmployee__ID = updatedMoment.EmployeeEmployee__ID;

            await _context.SaveChangesAsync();

            return Ok(Momentss);
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteMomentsByID(int ID)
        {
            var result = await _context.Moments.FindAsync(ID);
            if (result == null)
            {
                return Ok("Moments not found");
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(result);

        }

    }
}
