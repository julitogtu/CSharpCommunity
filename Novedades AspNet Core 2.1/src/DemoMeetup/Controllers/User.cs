using System.ComponentModel.DataAnnotations;

namespace DemoMeetup.Controllers
{
    /// <summary>
    /// Represents an user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// User id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        [Required]
        [StringLength(8)]
        public string Name { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}