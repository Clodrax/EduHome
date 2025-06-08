
namespace EduHome.Models
{
    public class About
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsDeactive { get; set; }

        public static implicit operator List<object>(About v)
        {
            throw new NotImplementedException();
        }
    }
}
