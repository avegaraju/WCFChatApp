using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using EA.Common.Contract.Service;
using EA.Services.EAChatService;
using EA.Host.ServiceHostEngine.Hosting;
using EA.Common.Utilities;
using EA.Common.Utilities.ConsoleHelper;
using Microsoft.Practices.Unity;
using EA.Common.Utilities.Exception;
using System.Net.Sockets;


namespace EA.Host.ServiceHostEngine
{
    class Program
    {

        static ServiceHost host;
        static string[] retriedArgument = new string[1];

        static void Main(string[] args)
        {

            try
            {

                RunService(args);

            }

            catch (Exception e)
            {
                ConsoleWriter.WriteException(e.Message);
            }
            finally
            {
                if (host != null)
                    host.Close();
            }
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

        private static void RunService(string[] args)
        {
            try
            {
                if (!Validator.IsValid(args))
                {
                    ConsoleWriter.WriteInvalidArguments();
                    retriedArgument[0] = ConsoleReader.GetPortNumberInput();
                    RunService(retriedArgument);
                }

                int portNumber = GetPortNumber(args);

                ChatHost chatHost = new ChatHost(portNumber.ToString());
                host = chatHost.GetHost();
                host.Open();

            }
            catch (CommunicationObjectFaultedException cEx)
            {
                ConsoleWriter.WriteException(cEx.Message);
            }
          
            catch (AddressAlreadyInUseException aEx)
            {
                ReRunService(aEx);
            }
            catch (CommunicationException cEx)
            {
                ReRunService(cEx);
            }
            ConsoleWriter.WriteAndWait("Press any key to stop the service..");
            Environment.Exit(0);
        }

        private static void ReRunService(CommunicationException aEx)
        {
            ConsoleWriter.WriteOnNewLine(aEx.Message);
            retriedArgument[0] = ConsoleReader.GetPortNumberInput();
            RunService(retriedArgument);
        }
        
    }
}
