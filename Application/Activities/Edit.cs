using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest                         //dato che stiamo inserendo qualcosa utilizziamo command
        {
            public Activity Activity { get; set; }
        }



        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);        //Prendiamo l'attivita dal database con l'id

                _mapper.Map(request.Activity, activity);                                        //Usiamo l'automapper per aggiornare la proprieta dentro l'attivita

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}