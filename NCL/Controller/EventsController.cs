using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NCL.Data;
using NCL.Migrations;
using NCL.Shared.Entities;
using System.Linq;
using Event = NCL.Shared.Entities.Event;

namespace NCL.Controller
{
    [Route("api/Events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly DataContext _context;

        public EventsController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("/api/Events/GetEvent")]
        public async Task<ActionResult<List<Event>>> GetEvent()
        {
            return await _context.Events.OrderBy(i => i.Event__SequenceNo).ToListAsync();
        }

        [HttpGet("/api/Events/GetEventOnce")]
        public async Task<ActionResult<List<Event>>> GetEventOnce()
        {
            // Filter the events based on the eventType parameter
            var query = _context.Events.AsQueryable();

            // Fetch the results
            var events = await query.OrderBy(i => i.Event__SequenceNo).ToListAsync();

            // Remove duplicates based on the EventName property (or any other property)
            var distinctEvents = events.DistinctBy(e => e.Event__FolderPathName).ToList();

            return Ok(distinctEvents);
        }

        [HttpPost("/api/Events/AddEvents")]
        public async Task<ActionResult<Event>> AddEvents(Event addNewEvent)
        {
            addNewEvent.Class = await _context.Classes.FindAsync(addNewEvent.Event_Class__ID);
            _context.Events.Add(addNewEvent);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                System.Diagnostics.Debug.Print(ex.Message.ToString());
            }
            return Ok(addNewEvent);
        }

        [HttpPost("/api/Events/AddEventsByID")]
        public async Task<ActionResult<Event>> AddEventsByID(Event addNewEventByID)
        {
            addNewEventByID.Class = await _context.Classes.FindAsync(addNewEventByID.Event_Class__ID);
            addNewEventByID.Event__ID = 0;
            _context.Events.Add(addNewEventByID);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message.ToString());
            }
            return Ok(addNewEventByID);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Event>> GetEventsByID(int ID)
        {
            var result = await _context.Events.FindAsync(ID);
            if (result == null)
            {
                return Ok("Event not found");
            }
            return Ok(result);
        }

        [HttpPut("/api/Events/UpdateEventByID/{ID}")]
        public async Task<ActionResult<Event>> UpdateEventByID(int ID, Event updatedEvent)
        {
            var Events = await _context.Events.FindAsync(ID);
            if (Events == null)
            {
                return Ok("Event not found");
            }
            Events.Event__Title = updatedEvent.Event__Title;
            Events.Event__Description = updatedEvent.Event__Description;
            Events.Event__SequenceNo = updatedEvent.Event__SequenceNo;

            Events.Event__FileSequenceNo = updatedEvent.Event__FileSequenceNo;
            Events.Event__FileDescription = updatedEvent.Event__FileDescription;
            Events.Event__FilePath = updatedEvent.Event__FilePath;
            Events.Event__Thumbnail = updatedEvent.Event__Thumbnail;
            Events.Event__FileType = updatedEvent.Event__FileType;

            Events.Event_Class__ID = updatedEvent.Event_Class__ID;

            await _context.SaveChangesAsync();

            return Ok(Events);
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteEventsByID(int ID)
        {

            var result = await _context.Events.FindAsync(ID);
            if (result == null)
            {
                return Ok("Event not found");
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(result);

        }

    }
}
