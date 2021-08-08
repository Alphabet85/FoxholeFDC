using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using FoxholeFDC.Helpers;
using FoxholeFDC.Models;
using FoxholeFDC.ViewModels;

namespace FoxholeFDC
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region " Constructor "

        public MainWindowViewModel()
        {

        }

        #endregion

        #region " Properties "

        private AddFOViewModel _addFOViewModel;
        private AddArtilleryViewModel _addArtilleryViewModel;

        private object _runningViewModel;
        public object RunningViewModel
        {
            get { return _runningViewModel; }
            set 
            { 
                _runningViewModel = value;
                OnPropertyChanged("RunningViewModel");
            }
        }

        private ForwardObserverModel _forwardObserver;
        public ForwardObserverModel ForwardObserver
        {
            get { return _forwardObserver; }
            set
            {
                _forwardObserver = value;
                OnPropertyChanged("ForwardObserver");
            }
        }

        private List<ArtilleryModel> _listOfArtillery;
        public List<ArtilleryModel> ListOfArtillery
        {
            get { return _listOfArtillery; }
            set
            {
                _listOfArtillery = value;
                OnPropertyChanged("ListOfArtillery");
            }
        }

        #endregion

        #region " Methods "

        private void AddFO()
        {
            Console.WriteLine("Adding Forward Observer");
            _addFOViewModel = new AddFOViewModel();
            RunningViewModel = _addFOViewModel;
        }

        private void AddArtillery()
        {
            Console.WriteLine("Adding Artillery");
            _addArtilleryViewModel = new AddArtilleryViewModel();
            RunningViewModel = _addArtilleryViewModel;
        }

        #endregion

        #region " Commands "

        private ICommand _addFOCommand;
        public ICommand AddFOCommand
        {
            get
            {
                if (_addFOCommand == null)
                {
                    _addFOCommand = new RelayCommand(P => true, p => AddFO());
                }

                return _addFOCommand;
            }
        }

        private ICommand _addArtilleryCommand;
        public ICommand AddArtilleryCommand
        {
            get
            {
                if (_addArtilleryCommand == null)
                {
                    _addArtilleryCommand = new RelayCommand(P => true, p => AddArtillery());
                }

                return _addArtilleryCommand;
            }
        }

        #endregion
    }
}
