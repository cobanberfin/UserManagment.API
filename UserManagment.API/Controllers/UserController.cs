using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagment.API.Fake;
using UserManagment.API.Models;

namespace UserManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<User> _users = Fakedata.GetUsers(200);
        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user =_users.FirstOrDefault(x=>x.Id== id);
            return user;  

        }
        //gonderdıgın requestın bodysınde user nesnesı beklıyorum gonder bnede bunu lısetye eklıyım
        [HttpPost]
        public User Post([FromForm] User user)
        {
            _users.Add(user);
            return user;
        }
        [HttpPost]
        public  User Put([FromBody] User user)
        {
            var editedUser = _users.FirstOrDefault(x=>x.Id== user.Id);
            editedUser.Firstname = user.Firstname;
            editedUser.Lastname = user.Lastname;
            editedUser.Address = user.Address;
            _users.Add(user);
            return user;
        }
        [HttpDelete]
        public void Delete (int id)
        {
            var deleteUser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deleteUser);
             


        }

    }
}
