using CleanArchitectureWithDomainEvents.Domain.Entities;

namespace CleanArchitectureWithDomainEvents.Application.Features.EntityNames.Queries.QueryName;

public class QueryNameMapping : Profile
{
    public QueryNameMapping()
    {
        CreateMap<EntityName, EntityNameDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id.Value));
    }
}
