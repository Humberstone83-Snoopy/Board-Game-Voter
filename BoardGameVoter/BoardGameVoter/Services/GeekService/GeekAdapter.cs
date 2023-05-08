using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Models.Enums;
using BoardGameVoter.Repositorys.BoardGames;
using static BoardGamer.BoardGameGeek.BoardGameGeekXmlApi2.ThingResponse;

namespace BoardGameVoter.Services.GeekService
{
    public static class GeekAdapter
    {
        private const string BOARD_GAME_ARTIST = "boardgameartist";
        private const string BOARD_GAME_CATEGORY = "boardgamecategory";
        private const string BOARD_GAME_DESIGNER = "boardgamedesigner";
        private const string BOARD_GAME_FAMILY = "boardgamefamily";
        private const string BOARD_GAME_IMPLEMENTATION = "boardgameimplementation";
        private const string BOARD_GAME_MECHANIC = "boardgamemechanic";
        private const string BOARD_GAME_PUBLISHER = "boardgamepublisher";

        private static List<BoardGameArtist> __BoardGameArtists;
        private static List<BoardGameCategory> __BoardGameCategories;
        private static List<BoardGameDesigner> __BoardGameDesigners;
        private static List<BoardGameFamily> __BoardGameFamilies;
        private static List<BoardGameMechanism> __BoardGameMechanisms;
        private static List<BoardGamePublisher> __BoardGamePublishers;

        private static IEnumerable<BoardGameArtist> CreateArtists(BoardGameArtistRepository boardGameArtistRepository, IEnumerable<Link> nonExistingArtists)
        {
            IEnumerable<BoardGameArtist> _NewArtists = boardGameArtistRepository.Add(nonExistingArtists.Select(link => new BoardGameArtist()
            {
                Name = link.Value,
                BoardGameGeekID = link.Id
            }));
            __BoardGameArtists.AddRange(_NewArtists ?? new List<BoardGameArtist>());
            return _NewArtists;
        }

        private static IEnumerable<BoardGameCategory> CreateCategories(BoardGameCategoryRepository boardGameCategoryRepository, IEnumerable<Link> nonExistingCategories)
        {
            IEnumerable<BoardGameCategory> _NewCategories = boardGameCategoryRepository.Add(nonExistingCategories.Select(link => new BoardGameCategory()
            {
                Name = link.Value,
                BoardGameGeekID = link.Id
            }));
            __BoardGameCategories.AddRange(_NewCategories ?? new List<BoardGameCategory>());
            return _NewCategories;
        }

        private static IEnumerable<BoardGameDesigner> CreateDesigners(BoardGameDesignerRepository boardGameDesignerRepository, IEnumerable<Link> nonExistingDesigners)
        {
            IEnumerable<BoardGameDesigner> _NewDesigners = boardGameDesignerRepository.Add(nonExistingDesigners.Select(link => new BoardGameDesigner()
            {
                Name = link.Value,
                BoardGameGeekID = link.Id
            }));
            __BoardGameDesigners.AddRange(_NewDesigners ?? new List<BoardGameDesigner>());
            return _NewDesigners;
        }

        private static IEnumerable<BoardGameFamily> CreateFamilies(BoardGameFamilyRepository boardGameFamilyRepository, IEnumerable<Link> nonExistingFamilies)
        {
            IEnumerable<BoardGameFamily> _NewFamilies = boardGameFamilyRepository.Add(nonExistingFamilies.Select(link => new BoardGameFamily()
            {
                Name = link.Value,
                BoardGameGeekID = link.Id
            }));
            __BoardGameFamilies.AddRange(_NewFamilies ?? new List<BoardGameFamily>());
            return _NewFamilies;
        }

        private static IEnumerable<BoardGameMechanism> CreateMechanisms(BoardGameMechanismRepository boardGameMechanismRepository, IEnumerable<Link> nonExistingMechanisms)
        {
            IEnumerable<BoardGameMechanism> _NewMechanisms = boardGameMechanismRepository.Add(nonExistingMechanisms.Select(link => new BoardGameMechanism()
            {
                Name = link.Value,
                BoardGameGeekID = link.Id
            }));
            __BoardGameMechanisms.AddRange(_NewMechanisms ?? new List<BoardGameMechanism>());
            return _NewMechanisms;
        }

        private static IEnumerable<BoardGamePublisher> CreatePublishers(BoardGamePublisherRepository boardGamePublisherRepository, IEnumerable<Link> nonExistingPublishers)
        {
            IEnumerable<BoardGamePublisher> _NewPublishers = boardGamePublisherRepository.Add(nonExistingPublishers.Select(link => new BoardGamePublisher()
            {
                Name = link.Value,
                BoardGameGeekID = link.Id
            }));
            __BoardGamePublishers.AddRange(_NewPublishers ?? new List<BoardGamePublisher>());
            return _NewPublishers;
        }

        internal static List<BoardGame> ToBoardGame(IBGVServiceProvider bgvServiceProvider, List<Item> thingResponseItems)
        {
            List<BoardGame> _BoardGames = new();
            foreach (Item thing in thingResponseItems)
            {
                BoardGame _ConvertedBoardGame = ToBoardGame(bgvServiceProvider, thing);
                _BoardGames.Add(_ConvertedBoardGame);
            }
            return _BoardGames;
        }

        internal static BoardGame ToBoardGame(IBGVServiceProvider bgvServiceProvider, Item thingResponseItem)
        {
            BoardGameRepository _BoardGameRepository = new(bgvServiceProvider);
            BoardGame _BoardGame = _BoardGameRepository.GetByBoardGameGeekID(thingResponseItem.Id);

            if (_BoardGame == null)
            {

                IEnumerable<Link> _ArtistLinks = thingResponseItem.Links.Where(link => link.Type == BOARD_GAME_ARTIST);
                List<BoardGameArtist> _Artists = ToBoardGameArtist(bgvServiceProvider, _ArtistLinks);

                IEnumerable<Link> _CategoryLinks = thingResponseItem.Links.Where(link => link.Type == BOARD_GAME_CATEGORY);
                List<BoardGameCategory> _Categories = ToBoardGameCategory(bgvServiceProvider, _CategoryLinks);

                IEnumerable<Link> _DesignerLinks = thingResponseItem.Links.Where(link => link.Type == BOARD_GAME_DESIGNER);
                List<BoardGameDesigner> _Designers = ToBoardGameDesigner(bgvServiceProvider, _DesignerLinks);

                IEnumerable<Link> _FamilyLinks = thingResponseItem.Links.Where(link => link.Type == BOARD_GAME_FAMILY);
                List<BoardGameFamily> _Families = ToBoardGameFamily(bgvServiceProvider, _FamilyLinks);

                IEnumerable<Link> _ImplementationLinks = thingResponseItem.Links.Where(link => link.Type == BOARD_GAME_IMPLEMENTATION);
                List<BoardGameImplementation> _Implementations = ToBoardGameImplementation(_ImplementationLinks);

                IEnumerable<Link> _MechanicLinks = thingResponseItem.Links.Where(link => link.Type == BOARD_GAME_MECHANIC);
                List<BoardGameMechanism> _Mechanics = ToBoardGameMechanism(bgvServiceProvider, _MechanicLinks);

                IEnumerable<Link> _PublisherLinks = thingResponseItem.Links.Where(link => link.Type == BOARD_GAME_PUBLISHER);
                List<BoardGamePublisher> _Publishers = ToBoardGamePublisher(bgvServiceProvider, _PublisherLinks);

                //I think we should handle images later
                //byte[] _Image = await DownloadImageAsync(thingResponseItem.Image);
                //byte[] _ThumbnailImage = await DownloadImageAsync(thingResponseItem.Thumbnail);

                _BoardGame = new BoardGame()
                {
                    AgeRating = thingResponseItem.MinAge != null ? (thingResponseItem.MinAge > 0 ? $"{thingResponseItem.MinAge}+" : "U") : "N/A",
                    BoardGameGeekID = thingResponseItem.Id,
                    Description = thingResponseItem.Description,
                    Implementations = _Implementations,
                    MaximumPlayers = thingResponseItem.MaxPlayers,
                    MaximumPlayTime = thingResponseItem.MaxPlayingTime,
                    Mechanisms = new(),
                    MinimumPlayers = thingResponseItem.MinPlayers,
                    MinimumPlayTime = thingResponseItem.MinPlayingTime,
                    Publishers = new(),
                    Rating = (decimal?)thingResponseItem.Statistics?.Ratings?.Average ?? 0,
                    ReleaseDate = thingResponseItem.ReleaseDate ?? (thingResponseItem.YearPublished != null ? new DateTime(thingResponseItem.YearPublished ?? 1, 1, 1) : null),
                    Title = thingResponseItem.Name,
                    Weight = (Weight)(int)Math.Round(thingResponseItem.Statistics?.Ratings?.AverageWeight ?? 0)
                };

                _BoardGame.Artists = _Artists.Select(artist => new BoardGame_BoardGameArtist()
                {
                    BoardGame = _BoardGame,
                    BoardGameArtist = artist
                }).ToList();

                _BoardGame.Categories = _Categories.Select(category => new BoardGame_BoardGameCategory()
                {
                    BoardGame = _BoardGame,
                    BoardGameCategory = category
                }).ToList();

                _BoardGame.Designers = _Designers.Select(designer => new BoardGame_BoardGameDesigner()
                {
                    BoardGame = _BoardGame,
                    BoardGameDesigner = designer
                }).ToList();

                _BoardGame.Families = _Families.Select(family => new BoardGame_BoardGameFamily()
                {
                    BoardGame = _BoardGame,
                    BoardGameFamily = family
                }).ToList();

                _BoardGame.Mechanisms = _Mechanics.Select(mechanism => new BoardGame_BoardGameMechanism()
                {
                    BoardGame = _BoardGame,
                    BoardGameMechanism = mechanism
                }).ToList();

                _BoardGame.Publishers = _Publishers.Select(publisher => new BoardGame_BoardGamePublisher()
                {
                    BoardGame = _BoardGame,
                    BoardGamePublisher = publisher
                }).ToList();
            }
            return _BoardGame;
        }

        public async static Task<byte[]> DownloadImageAsync(string imageURL)
        {
            using HttpClient httpClient = new HttpClient();
            return await httpClient.GetByteArrayAsync(imageURL);
        }

        private static List<BoardGameArtist> ToBoardGameArtist(IBGVServiceProvider bgvServiceProvider, IEnumerable<Link> artistLinks)
        {
            List<BoardGameArtist> _CurrentBoardGameArtists = new();

            if (artistLinks.Any())
            {
                BoardGameArtistRepository _BoardGameArtistRepository = new(bgvServiceProvider);
                if (__BoardGameArtists == null || !__BoardGameArtists.Any())
                {
                    __BoardGameArtists = _BoardGameArtistRepository.GetAll().ToList();
                }

                IEnumerable<int> _LinkIDs = artistLinks.Select(link => link.Id);

                _CurrentBoardGameArtists.AddRange(__BoardGameArtists.Where(artist => _LinkIDs.Contains(artist.BoardGameGeekID)));

                IEnumerable<int> _ExistingIDs = _CurrentBoardGameArtists.Select(link => link.BoardGameGeekID);
                IEnumerable<Link> _NonExistingArtists = artistLinks.Where(link => !_ExistingIDs.Contains(link.Id));

                if (_NonExistingArtists.Any())
                {
                    _CurrentBoardGameArtists.AddRange(CreateArtists(_BoardGameArtistRepository, _NonExistingArtists));
                }
            }
            return _CurrentBoardGameArtists;
        }

        private static List<BoardGameCategory> ToBoardGameCategory(IBGVServiceProvider bgvServiceProvider, IEnumerable<Link> categoryLinks)
        {
            List<BoardGameCategory> _CurrentBoardGameCategory = new();

            if (categoryLinks.Any())
            {
                BoardGameCategoryRepository _BoardGameCategoryRepository = new(bgvServiceProvider);
                if (__BoardGameCategories == null || !__BoardGameCategories.Any())
                {
                    __BoardGameCategories = _BoardGameCategoryRepository.GetAll().ToList();
                }

                IEnumerable<int> _LinkIDs = categoryLinks.Select(link => link.Id);

                _CurrentBoardGameCategory.AddRange(__BoardGameCategories.Where(category => _LinkIDs.Contains(category.BoardGameGeekID)));

                IEnumerable<int> _ExistingIDs = _CurrentBoardGameCategory.Select(link => link.BoardGameGeekID);
                IEnumerable<Link> _NonExistingCategories = categoryLinks.Where(link => !_ExistingIDs.Contains(link.Id));

                if (_NonExistingCategories.Any())
                {
                    _CurrentBoardGameCategory.AddRange(CreateCategories(_BoardGameCategoryRepository, _NonExistingCategories));
                }
            }
            return _CurrentBoardGameCategory;
        }

        private static List<BoardGameDesigner> ToBoardGameDesigner(IBGVServiceProvider bgvServiceProvider, IEnumerable<Link> designerLinks)
        {
            List<BoardGameDesigner> _CurrentBoardGameDesigners = new();

            if (designerLinks.Any())
            {
                BoardGameDesignerRepository _BoardGameDesignerRepository = new(bgvServiceProvider);
                if (__BoardGameDesigners == null || !__BoardGameDesigners.Any())
                {
                    __BoardGameDesigners = _BoardGameDesignerRepository.GetAll().ToList();
                }

                IEnumerable<int> _LinkIDs = designerLinks.Select(link => link.Id);

                _CurrentBoardGameDesigners.AddRange(__BoardGameDesigners.Where(designer => _LinkIDs.Contains(designer.BoardGameGeekID)));

                IEnumerable<int> _ExistingIDs = _CurrentBoardGameDesigners.Select(link => link.BoardGameGeekID);
                IEnumerable<Link> _NonExistingDesigners = designerLinks.Where(link => !_ExistingIDs.Contains(link.Id));

                if (_NonExistingDesigners.Any())
                {
                    _CurrentBoardGameDesigners.AddRange(CreateDesigners(_BoardGameDesignerRepository, _NonExistingDesigners));
                }
            }
            return _CurrentBoardGameDesigners;
        }

        private static List<BoardGameFamily> ToBoardGameFamily(IBGVServiceProvider bgvServiceProvider, IEnumerable<Link> familyLinks)
        {
            List<BoardGameFamily> _CurrentBoardGameFamilies = new();

            if (familyLinks.Any())
            {
                BoardGameFamilyRepository _BoardGameFamilyRepository = new(bgvServiceProvider);
                if (__BoardGameFamilies == null || !__BoardGameFamilies.Any())
                {
                    __BoardGameFamilies = _BoardGameFamilyRepository.GetAll().ToList();
                }

                IEnumerable<int> _LinkIDs = familyLinks.Select(link => link.Id);

                _CurrentBoardGameFamilies.AddRange(__BoardGameFamilies.Where(family => _LinkIDs.Contains(family.BoardGameGeekID)));

                IEnumerable<int> _ExistingIDs = _CurrentBoardGameFamilies.Select(link => link.BoardGameGeekID);
                IEnumerable<Link> _NonExistingFamilies = familyLinks.Where(link => !_ExistingIDs.Contains(link.Id));

                if (_NonExistingFamilies.Any())
                {
                    _CurrentBoardGameFamilies.AddRange(CreateFamilies(_BoardGameFamilyRepository, _NonExistingFamilies));
                }
            }
            return _CurrentBoardGameFamilies;
        }

        private static List<BoardGameImplementation> ToBoardGameImplementation(IEnumerable<Link> implementationLinks)
        {
            return implementationLinks.Select(link => new BoardGameImplementation()
            {
                Name = link.Value,
                BoardGameGeekID = link.Id
            }).ToList();
        }

        private static List<BoardGameMechanism> ToBoardGameMechanism(IBGVServiceProvider bgvServiceProvider, IEnumerable<Link> mechanicLinks)
        {
            List<BoardGameMechanism> _CurrentBoardGameMechanisms = new();

            if (mechanicLinks.Any())
            {
                BoardGameMechanismRepository _BoardGameMechanismRepository = new(bgvServiceProvider);
                if (__BoardGameMechanisms == null || !__BoardGameMechanisms.Any())
                {
                    __BoardGameMechanisms = _BoardGameMechanismRepository.GetAll().ToList();
                }

                IEnumerable<int> _LinkIDs = mechanicLinks.Select(link => link.Id);

                _CurrentBoardGameMechanisms.AddRange(__BoardGameMechanisms.Where(mechanism => _LinkIDs.Contains(mechanism.BoardGameGeekID)));

                IEnumerable<int> _ExistingIDs = _CurrentBoardGameMechanisms.Select(link => link.BoardGameGeekID);
                IEnumerable<Link> _NonExistingMechanisms = mechanicLinks.Where(link => !_ExistingIDs.Contains(link.Id));

                if (_NonExistingMechanisms.Any())
                {
                    _CurrentBoardGameMechanisms.AddRange(CreateMechanisms(_BoardGameMechanismRepository, _NonExistingMechanisms));
                }
            }
            return _CurrentBoardGameMechanisms;
        }

        private static List<BoardGamePublisher> ToBoardGamePublisher(IBGVServiceProvider bgvServiceProvider, IEnumerable<Link> publisherLinks)
        {
            List<BoardGamePublisher> _CurrentBoardGamePublishers = new();

            if (publisherLinks.Any())
            {
                BoardGamePublisherRepository _BoardGamePublisherRepository = new(bgvServiceProvider);
                if (__BoardGamePublishers == null || !__BoardGamePublishers.Any())
                {
                    __BoardGamePublishers = _BoardGamePublisherRepository.GetAll().ToList();
                }

                IEnumerable<int> _LinkIDs = publisherLinks.Select(link => link.Id);

                _CurrentBoardGamePublishers.AddRange(__BoardGamePublishers.Where(publisher => _LinkIDs.Contains(publisher.BoardGameGeekID)));

                IEnumerable<int> _ExistingIDs = _CurrentBoardGamePublishers.Select(link => link.BoardGameGeekID);
                IEnumerable<Link> _NonExistingPublishers = publisherLinks.Where(link => !_ExistingIDs.Contains(link.Id));

                if (_NonExistingPublishers.Any())
                {
                    _CurrentBoardGamePublishers.AddRange(CreatePublishers(_BoardGamePublisherRepository, _NonExistingPublishers));
                }
            }
            return _CurrentBoardGamePublishers;
        }
    }
}
