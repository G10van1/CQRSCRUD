using CQRSCRUD.Models;
using MediatR;

namespace CQRSCRUD.Resources.Queries
{
    public class GetClientePorIdQuery : IRequest<Cliente>
    {
        public int Id { get; set; }
    }
}
