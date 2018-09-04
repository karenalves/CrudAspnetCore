using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspnetCore.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar Nome do Funcionário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor informar Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Favor informar Cpf")]
        public string Cpf { get; set; }

        public Endereco Endereco { get; set; }

        public Empresa Empresa { get; set; }
    }
}
