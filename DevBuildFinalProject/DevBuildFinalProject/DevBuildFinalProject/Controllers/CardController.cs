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
    public class CardController : ControllerBase
    {
        private readonly ICardDataService cardData;

        public CardController(ICardDataService cardData)
        {
            this.cardData = cardData;
        }

        [HttpGet]
        public IEnumerable<Card> GetAllCards()
        {
            return cardData.GetAllCards();
        }

        [HttpGet("character/{id}")]
        public IEnumerable<Card> GetAllCardsOwnedById(int id)
        {
            return cardData.GetAllCardsOwnedById(id);
        }

        [HttpGet("{id}")]
        public Card ReturnCardById(int id)
        {
            return cardData.ReturnCardById(id);
        }

    }
}