using casamiento_invitacion2.Data;
using casamiento_invitacion2.Interfaces;
using casamiento_invitacion2.Models;
using casamiento_invitacion2.Repositorys;
using casamiento_invitacion2.ViewModel;
using OfficeOpenXml;


namespace casamiento_invitacion2.Services
{
    public class GuestService : IService
    {
        private readonly GuestRepository Repository;
    
        public GuestService(DataContext context)
        {
            Repository = new GuestRepository(context);
        }

        public async Task<GuestAddedViewModel> AddGuest(GuestViewModel form_result)
        {
            Guest guest_entity = new Guest()
            {
                Name = form_result.Name,
                Email = form_result.Email,
                PhoneNumber = form_result.PhoneNumber,
                DateSigned = form_result.DateSigned.ToString()
            };

            string result = await Repository.Add(guest_entity);
            GuestAddedViewModel view_model = new GuestAddedViewModel()
            {
                Name = form_result.Name,    
            };

            return view_model;
        }

        public async Task<MemoryStream> GenerateExcelFile()
        {
            MemoryStream stream = new MemoryStream();
            List<Guest> guests = await Repository.GetMany();
            string[] headers = new string[] { "id","nombre","e-mail","n° telefono","fecha de alta" };

            using ( ExcelPackage p = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = p.Workbook.Worksheets.Add("mysheet");


                for (int i = 1; i < 6; i++)
                {
                    string current = ((char)(64+i)).ToString();

                    worksheet.Cells[$"{current}1"].Style.Font.Bold = true;
                    worksheet.Cells[$"{current}1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[$"{current}1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    worksheet.Cells[$"{current}1"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                }

                for (int i = 1; i < 6; i++)
                    worksheet.Cells[$"{((char)(64 + i)).ToString()}{1}"].Value = headers[i-1];

                for (int i = 0; i < guests.Count; i++)
                {
                    Guest g = guests[i];
                    
                    worksheet.Cells[$"A{i+2}"].Value = g.Id;
                    worksheet.Cells[$"B{i+2}"].Value = g.Name;
                    worksheet.Cells[$"C{i+2}"].Value = g.Email;
                    worksheet.Cells[$"D{i+2}"].Value = g.PhoneNumber;                   
                    worksheet.Cells[$"E{i+2}"].Value = g.DateSigned;
                }

                await p.SaveAsync();
            }

            return stream;
        }

        public async Task<GuestTableViewModel> SetUpTable()
        {
            List<Guest> guests = await Repository.GetMany();
            GuestTableViewModel view_model = new GuestTableViewModel()
            {
                Guests = guests
            };

            return view_model;
        }
    }
}
