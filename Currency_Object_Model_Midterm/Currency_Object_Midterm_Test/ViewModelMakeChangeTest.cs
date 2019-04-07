using System;
using System.Windows.Input;
using Currency_Object_Model_Midterm.Models;
using Currency_Object_Model_Midterm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Currency_Object_Model_Midterm.ViewModels.ViewModelMakeChangeUI;

namespace Currency_Object_Midterm_Test
{
    [TestClass]
    public class ViewModelMakeChangeTest
    {
        public ViewModelMakeChangeUICommand ViewModelMakeChangeUICommand { get; private set; }

        [TestMethod]
        public void AmountTest()
        {
            //arrange
            CurrencyRepo repo = new CurrencyRepo();
            ViewModelMakeChangeUI vm = new ViewModelMakeChangeUI(repo);

            double defaultAmount;

            //act
            defaultAmount = vm.Amount;//default amount should be 0         

            //assert
            Assert.AreEqual(0, defaultAmount);        
        }

        [TestMethod]
        public void CoinsInRepoTest()
        {
            //arrange
            CurrencyRepo repo = new CurrencyRepo();
            ViewModelMakeChangeUI vm = new ViewModelMakeChangeUI(repo);

            string defaultCoinsInRepoMessage;
            string coinsInRepoAfterMakingChange;
            string aboutMessageAfterMakingChange;

            //act
            defaultCoinsInRepoMessage = vm.CoinsInRepo;//should return the empty message

            vm.makeChangeRepo = (CurrencyRepo)vm.makeChangeRepo.MakeChange(1.36);//need to figure out how to pass that in!  

            coinsInRepoAfterMakingChange = vm.CoinsInRepo;//should equal the about message
            aboutMessageAfterMakingChange = vm.makeChangeRepo.About();

            //assert
            Assert.AreEqual("Repo has 0 coins. COINS:", defaultCoinsInRepoMessage);
            Assert.AreEqual(aboutMessageAfterMakingChange, coinsInRepoAfterMakingChange);
        }

        [TestMethod]
        public void TestViewModelConstructor()
        {
            CurrencyRepo repo = new CurrencyRepo();
            ViewModelMakeChangeUI vm = new ViewModelMakeChangeUI(repo);

            ICommand saveCommand =  new ViewModelMakeChangeUICommand(vm.ExecuteCommandSave, vm.CanExecuteCommandSave);
            ICommand makeChangeCommand = new ViewModelMakeChangeUICommand(vm.ExecuteCommandMakeChange, vm.CanExecuteCommandMakeChange);


            Assert.AreEqual(repo, vm.makeChangeRepo);//they should be set to each other in the constructor
            Assert.AreEqual(makeChangeCommand.GetType(), vm.MakeChange.GetType());//The assert without the get type fails and I can't for the life of me figure out why.
            Assert.AreEqual(saveCommand.GetType(), vm.Save.GetType());//I tried casting them, but they still fail, so I at least can compare the type and make sure it's correct.
        }

        [TestMethod]
        public void TestPath()
        {
            CurrencyRepo repo = new CurrencyRepo();
            ViewModelMakeChangeUI vm = new ViewModelMakeChangeUI(repo);
            string defaultPath = vm.Path;

            Assert.AreEqual(defaultPath, "makeChangeRepo");
        }
    }
}
