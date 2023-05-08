using casamiento_invitacion2.ViewModel;

namespace casamiento_invitacion2.Interfaces
{
    public interface IService
    {
        public Task<GuestTableViewModel> SetUpTable();

        public Task<MemoryStream> GenerateExcelFile();

        public Task<GuestAddedViewModel> AddGuest(GuestViewModel guest);
    }
}
