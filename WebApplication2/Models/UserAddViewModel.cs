using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Entities;

namespace WebApplication2.Models
{
	public class UserAddViewModel
	{
        public User User { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}
