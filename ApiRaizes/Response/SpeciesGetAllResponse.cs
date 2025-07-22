using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Response
{
    public class SpeciesGetAllResponse
    {
        public IEnumerable<SpeciesEntity> Data { get; set; }
    }
}
