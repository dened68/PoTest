using AutoMapper;
using Newtonsoft.Json.Linq;
using TestPO.Model;

namespace TestPO
{
    public class AppMappingProfile : Profile 
    {

        public AppMappingProfile()
        {
            CreateMap<ClearResponse, Adress>();
                
        }
    }
}
