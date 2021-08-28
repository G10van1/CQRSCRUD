using CQRSCRUD.Database;
using CQRSCRUD.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSCRUD.Resources.Commands
{
    public class ClienteUpdateCommandHandler : IRequestHandler<ClienteUpdateCommand, Cliente>
    {
        private readonly CQRSCRUDContext _context;

        public ClienteUpdateCommandHandler(CQRSCRUDContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Handle(ClienteUpdateCommand request, CancellationToken cancellationToken)
        {
            var Cliente = _context.Cliente.Where(a => a.Id == request.Id).FirstOrDefault();
            if (Cliente == null)
            {
                return default;
            }
            else
            {
                Cliente.RazaoSocial = request.RazaoSocial;
                Cliente.CNPJ = request.CNPJ;
                Cliente.DataCadastramento = request.DataCadastramento;
                await _context.SaveChangesAsync();
                return Cliente;
            }
        }
    }
}
