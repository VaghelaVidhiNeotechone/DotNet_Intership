using CalculatorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
//using CalculatorLib;

namespace CalculatorLib.Tests
{
   
        public class CalculatorTests
        {
            [Fact]
            public void Add_TwoPlusThree_ReturnsFive()
            {
                // Arrange
                var calc = new Calculator();

                // Act
                int result = calc.Add(2, 3);

                // Assert
                Assert.Equal(5, result);
            }
        }

    }



