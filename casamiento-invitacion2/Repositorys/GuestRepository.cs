using casamiento_invitacion2.Data;
using casamiento_invitacion2.Interfaces;
using casamiento_invitacion2.Models;
using Microsoft.EntityFrameworkCore;

namespace casamiento_invitacion2.Repositorys
{
    public class GuestRepository : IRepository<Guest>
    {
        private readonly DataContext Context;

        public GuestRepository(DataContext context)
        {
            Context = context;
        }

        public async Task<string> Add(Guest guest)
        {
            await Context.Guests.AddAsync(guest);
            await Context.SaveChangesAsync();
            return guest.Name;
        }

        public async Task<List<Guest>> GetMany()
        {
            List<Guest> guests = await Context.Guests.ToListAsync();
            return guests;
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
