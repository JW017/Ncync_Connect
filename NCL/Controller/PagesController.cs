using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NCL.Data;
using NCL.Shared.Entities;
using Page = NCL.Shared.Entities.Page;

namespace NCL.Controller
{
    [Route("api/Pages")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly DataContext _context;

        public PagesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("/api/Pages/GetPage")]
        public async Task<ActionResult<List<Page>>> GetPage()
        {
            return await _context.Pages.OrderBy(i => i.Page__SequenceNo).ToListAsync();
        }



        [HttpPost("/api/Pages/AddPages")]
        public async Task<ActionResult<Page>> AddPages( Page addNewPage)
        {
            _context.Pages.Add(addNewPage);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                System.Diagnostics.Debug.Print(ex.Message.ToString());
            }
            return Ok(addNewPage);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Page>> GetPagesByID(int ID)
        {
            var result = await _context.Pages.FindAsync(ID);
            if (result == null)
            {
                return Ok("Page not found");
            }
            return Ok(result);
        }

        [HttpPut("/api/Pages/UpdatePageByID/{ID}")]
        public async Task<ActionResult<Page>> UpdatePageByID(int ID, Page updatedPage)
        {
            var Pages = await _context.Pages.FindAsync(ID);
            if (Pages == null)
            {
                return Ok("Video not found");
            }
            Pages.Page__Name = updatedPage.Page__Name;
            Pages.Page__SecondName = updatedPage.Page__SecondName;
            Pages.Page__SequenceNo = updatedPage.Page__SequenceNo;
            Pages.Page__FolderPathName = Pages.Page__FolderPathName;

            await _context.SaveChangesAsync();

            return Ok(Pages);
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeletePagesByID(int ID)
        {

            var result = await _context.Pages.FindAsync(ID);
            if (result == null)
            {
                return Ok("Page not found");
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(result);

        }

    }
}
