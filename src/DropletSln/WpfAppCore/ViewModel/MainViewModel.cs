using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using DevExpress.Mvvm;
using WebAppCore.Business.Interfaces.Models.DataModels.AppModels;
using WebAppCore.Business.Interfaces.Services;
using WebAppCore.Resources;
using WpfAppCore.Enums;

namespace WpfAppCore.ViewModel
{


    /// <summary>
    /// MainViewModel class derived from the interface <see cref="INotifyPropertyChanged"/> 
    /// Used an view model from main view window
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        /// <summary>
        /// _dropletThresholdValue Field
        /// Droplet threshold value
        /// </summary>
        /// <value>string</value>
        private string _dropletThresholdValue;

        /// <summary>
        /// _columns Field
        /// Contains container column information
        /// </summary>
        /// <value> Collection of Column objects</value>
        private ObservableCollection<ColumnViewModel> _columns;

        /// <summary>
        /// _sourceViewModels  Field
        /// Contains containers droplet information
        /// </summary>
        /// <value> Collection of Collection of SourceViewModels</value>
        private ObservableCollection<ObservableCollection<SourceViewModel>> _sourceViewModels;
        private ObservableCollection<FileModel> _fileModels;

        /// <summary>
        /// _selectedSourceViewModels Field
        /// Contains containers selected row od droplet information
        /// </summary>
        /// <value> Collection of SourceViewModels</value>
        private ObservableCollection<SourceViewModel> _selectedSourceViewModels;

        /// <summary>
        /// Constant string for setting display droplet information
        /// </summary>
        private const string Filler3EmptySpaces = "   ";
        private const string Filler4EmptySpaces = "    ";
        private const string Filler5EmptySpaces = "     ";
        private const string Filler6EmptySpaces = "      ";

        /// <summary>
        /// _isWaitIndicatorVisible Field
        /// Determines the visible state of the busy indicator
        /// </summary>
        /// <value>true</value>
        private bool _isWaitIndicatorVisible;

        /// <summary>
        /// _dropletCountTitle Field
        /// Number of droplets title  for a droplet object
        /// </summary>
        /// <values>string</values>
        private string _dropletCountTitle;

        /// <summary>
        /// _dropletCountText Field
        /// Number of droplets for a droplet object
        /// </summary>
        /// <values>string</values>
        private string _dropletCountText;

        /// <summary>
        /// _dropletIdentifierTitle Field
        /// Identifier  title of  droplet object
        /// </summary>
        /// <values>string</values>
        private string _dropletIdentifierTitle;

        /// <summary>
        /// _dropletIdentifierText Field
        /// Identifier  of  droplet object
        /// </summary>
        /// <values>string</values>
        private string _dropletIdentifierText;

        /// <summary>
        /// _waitIndicatorText Field
        /// Determines the text displayed when the busy indicator is visible
        /// </summary>
        /// <values>string</values>
        private string _waitIndicatorText;

        /// <summary>
        /// _isLayoutEnabled Field
        /// Determines the layout enable state for an object
        /// True is enabled  False is disabled
        /// </summary>
        /// <values>boolean</values>
        private bool _isLayoutEnabled;

        /// <summary>
        /// PropertyChanged  Field
        /// Event that occurs when a property value changes.
        /// </summary>
        /// <value>event PropertyChangedEventHandler </value>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// _selectedItemChangedCommand
        ///  Command for when droplet information to load is selected
        /// </summary>
        /// <value> ICommand</value>
        private ICommand _selectedItemChangedCommand;

        /// <summary>
        /// _blWebAppCorePlateDropletService Field
        /// Droplet business layer service
        /// </summary>
        /// <value>IBLWebAppCorePlateDropletService</value>
        private readonly IBLWebAppCorePlateDropletService _blWebAppCorePlateDropletService;


        #endregion

        #region Constructor
        /// <summary>
        /// MainViewModel parameterized constructor
        /// </summary>
        /// <param name="blWebAppCorePlateDropletService">Droplet business layer service referecnce</param>
        public MainViewModel(IBLWebAppCorePlateDropletService blWebAppCorePlateDropletService)
        {

            _blWebAppCorePlateDropletService = blWebAppCorePlateDropletService;
            Initialize();

            IsLayoutEnabled = true;
           
            // SourceViewModels = new ObservableCollection<SourceViewModel>();

            string error;
            var p = LoadDropletInformation(SelectedFileModel.FileName, out error);

            UpdateDropletDisplay(p);



        }
        #endregion

        #region Property Accessors
        /// <summary>
        /// SelectedFileModel Get / Set Property Accessor
        /// Contains selected file name information to load droplet information
        /// </summary>
        public FileModel SelectedFileModel { get; set; }

        #region Command Propety Accessors
        
        /// <summary>
        /// SelectedItemChangedCommand Command Get  Property Accessor
        /// Chooses droplet source information to load
        /// </summary>
        /// <value>ICommand</value>
        public ICommand SelectedItemChangedCommand
        {
            get
            {
                return _selectedItemChangedCommand ??= new DelegateCommand<object>(SelectedItemChangedCommandExecute);
            }
        }

        /// <summary>
        /// PreviewMouseDownCommand Get Property Accessor
        /// Handle the PreviewMouseDown click event on a container cell
        /// </summary>
        /// <value>ICommand argument SourceViewModel </value>
        public ICommand<SourceViewModel> PreviewMouseDownCommand { get; private set; }

        /// <summary>
        /// LoadSelectedSourceViewModeCommand Get Accessor Property
        /// Selected SourceViewModel object selected
        /// </summary>
        /// <value>ICommand</value>
        public ICommand LoadSelectedSourceViewModelCommand { get; private set; }

       /// <summary>
        /// DropletThresholdCommand Accessor Get / Set
        /// Update droplet information command
        /// </summary>
        /// <value> ICommand type paramater string</value>
        public ICommand<string> DropletThresholdCommand { get; private set; }

        #endregion

        #region Notifcation Binding Property Accessors
       /// <summary>
        /// DropletIdentifierTitle Get/ Set Notification Binding Property Accessor
        /// Identifier  title of  droplet object
        /// </summary>
        /// <value> string</value>
        public string DropletIdentifierTitle
        {
            get => _dropletIdentifierTitle;
            set => SetProperty(ref _dropletIdentifierTitle, value, "DropletIdentifierTitle");
        }
        
        /// <summary>
        /// DropletIdentifierText Get/ Set Notification Binding Property Accessor
        /// Identifier  of  droplet object
        /// </summary>
        /// <value> string</value>
        public string DropletIdentifierText
        {
            get => _dropletIdentifierText;
            set => SetProperty(ref _dropletIdentifierText, value, "DropletIdentifierText");
        }


        /// <summary>
        /// DropletCountTitle Get/ Set Notification Property Accessor
        ///  Number of droplets title for a droplet object
        /// </summary>
        /// <value> string</value>
        public string DropletCountTitle
        {
            get => _dropletCountTitle;
            set => SetProperty(ref _dropletCountTitle, value, "DropletCountTitle");
        }


        /// <summary>
        /// DropletCountText Get/ Set Notification Binding Property Accessor
        ///  Number of droplets for a droplet object
        /// </summary>
        /// <value> string</value>
        public string DropletCountText
        {
            get => _dropletCountText;
            set => SetProperty(ref _dropletCountText, value, "DropletCountText");
        }


        /// <summary>
        /// IsLayoutEnabled Get/ Set Notification Binding Property Accessor
        /// Determines the layout enable state for an object
        /// True is enabled  False is disabled
        /// </summary>
        /// <value> boolean</value>
        public bool IsLayoutEnabled
        {
            get => _isLayoutEnabled;
            set => SetProperty(ref _isLayoutEnabled, value, "IsLayoutEnabled");

        }


        /// <summary>
        /// IsWaitIndicatorVisible Get/ Set Notification Binding Property Accessor
        /// Determines the state of the busy indicator
        /// True show the indicator false hides it
        /// </summary>
        /// <value> boolean</value>
        public bool IsWaitIndicatorVisible
        {
            get => _isWaitIndicatorVisible;
            set => SetProperty(ref _isWaitIndicatorVisible, value, "IsWaitIndicatorVisible");

        }

        /// <summary>
        /// WaitIndicatorText Get/ Set Notification Binding Property Accessor
        /// Text displayed in the busy indicator when displayed
        /// </summary>
        /// <value> string</value>
        public string WaitIndicatorText
        {
            get => _waitIndicatorText;
            set => SetProperty(ref _waitIndicatorText, value, "WaitIndicatorText");
        }

        /// <summary>
        /// FileModels  Get/ Set Notification Binding Property Accessor
        /// Contains collection of file information
        /// </summary>
        /// <value> Collection of FileModel objects</value>
        public ObservableCollection<FileModel> FileModels
        {
            get => _fileModels;
            set => SetProperty(ref _fileModels, value, "FileModels");
        }

        /// <summary>
        /// DropletThresholdValue Notification Binding Property Accessor
        /// Threshold limit value
        /// </summary>
        /// <value> string</value>
        public string DropletThresholdValue
        {
            get => _dropletThresholdValue;
            set
            {
                ///this.RaiseCanExecuteChanged(c => c.DropletThresholdCanExecute(value));
                if (!string.IsNullOrEmpty(value))
                {
                    SetProperty(ref _dropletThresholdValue, value, "DropletThresholdValue");

                }
            }
        }

        /// <summary>
        /// Columns Notification Binding Property Accessor
        /// Contains column information for droplet display
        /// </summary>
        /// <value> Collection of Column objects</value>
        public ObservableCollection<ColumnViewModel> Columns
        {
            get => _columns;
            set => SetProperty(ref _columns, value, "Columns");
        }
       
        /// <summary>
        /// SourceViewModels Notification Binding Property Accessor
        /// Contains  droplet information
        /// </summary>
        /// <value> Collection of SourceViewModel objects</value>
        public ObservableCollection<ObservableCollection<SourceViewModel>> SourceViewModels
        {
            get => _sourceViewModels;
            set => SetProperty(ref _sourceViewModels, value, "SourceViewModels");
        }


        #endregion
     
        #endregion

        #region Command Event Handlers

        #region SelectedItemChangedCommand Command Event Handlers

        /// <summary>
        /// SelectedItemChangedCommandExecute Executed even handler
        /// </summary>
        /// <param name="selectedFileModel"> Selected droplet information selection</param>
        private async void SelectedItemChangedCommandExecute(object selectedFileModel)
        {
            // Disable window
            IsLayoutEnabled = false;

            // Set busy indicator display text
            WaitIndicatorText = "Loading droplet information";

            // Show busy signal
            IsWaitIndicatorVisible = true;

            //If new selection load new droplet information and reset displays
            if (selectedFileModel is FileModel selected
                &&
                string.Compare(selected.FileId, SelectedFileModel.FileId, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                // Set selection
                SelectedFileModel = selected;

                // Reset droplet display information
                DropletCountTitle = $"{WebAppCoreResource.DropletCount}:";
                DropletIdentifierTitle = $"{WebAppCoreResource.DropletIdentifier}:";
                DropletCountText = String.Empty;
                DropletIdentifierText = String.Empty;

                // Reset Droplet Source Information
                SourceViewModels.Clear();
                SourceViewModels = new ObservableCollection<ObservableCollection<SourceViewModel>>();

                // Load droplet information based on selection
                string error;
                var p = LoadDropletInformation(SelectedFileModel.FileName, out error);

                // Update displays
                UpdateDropletDisplay(p);
            }


            // Remove busy indicator 
            IsWaitIndicatorVisible = false;

            // Enable window
            IsLayoutEnabled = true;
        }


        #endregion


        #region PreviewMouseDown Command Handlers - Container selection
        /// <summary>
        /// PreviewMouseDownCanExecute can execute command handler
        /// Determines if corresponding PreviewMouseDownCanExecute can be called
        /// </summary>
        /// <param name="sourceViewModel">Selected droplet view model</param>
        ///<returns>true</returns>
        public bool PreviewMouseDownCanExecute(SourceViewModel sourceViewModel)
        {
            return true;//sourceViewModel != null;
        }

        /// <summary>
        /// PreviewMouseDownExecuted executed command handler
        /// Used to obtain selected droplet view model in container
        /// </summary>
        /// <param name="sourceViewModel">Selected droplet view model</param>
        public void PreviewMouseDownExecuted(SourceViewModel sourceViewModel)
        {
            if (sourceViewModel == null && _selectedSourceViewModels != null)
            {
                var sbDropletCountText = new StringBuilder();
                var sbDropletIdentifierText = new StringBuilder();

                DropletCountTitle = $"{WebAppCoreResource.DropletInformation}:";
                DropletIdentifierTitle = String.Empty;

                DropletIdentifierText = String.Empty;



                var selectedSourceViewModels = _selectedSourceViewModels.Skip(1);
                foreach (var sModel in selectedSourceViewModels)
                {
                    sbDropletCountText.Append($"{sModel.DropletIdentifier}:");
                    sbDropletCountText.Append($"{sModel.DropletCount.ToString()}; ");

                }

                DropletCountText = sbDropletCountText.ToString();

            }
            else if (sourceViewModel != null)
            {
                DropletCountTitle = $"{WebAppCoreResource.DropletCount}:";
                DropletIdentifierTitle = $"{WebAppCoreResource.DropletIdentifier}:";
                DropletCountText = sourceViewModel.DropletCount.ToString();
                DropletIdentifierText = sourceViewModel.DropletIdentifier;

            }
            else
            {
                DropletCountTitle = $"{WebAppCoreResource.DropletCount}:";
                DropletIdentifierTitle = $"{WebAppCoreResource.DropletIdentifier}:";
                DropletCountText = String.Empty;
                DropletIdentifierText = String.Empty;
            }
        }
        #endregion

        #region DropletThreshold Command Event Handlers
        /// <summary>
        /// DropletThresholdExecute execute command handler
        /// Updates container droplet display base on threshold value
        /// </summary>
        /// <param name="threshold">Threshold value</param>
        public void DropletThresholdExecute(string threshold)
        {
            // Disable window
            IsLayoutEnabled = false;

            // Set busy indicator display text
            WaitIndicatorText = "Updating droplet information";

            // Show busy signal
            IsWaitIndicatorVisible = true;
            var theshold = Convert.ToInt32(DropletThresholdValue);
            var ss = new ObservableCollection<ObservableCollection<SourceViewModel>>();
            foreach (var models in SourceViewModels)
            {
                var notSkip = false;
                foreach (var model in models)
                {
                    if (notSkip)
                        model.FieldName = model.DropletCount > theshold ? "n" : "L";
                    notSkip = true;
                }
                ss.Add(models);
            }


            // Enable window
            IsLayoutEnabled = true;


            // Hide busy indicator
            IsWaitIndicatorVisible = false;

        }
        /// <summary>
        /// DropletThresholdCanExecute can execute command handler
        /// Determines if the DropletThresholdExecute handler can be executed
        /// </summary>
        /// <param name="threshold"></param>
        /// <returns>True is threshold parameter is not null or and empty string</returns>
        public bool DropletThresholdCanExecute(string threshold)
        {
            return !string.IsNullOrEmpty(threshold);
        }
        #endregion

        #endregion


        #region INotifyPropertyChanged Implementation

        /// <summary>
        /// NotifyPropertyChanged method
        /// Updates binding between XAML and Property
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// SetProperty method
        /// Sets the property accessor value and  notifies xaml / property binding
        /// </summary>
        /// <typeparam name="T">Property accessor field</typeparam>
        /// <param name="storage"></param>
        /// <param name="value">Value to update property accessor field to</param>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T storage, T value, string propertyName)
        {
            if ((storage == null && value == null) ||
                (storage != null && storage.Equals(value)))
                return false;

            storage = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region ICommand Implementation

        #endregion


        // public IDispatcherService DispatcherService { get { return GetService<IDispatcherService>(); } }

        //[Command]
        //public void GridItemsSourceChanged(RoutedEventArgs e)
        //{
        //    DispatcherService.BeginInvoke(() => {
        //        GridControl grid = e.Source as GridControl;
        //        if (grid != null)
        //        {
        //            grid.Columns.FirstOrDefault().SortIndex = 0;
        //            ((TableView)grid.View).BestFitColumns();
        //        }
        //    });
        //}

        private void LoadSelectedSourceViewModel(ObservableCollection<SourceViewModel> obj)
        {
            _selectedSourceViewModels = obj;
        }






        #region Utility Methods

        #region Initialization
        /// <summary>
        /// Initialize method
        /// Initialize command and settings
        /// </summary>
        private void Initialize()
        {

            InitializeDropletSettings();
            InitializeCommands();
        }

        /// <summary>
        /// InitializeDropletSettings methods
        /// Initializes droplet settings and objects
        /// </summary>
        private void InitializeDropletSettings()
        {
            DropletCountTitle = $"{WebAppCoreResource.DropletCount}:";
            DropletIdentifierTitle = $"{WebAppCoreResource.DropletIdentifier}:";
            DropletCountText = String.Empty;
            DropletIdentifierText = String.Empty;

            FileModels = new ObservableCollection<FileModel>
            {
                new FileModel(WebAppCoreResource.PlateDropleFile, WebAppCoreResource.PlateDropleFileId,
                    WebAppCoreResource.PlateDropleFileDisplay),
                new FileModel(WebAppCoreResource.PlateDropletInfoFile48, WebAppCoreResource.PlateDropletInfoFile48Id,
                    WebAppCoreResource.PlateDropletInfoFile48Display)
            };
            SelectedFileModel = FileModels[0];

            DropletThresholdValue = 100.ToString();
            SourceViewModels = new ObservableCollection<ObservableCollection<SourceViewModel>>();

        }

        /// <summary>
        /// InitializeCommands method
        /// Initialize ICommand objects
        /// </summary>
        private void InitializeCommands()
        {
            LoadSelectedSourceViewModelCommand = new DelegateCommand<ObservableCollection<SourceViewModel>>(LoadSelectedSourceViewModel);
            DropletThresholdCommand = new DelegateCommand<string>(DropletThresholdExecute, DropletThresholdCanExecute);
            PreviewMouseDownCommand = new DelegateCommand<SourceViewModel>(PreviewMouseDownExecuted, PreviewMouseDownCanExecute);

        }
        #endregion

        #region Business Layer Plate Droplet Serives

        /// <summary>
        /// LoadDropletInformation method
        /// Load droplet information
        /// </summary>
        /// <param name="fileName">Drop;et filename</param>
        /// <param name="error">out parameter used to indicate if an error occurred during the operation</param>
        /// <returns>Collection of IBLWebAppCoreAppPlateDropletModel objects</returns>
        private IList<IBLWebAppCoreAppPlateDropletModel> LoadDropletInformation(string fileName, out string error)
        {
            var fileNameFullpath =
                $"{Directory.GetCurrentDirectory()}\\{WebAppCoreResource.PlateDropletDirectory}\\{fileName}";
            return _blWebAppCorePlateDropletService.LoadPlateDropletInformation(fileNameFullpath, out error);

        }

        #endregion

        /// <summary>
        /// UpdateDropletDisplay method
        /// Updates drop displays based on new droplet information
        /// </summary>
        /// <param name="dropletModels">Collection of  droplet information</param>
        private void UpdateDropletDisplay(IList<IBLWebAppCoreAppPlateDropletModel> dropletModels)
        {
            var dict = new Dictionary<int, IList<IBLWebAppCoreAppPlateDropletModel>>();
            var columnCount = dropletModels
                .Count(x => string.Compare(x.RowIndex.Substring(0, 1), "A", StringComparison.OrdinalIgnoreCase) == 0);

            Columns = new ObservableCollection<ColumnViewModel>
            {
                new ColumnViewModel
                {
                    HeaderName = string.Empty,
                    FieldName = "FieldName",
                    Settings = SettingsType.Hidden,
                    BindingPath = "[" + (0).ToString() + "]"
                }
            };
            for (var i = 1; i <= columnCount; i++)
            {
                Columns.Add(new ColumnViewModel
                {
                    HeaderName = i.ToString(),
                    FieldName = "FieldName",
                    Settings = SettingsType.Default,
                    BindingPath = "[" + (i).ToString() + "]"
                });
            }

            var rowCount = dropletModels.Count / columnCount;
            for (int index = 0; index < rowCount; index++)
            {
                var svList = dropletModels.Skip(index * columnCount).Take(columnCount).ToList();
                var svModels = new ObservableCollection<SourceViewModel>
                    {
                        new SourceViewModel {
                            DropletCount = -1
                            , FieldName = svList[0].RowIndex[0].ToString()
                            ,DropletIdentifier=svList[0].RowIndex
                        }
                    };
                foreach (var svListItem in svList)
                {
                    svModels.Add(new SourceViewModel
                    {
                        DropletCount = svListItem.DropletCount,
                        FieldName = svListItem.DropletCount <= Convert.ToInt32(DropletThresholdValue) ? "L" : "n",
                        DropletIdentifier = svListItem.RowIndex

                    });
                }// end  foreach (var svListItem in svList)
                SourceViewModels.Add(svModels);
            }// end for (int index = 0; index < rowCount; index++)


        }
        #endregion
    }
}
