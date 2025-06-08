using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Service
    {
        public int Id { get; set; }
        [StringLength(14)]
        [Required(ErrorMessage ="Bu xana bosh ola bilmez")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeactive { get; set; }
    }
}
