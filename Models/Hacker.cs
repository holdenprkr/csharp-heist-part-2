using System;

namespace HeistPart2
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;
            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
            else
            {
                Console.WriteLine($"{Name} is hacking the alarm system. Decreased security by {SkillLevel} points");
            }
        }
    }
}