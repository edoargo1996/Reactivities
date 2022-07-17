using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class ActivitiesController : BaseApiController                       //Utilizzando i mediator rendiamo le chiamate al database clientside
    {

        [HttpGet]                                                               //Identifica un'azione che contiene un metodo HTTP GET
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {                                                                       //Con questo metodo facciamo vedere al client una lista delle attivita presenti nel database
            return await Mediator.Send(new List.Query());                       //Avremo la risposta dal nostro mediator
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {                                                                       //Inserendo l'id gli chiediamo l'attivita' che ci interessa
            return await Mediator.Send(new Details.Query{Id=id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity){     //Creare un'attivita
            return Ok(await Mediator.Send(new Create.Command{Activity=activity}));
        }

        [HttpPut("{id}")]                                                        //Per fare l'update si usa httpu endpoint
        public async Task<IActionResult> EditActivity(Guid id, Activity activity){       //Modificare un'attivita
            activity.Id=id;
            return Ok(await Mediator.Send(new Edit.Command{Activity=activity}));
        }

        [HttpDelete("{id}")]                                                        //Per fare l'update si usa httpu endpoint
        public async Task<IActionResult> DeleteActivity(Guid id){               //Eliminare un'attivita
            return Ok(await Mediator.Send(new Delete.Command{Id=id}));
        }


    }
}