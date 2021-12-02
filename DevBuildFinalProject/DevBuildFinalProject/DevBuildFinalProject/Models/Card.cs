using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildFinalProject.Models
{
    public class Card
    {
        public int ID { get; set; }
        public string CardName { get; set; }
        public int Cost { get; set; }
        public string Info { get; set; }
        public int Modifier { get; set; }
        public string CardType { get; set; }
    }
}
