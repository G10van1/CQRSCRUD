using CQRSCRUD.Database;
using CQRSCRUD.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSCRUD.Resources.Commands
{
    public class ClienteDeleteCommandHandler : IRequestHandler<ClienteDeleteCommand, Cliente>
    {
        private readonly CQRSCRUDContext _context;

        public ClienteDeleteCommandHandler(CQRSCRUDContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Handle(ClienteDeleteCommand request, CancellationToken cancellationToken)
        {
            var Cliente = await _context.Cliente.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.Remove(Cliente);
            await _context.SaveChangesAsync();
            return Cliente;
        }
    }
}
