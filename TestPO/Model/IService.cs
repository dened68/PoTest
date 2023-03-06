namespace TestPO.Model
{
    public interface IService
    {
        public  Task<Adress> AddressService(string rawAdress);
    }
}
