using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using FoxholeFDC.Helpers;
using FoxholeFDC.Models;

namespace FoxholeFDC
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region " Constructor "

        public MainWindowViewModel()
        {
            ListOfArtillery = new ObservableCollection<ArtilleryModel>();
            ListOfTargets = new ObservableCollection<TargetInformationModel>();
        }

        #endregion

        #region " Properties "

        private string _fixedPointDirection;
        public string FixedPointDirection
        {
            get => _fixedPointDirection;
            set
            {
                _fixedPointDirection = value;
                OnPropertyChanged("FixedPointDirection");
            }
        }

        private string _fixedPointDistance;
        public string FixedPointDistance
        {
            get => _fixedPointDistance;
            set
            {
                _fixedPointDistance = value;
                OnPropertyChanged("FixedPointDistance");
            }
        }

        private ArtilleryModel _artilleryModel;
        public ArtilleryModel ArtilleryModel
        {
            get { return _artilleryModel; }
            set 
            { 
                _artilleryModel = value;
                OnPropertyChanged("ArtilleryModel");
            }
        }

        private TargetInformationModel _targetInformationModel;
        public TargetInformationModel TargetInformationModel
        {
            get { return _targetInformationModel; }
            set
            {
                _targetInformationModel = value;
                OnPropertyChanged("TargetInformationModel");
            }
        }

        private ObservableCollection<ArtilleryModel> _listOfArtillery;
        public ObservableCollection<ArtilleryModel> ListOfArtillery
        {
            get => _listOfArtillery;
            set
            {
                _listOfArtillery = value;
                OnPropertyChanged("ListOfArtillery");
            }
        }

        private ObservableCollection<TargetInformationModel> _listOfTargets;
        public ObservableCollection<TargetInformationModel> ListOfTargets
        {
            get => _listOfTargets;
            set
            {
                _listOfTargets = value;
                OnPropertyChanged("ListOfTargets");
            }
        }

        private bool _isAddArtilleryOpen;
        public bool IsAddArtilleryOpen
        {
            get { return _isAddArtilleryOpen; }
            set 
            { 
                _isAddArtilleryOpen = value;
                OnPropertyChanged("IsAddArtilleryOpen");
            }
        }

        private bool _isAddTargetOpen;
        public bool IsAddTargetOpen
        {
            get { return _isAddTargetOpen; }
            set
            { 
                _isAddTargetOpen = value;
                OnPropertyChanged("IsAddTargetOpen");
            }
        }

        #endregion

        #region " Methods "

        private void OpenAddTarget()
        {
            Console.WriteLine("Opening Add Target");
            IsAddTargetOpen = !IsAddTargetOpen;
            TargetInformationModel = new TargetInformationModel();
        }

        private void OpenAddArtillery()
        {
            Console.WriteLine("Opening Add Artillery");
            IsAddArtilleryOpen = !IsAddArtilleryOpen;
            ArtilleryModel = new ArtilleryModel();
        }

        private void DeleteTargetList()
        {
            Console.WriteLine("Deleting Target List");
            ListOfTargets.Clear();
        }

        private void DeleteArtilleryList()
        {
            Console.WriteLine("Deleting Artillery List");
            ListOfArtillery.Clear();
        }

        private void Target(string command)
        {
            if (command == "Add")
            {
                Console.WriteLine("Adding Target");
                Console.WriteLine("Name:      " + TargetInformationModel.Name);
                Console.WriteLine("Direction: " + TargetInformationModel.Direction);
                Console.WriteLine("Distance:  " + TargetInformationModel.Distance);
                ListOfTargets.Add(TargetInformationModel);
            }

            TargetInformationModel = null;
            IsAddTargetOpen = !IsAddTargetOpen;
        }

        private void Artillery(string command)
        {
            if (command == "Add")
            {
                Console.WriteLine("Adding Artillery");
                Console.WriteLine("Name:      " + ArtilleryModel.Name);
                Console.WriteLine("Direction: " + ArtilleryModel.FixedPointDirection);
                Console.WriteLine("Distance:  " + ArtilleryModel.FixedPointDistance);
                ListOfArtillery.Add(ArtilleryModel);
            }

            ArtilleryModel = null;
            IsAddArtilleryOpen = !IsAddArtilleryOpen;
        }

        #endregion

        #region " Commands "

        private ICommand _openAddTargetCommand;
        public ICommand OpenAddTargetCommand
        {
            get
            {
                if (_openAddTargetCommand == null)
                {
                    _openAddTargetCommand = new RelayCommand(P => true, p => OpenAddTarget());
                }

                return _openAddTargetCommand;
            }
        }

        private ICommand _openAddArtilleryCommand;
        public ICommand OpenAddArtilleryCommand
        {
            get
            {
                if (_openAddArtilleryCommand == null)
                {
                    _openAddArtilleryCommand = new RelayCommand(P => true, p => OpenAddArtillery());
                }

                return _openAddArtilleryCommand;
            }
        }

        private ICommand _deleteTargetListCommand;
        public ICommand DeleteTargetListCommand
        {
            get
            {
                if (_deleteTargetListCommand == null)
                {
                    _deleteTargetListCommand = new RelayCommand(P => true, p => DeleteTargetList());
                }

                return _deleteTargetListCommand;
            }
        }

        private ICommand _deleteArtilleryListCommand;
        public ICommand DeleteArtilleryListCommand
        {
            get
            {
                if (_deleteArtilleryListCommand == null)
                {
                    _deleteArtilleryListCommand = new RelayCommand(P => true, p => DeleteArtilleryList());
                }

                return _deleteArtilleryListCommand;
            }
        }

        private ICommand _targetCommand;
        public ICommand TargetCommand
        {
            get
            {
                if (_targetCommand == null)
                {
                    _targetCommand = new RelayCommand(P => true, p => Target(p.ToString()));
                }

                return _targetCommand;
            }
        }

        private ICommand _artilleryCommand;
        public ICommand ArtilleryCommand
        {
            get
            {
                if (_artilleryCommand == null)
                {
                    _artilleryCommand = new RelayCommand(P => true, p => Artillery(p.ToString()));
                }

                return _artilleryCommand;
            }
        }

        #endregion
    }
}
