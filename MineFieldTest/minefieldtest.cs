using System;
using MineFieldRichard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MineFieldTest
{
    [TestClass]
    public class minefieldtest
    {
        int row, col;
        minefield mf = new minefield();
        [TestMethod]
        public void makeMap()
        {
            row = 3;
            col = 3;
            //act
            char[,]  expect = new char[3, 3] { { '*', '*', '*' }, { '*', '*', '*' }, { '*', '*', '*' } };
            
            //do
            char[,] actual = mf.makeMap(row,col);

            //Assert
            CollectionAssert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void MapInput()
        {
            row = 3;
            col = 4;
            //act
            char[,] mineMap = new char[3, 4] { { '*', '.', '.', '.' }, { '.', '.', '*', '.' }, { '.', '.', '.', '.' } };
            char[,] expect = new char[3, 4] { { '*', '2', '1', '1' }, { '1', '2', '*', '1' }, { '0', '1', '1', '1' } };
            //do
            char[,] actual = mf.mineHint(mineMap);

            //Assert
            CollectionAssert.AreEqual(expect, actual);
        }
    }
}
