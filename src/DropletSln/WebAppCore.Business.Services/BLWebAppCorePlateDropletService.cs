using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebAppCore.Business.Interfaces.Models.DataModels.AppModels;
using WebAppCore.Business.Interfaces.Services;
using WebAppCore.Business.Models.AppModels;
using WebAppCore.Business.Models.FileModels.PlateDroplet;
using WebAppCore.Resources;

namespace WebAppCore.Business.Services
{
    /// <summary>
    /// BLWebAppCorePlateDropletService business layer plate droplet service 
    /// derived from the <see cref="BLWebAppCoreService"/> object,
    /// and the <see cref="IBLWebAppCorePlateDropletService"/> interface
    /// Provides plate droplet services
    /// </summary>

    public class BLWebAppCorePlateDropletService : BLWebAppCoreService
        , IBLWebAppCorePlateDropletService
    {
        #region Services
        #region LoadPlateDropletInformation

        /// <summary>
        /// LoadPlateDropletInformation service stub
        /// </summary>
        /// <param name="fileName">File name </param>
        /// <param name="error">Out parameter use to indication if error occurred during service</param>
        /// <returns>Collection of IBLWebAppCoreAppPlateDropletModel objects </returns>
        public IList<IBLWebAppCoreAppPlateDropletModel> LoadPlateDropletInformation(string fileName
            , out string error)
        {
            var plateDropletModels = new List<IBLWebAppCoreAppPlateDropletModel>();

            try
            {
                if (File.Exists(fileName))
                {
                    var jsonString = File.ReadAllText(fileName);
                    var fileInfo = JsonConvert.DeserializeObject<Root>(jsonString);
                    var wells= fileInfo.PlateDropletInfo.DropletInfo.Wells
                        .OrderBy(x => x.WellName)
                        .ThenBy(y => y.WellIndex)
                        .ToList();
                   plateDropletModels.AddRange(wells.Select(plateDropInfos => new BLWebAppCoreAppPlateDropletModel {DropletCount = plateDropInfos.DropletCount, RowIndex = plateDropInfos.WellName, ColumnIndex = plateDropInfos.WellIndex.ToString()}).Cast<IBLWebAppCoreAppPlateDropletModel>());
                   error = string.Empty;
                   return plateDropletModels;
                }
                else
                {
                    error = $"{ErrorResource.ErrMsg0} - {fileName}";
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return new List<IBLWebAppCoreAppPlateDropletModel>();
        }
        #endregion

        #endregion
    }
}
