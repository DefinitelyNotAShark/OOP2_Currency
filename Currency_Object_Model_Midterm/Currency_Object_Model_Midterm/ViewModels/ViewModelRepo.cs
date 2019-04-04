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
    partial class ViewModelRepo : ViewModelBase
    {
        private ICurrencyRepo repo;
        //private CurrencyRepo editableCurrencyRepo;

        public ICommand Add { get; set; }
        public ICommand Load { get; set; }
        public ICommand Save { get; set; }
        public ICommand New { get; set; }

        public string CoinCount
        {
            get
            {
                return  "Coins: " + this.repo.GetCoinCount().ToString();
            }
            set
            {
                string str = "Coins: " + this.repo.GetCoinCount().ToString();
                str = value;
            }
        }

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
           // editableCurrencyRepo = new CurrencyRepo();//this is the one we can change;

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
            IFormatter formatter = new BinaryFormatter();//make the writer?
            Stream stream = File.Open(Path, FileMode.Open, FileAccess.Read, FileShare.Read);

            repo = (CurrencyRepo)formatter.Deserialize(stream);//I made this whole line up without looking at how to do this, let's see if it works
            stream.Close();

            RaisePropertyChanged("CoinCount");
        }

        public bool CanExecuteCommandLoad(object parameter)
        {
            //if file exists
            return true;
        }
        #endregion

        #region New Command
        public void ExecuteCommandNew(object parameter)
        {
            repo = new CurrencyRepo();//set it to a new empty repo;

            RaisePropertyChanged("CoinCount");

        }
        public bool CanExecuteCommandNew(object parameter)
        {
            return true;//can always make a new one
        }
        #endregion
    }
}
