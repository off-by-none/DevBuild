using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab151_ConsumingAPI.Models
{
    public class Hand
    {
        public CardData[] Cards { get; set; }
    }

    public class CardData
    {
        public string Image { get; set; }
        public string Value { get; set; }
        public string Suit { get; set; }
    }
}