namespace DataBinding.XamlElement
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            EnteredTextLabel.Text=string.Empty;
        }
        private void Entry_Changed_TextChanged(object sender, EventArgs e) {
            EnteredTextLabel.Text= TextEntry.Text;
        }

    }
}
