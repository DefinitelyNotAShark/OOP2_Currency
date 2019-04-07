using System;
using System.Windows.Input;
using Currency_Object_Model_Midterm.Models;
using Currency_Object_Model_Midterm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Currency_Object_Model_Midterm.ViewModels.ViewModelRepo;

namespace Currency_Object_Midterm_Test
{
    [TestClass]
    public class ViewModelRepoTest
    {
        [TestMethod]
        public void TestRepoConstructor()
        {
            //arrange
            CurrencyRepo repo = new CurrencyRepo();
            ViewModelRepo vm = new ViewModelRepo(repo);

            //act
            ICommand addCommand = new ViewModelRepoCommand(vm.ExecuteCommandAdd, vm.CanExecuteCommandAdd);
            ICommand saveCommand = new ViewModelRepoCommand(vm.ExecuteCommandSave, vm.CanExecuteCommandSave);
            ICommand loadCommand = new ViewModelRepoCommand(vm.ExecuteCommandLoad, vm.CanExecuteCommandLoad);
            ICommand newCommand = new ViewModelRepoCommand(vm.ExecuteCommandNew, vm.CanExecuteCommandNew);

            Assert.AreEqual(repo, vm.repo);//they should be set to each other in the constructor
            Assert.AreEqual(addCommand.GetType(), vm.Add.GetType());//these don't assert are equal and they return the same value of the same type, so instead I compare type
            Assert.AreEqual(saveCommand.GetType(), vm.Save.GetType());
            Assert.AreEqual(loadCommand.GetType(), vm.Load.GetType());
            Assert.AreEqual(newCommand.GetType(), vm.New.GetType());
            //assert

        }

        [TestMethod]
        public void TestCoinCount()
        {
            CurrencyRepo repo = new CurrencyRepo();
            ViewModelRepo vm = new ViewModelRepo(repo);

            string defaultCount = vm.CoinCount;//get start count

            ICoin quarter = new Quarter();//make and add quarter
            repo.AddCoin(quarter);

            string countAfterOneCoin = vm.CoinCount;//get count after adding quarter

            ICoin penny = new Penny();
            ICoin dollar = new DollarCoin();
            ICoin nickel = new Nickel();
            ICoin dime = new Dime();
            repo.AddCoin(penny);
            repo.AddCoin(dollar);
            repo.AddCoin(nickel);
            repo.AddCoin(dime);

            string countAfterOneOfEachCoin = vm.CoinCount;

            Assert.AreEqual("Coins: 0", defaultCount);
            Assert.AreEqual("Coins: 1", countAfterOneCoin);
            Assert.AreEqual("Coins: 5", countAfterOneOfEachCoin);
        }

        [TestMethod]
        public void TestCoinValue()
        {
            CurrencyRepo repo = new CurrencyRepo();
            ViewModelRepo vm = new ViewModelRepo(repo);

            string defaultValue = vm.CoinValue;//get start count

            ICoin quarter = new Quarter();//make and add quarter
            repo.AddCoin(quarter);

            string valueAfterQuarter = vm.CoinValue;//get count after adding quarter

            ICoin penny = new Penny();
            ICoin dollar = new DollarCoin();
            ICoin nickel = new Nickel();
            ICoin dime = new Dime();
            repo.AddCoin(penny);
            repo.AddCoin(dollar);
            repo.AddCoin(nickel);
            repo.AddCoin(dime);

            string valueAfterOneOfEachCoin = vm.CoinValue;

            Assert.AreEqual("Repo Value: 0", defaultValue);
            Assert.AreEqual("Repo Value: 0.25", valueAfterQuarter);
            Assert.AreEqual("Repo Value: 1.41", valueAfterOneOfEachCoin);          
        }

        [TestMethod]
        public void TestCoinsInRepo()
        {
            CurrencyRepo repo = new CurrencyRepo();
            ViewModelRepo vm = new ViewModelRepo(repo);

            string defaultCoinsMessage = vm.CoinsInRepo;

            ICoin penny = new Penny();
            vm.repo.AddCoin(penny);

            string CoinMessageAfterPennyAdded = vm.CoinsInRepo;

            Assert.AreEqual("Repo has 0 coins. COINS:", defaultCoinsMessage);
            Assert.AreEqual("Repo has 1 coins. COINS:\n" + penny.GetType(), CoinMessageAfterPennyAdded);
        }
    }
}


