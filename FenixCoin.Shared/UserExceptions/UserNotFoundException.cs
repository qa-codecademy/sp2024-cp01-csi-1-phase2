namespace FenixCoin.Shared.UserExceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message) { }
    }
}
