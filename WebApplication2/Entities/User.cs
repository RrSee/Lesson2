using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Entities
{
	public class User
	{
        [Range(0, 200)]
        public int Id { get; set; }

        [DisplayName("User name")]
        [Required]  
        public string FirstName { get; set; }

        [DisplayName("User surname")]
        [Required]
        public string LastName { get; set; }

        public int CityId { get; set; }
    }
}
