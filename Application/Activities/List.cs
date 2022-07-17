using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }                   //Stiamo ritornando una lista
        public class Handler : IRequestHandler<Query, List<Activity>>       //Handler della richiesta
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }

            public DataContext Context { get; }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)        //Metodo per ritornare la nostra lista
            {
                return await _context.Activities.ToListAsync();
            }
        }
    }
}