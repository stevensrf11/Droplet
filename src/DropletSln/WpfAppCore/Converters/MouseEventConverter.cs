using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Grid;
using WpfAppCore.ViewModel;
using DevExpress.Mvvm.UI;

namespace WpfAppCore.Converters
{
    /// <summary>
    /// MouseEventConverter object derived from EventArgsConverterBase class parameter MouseButtonEventArgs
    /// Converts MouseButtonEventArgs to a SourceViewModel object
    /// </summary>
    public class MouseEventConverter : EventArgsConverterBase<MouseButtonEventArgs>
    {
        /// <summary>
        /// Converts MouseButtonEventArgs to a a SourceViewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>SourceViewModel object or null</returns>
        protected override object Convert(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as GridControl;
            var info = ((TableView)((GridControl)sender).View).CalcHitInfo((DependencyObject)e.OriginalSource);
            if (info.InRowCell
                && info.Column.VisibleIndex > 0
                && grid != null)
            {
                var selected = grid.SelectedItem as ObservableCollection<SourceViewModel>;
                return selected[info.Column.VisibleIndex];
            }
            return null;
        }
    }
}
