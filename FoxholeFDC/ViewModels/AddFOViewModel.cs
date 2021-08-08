using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FoxholeFDC.Helpers;

namespace FoxholeFDC.ViewModels
{
    public class AddFOViewModel : ViewModelBase
    {
        #region " Constructor "

        public AddFOViewModel()
        {

        }

        #endregion

        #region " Properties "

        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private bool _areAllFieldsFilled;
        public bool AreAllFieldsFilled
        {
            get { return _areAllFieldsFilled; }
            set 
            { 
                _areAllFieldsFilled = value;
                OnPropertyChanged("AreAllFieldsFilled");
            }
        }

        #endregion

        #region " Methods "

        private void AddForwardObserver()
        {

        }

        #endregion

        #region " Commands "

        private ICommand _addForwardObserverCommand;
        public ICommand AddForwardObserverCommand
        {
            get
            {
                if (_addForwardObserverCommand == null)
                {
                    _addForwardObserverCommand = new RelayCommand(P => true, p => AddForwardObserver());
                }

                return _addForwardObserverCommand;
            }
        }

        #endregion
    }
}
