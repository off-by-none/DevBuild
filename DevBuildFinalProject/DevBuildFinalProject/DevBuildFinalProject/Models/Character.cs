using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildFinalProject.Models
{
    public class Character
    {
        public int ID { get; set; }
        public string CharName { get; set; }
        public int HP { get; set; }
        public int AP { get; set; }
        public int Progress { get; set; }
        public bool Player { get; set; }

    }
}
