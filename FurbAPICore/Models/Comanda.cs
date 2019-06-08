using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurbAPICore.Models
{
    public class Comanda
    {

        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        public string Produtos { get; set; }

        public decimal ValorTotal { get; set; }

    }
}
