using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTCC.Models;
using AppTCC.Controller;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTCC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]


	public partial class PageCadastroPedido : ContentPage
	{
		private ObservableCollection<Produto> productsInCart = new ObservableCollection<Produto>();
		private List<Produto> produtosFromDatabase;


		public PageCadastroPedido()
		{
			InitializeComponent();


			produtosFromDatabase = ProdutoCon.ListarProdutosAgrupados();
			foreach (var produto in produtosFromDatabase)
			{
				productPicker.Items.Add(produto.nomeProduto);
				//productPicker.Items.Add(produto.cor);
			}

			cartListView.ItemsSource = productsInCart;
		}

		private void AddToCart_Clicked(object sender, EventArgs e)
		{
			if (productPicker.SelectedIndex >= 0)
			{

				var selectedProduct = produtosFromDatabase[productPicker.SelectedIndex];
				selectedProduct.quantidade = Convert.ToInt32(txtQuantidade.Text);
				productsInCart.Add(selectedProduct);
				
				
			}
		}
	}
}