using IntsurfingTest.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntsurfingTest.Models
{
    public class GetData
    {
        private ApiService _apiService;

        public GetData()
        {
            _apiService = new ApiService();
        }

        public async Task<List<Users>> GetUsersAsync()
        {
            var users = await _apiService.GetRequestAsync<List<Users>>("users");
            return users;
        }

        public async Task<List<Posts>> GetPostsAsync()
        {
            var posts = await _apiService.GetRequestAsync<List<Posts>>("posts");
            return posts;
        }
    }
}
