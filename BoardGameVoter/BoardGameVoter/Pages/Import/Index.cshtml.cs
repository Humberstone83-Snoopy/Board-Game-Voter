using BoardGameVoter.Logic.Utility;
using BoardGameVoter.Models;
using BoardGameVoter.Models.EntityModels.BoardGames;
using BoardGameVoter.Models.Enums;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Repositorys.BoardGames;
using BoardGameVoter.Services;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;

namespace BoardGameVoter.Pages.Import
{
    public class IndexModel : BoardGameVoterPageBase
    {
        private readonly IOptions<StorageAccountOptions> __OptionsAccessor;
        private readonly BlobUtility __BlobUtility;
        private readonly BoardGameRepository __BoardGameRepository;

        public IndexModel(IBGVServiceProvider bgvServiceProvider, IOptions<StorageAccountOptions> optionsAccessor)
            :base(bgvServiceProvider)
        {
            __OptionsAccessor = optionsAccessor;
            __BlobUtility = new BlobUtility(__OptionsAccessor.Value.StorageAccountNameOption, __OptionsAccessor.Value.StorageAccountKeyOption);
            __BoardGameRepository = new BoardGameRepository(bgvServiceProvider);
        }

        public void OnGet()
        {
        }

        public void OnPostCreateGames()
        {
            using (var reader = new StreamReader("C:\\Users\\JackHumberstone\\source\\repos\\humberstone83\\board-game-voter\\BoardGameVoter\\BoardGameVoter\\bgg-combined.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                using (var dr = new CsvDataReader(csv))
                {
                    var dt = new DataTable();
                    dt.Columns.Add("Title", typeof(string));
                    dt.Columns.Add("Date", typeof(string));
                    dt.Columns.Add("Rating", typeof(decimal));
                    dt.Columns.Add("Description", typeof(string));
                    dt.Columns.Add("Minimum_Players", typeof(int));
                    dt.Columns.Add("Maximum_Players", typeof(int));
                    dt.Columns.Add("Minimum_Playtime", typeof(int));
                    dt.Columns.Add("Maximum_Playtime", typeof(int));
                    dt.Columns.Add("Age", typeof(string));
                    dt.Columns.Add("Weight", typeof(decimal));
                    dt.Columns.Add("Publisher", typeof(string));
                    dt.Columns.Add("Type_Primary_ID", typeof(int));
                    dt.Columns.Add("Type_Secondary_ID", typeof(int));
                    dt.Columns.Add("Category_Primary_ID", typeof(int));
                    dt.Columns.Add("Category_Secondary_ID", typeof(int));
                    dt.Columns.Add("Category_Tertiary_ID", typeof(int));
                    dt.Columns.Add("Mechanic_Primary_ID", typeof(int));
                    dt.Columns.Add("Mechanic_Secondary_ID", typeof(int));
                    dt.Columns.Add("Mechanic_Tertiary_ID", typeof(int));
                    dt.Columns.Add("Description_Long", typeof(string));
                    dt.Load(dr);

                    List<BoardGame> _Games = new();
                    foreach (DataRow row in dt.Rows)
                    {
                        _Games.Add(new()
                        {
                            Title = row["Title"] as string,
                            ReleaseDate = DateTime.Parse("01/01/" + row["Date"] as string),
                            Rating = row["Rating"] as decimal? ?? 0,
                            Description = row["Description"] as string,
                            MinimumPlayers = row["Minimum_Players"] as int? ?? 0,
                            MaximumPlayers = row["Maximum_Players"] as int? ?? 0,
                            MinimumPlayTime = row["Minimum_Playtime"] as int? ?? 0,
                            MaximumPlayTime = row["Maximum_Playtime"] as int? ?? 0,
                            AgeRating = row["Age"] as string,
                            Weight = (Weight)(int)Math.Round(row["Weight"] as decimal? ?? 0),
                            //Publisher = row["Publisher"] as string,
                            //PrimaryTypeID = ((row["Type_Primary_ID"] as int? ?? 0) > 0) ? (row["Type_Primary_ID"] as int? ?? 0) : null,
                            //SecondaryTypeID = ((row["Type_Secondary_ID"] as int? ?? 0) > 0) ? (row["Type_Secondary_ID"] as int? ?? 0) : null,
                            //PrimaryCategoryID = ((row["Category_Primary_ID"] as int? ?? 0) > 0) ? (row["Category_Primary_ID"] as int? ?? 0) : null,
                            //SecondaryCategoryID = ((row["Category_Secondary_ID"] as int? ?? 0) > 0) ? (row["Category_Secondary_ID"] as int? ?? 0) : null,
                            //TertiaryCategoryID = ((row["Category_Tertiary_ID"] as int? ?? 0) > 0) ? (row["Category_Tertiary_ID"] as int? ?? 0) : null,
                            //PrimaryMechanismID = ((row["Mechanic_Primary_ID"] as int? ?? 0) > 0) ? (row["Mechanic_Primary_ID"] as int? ?? 0) : null,
                            //SecondaryMechanismID = ((row["Mechanic_Secondary_ID"] as int? ?? 0) > 0) ? (row["Mechanic_Secondary_ID"] as int? ?? 0) : null,
                            //TertiaryMechanismID = ((row["Mechanic_Tertiary_ID"] as int? ?? 0) > 0) ? (row["Mechanic_Tertiary_ID"] as int? ?? 0) : null,
                            
                        });
                    }
                    __BoardGameRepository.Add(_Games);
                }
            }
        }

        public async Task OnPostUploadAsync()
        {
            foreach (IFormFile formFile in FileUpload.FormFiles)
            {
                //check formFile is an image
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    await __BlobUtility.UploadBlob("images", formFile, "Game"); //Game is not directory name but would need to get this somehow
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.
        }


        [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }

        public class BufferedSingleFileUploadDb
        {
            [Required]
            [Display(Name = "File")]
            public List<IFormFile> FormFiles { get; set; }
        }
    }
}
