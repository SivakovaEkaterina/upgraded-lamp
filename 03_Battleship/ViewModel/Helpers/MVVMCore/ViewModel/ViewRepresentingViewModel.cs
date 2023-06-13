namespace _03_Battleship.MVVMCore
{

    public abstract class ViewRepresentingViewModel : NotifyingViewModel
    {
        public ViewRepresentingViewModel(ViewShellBaseViewModel viewShell)
        {
            this.ViewShell = viewShell;
        }

        protected ViewShellBaseViewModel ViewShell
        {
            get;
            set;
        }
    }
}
