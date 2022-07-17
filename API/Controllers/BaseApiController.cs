using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]     //controller viene sostituito con qualsiasi sia la classe controller che utilizziamo
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;        //rendo disponibile il mediator in ogni controller derivante dal BaseApiController

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();   //??= vuol dire che se e' null gli assegnamo questo valore, in questo caso gli passiam il servizio Imediator()

    }
}