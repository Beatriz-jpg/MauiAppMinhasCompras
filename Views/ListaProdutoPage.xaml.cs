using MauiAppMinhasCompras.Helpers;
using MauiAppMinhasCompras.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras.Views
{
    public partial class ListaProdutoPage : ContentPage
    {
        public ListaProdutoPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CarregarProdutos();
        }

        private async Task CarregarProdutos()
        {
            var db = new SQLiteDatabaseHelper(App.DBPath);
            ProdutosList.ItemsSource = await db.GetAll();
        }

        private async void OnAdicionarProdutoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovoProdutoPage());
        }

        private async void OnProdutoSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                var produtoSelecionado = e.CurrentSelection[0] as Produto;
                await Navigation.PushAsync(new EditarProdutoPage(produtoSelecionado));
            }
        }

        private async void OnExcluirClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var produto = button.BindingContext as Produto;

            var db = new SQLiteDatabaseHelper(App.DBPath);
            await db.Delete(produto.Id);

            // Atualiza a lista após a exclusão
            await CarregarProdutos();
        }
    }
}