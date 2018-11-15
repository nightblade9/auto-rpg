using AutoRpg.DatabaseMediator;
using AutoRpg.ServiceExtensions;
using System;

namespace AutoRpg.Services.PartyManagementService
{
    public class PartyManagementMediator : AbstractService
    {
        private IDatabaseMediator databaseMediator;

        public PartyManagementMediator()
        {
            this.databaseMediator = this.CreateDatabaseMediator();
        }

        /// <summary>
        /// Adds an existing character to a user's active party.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="characterId"></param>
        /// <returns>True if we added the character to the user's party. False for any other reason (eg. player doesn't have access to that character.)</returns>
        public bool AddCharacterToParty(string userId, int characterId)
        {
            // Adds party member if not already part of that party
            var isAlreadyInParty = this.databaseMediator.ExecuteScalar<int>("SELECT COUNT(*) FROM PartyCharacters WHERE UserId=@userId AND CharacterId=@characterId",
                new { userId = userId, characterId = characterId });

            if (isAlreadyInParty == 0)
            {
                this.databaseMediator.Execute("INSERT INTO PartyCharacters (UserId, CharacterId) VALUES (@userId, @characterId)", new { userId = userId, characterId = characterId });
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
