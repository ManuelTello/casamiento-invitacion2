using System.ComponentModel.DataAnnotations;

namespace casamiento_invitacion2.ViewModel
{
    public class GuestViewModel
    {
        [Required(ErrorMessage = "* Nombre requerido")]
        [Display(Name="Nombre")]
        public string Name { get; set; }

        [Display(Name="E-Mail")]
        public string Email { get; set; }

        [Display(Name="Numero de telfono")]
        public int PhoneNumber { get; set; }

        public DateTime DateSigned { get; set; }
    }
}
