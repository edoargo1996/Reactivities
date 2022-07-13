using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]       //Identifica un'azione che contiene un metodo HTTP GET
        public async Task<ActionResult<List<Activity>>> GetActivities(){        //Con questo metodo facciamo vedere al client una lista delle attivita presenti nel database
            return await _context.Activities.ToListAsync();
        }


        [HttpGet("{id}")]       

        public async Task<ActionResult<Activity>> GetActivity(Guid id){         //Inserendo l'id gli chiediamo l'attivita' che ci interessa
            return await _context.Activities.FindAsync(id);
        }

    }
}