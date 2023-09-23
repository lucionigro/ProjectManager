using ProjectManager.DTO;
using ProjectManager.Models;

namespace ProjectManager.Utilities.DataMapper
{
    public static class UserDataMapper
    {
        public static User ToModel(this LoginDTO user) 
        {
            return new User {
                Email = user.Email,
                Password = user.Password,
            };
        }
    }
}
