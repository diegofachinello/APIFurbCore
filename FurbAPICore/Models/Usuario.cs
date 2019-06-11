using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurbAPICore.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

    }

   /* public class UserAuth : Usuario
    {
        public string Token { get; set; }
    }
    */
}
