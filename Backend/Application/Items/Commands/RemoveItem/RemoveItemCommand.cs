using MediatR;
using QaR.Finder.Application.Common.Exceptions;
using QaR.Finder.Application.Common.Interfaces;
using QaR.Finder.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace QaR.Finder.Application.Items.Commands.AddItem
{
    public class RemoveItemCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public RemoveItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Items.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Item), request.Id);
            }

            _context.Items.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
