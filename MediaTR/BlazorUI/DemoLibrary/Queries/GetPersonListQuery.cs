using DemoLibrary.DataAccess;
using DemoLibrary.Model;
using MediatR;

namespace DemoLibrary.Queries
{
    public record GetPersonListQuery() : IRequest<List<PersonModel>>;
}