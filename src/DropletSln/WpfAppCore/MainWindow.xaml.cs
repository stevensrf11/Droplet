using System.ComponentModel;
using System.Windows;
using DevExpress.Xpf.Grid;
using WebAppCore.Business.Services;
using  WpfAppCore.ViewModel;

namespace WpfAppCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            
            DataContext = new MainViewModel(new BLWebAppCorePlateDropletService());
        }

        /// <summary>
        /// TableView Loaded event handler
        /// Use to size column rows to grid
        /// </summary>
        /// <param name="sender">TableView control</param>
        /// <param name="e">RouteEventArgs</param>
        private void TableVieOnLoaded(object sender, RoutedEventArgs e)
        {
            //GridControl.Width= this.ActualWidth;
            if (sender is TableView tableView)
            {
                tableView.Width = this.ActualWidth;
                //  tableView.HorizontalAlignment = HorizontalAlignment.Stretch;
                var columnWidth = tableView.Width / tableView.VisibleColumns.Count;
                columnWidth = (tableView.Width - columnWidth) / tableView.VisibleColumns.Count;

                foreach (var item in tableView.VisibleColumns)
                {
                    item.Width = columnWidth;
                    //        tableView.BestFitColumn(item);
                }
            }
        }
    }
}
