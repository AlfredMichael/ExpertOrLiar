using System;
using Firebase.Database;
using Exol.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exol.Helpers
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://expertorliar-default-rtdb.europe-west1.firebasedatabase.app/");

        public async Task<List<Cat>> GetAllCategories()
        {
            return (await firebase
                .Child("categories")
                .OnceAsync<Cat>()).Select(item => new Cat
                {
                    Title = item.Object.Title,
                    Description = item.Object.Description,
                    ImageUrl = item.Object.ImageUrl,
                }).ToList();

        }
    }
}
