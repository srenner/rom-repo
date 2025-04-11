using Microsoft.AspNetCore.Mvc;

namespace RomRepo.api.Controllers
{
    /// <summary>
    /// Handles operations for marking items as a favorite
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        /// <summary>
        /// Allows API user to mark a game as a favorite
        /// </summary>
        /// <param name="gameID"></param>
        [HttpPost("game")]
        public void ToggleGameFavorite(int gameID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows API user to makr a gaming system as a favorite
        /// </summary>
        /// <param name="gameSystemID"></param>
        [HttpPost("gamesystem")]
        public void ToggleGameSystemFavorite(int gameSystemID)
        {
            throw new NotImplementedException();
        }
    }
}
