using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBuildFinalProject.Models;

namespace DevBuildFinalProject.Services
{
    public interface ICharacterDataService
    {
        public int AddPlayer(Character character);
        public IEnumerable<Character>GetAllCharacters();
        public int AssignStarterDeck(int id);
        public Character GetCurrentUser();
        public int AssignCurrentUser(int id);
        public Character GetEnemyByProgress(int progress);
        public int UpdateCharacterHelth(Character character);
        //remove character
        //edit character
    }
}
