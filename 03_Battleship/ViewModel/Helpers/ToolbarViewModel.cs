namespace _03_Battleship.ViewModel
{
    using MVVMCore;

    internal class ToolbarViewModel : NotifyingViewModel
    {

        private bool carrierEnabled;

        private bool battleshipEnabled;

        private bool cruiserEnabled;

        private bool destroyerEnabled;

        private bool subEnabled;

        private bool randomPositionsEnabled;

        public ToolbarViewModel()
        {
            this.CarrierEnabled = true;
            this.BattleshipEnabled = true;
            this.CruiserEnabled = true;
            this.DestroyerEnabled = true;
            this.SubEnabled = true;
            this.randomPositionsEnabled = true;
        }

        public bool CarrierEnabled
        {
            get
            {
                return this.carrierEnabled;
            }

            set
            {
                this.carrierEnabled = value;
                this.Notify();
            }
        }

        public bool BattleshipEnabled
        {
            get
            {
                return this.battleshipEnabled;
            }

            set
            {
                this.battleshipEnabled = value;
                this.Notify();
            }
        }

        public bool CruiserEnabled
        {
            get
            {
                return this.cruiserEnabled;
            }

            set
            {
                this.cruiserEnabled = value;
                this.Notify();
            }
        }

        public bool DestroyerEnabled
        {
            get
            {
                return this.destroyerEnabled;
            }

            set
            {
                this.destroyerEnabled = value;
                this.Notify();
            }
        }

        public bool SubEnabled
        {
            get
            {
                return this.subEnabled;
            }

            set
            {
                this.subEnabled = value;
                this.Notify();
            }
        }

        public bool RandomPositionsEnabled
        {
            get
            {
                return this.randomPositionsEnabled;
            }

            set
            {
                this.randomPositionsEnabled = value;
                this.Notify();
            }
        }
    }
}
