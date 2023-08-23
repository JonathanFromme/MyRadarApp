using MyRadarQuizApp.Models;
using MyRadarVideoApp.Views;

namespace MyRadarVideoApp
{
    public partial class App : Application
    {
        public static VideoItemManager VideoManager { get; private set; }
        public App()
        {
            InitializeComponent();

            VideoManager = new VideoItemManager(new RestService());
            MainPage = new NavigationPage(new VideoListPage());

        }
    }
}