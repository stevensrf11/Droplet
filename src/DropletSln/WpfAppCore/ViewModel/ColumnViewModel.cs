using System;
using System.Collections.Generic;
using System.Text;
using WpfAppCore.Enums;

namespace WpfAppCore.ViewModel
{
    /// <summary>
    /// ColumnViewModel class
    /// Contains information for container columns
    /// </summary>
    public class ColumnViewModel
    {
        #region Property Accessors
        /// <summary>
        /// FieldName Get/Set Property Accessor
        /// Specifies the name of a data source field to which the column is bound.
        /// </summary>
        /// <value>string</value>
        public string FieldName { get; set; }


        /// <summary>
        /// HeaderName Get/Set Property Accessor
        /// Specifies the header displayed content
        /// </summary>
        /// <value>string</value>
        public string HeaderName { get; set; }

        /// <summary>
        /// Settings Get/Set Property Accessor
        /// Specifies state of column
        /// </summary>
        /// <value>SettingsType enum</value>        
        // Specifies the type of an in-place editor used to edit column values.
        public SettingsType Settings { get; set; }

        /// <summary>
        /// BindingPath Get/Set Property Accessor
        /// Specifies binding path name
        /// </summary>
        /// <value>string</value>
        public string BindingPath { get; set; }
        #endregion


    }
}
