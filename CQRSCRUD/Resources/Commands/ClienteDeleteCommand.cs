using CQRSCRUD.Models;
using MediatR;

namespace CQRSCRUD.Resources.Commands
{
    public class ClienteDeleteCommand : IRequest<Cliente>
    {
        public int Id { get; set; }
    }
}
