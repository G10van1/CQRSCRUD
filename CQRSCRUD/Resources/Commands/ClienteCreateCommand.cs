using CQRSCRUD.Models;
using MediatR;
using System;

namespace CQRSCRUD.Resources.Commands
{
    public class ClienteCreateCommand : IRequest<Cliente>
    {       
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataCadastramento { get; set; }
    }
}
