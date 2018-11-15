using AutoRpg.Services.CharacterService;
using AutoRpg.Services.PartyManagementService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRpg.Web.Services
{
    public class NewUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public NewUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            var user = httpContextAccessor.HttpContext.User;

        }
        public void CreateNewUserParty(string userId)
        {
            var fighter = new CharacterServiceMediator().CreateStarterCharacter(userId);
            new PartyManagementMediator().AddCharacterToParty(userId, fighter.Id);
        }
    }
}
