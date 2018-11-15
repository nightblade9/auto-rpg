using AutoRpg.DatabaseMediator;
using AutoRpg.Services.CharacterService.Model;
using AutoRpg.ServiceExtensions;
using System;

namespace AutoRpg.Services.CharacterService
{
    public class CharacterServiceMediator : AbstractService
    {
        private IDatabaseMediator databaseMediator;

        public CharacterServiceMediator()
        {
            this.databaseMediator = this.CreateDatabaseMediator();
        }

        public Character CreateStarterCharacter(string userId)
        {
            // Sanity check: this user has no characters, right? Right??
            var count = this.databaseMediator.ExecuteScalar<int>("SELECT COUNT(*) FROM Characters WHERE UserId = @userId", new { userId = userId });

            if (count == 0)
            {
                // Return a simple fighter.
                var fighter = new Character()
                {
                    TotalHealthPoints = 20,
                    HealthPoints = 20,
                    Strength = 5,
                    Defense = 3,
                    Agility = 1,
                    Job = "Fighter",
                    SkillPoints = 0,
                    TotalSkillPoints = 0
                };

                fighter.Id = this.databaseMediator.ExecuteScalar<int>(@"INSERT INTO Characters
                    ([UserId], [TotalHealthPoints], [HealthPoints] ,[Strength] ,[Defense] ,[Agility] ,[Job] ,[SkillPoints], [TotalSkillPoint])
                    OUTPUT Inserted.[CharacterId]
                    VALUES (@userId, @health, @health, @strength, @defense, @agility, @job, @skillPoints, @skillPoints)",
                    new { 
                        userId = userId, health = fighter.TotalHealthPoints, strength = fighter.Strength, defense = fighter.Defense, agility = fighter.Agility, job = fighter.Job,
                        skillPoints = fighter.TotalSkillPoints });

                // Insert into DB
                return fighter;
            }
            else
            {
                throw new InvalidOperationException($"User already has {count} characters.");
            }
        }

    }
}
