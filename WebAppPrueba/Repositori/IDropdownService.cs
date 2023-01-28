using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppPrueba.Repositori
{
    public interface IDropdownService
    {
        List<SelectListItem> ListofClient(char idClient);
        List<SelectListItem> ListofOperario(char idOperario);
        

    }
}
