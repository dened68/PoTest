using AutoMapper;

namespace TestPO.Model
{
    public class Service : IService
    {
        private readonly IMapper mapper;
        private readonly IDadata _dadata;
        public Service(IDadata dadata) { _dadata = dadata; }
        public  async Task<Adress> AddressService(string rawAdress)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AppMappingProfile>();
                });
                var mapper = config.CreateMapper();

                List<ClearResponse> cleanResponse = await _dadata.ClearRequest(rawAdress);


                Adress adress = mapper.Map<Adress>(cleanResponse[0]);
                return adress;
            }
            catch (Exception ex)
            {
                
                return null;
            }

        }

    }
}
