namespace FenixCoin.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }


        // Foreign Key Properties
        public virtual Wallet Wallet { get; set; }
        public virtual List<Trade> TradeHistory { get; set; } = new List<Trade>();
    }
}
