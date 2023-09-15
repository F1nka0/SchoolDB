using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    class ViewData {
        private ViewData() { }
        public static ViewData GetValues(SchoolDBEntities1 context) {
            ViewData result = new ViewData();
            var waiter = context.Teacher;
            result.teachers = waiter.ToList();
            return result;
        }
        public List<Lesson> lessons = new List<Lesson>();
        public List<Mark> marks = new List<Mark>();
        public List<Palor> palors = new List<Palor>();
        public List<Pupil> pupils = new List<Pupil>();
        public List<Teacher> teachers = new List<Teacher>();
        public List<ReportCard> reportCards = new List<ReportCard>();
        public List<Schedule> schedules = new List<Schedule>();

    }
    public partial class MainWindow : Window
    {
        SchoolDBEntities1 Context;
        public MainWindow()
        {
            InitializeComponent();
            Context= new SchoolDBEntities1();

            //Context.Teacher.Add(new Teacher() { SubjectName="Science",TeacherName= "Fredd"});
            Context.SaveChanges();
        }

        private async void RefreshGeneralSelect(object sender, RoutedEventArgs e)
        {   var res = await (Task.Run(() => ViewData.GetValues(Context)));
            GenerealSelect.ItemsSource = res.teachers.ToArray();
            GenerealSelect.UpdateLayout();
        }
    }
}
