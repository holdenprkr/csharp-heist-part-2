using System;
using System.Collections.Generic;

namespace HeistPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rolodex = new List<IRobber>();

            var Holden = new Hacker()
            {
                Name = "Holden",
                SkillLevel = 80,
                PercentageCut = 40
            };
            var William = new Hacker()
            {
                Name = "William",
                SkillLevel = 65,
                PercentageCut = 33
            };

            var Audrey = new Muscle()
            {
                Name = "Audrey",
                SkillLevel = 70,
                PercentageCut = 40
            };
            var Namita = new Muscle()
            {
                Name = "Namita",
                SkillLevel = 65,
                PercentageCut = 20
            };

            var Kevin = new LockSpecialist()
            {
                Name = "Kevin",
                SkillLevel = 70,
                PercentageCut = 25
            };
            var Taylor = new LockSpecialist()
            {
                Name = "Taylor",
                SkillLevel = 80,
                PercentageCut = 30
            };

            rolodex.Add(Holden);
            rolodex.Add(William);
            rolodex.Add(Audrey);
            rolodex.Add(Namita);
            rolodex.Add(Kevin);
            rolodex.Add(Taylor);

            while (true)
            {
                Console.WriteLine($"There are currently {rolodex.Count} available operatives");
                Console.WriteLine("Enter the name of a new possible crew member or nothing to contine.");
                var newMemberName = Console.ReadLine();
                if (string.IsNullOrEmpty(newMemberName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"What specialty do you want {newMemberName} to have?");
                    Console.WriteLine("Hacker (Disables alarms)");
                    Console.WriteLine("Muscle (Disarms guards)");
                    Console.WriteLine("Lock Specialist (cracks vault)");
                    string newMemberSpecialty;
                    while (true)
                    {
                        newMemberSpecialty = Console.ReadLine().ToLower();

                        if (newMemberSpecialty == "hacker" || newMemberSpecialty == "muscle" || newMemberSpecialty == "lock specialist")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Not a valid entry. Please choose Hacker, Muscle, or Lock Specialist");
                        }
                    }

                    Console.WriteLine($"What is {newMemberName}'s skill level? (1-100)");
                    int newMemberSkillLevel;
                    while (true)
                    {
                        try
                        {
                            newMemberSkillLevel = int.Parse(Console.ReadLine());

                            if (newMemberSkillLevel > 0 && newMemberSkillLevel <= 100)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Not a valid entry. Please enter a skill level between 1-100");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Not a valid entry. Please enter a valid skill level between 1-100");
                        }
                    }

                    Console.WriteLine($"What percentage cut does {newMemberName} want? (1-50)");
                    int newMemberCut;
                    while (true)
                    {
                        try
                        {
                            newMemberCut = int.Parse(Console.ReadLine());

                            if (newMemberCut > 0 && newMemberCut <= 50)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Not a valid input, please choose an integer between 1-50");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Not a valid input, please choose an integer between 1-50");
                        }
                    }

                    if (newMemberSpecialty == "hacker")
                    {
                        Hacker hacker = new Hacker()
                        {
                        Name = $"{newMemberName}",
                        SkillLevel = newMemberSkillLevel,
                        PercentageCut = newMemberCut
                        };

                        rolodex.Add(hacker);
                    }
                    else if (newMemberSpecialty == "muscle")
                    {
                        Muscle muscle = new Muscle()
                        {
                        Name = $"{newMemberName}",
                        SkillLevel = newMemberSkillLevel,
                        PercentageCut = newMemberCut
                        };

                        rolodex.Add(muscle);
                    }
                    else if (newMemberSpecialty == "lock specialist")
                    {
                        LockSpecialist lockSpecialist = new LockSpecialist()
                        {
                        Name = $"{newMemberName}",
                        SkillLevel = newMemberSkillLevel,
                        PercentageCut = newMemberCut
                        };

                        rolodex.Add(lockSpecialist);
                    }
                }
            }
        }
    }
}