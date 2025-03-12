using appminhascompras_fixed_.Models;

namespace appminhascompras_fixed_.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        // Adicione aqui a lógica que deve ser executada quando o item da barra de ferramentas for clicado
        try
        {
            Produto p = new Produto
            {
                Descricao = txt_descrição.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                preco = Convert.ToDouble(txt_preco.Text)
            };
            await App._Db.Insert(p);
            await DisplayAlert("Sucesso", "Produto inserido com sucesso", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}

