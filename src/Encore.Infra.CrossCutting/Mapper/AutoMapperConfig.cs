using AutoMapper;
using Encore.Application.Forms;
using Encore.Application.Homes;
using Encore.Application.Microregions;
using Encore.Application.Persons;
using Encore.Application.Questions;

namespace Encore.Infra.CrossCutting.Mapper
{
    public static class AutoMapperConfig
    {
        public static Type[] Setup()
        {
            var profiles = RegisterMappings();
            return profiles.Select(c => c.GetType()).Distinct().ToArray();
        }

        public static IEnumerable<Profile> RegisterMappings()
        {
            yield return new HomeMappingProfile();
            yield return new PersonMappingProfile();
            yield return new MicroregionMappingProfile();
            yield return new QuestionMappingProfile();
            yield return new FormMappingProfile();
        }
    }
}
