using MauiAppMinhasCompras.Helpers;
using MauiAppMinhasCompras.Models;
using Microsoft.Maui.Controls;
using System;

namespace MauiAppMinhasCompras.Views
{
    public partial class NovoProdutoPage : ContentPage
    {
        public NovoProdutoPage()
        {
            InitializeComponent();
        }

        private async void OnAdicionarClicked(object sender, EventArgs e)
        {
            var produto = new Produto
            {
                Descricao = txtDescricao.Text,
                Quantidade = double.Parse(txtQuantidade.Text),
                Preco = double.Parse(txtPreco.Text)
            };

            var db = new SQLiteDatabaseHelper(App.DBPath);
            await db.Insert(produto);
            await Navigation.PopAsync();
        }

        // Novo método para o botão "Voltar"
        private async void OnVoltarClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}