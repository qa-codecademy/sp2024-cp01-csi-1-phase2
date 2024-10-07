using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FenixCoin.Shared.CryptoExceptions
{
    public class CryptoNotFoundException : Exception
    {
        public CryptoNotFoundException(string message) : base(message) { }
    }
}
