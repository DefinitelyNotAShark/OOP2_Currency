using Currency_Object_Model_Midterm.Models;
using System.Collections.Generic;
using System.Linq;
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
        }

        bool CanExecuteCommandMakeChange(object parameter)
        {
            return true;
        }

        void ExecuteCommandMakeChange(object parameter)
        {
            makeChangeRepo = (CurrencyRepo)repo.MakeChange(Amount);//need to figure out how to pass that in!   
            RaisePropertyChanged("CoinsInRepo");
        }
    }
}
