using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Galytix.Api.Model.Entities;
using Galytix.Api.Model.Web;

namespace Galytix.Api.Model.Profiles;

[ExcludeFromCodeCoverage]
public class AverageGwpProfile : Profile
{
    public AverageGwpProfile()
    {
        CreateMap<GetAverageGwpRequest, AverageGwpQuery>();
    }
}