using AutoMapper;
using QaR.Finder.Application.Mappings;
using QaR.Finder.Domain.Entities;

namespace QaR.Finder.Application.Items.Queries.GetItem
{
    public class ItemDTO : IMapFrom<Item>
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Item, ItemDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Text, opt => opt.MapFrom(s => s.Text))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));
        }
    }
}