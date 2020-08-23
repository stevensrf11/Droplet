using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCore.Business.Interfaces.Models.DataModels.AppModels;

namespace WebAppCore.Business.Interfaces.Services
{
    /// <summary>
    /// IBLWebAppCorePlateDropletService business layer plate droplet service interface
    /// derived from the <see cref="IBLWebAppCoreService"/>
    /// Provides plate droplet service stubs
    /// </summary>
    public interface IBLWebAppCorePlateDropletService : IBLWebAppCoreService
    {
        #region Services 
        #region LoadPlateDropletInformation
        /// <summary>
        /// LoadPlateDropletInformation service stub
        /// </summary>
        /// <param name="fileName">File name </param>
        /// <param name="error">Out parameter use to indication if error occurred during service</param>
        /// <returns>Collection of IBLWebAppCoreAppPlateDropletModel objects </returns>
        IList<IBLWebAppCoreAppPlateDropletModel> LoadPlateDropletInformation(string fileName
            , out string error);
        #endregion

        #endregion
    }
}
