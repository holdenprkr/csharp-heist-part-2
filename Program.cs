﻿using System;
using System.Collections.Generic;
using System.Linq;

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
                // Makes the console a bit more user-friendly by adding a break in the terminal
                Console.WriteLine("");

                //Print out how many operatives are in your rolodex
                Console.WriteLine($"There are currently {rolodex.Count} available operatives");

                // Makes the console a bit more user-friendly by adding a break in the terminal
                Console.WriteLine("");

                Console.WriteLine("Enter the name of a new possible crew member or press enter to contine.");
                var newMemberName = Console.ReadLine();
                //break out of while loop if blank name is entered
                if (string.IsNullOrEmpty(newMemberName))
                {
                    break;
                }
                else
                {
                    //Pick new member's specialty
                    Console.WriteLine($"What specialty do you want {newMemberName} to have?");
                    Console.WriteLine("Hacker (Disables alarms)");
                    Console.WriteLine("Muscle (Disarms guards)");
                    Console.WriteLine("Lock Specialist (Cracks vault)");
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

                    //pick new member's skill level
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

                    //new member's percentage cut
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

                    //create new instance off of information you entered
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

            // Randomize variables for bank
            int alarmScore = new Random().Next(0, 101);
            int vaultScore = new Random().Next(0, 101);
            int securityGuardScore = new Random().Next(0, 101);
            int cashOnHand = new Random().Next(50000, 1000001);

            Console.WriteLine($"cashOnHand {cashOnHand}");

            // Create new bank instance and apply randomized variables
            Bank bank = new Bank()
            {
                AlarmScore = alarmScore,
                VaultScore = vaultScore,
                SecurityGuardScore = securityGuardScore,
                CashOnHand = cashOnHand
            };

            // Create dictionary to store randomized scores with corresponding labels
            Dictionary<string, int> scores = new Dictionary<string, int>();
            scores.Add("Alarm", alarmScore);
            scores.Add("Vault", vaultScore);
            scores.Add("Security Guard", securityGuardScore);

            // Order dictionary by ascending score values from lowest to highest
            var ascendingScores = scores.OrderBy(score => score.Value);

            // Store the first KeyValuePair in a variable, being the lowest
            var lowestScore = ascendingScores.First();
            // Store the last KeyValuePair in a variable, being the highest
            var highestScore = ascendingScores.Last();

            Console.WriteLine("-----------------------------------");
            // Console the most secure system
            Console.WriteLine($"Most secure: {highestScore.Key}");
            // Console the least secure system
            Console.WriteLine($"Least secure: {lowestScore.Key}");

            Console.WriteLine("-----------------------------------");

            // Console the index of each robber in your rolodex and their report
            foreach (var robber in rolodex)
            {
                Console.WriteLine($"{rolodex.IndexOf(robber)}: {robber}");
            }

            // Create a new list instance for your crew
            var crew = new List<IRobber>();
            // Set a variable equal to 100 to represent how much percentage of the take is left for new crew members
            int crewCutPercentageLeft = 100;

            while (true)
            {
                try
                {
                    // Makes the console a bit more user-friendly by adding a break in the terminal
                    Console.WriteLine("");

                    Console.WriteLine("Which robber would you like to add to your crew? (Index integer or press enter to continue)");
                    //Check to see if nothing is entered
                    var robberIndexString = Console.ReadLine();
                    if (string.IsNullOrEmpty(robberIndexString))
                    {
                        break;
                    }
                    else
                    {
                        var robberIndex = int.Parse(robberIndexString);

                        if (robberIndex < rolodex.Count || robberIndex >= 0)
                        {
                            //Add member to your crew
                            crew.Add(rolodex[robberIndex]);
                            //Subtract added member's percentage cut from crewCutPercentageLeft
                            crewCutPercentageLeft -= rolodex[robberIndex].PercentageCut;
                            //Remove new crew member from rolodex
                            rolodex.Remove(rolodex[robberIndex]);
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid index integer");
                        }
                    }

                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a valid index integer");
                }
                // Makes the console a bit more user-friendly by adding a break in the terminal
                Console.WriteLine("");
                // Display the securities again for better user experience
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Most secure: {highestScore.Key}");
                Console.WriteLine($"Least secure: {lowestScore.Key}");
                Console.WriteLine("-----------------------------------");

                Console.WriteLine("Robbers available to add to your crew:");
                //  Display who's left you're able to add
                foreach (var robber in rolodex)
                {
                    if (crewCutPercentageLeft - robber.PercentageCut >= 0)
                    {
                        Console.WriteLine($"{rolodex.IndexOf(robber)}: {robber}");
                    }
                }
            }

            // Have each crew member in your crew perform their skill on the bank
            foreach (var crewMember in crew)
            {
                crewMember.PerformSkill(bank);
            }

            // Makes the console a bit more user-friendly by adding a break in the terminal
            Console.WriteLine("");

            // Check to see if the bank is still secure after the heist
            if (bank.IsSecure)
            {
                // Failure message:
                Console.WriteLine("Unfortunately everyone's hard work didn't pay off. Don't quit your day jobs!");
            }
            else
            {
                // Success message and report:
                Console.WriteLine($"Success! Your crew managed to get away with ${cashOnHand}!");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Everyone gets their piece of the pie:");
                Console.WriteLine("--------------------------------------");
                foreach (var crewMember in crew)
                {
                    // Calculate how much each crew member gets from the heist
                    double cut = (crewMember.PercentageCut * cashOnHand) / 100;
                    Console.WriteLine($"{crewMember.Name} walks away with ${cut}!");
                }
                // Makes the console a bit more user-friendly by adding a break in the terminal
                Console.WriteLine("");
                // Calculate what you walk away with for setting up the heist!
                double leftover = (crewCutPercentageLeft * cashOnHand) / 100;
                Console.WriteLine($"For setting up the heist you get what's leftover and walk away with ${leftover}. Good job!");
            }
        }
    }
}