namespace MyBusinessApplication
{
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using MyBusinessApplication.Web.Services;
    using System.Windows;
    using System;
    using System.ServiceModel.DomainServices.Client;
    using MyBusinessApplication.Web.Models;

    /// <summary>
    /// Home page for the application.
    /// </summary>
    public partial class Home : Page
    {
        /// <summary>
        /// Creates a new <see cref="Home"/> instance.
        /// </summary>
        public Home()
        {
            InitializeComponent();

            this.Title = ApplicationStrings.HomePageTitle;
        }

        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //ProdottoContext context = new ProdottoContext();
            //EntityQuery<Prodotto> query=  context.GetProdottiQuery();
            //context.Load<Prodotto>(query);
            //dataGrid.ItemsSource = context.Prodottos;
        }

        private void dataGrid_RowEditEnded(object sender, DataGridRowEditEndedEventArgs e)
        {
            ProdottoContext context = ddsProdotti.DomainContext as ProdottoContext;
            if (context.HasChanges)
            {
                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    ErrorWindow.CreateNew(ex);
                }
            }
        }

        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "IDProdotto")
            {
                e.Cancel = true;
            }
        }

        private void dataForm1_AutoGeneratingField(object sender, DataFormAutoGeneratingFieldEventArgs e)
        {
            if (e.PropertyName == "IDProdotto")
            {
                e.Cancel = true;
            }
        }

        private void dataForm1_EditEnded(object sender, DataFormEditEndedEventArgs e)
        {
            
            ProdottoContext context = ddsProdotti.DomainContext as ProdottoContext;
            if (context.HasChanges)
            {
                try
                {
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    ErrorWindow.CreateNew(ex);
                }
            }
        }
    }
}