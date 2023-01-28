using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAppPrueba.ViewModel
{
    public class DropdownViewModel
    {
        [Required(ErrorMessage = "Id Cliente Requerido")]
        public string idClient { get; set; }
        public List<SelectListItem> ListofClientes { get; set; }

        [Required(ErrorMessage = "Operario es requerido")]
        public string idOperario { get; set; }
        public List<SelectListItem> ListofOperarios { get; set; }
    }
}
