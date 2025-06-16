using DemoLibrary.Context;
using DemoLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoLibrary.DataAccess
{
    public class EfDataAccess : IDataAccess
    {
        private readonly DemoDbContext _context;

        public EfDataAccess(DemoDbContext context)
        {
            _context = context;
        }

        public List<PersonModel> GetPeople()
        {
            return _context.Personas.ToList();
        }
    }
}