using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCore.Business.Interfaces.Models.DataModels.AppModels
{
    /// <summary>
    /// IBLWebAppCoreAppPlateDropletModel business layer application plate droplet model interface
    /// derived from the <see cref="IBLWebAppCoreAppIndexModel"/> interface.
    /// </summary>
    public interface IBLWebAppCoreAppPlateDropletModel : IBLWebAppCoreAppIndexModel
    {
        #region Property Accessors  
        /// <summary>
        /// DropletCount Get / Set Accessor
        /// Number of droplets
        /// </summary>
        /// <value> int </value>
        int DropletCount  { get; set; }

        #endregion
    }
}
