using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCore.Business.Interfaces.Models.DataModels.AppModels
{
    /// <summary>
    /// IBLWebAppCoreAppModel business layer application model interface
    /// derived from the <see cref="IBLWebAppCoreModel"/> interface
    /// </summary>
    public interface IBLWebAppCoreAppModel : IBLWebAppCoreModel
    {
        #region Property Accessors
        /// <summary>
        /// AppId Get / Set Accessor
        /// Application Identification
        /// </summary>
        /// <value> long</value>
         long AppId { get; set; }
        #endregion
    }
}
