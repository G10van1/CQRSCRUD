using CQRSCRUD.Models;
using MediatR;
using System.Collections.Generic;

namespace CQRSCRUD.Resources.Queries
{
    public class GetTodosClientesQuery : IRequest<IEnumerable<Cliente>>
    {
    }
}

