using AutoMapper;
using Span.Culturio.Core.Models.CultureObject;
using Span.Culturio.CultureObjects.Data.Entities.CultureObject;

namespace Span.Culturio.CultureObjects.Profiles
{
    public class CultureObjectProfile : Profile
    {
        public CultureObjectProfile()
        {
            CreateMap<CreateCultureObjectDto, CultureObject>();
            CreateMap<CultureObjectDto, CultureObject>();
            CreateMap<CultureObject, CultureObjectDto>();
        }
    }
}
