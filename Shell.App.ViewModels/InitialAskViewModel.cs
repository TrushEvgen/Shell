using Shell.Core;
using System.Windows.Input;

namespace Shell.App.ViewModels
{
    public class InitialAskViewModel : ViewModelBase
    {
        #region Fields

        //IcetradeParser icetradeParser;

        #endregion

        #region Constructor

        public InitialAskViewModel()
        {
            AddCommand = new RelayCommand(Add, x => CanAdd());
            DownloadCommand = new RelayCommand(Download, x => CanDownload());

            URL = string.Empty;

            //icetradeParser = new IcetradeParser();

#if DEBUG
            URL = "http://www.icetrade.by/tenders/all/view/349324";
#endif
        }

        #endregion

        #region Property

        public string URL
        {
            get { return Get<string>("URL"); }
            set { Set(value, "URL"); }
        }

        //public Tender Tender
        //{
        //    get { return Get<Tender>("Tender"); }
        //    set { Set(value, "Tender"); }
        //}

        #endregion

        #region Commands

        public ICommand AddCommand { get; set; }

        public ICommand DownloadCommand { get; set; }

        #endregion

        #region Methods

        private bool CanDownload()
        {
            return (!URL.Equals(string.Empty));
        }

        private void Download()
        {
            if (URL.StartsWith("http://www.icetrade.by/tenders/all/view/"))
            {
                //for (int i = 275495; i < 275495+1 /*339100*/; i++)
                //{
                //    Tender = icetradeParser.GetTender("http://www.icetrade.by/tenders/all/view/" + i.ToString());
                //    Thread.Sleep(150);
                //}
                //Tender = icetradeParser.GetTender(URL);
            }
        }

        private bool CanAdd()
        {
            return true;  //(Tender != null);
        }

        private void Add()
        {
            //NavigationManager.Instance.Navigate("Shell.App.AllTendersPage");
        }

        #endregion
    }
}
