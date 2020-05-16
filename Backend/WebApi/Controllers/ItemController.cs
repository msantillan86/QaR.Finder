using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QaR.Finder.Application.Items.Commands.AddItem;
using QaR.Finder.Application.Items.Queries.GetItem;
using QaR.Finder.Application.Items.Queries.GetItemsQuery;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QaR.Finder.Api.Controllers
{
    //[Authorize]
    public class ItemController : ApiController
    {
        [HttpGet("{id}")]
        public async Task<ItemDTO> Get(int id)
        {
            return await Mediator.Send(new GetItemQuery { ItemId = id });
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDTO>> List()
        {
            return await Mediator.Send(new GetItemsQuery { });
        }

        [HttpPost]
        public async Task<ActionResult<ItemDTO>> Add(AddItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateItemCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await Mediator.Send(new RemoveItemCommand { Id = id });
            return NoContent();
        }
    }
}