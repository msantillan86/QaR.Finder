using AutoMapper;
using MediatR;
using QaR.Finder.Application.Common.Interfaces;
using QaR.Finder.Application.Items.Queries.GetItem;
using QaR.Finder.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QaR.Finder.Application.Items.Commands.AddItem
{
    public class AddItemCommand : IRequest<ItemDTO>
    {
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, ItemDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddItemCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemDTO> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Item
                {
                    Description = request.Description,
                    Text = request.Text
                };

                _context.Items.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ItemDTO>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
