using casamiento_invitacion2.Models;
using casamiento_invitacion2.ViewModel;

namespace casamiento_invitacion2.Interfaces
{
    public interface IRepository<T>
    {
        public Task<string> Add(Guest guest_entity);

        public Task<List<Guest>> GetMany();

        public Task Remove(int  id);
    }
}
