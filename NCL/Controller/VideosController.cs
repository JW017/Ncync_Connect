using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NCL.Data;
using NCL.Shared.Entities;

namespace NCL.Controller
{
    [Route("api/Videos")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly DataContext _context;

        public VideosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Video>>> GetVideos()
        {
            return await _context.Videos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Video>> AddVideos(Video addNewVideo)
        {
            _context.Add(addNewVideo);
            await _context.SaveChangesAsync();

            return Ok(addNewVideo);
        }


        [HttpDelete("/api/Videos/DeleteVideoByID/{ID}")]
        public async Task<IActionResult> DeleteVideoByID(int ID)
        {
            var result = await _context.Videos.FindAsync(ID);
            if (result == null)
            {
                return Ok("Video Not Found");
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(result);

        }

        [HttpPut("/api/Videos/UpdateVideoByID/{ID}")]
        public async Task<ActionResult<Video>> UpdateVideoByID(int ID, Video updatedVideo)
        {
            var Videos = await _context.Videos.FindAsync(ID);
            if (Videos == null)
            {
                return Ok("Video not found");
            }
            Videos.Video__Name = updatedVideo.Video__Name;
            Videos.Video__Path = updatedVideo.Video__Path;
            Videos.LocationLocation__ID = updatedVideo.LocationLocation__ID;

            await _context.SaveChangesAsync();

            return Ok(Videos);
        }

    }
}
