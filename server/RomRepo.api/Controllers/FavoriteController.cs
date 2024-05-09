using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RomRepo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        [HttpPost("game")]
        public void ToggleGameFavorite(int gameID)
        {
            throw new NotImplementedException();
        }

        [HttpPost("gamesystem")]
        public void ToggleGameSystemFavorite(int gameSystemID)
        {
            throw new NotImplementedException();
        }

    }
}
