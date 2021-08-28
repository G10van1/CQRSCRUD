using CQRSCRUD.Database;
using CQRSCRUD.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSCRUD.Resources.Queries
{
    public class GetClientePorIdQueryHandler : IRequestHandler<GetClientePorIdQuery, Cliente>
    {
        private readonly CQRSCRUDContext _context;

        public GetClientePorIdQueryHandler(CQRSCRUDContext context)
        {
            _context = context;
        }
        public async Task<Cliente> Handle(GetClientePorIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Cliente.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
