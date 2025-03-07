using Microsoft.AspNetCore.Mvc;
using TestUdv.API.DTO;
using TestUdv.Core.Interfaces;

namespace TestUdv.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NoteController(INoteService noteService) : ControllerBase
    {
        private readonly INoteService _noteService = noteService;

        [HttpPost("[action]")]
        public async Task<ActionResult<NoteResponse>> CreateNote(NoteRequest request)
        {
            var result = await _noteService.CreateNote(request.OwnerId, request.AccessToken);

            var response = new NoteResponse(result.OwnerId, result.Occurrence);

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<NoteResponse>> AllNotes()
        {
            var result = await _noteService.GetAllNotes();

            var response = result.Select(n => new NoteResponse(n.OwnerId, n.Occurrence)).ToList();

            return Ok(response);
        }
    }
}
