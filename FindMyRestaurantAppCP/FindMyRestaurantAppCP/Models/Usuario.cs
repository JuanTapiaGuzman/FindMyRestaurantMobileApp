using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyRestaurantAppCP.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int IdTransporte { get; set; }
    }
}
