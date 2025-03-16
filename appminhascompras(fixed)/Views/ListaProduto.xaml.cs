using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using SQLite;

namespace appminhascompras_fixed_.Views
{
    public partial class ListaProduto : ContentPage
    {
        private ObservableCollection<Item> ItensFiltrados { get; set; }
        private List<Item> _todosOsItens;
        private CancellationTokenSource _cts;

        public ListaProduto()
        {
            InitializeComponent();
            _todosOsItens = new List<Item>
            {
                new Item { Nome = "Arroz" },
                new Item { Nome = "Feijão" },
                new Item { Nome = "Macarrão" },
                new Item { Nome = "Leite" }
            };

            ItensFiltrados = new ObservableCollection<Item>(_todosOsItens);
            _cts = new CancellationTokenSource();

            // Definir a BindingContext para que a UI reflita os dados corretamente
            BindingContext = this;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Views.NovoProduto());
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            try
            {
                await Task.Delay(500, _cts.Token); // Aguarda antes de filtrar para evitar chamadas excessivas
                FiltrarDados(e.NewTextValue);
            }
            catch (TaskCanceledException) { }
        }

        private void FiltrarDados(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                // Restaurar a lista original se não houver texto de pesquisa
                AtualizarLista(_todosOsItens);
            }
            else
            {
                // Filtrar e atualizar a coleção observável
                var resultado = _todosOsItens
                    .Where(i => i.Nome.Contains(texto, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                AtualizarLista(resultado);
            }
        }

        private void AtualizarLista(List<Item> itens)
        {
            ItensFiltrados.Clear();
            foreach (var item in itens)
            {
                ItensFiltrados.Add(item);
            }
        }

        public ObservableCollection<Item> ItensFiltradosExibidos => ItensFiltrados;
    }

    public class Item
    {
        public string Nome { get; set; } = string.Empty;
    }
}
