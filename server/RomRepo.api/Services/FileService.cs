using RomRepo.api.Models;
using System.Xml;
using System.Xml.Linq;

namespace RomRepo.api.Services
{
    /// <inheritdoc cref="IFileService"/>
    public class FileService : IFileService
    {
        ILogger<FileService> _logger;
        public FileService(ILogger<FileService> logger) 
        { 
            _logger = logger;
        }

        [Obsolete("Use stream version instead")]
        public async Task<GameSystem> ExtractGameSystem(IFormFile file)
        {
            GameSystem gameSystem = new GameSystem(){ Name = "new" };
            try
            {
                using (Stream stream = file.OpenReadStream())
                {
                    CancellationToken cancellationToken = new CancellationToken();
                    XDocument xmlDocument = await XDocument.LoadAsync(stream, LoadOptions.None, cancellationToken);
                    await stream.DisposeAsync();

                    var elements = xmlDocument.Root?.Elements() ?? Enumerable.Empty<XElement>();

                    var header = elements.Where(w => w.Name == "header").FirstOrDefault();

                    if (header != null)
                    {
                        var headerElements = header.Elements();
                        if(headerElements.Any())
                        {
                            gameSystem = new GameSystem
                            {
                                NoIntroGameSystemID = headerElements.FirstOrDefault(w => w.Name == "id")?.Value,
                                Name = headerElements.FirstOrDefault(w => w.Name == "name").Value,
                                Description = headerElements.FirstOrDefault(w => w.Name == "description")?.Value,
                                Version = headerElements.FirstOrDefault(w => w.Name == "version")?.Value,
                                Author = headerElements.FirstOrDefault(w => w.Name == "author")?.Value,
                                Homepage = headerElements.FirstOrDefault(w => w.Name == "homepage")?.Value,
                                URL = headerElements.FirstOrDefault(w => w.Name == "url")?.Value,
                            };

                            var games = new List<Game>();

                            var gameElements = elements.Where(w => w.Name == "game").ToList();
                            foreach (var g in gameElements)
                            {
                                var details = g.Elements();
                                var primaryAttributes = g.Attributes();
                                Game game = new Game
                                {
                                    Name = primaryAttributes.FirstOrDefault(w => w.Name == "name").Value,
                                    NoIntroGameID = primaryAttributes.FirstOrDefault(w => w.Name == "id")?.Value,
                                    NoIntroGameSystemID = gameSystem.NoIntroGameSystemID,
                                    Description = details.FirstOrDefault(w => w.Name == "description")?.Value,
                                    ParentNoIntroID = primaryAttributes.FirstOrDefault(w => w.Name == "cloneofid")?.Value
                                };

                                var roms = new List<Rom>();

                                var romElements = details.Where(w => w.Name == "rom").ToList();
                                romElements.ForEach(re => { 
                                    var attrs = re.Attributes();
                                    int size = 0;
                                    int.TryParse(attrs.FirstOrDefault(w => w.Name == "size")?.Value, out size);
                                    roms.Add(new Rom
                                    {
                                        Name = attrs.FirstOrDefault(w => w.Name == "name").Value,
                                        CRC = attrs.FirstOrDefault(w => w.Name == "crc")?.Value,
                                        MD5 = attrs.FirstOrDefault(w => w.Name == "md5")?.Value,
                                        Serial = attrs.FirstOrDefault(w => w.Name == "serial")?.Value,
                                        SHA1 = attrs.FirstOrDefault(w => w.Name == "sha1")?.Value,
                                        SHA256 = attrs.FirstOrDefault(w => w.Name == "sha256")?.Value,
                                        Size = size,    
                                        Status = attrs.FirstOrDefault(w => w.Name == "status")?.Value,
                                    });
                                });
                                game.Roms = roms;
                                games.Add(game);
                            }
                            gameSystem.Games = games;
                            return gameSystem;
                        }
                    }
                }
                throw new XmlException();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in FileService.ExtractGameSystems(IFormFile)");
                return null;
            }
        }

        /// <inheritdoc/>
        /// <exception cref="XmlException"></exception>
        public async Task<GameSystem?> ExtractGameSystem(Stream stream, CancellationToken cancellationToken)
        {
            GameSystem gameSystem = new GameSystem() { Name = "new" };
            try
            {
                using (stream)
                {
                    XDocument xmlDocument = await XDocument.LoadAsync(stream, LoadOptions.None, cancellationToken);
                    await stream.DisposeAsync();

                    var elements = xmlDocument.Root?.Elements() ?? Enumerable.Empty<XElement>();

                    var header = elements.Where(w => w.Name == "header").FirstOrDefault();

                    if (header != null)
                    {
                        var headerElements = header.Elements();
                        if (headerElements.Any())
                        {
                            gameSystem = new GameSystem
                            {
                                NoIntroGameSystemID = headerElements.FirstOrDefault(w => w.Name == "id")?.Value,
                                Name = headerElements.FirstOrDefault(w => w.Name == "name").Value,
                                Description = headerElements.FirstOrDefault(w => w.Name == "description")?.Value,
                                Version = headerElements.FirstOrDefault(w => w.Name == "version")?.Value,
                                Author = headerElements.FirstOrDefault(w => w.Name == "author")?.Value,
                                Homepage = headerElements.FirstOrDefault(w => w.Name == "homepage")?.Value,
                                URL = headerElements.FirstOrDefault(w => w.Name == "url")?.Value,
                            };

                            var games = new List<Game>();

                            var gameElements = elements.Where(w => w.Name == "game").ToList();
                            foreach (var g in gameElements)
                            {
                                if(cancellationToken.IsCancellationRequested)
                                    return null;
                                var details = g.Elements();
                                var primaryAttributes = g.Attributes();
                                Game game = new Game
                                {
                                    Name = primaryAttributes.FirstOrDefault(w => w.Name == "name").Value,
                                    NoIntroGameID = primaryAttributes.FirstOrDefault(w => w.Name == "id")?.Value,
                                    NoIntroGameSystemID = gameSystem.NoIntroGameSystemID,
                                    Description = details.FirstOrDefault(w => w.Name == "description")?.Value,
                                    ParentNoIntroID = primaryAttributes.FirstOrDefault(w => w.Name == "cloneofid")?.Value
                                };

                                var roms = new List<Rom>();

                                var romElements = details.Where(w => w.Name == "rom").ToList();
                                romElements.ForEach(re => {
                                    var attrs = re.Attributes();
                                    int size = 0;
                                    int.TryParse(attrs.FirstOrDefault(w => w.Name == "size")?.Value, out size);
                                    roms.Add(new Rom
                                    {
                                        Name = attrs.FirstOrDefault(w => w.Name == "name").Value,
                                        CRC = attrs.FirstOrDefault(w => w.Name == "crc")?.Value,
                                        MD5 = attrs.FirstOrDefault(w => w.Name == "md5")?.Value,
                                        Serial = attrs.FirstOrDefault(w => w.Name == "serial")?.Value,
                                        SHA1 = attrs.FirstOrDefault(w => w.Name == "sha1")?.Value,
                                        SHA256 = attrs.FirstOrDefault(w => w.Name == "sha256")?.Value,
                                        Size = size,
                                        Status = attrs.FirstOrDefault(w => w.Name == "status")?.Value,
                                    });
                                });
                                game.Roms = roms;
                                games.Add(game);
                            }
                            gameSystem.Games = games;
                            return gameSystem;
                        }
                    }
                }
                throw new XmlException();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in FileService.ExtractGameSystems(IFormFile)");
                return null;
            }
        }
    }
}
