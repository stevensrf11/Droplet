using System.Windows;
using System.Windows.Data;

namespace WpfAppCore.Helpers {
    /// <summary>
    /// ColumnBindingHelper object
    /// Used in xaml binding of grid column
    /// </summary>
    public class ColumnBindingHelper {
        #region Fields
        /// <summary>
        /// BindingPath Attached DependencyProperty
        /// Used in binding columns value from source
        /// </summary>
        /// <value>DependencyProperty</value>
        public static readonly DependencyProperty BindingPathProperty =
            DependencyProperty.RegisterAttached("BindingPath", 
                typeof(string), 
                typeof(ColumnBindingHelper),
                new PropertyMetadata(null, OnBindingPathChanged));

        #endregion
        #region Property Accessors
        #region BindingPath Get/Set Property Accessors
        /// <summary>
        /// GetBindingPath Get Property Accessor
        /// BindingPathProperty Get Accessory
        /// </summary>
        /// <param name="obj">Source of accessor property</param>
        /// <returns>string</returns>
        public static string GetBindingPath(DependencyObject obj)
        {
            return (string)obj.GetValue(BindingPathProperty);
        }

        /// <summary>
        /// SetBindingPath Set Property Accessor
        /// BindingPathProperty Set Accessory
        /// </summary>
        /// <param name="obj">Source of accessor property</param>
        /// <param name="value">Value to set property to</param>
        public static void SetBindingPath(DependencyObject obj, string value)
        {
            obj.SetValue(BindingPathProperty, value);
        }


        #endregion
        #endregion

        #region Utility Methods
        /// <summary>
        /// OnBindingPathChanged event change handler
        /// Called when the BindingPathProperty changed value
        /// </summary>
        /// <param name="d">Source of even property change</param>
        /// <param name="e">Event property change event information</param>
        private static void OnBindingPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var column = d as DevExpress.Xpf.Grid.GridColumn;
            if (column == null || e.NewValue == null)
                return;
            column.Binding = new Binding(e.NewValue.ToString());
        }
        #endregion


    }
}
