using _0_Framework.Application;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contract.Account
{
    public class RegisterAccount
    {
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string FullName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string UserName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get; set; }
             
        public int RoleId { get; set; }

        public IFormFile? ProfilePhoto { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
