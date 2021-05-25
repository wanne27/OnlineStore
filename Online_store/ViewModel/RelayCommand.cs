using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Online_store
{
    public class RelayCommand : ICommand
    {
        #region Private Members
        private Action mAction;
        #endregion

        #region Public events
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Conctructor
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        internal ViewModel.MainClientViewModel MainClientViewModel
        {
            get => default(ViewModel.MainClientViewModel);
            set
            {
            }
        }

        internal ViewModel.AdminWindowModel AdminWindowModel
        {
            get => default(ViewModel.AdminWindowModel);
            set
            {
            }
        }
        #endregion

        #region Command methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
        #endregion
    }
}
