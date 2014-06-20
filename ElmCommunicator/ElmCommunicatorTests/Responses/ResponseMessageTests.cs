﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElmCommunicator.Commands;
using ElmCommunicator.Responses;
using NUnit.Framework;
using Rhino.Mocks;

namespace ElmCommunicatorTests.Responses
{
    [TestFixture]
    public class ResponseMessageTests
    {
        private ResponseMessage _responseMessage; 

        [SetUp]
        public void SetUp()
        {
            this._responseMessage = MockRepository.GeneratePartialMock<ResponseMessage>();
        }

        [Test]
        public void ShouldConvertHexStringToInt()
        {
            const string hex = "3C";
            const int expectedDec = 60;

            int result = this._responseMessage.HexToDec(hex);

            Assert.AreEqual(expectedDec, result);
        }

        [Test]
        public void ShouldHexToDecThrowExceptionWhenEmptyStringArgument()
        {
            var expectedException = new ArgumentNullException("hex");

            var actualException = Assert.Throws<ArgumentNullException>(() => this._responseMessage.HexToDec(null));
            Assert.AreEqual(expectedException.Message, actualException.Message);
        }

        [Test]
        public void ShouldReversBitsInAByte()
        {
            const byte originalByte = 0x88;
            const byte expectedReversByte = 0x11;

            byte actualByte = this._responseMessage.ReverseByte(originalByte);

            Assert.AreEqual(expectedReversByte, actualByte);
        }

        [Test]
        public void ShouldConvertHexStringToByteArray()
        {
            var expectedArray = new byte[] {0x01, 0x02};
            var expectedReverse = new byte[]{0x80, 0x40};
            
            byte[] actualArray = this._responseMessage.StringToByteArray("01 02");
            byte[] actualReverse = this._responseMessage.StringToByteArray("01 02", true);

            Assert.AreEqual(expectedArray, actualArray);
            Assert.AreEqual(expectedReverse, actualReverse);
        }
    }
}
