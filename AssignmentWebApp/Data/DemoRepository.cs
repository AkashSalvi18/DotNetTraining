using AssignmentWebApp.Models;
using System.Collections.Generic;
namespace AssignmentWebApp.Data
{
    public class DemoRepository
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static void DeleteUser(int userId)
        {
            var user = Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                Users.Remove(user);
            }
        }
    }
}
