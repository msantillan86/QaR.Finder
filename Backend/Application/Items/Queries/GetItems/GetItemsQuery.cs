using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QaR.Finder.Application.Common.Interfaces;
using QaR.Finder.Application.Items.Queries.GetItem;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QaR.Finder.Application.Items.Queries.GetItemsQuery
{
    public class GetItemsQuery : IRequest<IEnumerable<ItemDTO>> { }

    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IEnumerable<ItemDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDTO>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Items
                .ProjectTo<ItemDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            

            return await Task.FromResult(entity);
        }
    }
}
