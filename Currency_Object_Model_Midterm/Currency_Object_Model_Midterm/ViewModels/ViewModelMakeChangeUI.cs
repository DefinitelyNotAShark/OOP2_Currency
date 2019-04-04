using Currency_Object_Model_Midterm.Models;
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
    partial class ViewModelMakeChangeUI : ViewModelBase
    {
        private ICurrencyRepo repo;

        private CurrencyRepo makeChangeRepo;

        public ICommand MakeChange { get; set; }

        public ICommand Save { get; set; }

        public string Path = "mypath";//CHANGE LATER

        private double amount;

        public double Amount
        {
            get { return this.amount; }
            set
            {
                if(amount != value)
                {
                    RaisePropertyChanged("Amount");//we don't really need it to change until the button is pressed, but I guess that means the button doesn't have to get the value everytime it's pressed
                    amount = value;
                }
            }
        }

        public string CoinsInRepo
        {
            get {
                if (makeChangeRepo != null)
                    return this.makeChangeRepo.About();
                else return "Make change to see coins returned here.";
            }
        }


        public ViewModelMakeChangeUI(CurrencyRepo repo)
        {
            this.repo = repo;
            this.MakeChange = new ViewModelMakeChangeUICommand(ExecuteCommandMakeChange, CanExecuteCommandMakeChange);
            this.Save = new ViewModelMakeChangeUICommand(ExecuteCommandSave, CanExecuteCommandSave);
        }

       void ExecuteCommandSave(object parameter)
       {
            IFormatter formatter = new BinaryFormatter();//make the writer?
            Stream stream = new FileStream(this.Path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);//create the file to write?

            formatter.Serialize(stream, makeChangeRepo);//write the file
            stream.Close();//end
        }

        void ExecuteCommandMakeChange(object parameter)
        {
            makeChangeRepo = (CurrencyRepo)repo.MakeChange(Amount);//need to figure out how to pass that in!   
            RaisePropertyChanged("CoinsInRepo");
        }

        bool CanExecuteCommandMakeChange(object parameter)
        {
            return true;
        }

        bool CanExecuteCommandSave(object parameter)
        {
            if (Path != null)
            {
                return true;
            }
            else return false;
        }
    }
}
