using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCore.Business.Interfaces.Models.DataModels.AppModels;

namespace WebAppCore.Business.Models.AppModels
{
    /// <summary>
    /// BLWebAppCoreAppIndexModel business layer index model 
    /// derived from the <see cref="BLWebAppCoreAppModel"/> object,
    /// and the <seealso cref="IBLWebAppCoreAppIndexModel"/> interface.
    /// Contains index information
    /// </summary>
    public class BLWebAppCoreAppIndexModel : BLWebAppCoreAppModel
        , IBLWebAppCoreAppIndexModel
    {
        #region Property Accessors  
        /// <summary>
        /// RowIndex Get / Set Accessor
        /// Row index identifier
        /// </summary>
        /// <value> string</value>
        public string RowIndex { get; set; }

        /// <summary>
        /// ColumnIndex Get / Set Accessor
        /// Column index identifier
        /// </summary>
        /// <value> string</value>
        public string ColumnIndex { get; set; }
        #endregion

    }
}
