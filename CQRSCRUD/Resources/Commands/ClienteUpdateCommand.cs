using CQRSCRUD.Models;
using MediatR;
using System;

namespace CQRSCRUD.Resources.Commands
{
    public class ClienteUpdateCommand : IRequest<Cliente>
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string DataCadastramento { get; set; }
    }
}
