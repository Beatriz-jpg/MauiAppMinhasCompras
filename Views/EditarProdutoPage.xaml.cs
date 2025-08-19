using MauiAppMinhasCompras.Helpers;
using MauiAppMinhasCompras.Models;
using Microsoft.Maui.Controls;
using System;

namespace MauiAppMinhasCompras.Views
{
    public partial class EditarProdutoPage : ContentPage
    {
        private Produto _produto;

        public EditarProdutoPage(Produto produto)
        {
            InitializeComponent();
            _produto = produto;
            BindingContext = _produto;
        }
       
    }
}