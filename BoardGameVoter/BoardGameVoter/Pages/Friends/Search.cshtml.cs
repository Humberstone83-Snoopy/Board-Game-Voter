using BoardGameVoter.Logic.Friends;
using BoardGameVoter.Models.TableModels;
using BoardGameVoter.Pages.Shared;
using BoardGameVoter.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Pages.Friends
{
    public class SearchModel : BoardGameVoterPageBase
    {
        private readonly FriendManager __FriendManager;

        public SearchModel(IBGVServiceProvider bGVServiceProvider) : base(bGVServiceProvider)
        {
            __FriendManager = new FriendManager(bGVServiceProvider);
        }

        public void OnGet()
        {
            Users = new();
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {

                Users = __FriendManager.UsernameSearch(UserManager.User.ID, Username);
            }
        }

        [BindProperty]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        public List<FriendsTableModel> Users { get; set; }
    }
}