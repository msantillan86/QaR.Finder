using QaR.Finder.Application.Items.Queries.GetItem;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using QaR.Finder.Application.Items.Queries.GetItemsQuery;

namespace QaR.Finder.Api.Controllers
{
    public class ItemController : ApiController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ItemDTO> Get(string id)
        {
            return await Mediator.Send(new GetItemQuery { ItemId = id });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<ItemDTO>> List()
        {
            return await Mediator.Send(new GetItemsQuery { });
        }
    }
}