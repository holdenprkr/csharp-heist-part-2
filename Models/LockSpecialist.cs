using System;

namespace HeistPart2
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.VaultScore -= SkillLevel;
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has unlocked the vault!");
            }
            else
            {
                Console.WriteLine($"{Name} is picking the lock to the vault. Decreased vault security by {SkillLevel} points");
            }
        }
    }
}