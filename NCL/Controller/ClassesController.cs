using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NCL.Data;
using NCL.Migrations;
using NCL.Shared.Entities;
using Class = NCL.Shared.Entities.Class;

namespace NCL.Controller
{
    [Route("api/Classes")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly DataContext _context;

        public ClassesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("/api/Classes/GetClass")]
        public async Task<ActionResult<List<Class>>> GetClass()
        {
            return await _context.Classes.OrderBy(i => i.Class__SequenceNo).ToListAsync();
        }

        [HttpGet("/api/Classes/GetClassByPage")]
        public async Task<ActionResult<List<Class>>> GetClassByPage()
        {
            return await _context.Classes.OrderBy(i => i.Class_Page__ID).ToListAsync();
        }



        [HttpPost("/api/Classes/AddClasses")]
        public async Task<ActionResult<Class>> AddClasses(Class addNewClass)
        {
            addNewClass.Page = await _context.Pages.FindAsync(addNewClass.Class_Page__ID);
            _context.Classes.Add(addNewClass);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                System.Diagnostics.Debug.Print(ex.Message.ToString());
            }
            return Ok(addNewClass);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Class>> GetClassesByID(int ID)
        {
            var result = await _context.Classes.FindAsync(ID);
            if (result == null)
            {
                return Ok("Class not found");
            }
            return Ok(result);
        }

        [HttpPut("/api/Classes/UpdateClassByID/{ID}")]
        public async Task<ActionResult<Class>> UpdateClassByID(int ID, Class updatedClass)
        {
            var Classes = await _context.Classes.FindAsync(ID);
            if (Classes == null)
            {
                return Ok("Class not found");
            }
            Classes.Class__Name = updatedClass.Class__Name;
            Classes.Class__SequenceNo = updatedClass.Class__SequenceNo;
            Classes.Class_Page__ID = updatedClass.Class_Page__ID;

            await _context.SaveChangesAsync();

            return Ok(Classes);
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteClassesByID(int ID)
        {

            var result = await _context.Classes.FindAsync(ID);
            if (result == null)
            {
                return Ok("Class not found");
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(result);

        }

    }
}
