using Bogus;
using UserManagment.API.Models;

namespace UserManagment.API.Fake
{
    public  static class Fakedata
    {//boguslibrary
        private static List<User> _users; 

        public static List<User> GetUsers(int number) 
        {//herdafesında farklı userlar gelmesın dıye bossa gonderdım
            if (_users == null)
            {
                _users = new Faker<User>().RuleFor(u => u.Id, f => f.IndexFaker + 1).RuleFor(u => u.Firstname, f => f.Name.FirstName()).RuleFor(u => u.Lastname, f => f.Name.LastName()).RuleFor(u => u.Address, f => f.Address.City()).Generate(number);
            }
           

              return _users; 
        }
    }
}
