using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspnetCore.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar Rua/AV")]
        [StringLength(100, MinimumLength = 1)]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Favor informar Bairro")]
        [StringLength(100, MinimumLength = 1)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Favor informar Cidade")]
        [StringLength(100, MinimumLength = 1)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Favor informar Estado")]
        [StringLength(100, MinimumLength = 1)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Favor informar Numero")]
        public int Numero { get; set; }

        public string Cep { get; set; }
    }
}
