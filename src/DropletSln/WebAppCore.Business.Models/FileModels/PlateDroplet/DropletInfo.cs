using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCore.Business.Models.FileModels
{
    /// <summary>
    /// DropletInfo business layer class
    /// Used to store DropletInfo state information
    /// </summary>
    public class DropletInfo
    {
        #region Property Accessors  
        /// <summary>
        /// Wells Get / Set Accessor
        /// Collection of Well objects
        /// </summary>
        /// <value> Collection of Well objects</value>
        public List<Well> Wells { get; set; }

        /// <summary>
        /// Version Get / Set Accessor
        /// Droplet information version
        /// </summary>
        /// <value> int</value>
        public int Version { get; set; }
        #endregion

    }
}
