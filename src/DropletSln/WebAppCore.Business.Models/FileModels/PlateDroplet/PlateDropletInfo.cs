using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCore.Business.Models.FileModels.PlateDroplet
{
    /// <summary>
    /// PlateDropletInfo business layer class
    /// Used to store PlateDropletInfo state information
    /// </summary>
    public class PlateDropletInfo
    {
        #region Property Accessors  
        /// <summary>
        /// DropletInfo Get / Set Accessor
        /// Collection of DropletInfo objects
        /// </summary>
        /// <value> Collection of DropletInfo objects</value>
        public DropletInfo DropletInfo { get; set; }

        /// <summary>
        /// Version Get / Set Accessor
        /// PlateDropletInfo information version
        /// </summary>
        /// <value> int</value>
        public int Version { get; set; }
        #endregion
    }
}
