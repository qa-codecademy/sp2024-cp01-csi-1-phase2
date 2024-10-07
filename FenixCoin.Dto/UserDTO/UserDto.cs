using FenixCoin.Dto.TradeDTO;
using FenixCoin.Dto.WalletDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FenixCoin.Dto.UserDTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public WalletDto Wallet { get; set; }
        public List<TradeDto> TradeHistory { get; set; } = new List<TradeDto>();
    }
}
