using BoardGameVoter.Logic.Utility;
using BoardGameVoter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOptions<StorageAccountOptions> __OptionsAccessor;
        private readonly BlobUtility __BlobUtility;

        public IndexModel(ILogger<IndexModel> logger, IOptions<StorageAccountOptions> optionsAccessor)
        {
            _logger = logger;
            __OptionsAccessor = optionsAccessor;
            __BlobUtility = new BlobUtility(__OptionsAccessor.Value.StorageAccountNameOption, __OptionsAccessor.Value.StorageAccountKeyOption);
        }

        public void OnGet()
        {
        }

    }
}