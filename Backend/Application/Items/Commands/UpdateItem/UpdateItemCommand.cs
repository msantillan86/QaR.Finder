using MediatR;
using QaR.Finder.Application.Common.Exceptions;
using QaR.Finder.Application.Common.Interfaces;
using QaR.Finder.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace QaR.Finder.Application.Items.Commands.AddItem
{
    public class UpdateItemCommand : IRequest
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Items.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Item), request.Id);
            }

            entity.Text = request.Text;
            entity.Description = request.Description;

            //_context.Items.Update(entity); //no se si es necesario, probar

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
