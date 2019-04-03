using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency_App_Fixed;

namespace OOP2_Currency_App_Test
{
    [TestClass]
    public class USCoinTests
    {
        Penny p;

        public USCoinTests()
        {
            p = new Penny();
        }

        [TestMethod]
        public void USCoinPennyConstructor()
        {
            //Arrange
            p = new Penny();
            //Act 

            //Assert
            Assert.AreEqual(MintMark.D, p.USCoinMintMark); //D is the default mint mark
            Assert.AreEqual(System.DateTime.Now.Year, p.Year); //Current year is default year
        }

        [TestMethod]
        public void USCoinMintMark()
        {
            //Arrange
            string mintNameDenver, mintNamePhili, mintNameSanFran, mintNameWestPoint;
            MintMark D, P, S, W;

            //Act 
            mintNameDenver = "Denver";
            mintNamePhili = "Philadephia";
            mintNameSanFran = "San Francisco";
            mintNameWestPoint = "West Point";

            D = MintMark.D;
            P = MintMark.P;
            S = MintMark.S;
            W = MintMark.W;


            //Assert
            Assert.AreEqual(USCoin.GetMintNameFromMark(D), mintNameDenver);
            Assert.AreEqual(USCoin.GetMintNameFromMark(P), mintNamePhili);
            Assert.AreEqual(USCoin.GetMintNameFromMark(S), mintNameSanFran);
            Assert.AreEqual(USCoin.GetMintNameFromMark(W), mintNameWestPoint);
        }



        [TestMethod]
        public void USCoinPennyMonetaryValue()
        {
            //Arrange
            p = new Penny();

            //Act 
            //nothing should have .01;
            //Assert

            Assert.AreEqual(.01, p.MonetaryValue);
        }


        [TestMethod]
        public void USCoinPennyAbout()
        {
            //Arrange
            p = new Penny();

            //Act 

            //Assert
            Assert.AreEqual($"Penny is from {DateTime.Now.Year.ToString()}. It is worth 0.01. It was made in Denver", p.About());
        }
    }
}
