using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspnetCore.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar Nome Fantasia")]
        [StringLength(60, MinimumLength = 1)]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Favor informar Razão Social")]
        [StringLength(60, MinimumLength = 1)]
        public string RazaoSocial { get; set; }

        public string Cnpj { get; set; }

        public Endereco Endereco { get; set; }
    }
}
