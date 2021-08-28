using CQRSCRUD.Database;
using CQRSCRUD.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSCRUD.Resources.Commands
{
    public class ClienteCreateCommandHandler : IRequestHandler<ClienteCreateCommand, Cliente>
    {
        private readonly CQRSCRUDContext _context;

        public ClienteCreateCommandHandler(CQRSCRUDContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Handle(ClienteCreateCommand request, CancellationToken cancellationToken)
        {
            var Cliente = new Cliente();
            Cliente.RazaoSocial = request.RazaoSocial;
            Cliente.CNPJ = request.CNPJ;
            Cliente.DataCadastramento = request.DataCadastramento;
            _context.Cliente.Add(Cliente);
            await _context.SaveChangesAsync();
            return Cliente;
        }
    }
}
