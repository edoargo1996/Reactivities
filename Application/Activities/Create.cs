using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest                         //dato che stiamo inserendo qualcosa utilizziamo command
        {
            public Activity Activity { get; set; }
        }



        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);      //non serve sia async perche per ora non stiamo ancora inserendo

                await _context.SaveChangesAsync();              //qui stiamo inserendo quindi serve sia async

                return Unit.Value;                              //stiamo dicendo al controller che abbiamo finito
            }
        }
    }
}