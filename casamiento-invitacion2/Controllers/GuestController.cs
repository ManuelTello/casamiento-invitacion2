using Microsoft.AspNetCore.Mvc;
using casamiento_invitacion2.ViewModel;
using casamiento_invitacion2.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace casamiento_invitacion2.Controllers
{
    public class GuestController : Controller
    {
        private readonly IService Service;

        public GuestController(IService service)
        {
            Service = service;
        }

        [HttpGet]
        [Route("invitados/formulario")]
        public IActionResult FormFill()
        {
            return View();
        }

        [HttpPost]        
        [Route("invitados/formulario")]
        public async Task<IActionResult> FormResult(GuestViewModel result)
        {
            if(ModelState.IsValid)
            {
                GuestAddedViewModel view_model = await Service.AddGuest(result);
                return View(view_model);
            }
            else
            {
                return RedirectToAction("FormFill");
            }
        }

        [HttpGet]
        [Route("invitados/listado")]
        public async Task<IActionResult> TableRepresentation()
        {
            GuestTableViewModel view_model = await Service.SetUpTable();
            return View(view_model);
        }

        [HttpGet]
        [Route("invitados/archivo")]
        public async Task<IActionResult> SendExcelFile()
        {
            MemoryStream excel_memory = await Service.GenerateExcelFile();
            return File(excel_memory.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "listas_invitados.xlsx");
        }
    }
}
