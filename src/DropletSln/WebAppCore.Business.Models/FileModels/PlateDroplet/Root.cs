using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCore.Business.Models.FileModels.PlateDroplet
{
    /// <summary>
    /// Root business layer class
    /// Used to store PlateDropletInfo file information
    /// </summary>
    public class Root
    {
        #region Property Accessors  
        /// <summary>
        /// PlateDropletInfo Get / Set Accessor
        /// Collection of PlateDropletInfo objects
        /// </summary>
        /// <value> Collection of DropletInfo objects</value>
        public PlateDropletInfo PlateDropletInfo { get; set; }
        #endregion
    }
}
