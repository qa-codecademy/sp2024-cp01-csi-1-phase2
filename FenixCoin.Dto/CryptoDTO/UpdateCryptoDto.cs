﻿namespace FenixCoin.Dto.CryptoDTO
{
    public class UpdateCryptoDto
    {
        public int Id { get; set; }
        public string CryptoName { get; set; }
        public decimal CryptoValueInUSD { get; set; }
        public string ShortName { get; set; }
    }
}
