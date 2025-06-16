using DemoLibrary.Context;
using DemoLibrary.DataAccess;
using DemoLibrary.Model;
using DemoLibrary.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace DemoLibrary.Handlers;

public class GetPersonListQueryHandler : IRequestHandler<GetPersonListQuery, List<PersonModel>>
{
    private readonly DemoDbContext _context;

    public GetPersonListQueryHandler(DemoDbContext context)
    {
        _context = context;
    }

    public async Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Personas.ToListAsync(cancellationToken);
    }
}