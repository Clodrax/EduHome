using System.ComponentModel.DataAnnotations;

namespace EduHome.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Bu xana bosh ola bilmez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="this line must be as same as Password")]
        public string RepeatPassword { get; set; }
        public bool IsRemember { get; set; }

    }
}
