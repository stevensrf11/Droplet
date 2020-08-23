using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfAppCore.ViewModel
{
    public class FileModel
    {
        #region Property Accessors
       /// <summary>
       /// FileName Accessor Get
       /// </summary>
       /// <value>string</value>
        public string FileName { get; private set; }

       /// <summary>
       /// FileId Accessor Get
       /// </summary>
       /// <value>int</value>
        public string FileId { get; private set; }

        #endregion

        /// <summary>
        /// FileDisplay Accessor Get
        /// </summary>
        /// <value>string</value>
        public string FileDisplay { get; private set; }

        #region Constructor
        public FileModel(string fileName
            , string fileId
            , string fileDisplay)
        {
            FileName = fileName;
            FileId = fileId;
            FileDisplay = fileDisplay;
        }
        #endregion
    }
}
