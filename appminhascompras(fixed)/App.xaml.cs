namespace appminhascompras_fixed_
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ListaProduto());
            // troca a tela inicial para a tela de lista de produtos
        }
    }
}
