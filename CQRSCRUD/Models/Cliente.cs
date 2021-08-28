using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSCRUD.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [StringLength(80, MinimumLength = 4)]
        public string RazaoSocial { get; set; }
        [StringLength(18, MinimumLength = 14)]
        public string CNPJ { get; set; }
        public DateTime DataCadastramento { get; set; }
    }
}
