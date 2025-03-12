using appminhascompras_fixed_.Helpers;

namespace appminhascompras_fixed_
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db; //aqui falando pro vs que estamos usando sql 

        public static SQLiteDatabaseHelper _Db
        {
            get
            {
                if(_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BANCO_SQL_COMPRAS.db3");
                    _db = new SQLiteDatabaseHelper(path);
                }
                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ListaProduto());
            // troca a tela inicial para a tela de lista de produtos
        }
    }
}
