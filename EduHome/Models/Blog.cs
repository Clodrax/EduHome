﻿namespace EduHome.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string By { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeactive { get; set; }
    }
}
