﻿namespace EduHome.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Position { get; set; }
        public bool IsDeactive { get; set; }

    }
}
