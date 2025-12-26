using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Project_Advanced.ViewModels
{
    public class EditRoleViewModel
    {

        public string Id { get; set; } //role id

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; } = new(); //list of users assigned to this role
    }
}
