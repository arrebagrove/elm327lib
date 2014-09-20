﻿using ElmCommunicator.Responses.ObdIIResponses.ShowCurrentData;
using NUnit.Framework;
using Units;

namespace ElmCommunicatorTests.Responses.ObdIIResponses.ShowCurrentData
{
    [TestFixture]
    public class FuelPressureResponseTests
    {
        private FuelPressureResponse _response;

        [SetUp]
        public void SetUp()
        {
            this._response = new FuelPressureResponse();
        }

        [Test]
        public void ShouldSetTheCommand()
        {
            const string message = "41 01 55";
            const string expectedCommand = "4101";
            this._response.Parse(message);
            Assert.AreEqual(expectedCommand, this._response.Command);
        }

        [Test]
        public void ShouldParseTheResponse()
        {
            const string message = "41 01 55";
            Pressure expectedPressure = 255*Pressure.Kilopascal;
            this._response.Parse(message);
            Assert.AreEqual(expectedPressure, this._response.Pressure);
        }
    }
}