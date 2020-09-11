using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Models
{
    public class Fixture
    {
        public int ID { get; set; }
        public int LocalTeamID { get; set; }
        public int VisitorTeamID { get; set; }
        public DateTime Time { get; set; }
    }
}
