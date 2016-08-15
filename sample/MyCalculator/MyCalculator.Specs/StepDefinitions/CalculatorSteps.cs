﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace MyCalculator.Specs.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        private readonly ICalculator calculator;

        public CalculatorSteps(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int operand)
        {
            calculator.Enter(operand);
        }

        [Given(@"I have entered the following numbers")]
        public void GivenIHaveEnteredTheFollowingNumbers(Table table)
        {
            foreach (var number in table.Rows.Select(r => int.Parse(r["number"])))
            {
                calculator.Enter(number);
            }
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            calculator.Add();
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            calculator.Multiply();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            Assert.AreEqual(expectedResult, calculator.Result);
        }
    }
}
