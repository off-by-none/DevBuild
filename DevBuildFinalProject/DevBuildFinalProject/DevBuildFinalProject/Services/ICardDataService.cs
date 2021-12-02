using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBuildFinalProject.Models;

namespace DevBuildFinalProject.Services
{
    public interface ICardDataService
    {
        public IEnumerable<Card> GetAllCards();
        public IEnumerable<Card> GetAllCardsOwnedById(int id);
        public Card ReturnCardById(int id);
    }
}
