﻿using EduHome.Models;

namespace EduHome.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Service> Services { get; set; }
        public About About { get; set; }
        public List<Course> Courses { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
