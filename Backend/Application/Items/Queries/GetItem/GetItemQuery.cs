using AutoMapper;
using MediatR;
using QaR.Finder.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace QaR.Finder.Application.Items.Queries.GetItem
{
    public class GetItemQuery : IRequest<ItemDTO>
    {
        public int ItemId { get; set; }
    }

    public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetItemQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemDTO> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Items.FindAsync(request.ItemId);
            var vm = _mapper.Map<ItemDTO>(entity);

            return await Task.FromResult(vm);
        }
    }
}
