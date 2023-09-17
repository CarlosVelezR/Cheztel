using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cheztel.Models
{
    public class EditarHabitacionViewModel : Habitacion
    {

        public IEnumerable<SelectListItem> Hoteles { get; set; }
        public IEnumerable<SelectListItem> Acomodaciones { get; set; }

    }
}
