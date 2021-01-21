using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TBP.DeckOfCards.Domain.Interfaces;

namespace TBP.DeckOfCards.API.Controllers
{
    //TODO Implement MVVM Pattern
    [ApiController]
    [Route("[controller]")]
    public class DeckController : ControllerBase
    {
        /*
         It is implemented like that just to show how to use DI and avoid implementing a database or cache layer.
         */
        private readonly IDeck _deck;
        private readonly ILogger<DeckController> _logger;

        public DeckController(IDeck deck, ILogger<DeckController> logger)
        {
            _logger = logger;
            _deck = deck;
        }

        /// <summary>
        /// Method to get the deck on its current status
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public ActionResult<IDeck> Get()
        {
            return new OkObjectResult(_deck);
        }

        /// <summary>
        /// Method to shuffled the deck
        /// </summary>
        /// <returns></returns>
        [Route("shuffle")]
        [HttpPost]
        public ActionResult<IDeck> Shuffle()
        {
            _deck.Shuffle();

            return new OkObjectResult(_deck);
        }

        /// <summary>
        /// Method to deal a card
        /// </summary>
        /// <returns></returns>
        [Route("deal")]
        [HttpPost]
        public ActionResult<IDeck> Deal()
        {
            var card = _deck.Deal();

            return new OkObjectResult(card);
        }

        /// <summary>
        /// Method to start over
        /// </summary>
        /// <returns></returns>
        [Route("startover")]
        [HttpPost]
        public ActionResult<IDeck> StartOver()
        {
            _deck.StartOver();

            return new OkObjectResult(_deck);
        }
    }
}
