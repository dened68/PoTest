namespace TestPO.Model
{
    public interface IDadata
    {
        public  Task<List<ClearResponse>> ClearRequest(string rawAdress);
    }
}
