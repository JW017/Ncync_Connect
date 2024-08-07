using BlazorBootstrap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NCL.Data;
using NCL.Shared.Entities;
using System;
using System.Diagnostics;

namespace NCL.Controller
{
    [Route("api/Visitors")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly DataContext _context;

        public GuestsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Visitor>>> GetVisitors()
        {
            return await _context.Visitors.ToListAsync();
        }


        [HttpGet("{ID}")]
        public async Task<ActionResult<Visitor>> GetVisitorsByID(int ID)
        {
            var result = await _context.Visitors.FindAsync(ID);
            if (result == null)
            {
                return NotFound("Visitor not found");
            }
            return Ok(result);
        }


        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteVisitorsByID(int ID)
        {

            var result = await _context.Visitors.FindAsync(ID);
            if (result == null)
            {
                return Ok("Visitor not found");
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(result);
        }


        [HttpPut("{ID}")]
        public async Task<ActionResult<Visitor>> UpdateVisitorsByID(int ID, Visitor updatedVisitor)
        {
            var Visitors = await _context.Visitors.FindAsync(ID);
            if (Visitors == null)
            {
                return Ok("Visitor not found");
            }
            Visitors.Visitor__Name = updatedVisitor.Visitor__Name;
            Visitors.Visitor__Contact = updatedVisitor.Visitor__Contact;

            await _context.SaveChangesAsync();
            return Ok(Visitors);
        }

        [HttpPost("/api/Visitors/AddVisitors")]
        public async Task<ActionResult<Visitor>> AddVisitors(Visitor addNewVisitor)
        {
            _context.Add(addNewVisitor);
            await _context.SaveChangesAsync();

            return Ok(addNewVisitor);
        }


        // VisitorActivity Controller

        [HttpGet("/api/Visitors/GetVisitorActivities")]
        public async Task<ActionResult<List<VisitorActivity>>> GetVisitorActivity()
        {
            return await _context.VisitorActivities.ToListAsync();
        }

        [HttpGet("/api/Visitors/GetVisitorActivityByID/{ID}")]
        public async Task<ActionResult<VisitorActivity>> GetVisitorActivityByID(int ID)
        {
            var result = await _context.VisitorActivities.FindAsync(ID);
            if (result == null)
            {
                return NotFound("Visitor Activity not found");
            }
            return Ok(result);
        }


        [HttpDelete("/api/Visitors/DeleteVisitorActivityByID/{ID}")]
        public async Task<IActionResult> DeleteVisitorActivityByID(int ID)
        {

            var result = await _context.VisitorActivities.FindAsync(ID);
            if (result == null)
            {
                return Ok("Visitor Activity not found");
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(result);
        }

        [HttpPost("/api/Visitors/AddVisitorActivities")]
        public async Task<ActionResult<VisitorActivity>> AddVisitorActivity(VisitorActivity addNewVisitorActivity)
        {
            addNewVisitorActivity.VisitorActivity__DateTime = DateTime.Now;
            _context.Add(addNewVisitorActivity);
            await _context.SaveChangesAsync();

            return Ok(addNewVisitorActivity);
        }

        [HttpPut("/api/Visitors/UpdateVisitorActivitiesByID/{ID}")]
        public async Task<ActionResult<VisitorActivity>> UpdateVisitorActivitiesByID(int ID, VisitorActivity updatedVisitorActivity)
        {
            var Activities = await _context.VisitorActivities.FindAsync(ID);
            if (Activities == null)
            {
                return Ok("Visitor Activity not found");
            }
            Activities.VisitorActivity__DateTime = updatedVisitorActivity.VisitorActivity__DateTime;
            Activities.LocationLocation__ID = updatedVisitorActivity.LocationLocation__ID;

            await _context.SaveChangesAsync();

            return Ok(Activities);
        }

    }
}
