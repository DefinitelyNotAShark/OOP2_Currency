using System;
using Currency_Object_Model_Midterm.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Currency_Object_Midterm_Test
{
    [TestClass]
    public class CoinTests
    {
        #region penny
        [TestMethod]
        public void PennyConstructor()
        {
            //Arrange
            Penny p, philiPenny;

            //Act 
            p = new Penny();
            philiPenny = new Penny(MintMark.P);

            //Assert
            Assert.AreEqual(MintMark.D, p.USCoinMintMark);//default mark is D
            Assert.AreEqual(DateTime.Now.Year, p.Year);
            Assert.AreEqual(MintMark.P, philiPenny.USCoinMintMark);
        }

        [TestMethod]
        public void PennyMonetaryValue()
        {
            //Arrange
            Penny p;

            //Act 
            p = new Penny();

            //Assert
            Assert.AreEqual(.01f, p.MonetaryValue);
        }

        [TestMethod]
        public void PennyAbout()
        {
            //Arrange
            Penny p;

            //Act 
            p = new Penny();

            //Assert
            Assert.AreEqual("Penny is from 2019. It is worth 0.01. It was made in Denver", p.About());
        }
        #endregion

        #region nickel
        [TestMethod]
        public void NickelConstructor()
        {
            //Arrange
            Nickel n, philiNickel;

            //Act 
            n = new Nickel();
            philiNickel = new Nickel(MintMark.P);

            //Assert
            Assert.AreEqual(MintMark.D, n.USCoinMintMark);//default mark is D
            Assert.AreEqual(DateTime.Now.Year, n.Year);
            Assert.AreEqual(MintMark.P, philiNickel.USCoinMintMark);
        }

        [TestMethod]
        public void NickelMonetaryValue()
        {
            //Arrange
            Nickel n;

            //Act 
            n = new Nickel();

            //Assert
            Assert.AreEqual(.05f, n.MonetaryValue);
        }

        [TestMethod]
        public void NickelAbout()
        {
            //Arrange
            Nickel n;

            //Act 
            n = new Nickel();

            //Assert
            Assert.AreEqual("Nickel is from 2019. It is worth 0.05. It was made in Denver", n.About());
        }
        #endregion

        #region dime
        [TestMethod]
        public void DimeConstructor()
        {
            //Arrange
            Dime d, philiDime;

            //Act 
            d = new Dime();
            philiDime = new Dime(MintMark.P);

            //Assert
            Assert.AreEqual(MintMark.D, d.USCoinMintMark);//default mark is D
            Assert.AreEqual(DateTime.Now.Year, d.Year);
            Assert.AreEqual(MintMark.P, philiDime.USCoinMintMark);
        }

        [TestMethod]
        public void DimeMonetaryValue()
        {
            //Arrange
            Dime d;

            //Act 
            d = new Dime();

            //Assert
            Assert.AreEqual(.10f, d.MonetaryValue);
        }

        [TestMethod]
        public void DimeAbout()
        {
            //Arrange
            Dime d;

            //Act 
            d = new Dime();

            //Assert
            Assert.AreEqual("Dime is from 2019. It is worth 0.1. It was made in Denver", d.About());
        }
        #endregion

        #region quarter
        [TestMethod]
        public void QuarterConstructor()
        {
            //Arrange
            Quarter q, philiQuarter;

            //Act 
            q = new Quarter();
            philiQuarter = new Quarter(MintMark.P);

            //Assert
            Assert.AreEqual(MintMark.D, q.USCoinMintMark);//default mark is D
            Assert.AreEqual(DateTime.Now.Year, q.Year);
            Assert.AreEqual(MintMark.P, philiQuarter.USCoinMintMark);
        }

        [TestMethod]
        public void QuarterMonetaryValue()
        {
            //Arrange
            Quarter q;

            //Act 
            q = new Quarter();

            //Assert
            Assert.AreEqual(.25f, q.MonetaryValue);
        }

        [TestMethod]
        public void QuarterAbout()
        {
            //Arrange
            Quarter q;

            //Act 
            q = new Quarter();

            //Assert
            Assert.AreEqual("Quarter is from 2019. It is worth 0.25. It was made in Denver", q.About());
        }
        #endregion

        #region dollar coin
        [TestMethod]
        public void DollarCoinConstructor()
        {
            //Arrange
            DollarCoin dc, philiDollarCoin;

            //Act 
            dc = new DollarCoin();
            philiDollarCoin = new DollarCoin(MintMark.P);

            //Assert
            Assert.AreEqual(MintMark.D, dc.USCoinMintMark);//default mark is D
            Assert.AreEqual(DateTime.Now.Year, dc.Year);
            Assert.AreEqual(MintMark.P, philiDollarCoin.USCoinMintMark);
        }

        [TestMethod]
        public void DollarCoinMonetaryValue()
        {
            //Arrange
            DollarCoin dc;

            //Act 
            dc = new DollarCoin();

            //Assert
            Assert.AreEqual(1f, dc.MonetaryValue);
        }

        [TestMethod]
        public void DollarCoinAbout()
        {
            //Arrange
            DollarCoin dc;

            //Act 
            dc = new DollarCoin();

            //Assert
            Assert.AreEqual("Dollar Coin is from 2019. It is worth 1. It was made in Denver", dc.About());
        }
        #endregion

        #region MintMark
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
        #endregion
    }
}
