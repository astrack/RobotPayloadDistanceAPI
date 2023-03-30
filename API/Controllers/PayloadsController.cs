using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class PayloadsController : BaseApiController
    {
        private readonly DataContext _context;
        public PayloadsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Payload>>> GetPayloads()
        {
            return await _context.Payloads.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payload>> GetPayload(int id){
            return await _context.Payloads.FindAsync(id);
        }

    }
}