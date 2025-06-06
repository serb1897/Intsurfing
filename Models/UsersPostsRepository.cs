using IntsurfingTest.Models.DTO;
using System.Numerics;

namespace IntsurfingTest.Models
{
    public class UsersPostsRepository
    {
        async Task<List<UsersPosts>> GetUsersPostsAsync()
        {
            var getData = new GetData();
            var users = await getData.GetUsersAsync();
            var posts = await getData.GetPostsAsync();

            if (users is null)
            {
                Console.WriteLine("Users were not found");
                return new List<UsersPosts>();
            }

            if (posts is null)
            {
                Console.WriteLine("Posts were not found");
                return new List<UsersPosts>();
            }

            var usersPosts = (from u in users
                              select new UsersPosts()
                              {
                                  Name = u.Name,
                                  City = u.Address?.City ?? "-Unknown",
                                  Phone = u.Phone,
                                  Email = u.Email,
                                  Website = u.Website,
                                  PostsCount = posts.Where(w => w.UserId == u.Id).Count()
                              }).ToList();

            return usersPosts;
        }

        public async Task GetAllUsersPostsAsync()
        {
            var usersPosts = await GetUsersPostsAsync();
            DisplayUsers(usersPosts);
        }

        public async Task GetUsersByCityAsync(string startLetter)
        {
            if (string.IsNullOrEmpty(startLetter))
            {
                Console.WriteLine("Letter cannot be empty");
                return;
            }

            var usersPosts = await GetUsersPostsAsync();
            usersPosts = usersPosts.Where(w => w.City != null && w.City.StartsWith(startLetter, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayUsers(usersPosts);
        }

        public async Task GetTopPostsUsersAsync()
        {
            var usersPosts = await GetUsersPostsAsync();
            usersPosts = usersPosts.OrderByDescending(o => o.PostsCount).ThenBy(t => t.Name).Take(5).ToList();
            DisplayUsers(usersPosts);
        }

        public async Task GetUsersByPartOfPhoneAsync(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                Console.WriteLine("Phone cannot be empty");
                return;
            }

            if (phone.Length > 30)
            {
                Console.WriteLine("Phone too long");
                return;
            }

            var usersPosts = await GetUsersPostsAsync();
            usersPosts = usersPosts.Where(w => !string.IsNullOrEmpty(w.Phone) && w.Phone.Contains(phone)).ToList();
            DisplayUsers(usersPosts);
        }

        public async Task GetUsersByPartOfEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email cannot be empty");
                return;
            }

            if (email.Length > 50)
            {
                Console.WriteLine("Email too long");
                return;
            }

            var usersPosts = await GetUsersPostsAsync();
            usersPosts = usersPosts.Where(w => !string.IsNullOrEmpty(w.Email) && w.Email.Contains(email, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayUsers(usersPosts);
        }

        public async Task GetUsersByPartOfWebsiteAsync(string website)
        {
            if (string.IsNullOrEmpty(website))
            {
                Console.WriteLine("Website cannot be empty");
                return;
            }

            if (website.Length > 50)
            {
                Console.WriteLine("Website too long");
                return;
            }

            var usersPosts = await GetUsersPostsAsync();
            usersPosts = usersPosts.Where(w => !string.IsNullOrEmpty(w.Website) && w.Website.Contains(website, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayUsers(usersPosts);
        }

        void DisplayUsers(List<UsersPosts> usersPosts)
        {
            if (!usersPosts.Any())
            {
                Console.WriteLine("Users not found");
            }

            foreach (var user in usersPosts)
            {
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"City: {user.City}");
                Console.WriteLine($"Posts count: {user.PostsCount}");
                Console.WriteLine("===============================");
            }
        }
    }
}