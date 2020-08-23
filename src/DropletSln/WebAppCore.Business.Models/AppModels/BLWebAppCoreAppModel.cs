using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCore.Business.Interfaces.Models.DataModels.AppModels;

namespace WebAppCore.Business.Models.AppModels
{

    /// <summary>
    /// BLWebAppCoreAppModel business layer application model object
    /// derived from the <see cref="BLWebAppCoreModel"/> object,
    /// and the <seealso cref="IBLWebAppCoreAppModel"/> interface
    /// </summary>

    public class BLWebAppCoreAppModel : BLWebAppCoreModel
        ,IBLWebAppCoreAppModel
    {
        #region Property Accessors
        /// <summary>
        /// AppId Get / Set Accessor
        /// Application Identification
        /// </summary>
        /// <value> long</value>
        public long AppId { get; set; }
        #endregion
    }
}
