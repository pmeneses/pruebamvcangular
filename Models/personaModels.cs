using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pruebamvc.Models
{
    
    public partial class personaModels
    {
        public int id { get; set; }
         [Required(ErrorMessage = "Ingrese el nombre de la persona")]
         public string nombre { get; set; }
         [Required(ErrorMessage = "Ingrese los apellidos de la persona")]
         public string apellidos { get; set; }
         public string telefono { get; set; }
    }
}