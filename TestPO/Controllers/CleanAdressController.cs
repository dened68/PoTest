using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using TestPO.Model;

namespace TestPO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CleanAdressController : ControllerBase
    {
        

        private readonly ILogger<CleanAdressController> _logger;
        private readonly IService _service;

        public CleanAdressController(ILogger<CleanAdressController> logger, IService serviceProvider)
        {
            _logger = logger;
            _service = serviceProvider;
        }
                

        [HttpGet(Name = "CleanAdress")]
        public async Task<Adress> GET( string rawAdres)
        {


            
            return await _service.AddressService(rawAdres);
        }
    }

    

}