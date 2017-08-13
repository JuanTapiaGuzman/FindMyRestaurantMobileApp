using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMyRestaurantAppCP.Models
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipoRestaurante { get; set; }
        public int IdRangoPrecio { get; set; }
        public string Direccion { get; set; }
        public int IdCiudad { get; set; }
        public string Telefono { get; set; }
        public string LatitudGps { get; set; }
        public string LongitudGps { get; set; }
    }
}