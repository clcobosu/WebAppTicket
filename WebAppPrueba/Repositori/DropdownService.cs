using WebAppPrueba.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppPrueba.Repositori
{
    public class DropdownService : IDropdownService
    {
        private readonly ApplicationDbContext _context;

        public DropdownService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> ListofClient(char idClient)
        {
            try
            {
                var listofClientes = (from xcliente in _context.Client.AsNoTracking()
                                       select new SelectListItem()
                                       {
                                           Text = xcliente.IdClient,
                                           Value = xcliente.IdClient.ToString()
                                       }
                    ).ToList();

                listofClientes.Insert(0, new SelectListItem()
                {
                    Value = "",
                    Text = "---Select---"
                });

                return listofClientes;
            }
            catch (Exception)
            { 
                throw;
            }

            
        }

        public List<SelectListItem> ListofOperario(char idOperario)
        {
            try
            {

                var listofOperarios = (from xOperario in _context.Operario.AsNoTracking()
                                      select new SelectListItem()
                                      {
                                          Text = xOperario.IdOperario,
                                          Value = xOperario.IdOperario.ToString()
                                      }
                   ).ToList();

                listofOperarios.Insert(0, new SelectListItem()
                {
                    Value = "",
                    Text = "---Select---"
                });

                return listofOperarios;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
