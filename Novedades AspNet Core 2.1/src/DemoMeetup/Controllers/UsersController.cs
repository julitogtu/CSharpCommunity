using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DemoMeetup.Controllers
{
    /// <summary>
    /// Endpoint to manage users.
    /// </summary>
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>()
        {
            new User(1, "Bruce Wayne"),
            new User(2, "Diana Prince")
        };

        /// <summary>
        /// Returns all users.
        /// </summary>
        /// <returns>List of users</returns>
        /// <response code="200">Returns the user list</response>
        /// <response code="500">Error</response>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(users);
        }

        /// <summary>
        /// Returns a user by id.
        /// </summary>
        /// <param name="id">User id to find.</param>
        /// <returns>A user</returns>
        /// <response code="200">Returns the user list</response>
        /// <response code="404">User with a given id does not exists.</response>
        /// <response code="500">Error</response>
        [HttpGet("{id:int}", Name = "GetUserById")]
        public ActionResult<User> GetById(int id)
        {
            var user = users.FirstOrDefault(c => c.Id == id);

            if (user is null)
            {
                return NotFound(new
                {
                    errorCode = 404,
                    description = "Not user with id 1 found"
                });
            }

            return user;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">User information</param>
        /// <returns>HTTP Code result</returns>
        /// <response code="201">User created</response>
        /// <response code="500">Error</response>
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            users.Add(user);
            return CreatedAtRoute("GetUserById", new {id = user.Id}, user);
        }
    }
}