using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRpg.Services.CharacterService.Model
{
    public class Character
    {
        public int Id { get; set; }
        public string Job { get; set; } = "Fighter";
        public int HealthPoints { get; set; }
        public int TotalHealthPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Agility { get; set; }
        public int SkillPoints { get; set; }
        public int TotalSkillPoints { get; set; }
    }
}
