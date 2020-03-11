using System;

namespace HeistPart2
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= SkillLevel;
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the security guards!");
            }
            else
            {
                Console.WriteLine($"{Name} is holding off the security guards. Decreased the security guards's defense by {SkillLevel} points");
            }
        }

        public override string ToString()
        {
            return $"{Name}'s the muscle of the job with a skill level of {SkillLevel} and want's a {PercentageCut}% cut of the take.";
        }
    }
}