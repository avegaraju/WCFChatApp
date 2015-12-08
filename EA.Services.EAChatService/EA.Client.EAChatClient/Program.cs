using EA.Client.EAChatClient.Callback;
using Microsoft.Practices.Unity.Configuration;
using EA.Common.Utilities;
using EA.Common.Utilities.ConsoleHelper;
using EA.Common.Contract.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using EA.Common.Contract.Service;

namespace EA.Client.EAChatClient
{
    class Program
    {
        static string[] retriedArgument = new string[1];
        static IEAChatService proxy;
        static void Main(string[] args)
        {
            
            try
            {
                RunClient(args);
                Environment.Exit(0);
            }
          
          
            catch (Exception ex)
            {
                ConsoleWriter.WriteException(ex.Message);
                if (proxy != null)
                {
                    ((ICommunicationObject)proxy).Abort();
                }
            }
        }
        /// <summary>
        /// Method to Run the chat client.
        /// </summary>
        /// <param name="args"></param>
        private static void RunClient(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration();

            try
            {
                if (!Validator.IsValid(args))
                {
                    ConsoleWriter.WriteInvalidArguments();
                    retriedArgument[0] = ConsoleReader.GetPortNumberInput();
                    RunClient(retriedArgument);
                }

                int portNumber = GetPortNumber(args);
                ChatClient chatClient = new ChatClient(portNumber.ToString());
                proxy = chatClient.GetProxy();

                ConsoleWriter.WriteOnNewLine("Press 'X' key to quit");
                //Run this till the user keys in X key.
                while (true)
                {
                    ConsoleWriter.WriteOnSameLine("Me: ");
                    string userInput = ConsoleReader.GetUserInput();

                    if (userInput.Equals("X"))
                        break;

                    SendMessage(userInput);
                }

            }
            catch (CommunicationException cEx)
            {
                ConsoleWriter.WriteOnNewLine(cEx.Message);
                retriedArgument[0] = ConsoleReader.GetPortNumberInput();
                RunClient(retriedArgument);
            }
            finally
            {
                if (proxy != null)
                {
                    ((ICommunicationObject)proxy).Close();
                }
            }
           
        }

        private static void SendMessage(string userInput)
        {
            Message message = new Message()
            {
                SimpleMessage = userInput
            };

            proxy.Send(message);
        }

        /// <summary>
        /// Method to get the port number.
        /// </summary>
        /// <param name="args">argument containing the port number</param>
        /// <returns></returns>
        private static int GetPortNumber(string[] args)
        {
            return Int32.Parse(args[0]);
        }

    }
}
