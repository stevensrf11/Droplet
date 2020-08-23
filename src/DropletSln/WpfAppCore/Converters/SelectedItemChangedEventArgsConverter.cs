using System;
using System.Windows.Markup;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Grid;

namespace WpfAppCore.Converters
{
    /// <summary>
    /// SelectedItemChangedEventArgsConverter class
    /// Derived from <see cref="MarkupExtension"/> object, and the <seealso cref="IEventArgsConverter"/> interface
    /// Used in the xaml to convert an EventArg object to a particular type
    /// </summary>
    public class SelectedItemChangedEventArgsConverter : MarkupExtension, IEventArgsConverter
    {
        #region IEventArgsConverter Implementation
        /// <summary>
        ///   Converts the event argument to the command's parameter.
        /// </summary>
        /// <param name="sender">The event's sender.</param>
        /// <param name="args">The event's argument.</param>
        /// <returns>The command's parameter.</returns>
        public object Convert(object sender, object args)
        {
            if (args is SelectedItemChangedEventArgs eventArgs)
                return eventArgs.NewItem;
            return null;
        }
        #endregion

        #region MarkupExtension Implementation
        /// <summary>
        ///  Returns an object that is provided as the value of the target property for this markup extension.
        /// </summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension</param>
        /// <returns>Reference to class</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #endregion
    }

}
