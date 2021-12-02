using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBuildFinalProject.Models;
using DevBuildFinalProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevBuildFinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterDataService characterData;

        public CharacterController(ICharacterDataService characterData)
        {
            this.characterData = characterData;
        }

        [HttpGet]
        public IEnumerable<Character> GetAllCharacters()
        {
            return characterData.GetAllCharacters();
        }

        [HttpGet("currentuser")]
        public Character GetCurrentUser()
        {
            return characterData.GetCurrentUser();
        }

        [HttpPost("new")]
        public object AddPlayer(Character character)
        {
            int characterResult = characterData.AddPlayer(character);

            if (characterResult == 1)
            {
                return new { Success = true, Message = "Character Added" };
            }
            else
            {
                return new { Success = false, Message = "There was an error, Character was not added" };
            }
        }

        [HttpGet("enemy/{progress}")]
        public Character GetEnemyByProgress(int progress)
        {
            return characterData.GetEnemyByProgress(progress);
        }

    }
}