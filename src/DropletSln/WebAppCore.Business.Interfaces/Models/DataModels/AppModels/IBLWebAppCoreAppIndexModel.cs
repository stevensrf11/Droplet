using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCore.Business.Interfaces.Models.DataModels.AppModels
{
    /// <summary>
    /// IBLWebAppCoreAppIndexModel business layer index model interface
    /// derived from the <see cref="IBLWebAppCoreAppModel"/> interface
    /// Contains index information
    /// </summary>
    public interface IBLWebAppCoreAppIndexModel : IBLWebAppCoreAppModel
    {
        #region Property Accessors  
        /// <summary>
        /// RowIndex Get / Set Accessor
        /// Row index identifier
        /// </summary>
        /// <value> string</value>
        string RowIndex { get; set; }

        /// <summary>
        /// ColumnIndex Get / Set Accessor
        /// Column index identifier
        /// </summary>
        /// <value> string</value>
        string ColumnIndex { get; set; }
        #endregion

    }
}
