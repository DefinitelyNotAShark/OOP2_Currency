using Currency_Object_Model_Midterm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Currency_Object_Model_Midterm.ViewModels
{
    public partial class ViewModelRepo : ViewModelBase
    {
        public ICurrencyRepo repo;
        //private CurrencyRepo editableCurrencyRepo;

        public ICommand Add { get; set; }
        public ICommand Load { get; set; }
        public ICommand Save { get; set; }
        public ICommand New { get; set; }

        public string CoinCount { get { return  "Coins: " + this.repo.GetCoinCount().ToString(); } }
        public string CoinValue { get { return "Repo Value: " + this.repo.TotalValue().ToString(); } }

        private string selectedCoinString;

        public string SelectedCoinString
        {
            get { return selectedCoinString; }
            set
            {
                selectedCoinString = value;
                RaisePropertyChanged("SelectedCoin");//do something here
            }
        }

        public string CoinsInRepo
        {
            get { return this.repo.About(); }
        }

        #region Convert String to Coin
        ICoin ConvertStringToICoin(string str)
        {
            switch (str)
            {
                case "Penny":
                    ICoin p = new Penny();
                    return p;
                case "Nickel":
                    ICoin n = new Nickel();
                    return n;
                case "Dime":
                    ICoin d = new Dime();
                    return d;
                case "Quarter":
                    ICoin q = new Quarter();
                    return q;
                case "Dollar Coin":
                    ICoin dc = new DollarCoin();
                    return dc;
                default:
                    return null;
            }
        }
        #endregion

        public ICoin SelectedCoin
        {
            get
            {
                return ConvertStringToICoin(selectedCoinString);
            }
            set
            {
                ICoin coin = ConvertStringToICoin(selectedCoinString);
                coin  = value;
                RaisePropertyChanged();
            }

        }//this should change with the slidy thing

        public string Path = "currencyRepo";//default path appears in bin debug

        public ViewModelRepo(CurrencyRepo repo)
        {
            this.repo = repo;

            this.Add = new ViewModelRepoCommand(ExecuteCommandAdd, CanExecuteCommandAdd);
            this.Save = new ViewModelRepoCommand(ExecuteCommandSave, CanExecuteCommandSave);
            this.Load = new ViewModelRepoCommand(ExecuteCommandLoad, CanExecuteCommandLoad);
            this.New = new ViewModelRepoCommand(ExecuteCommandNew, CanExecuteCommandNew);
        }
        #region Add Command
        public void ExecuteCommandAdd(object parameter)
        {
            if (SelectedCoin != null)
                repo.AddCoin(SelectedCoin);

            RaisePropertyChanged("CoinCount");
            RaisePropertyChanged("CoinValue");
            RaisePropertyChanged("CoinsInRepo");
        }

        public bool CanExecuteCommandAdd(object parameter)
        {
            return true; 
        }
        #endregion

        #region Save Command
        public void ExecuteCommandSave(object parameter)//save the current repo to the file path in bin/Debug (for now)
        {
            //save the repo
            IFormatter formatter = new BinaryFormatter();//make the writer?
            Stream stream = new FileStream(this.Path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);//create the file to write?

            formatter.Serialize(stream, repo);//write the file
            stream.Close();//end
        }

        public bool CanExecuteCommandSave(object parameter)
        {
            //maybe can't save an empty repo?
            return true;//eh why not
        }
        #endregion

        #region Load Command
        public void ExecuteCommandLoad(object parameter)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();//make the writer?
                Stream stream = File.Open(Path, FileMode.Open, FileAccess.Read, FileShare.Read);

                repo = (CurrencyRepo)formatter.Deserialize(stream);//I made this whole line up without looking at how to do this, let's see if it works
                stream.Close();
            }
            catch(System.IO.FileNotFoundException e)
            {
                //Don't load anyhting if there's nothing to load
            }

            RaisePropertyChanged("CoinCount");
            RaisePropertyChanged("CoinValue");
            RaisePropertyChanged("CoinsInRepo");
        }

        public bool CanExecuteCommandLoad(object parameter)
        {
            return true;
        }
        #endregion

        #region New Command
        public void ExecuteCommandNew(object parameter)
        {
            repo = new CurrencyRepo();//set it to a new empty repo;

            RaisePropertyChanged("CoinCount");
            RaisePropertyChanged("CoinValue");
            RaisePropertyChanged("CoinsInRepo");

        }
        public bool CanExecuteCommandNew(object parameter)
        {
            return true;//can always make a new one
        }
        #endregion
    }
}
