using CQRSCRUD.Database;
using CQRSCRUD.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSCRUD.Resources.Queries
{
    public class GetTodosClientesQueryHandler : IRequestHandler<GetTodosClientesQuery, IEnumerable<Cliente>>
    {
        private readonly CQRSCRUDContext _context;

        public GetTodosClientesQueryHandler(CQRSCRUDContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> Handle(GetTodosClientesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Cliente.ToListAsync();
        }
    }
}
