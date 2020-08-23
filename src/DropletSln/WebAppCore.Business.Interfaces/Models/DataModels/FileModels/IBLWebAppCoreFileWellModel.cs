using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCore.Business.Interfaces.Models.DataModels.FileModels
{
    /// <summary>
    /// IBLWebAppCoreFileWellModel business layer file interface model
    /// derived from the <see cref="IBLWebAppCoreModel"/> interface
    /// Used to  store information from file
    /// </summary>

    public interface IBLWebAppCoreFileWellModel : IBLWebAppCoreModel
    {
        #region Property Accessors  
        /// <summary>
        /// WellName Get / Set Accessor
        /// </summary>
        /// <value> string</value>
        string WellName { get; set; }

        /// <summary>
        /// WellIndex Get / Set Accessor
        /// </summary>
        /// <value> int</value>
        int WellIndex { get; set; }

        /// <summary>
        /// DropletCount Get / Set Accessor
        /// </summary>
        /// <value> int</value>
        int DropletCount { get; set; }
        #endregion
    }
}
