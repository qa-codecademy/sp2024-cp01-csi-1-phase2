namespace FenixCoin.Shared
{
    public class OurResponse
    {
        public string Message { get; set; }
        public OurResponse(string message)
        {
            Message = message;
        }
    }
}
