namespace ListViewMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new NavigationPage(new MainPage()));
            window.Width = 450;
            return window;
        }
    }
}