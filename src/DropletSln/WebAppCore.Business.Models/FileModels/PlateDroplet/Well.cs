using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCore.Business.Interfaces.Models.DataModels.FileModels;

namespace WebAppCore.Business.Models.FileModels
{

    /// <summary>
    /// Well business layer file  model derived from the <see cref="BLWebAppCoreModel"/> class,
    /// and <seealso cref="IBLWebAppCoreFileWellModel"/>
    /// Used to  Wells section information from a file
    /// </summary>
    public class Well : BLWebAppCoreModel
    , IBLWebAppCoreFileWellModel
    {
        #region Property Accessors  
        /// <summary>
        /// WellName Get / Set Accessor
        /// Contains row index name
        /// </summary>
        /// <value> string</value>
        public string WellName { get; set; }

        /// <summary>
        /// WellIndex Get / Set Accessor
        /// Contain column index name
        /// </summary>
        /// <value> int</value>
        public int WellIndex { get; set; }

        /// <summary>
        /// DropletCount Get / Set Accessor
        /// Contains the number of count of droplets
        /// </summary>
        /// <value> int</value>
        public int DropletCount { get; set; }
        #endregion

    }
}
