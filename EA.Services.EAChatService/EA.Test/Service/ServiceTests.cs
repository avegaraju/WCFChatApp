using EA.Client.EAChat.UI;
using EA.Client.EAChat.UI.Proxy;
using EA.Common.Contract.Callback;
using EA.Common.Contract.Fault;
using EA.Common.Contract.Request;
using EA.Common.Contract.Service;
using EA.Common.Utilities.Contract.Request;
using EA.Host.ServiceHostEngine.Hosting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EA.Test.Service
{
    [TestFixture]
    public class ServiceTests : IChatCallback
    {
        ServiceHost host;
        IEAChatService proxy;
        public string ServerCallBackMessage { get; set; }

        [TestFixtureSetUp]
        public void HostService()
        {
           
            HostingHelper helper = new HostingHelper(new NetTcpHost(), "8523", true);
            host = helper.Host();

            host.Open();

            CreateProxy();
        }

        [Test]
        public void CreateProxy()
        {
            ChatClientHelper chatClient = new ChatClientHelper(new NetTcpClient(), "8523");
            proxy = chatClient.GetProxy(this);
            Assert.AreEqual(true,proxy.Connect());
        }

        [Test]
        public void Test_The_Exception_When_Register_User_With_Same_Handle()
        {
            if (host.State == CommunicationState.Closed)
                host.Open();

            User user = new User();
            user.UserId="Test";

            proxy.Register(user);

            Assert.Throws(typeof(FaultException<EAChatServiceFault>), new TestDelegate(NewRegistration));

            proxy.DeRegister(user);
            proxy.DeRegister(user);
            
        }

        [Test]
        public void TestMessageDeliveryToEAChatServer()
        {
            proxy.DeRegister(new User() { UserId = "Test" });
            proxy.DeRegister(new User() { UserId = "Test1" });

            proxy.Register(new User() { UserId = "Test" });
            proxy.Register(new User() { UserId = "Test1" });

            Message message = new Message(){
                Self=new User(){UserId = "Test"},
                ToUser= new User(){UserId= string.Empty},
                SimpleMessage = "hi"
            };
            proxy.Send(message);
            Assert.AreEqual("Hello!", ServerCallBackMessage);
        }
      
        private void NewRegistration()
        {
            try
            {
                User user = new User();
                user.UserId = "Test";

                CreateProxy();
                proxy.Register(user);
            }
            catch (FaultException<EAChatServiceFault> cf)
            {
                throw cf;
            }
        }

        [TestFixtureTearDown]
        public void BringDownService()
        {
            proxy.DeRegister(new User() { UserId="Test"});
            proxy.DeRegister(new User() { UserId = "Test1" });

            if (proxy != null)
            {
                ((ICommunicationObject)proxy).Abort();
            }

            if (host != null)
                host.Close();
        }

        public void RefreshUserList(List<EA.Common.Utilities.Contract.Request.User> onlineUsers)
        {
           // throw new NotImplementedException();
        }

        public void ResponseMessage(EA.Common.Contract.Response.ResponsePacket response)
        {
            //throw new NotImplementedException();
            ServerCallBackMessage = response.ResponseMessage;

        }
    }
}
