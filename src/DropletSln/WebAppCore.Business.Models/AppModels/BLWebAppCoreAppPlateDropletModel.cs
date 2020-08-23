using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCore.Business.Interfaces.Models.DataModels.AppModels;

namespace WebAppCore.Business.Models.AppModels
{
    /// <summary>
    /// BLWebAppCoreAppPlateDropletModel business layer application plate droplet model object
    /// derived from the <see cref="BLWebAppCoreAppIndexModel"/> object,
    /// and the <seealso cref="IBLWebAppCoreAppPlateDropletModel"/> interface
    /// </summary>
    public class BLWebAppCoreAppPlateDropletModel: BLWebAppCoreAppIndexModel
        , IBLWebAppCoreAppPlateDropletModel
    {
        #region Property Accessors  
        /// <summary>
        /// DropletCount Get / Set Accessor
        /// Number of droplets
        /// </summary>
        /// <value> int </value>
        public int DropletCount { get; set; }

        #endregion

    }
}
