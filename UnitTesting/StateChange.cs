using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting;


namespace UnitTesting
{
    internal class StateChange
    {
        public class AlreadyConnectedToServiceException : ApplicationException
        {
            public AlreadyConnectedToServiceException(string msg) : base(msg) { }
        }

        public class ServiceConnection
        {
            public bool Connected { get; protected set; }
            public void Connect()
            {
                if (Connected)
                {
                    throw new AlreadyConnectedToServiceException("Only one connection at a time is permitted.");
                }
                // Connect to the service.
                Connected = true;
            }

            public void Disconnect()
            {
                // Disconnect from the service.
                Connected = false;
            }
        }



        [TestClass]
        public class ServiceConnectionFixture
        {
            [TestMethod]
            public void TestInitialState()
            {
                ServiceConnection conn = new ServiceConnection();
                Assert.IsFalse(conn.Connected);
            }

            [TestMethod]
            public void TestConnectedState()
            {
                ServiceConnection conn = new ServiceConnection();
                conn.Connect();
                Assert.IsTrue(conn.Connected);
            }

            [TestMethod]
            public void TestDisconnectedState()
            {
                ServiceConnection conn = new ServiceConnection();
                conn.Connect();
                conn.Disconnect();
                Assert.IsFalse(conn.Connected);
            }

            [TestMethod]
            [ExpectedException(typeof(AlreadyConnectedToServiceException))]
            public void TestAlreadyConnectedException()
            {
                ServiceConnection conn = new ServiceConnection();
                conn.Connect();
                conn.Connect();
            }
        }
    }
}
