using static UnitTesting.StateChange;

namespace UnitTesting
{
    internal class Prove_a_Method_Correctly_Handles_an_External_Exception
    {
        //Moking classes
        public class MockableServiceConnection
        {
            public bool Connected { get; protected set; }

            protected virtual void ConnectToService()
            {
                // Connect to the service.
            }

            protected virtual void DisconnectFromService()
            {
                // Disconnect from the service.
            }

            public void Connect()
            {
                if (Connected)
                {
                    throw new AlreadyConnectedToServiceException("Only one connection at a time is permitted.");
                }
                ConnectToService();
                Connected = true;
            }

            public void Disconnect()
            {
                DisconnectFromService();
                Connected = false;
            }
        }



        //A MOCK CLASS:
        public class ServiceConnectionMock : MockableServiceConnection
        {
            protected override void ConnectToService()
            {
                // Do nothing.
            }

            protected override void DisconnectFromService()
            {
                // Do nothing.
            }
        }
    }
}
