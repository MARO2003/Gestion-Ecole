using demo_iteraive1.Domain.Services;
using demo_iteraive1.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_iteraive1.Buisness
{
    public class App
    {
        public StudentService studentService;
        public CourseService courseService;
        private MainMenu mainMenu;
        public App()
        {

            ApplicationConfiguration.Initialize();
            this.studentService = new StudentService();
            this.courseService = new CourseService();
            this.mainMenu = new MainMenu(this);
        }

        public void Start()
        {
            Application.Run(this.mainMenu);
        }
    }
}
