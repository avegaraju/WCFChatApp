using EA.Client.EAChat.UI.Proxy;
using EA.Common.Contract.Callback;
using EA.Common.Contract.Fault;
using EA.Common.Contract.Response;
using EA.Common.Contract.Service;
using EA.Common.Utilities;
using EA.Common.Utilities.Contract.Request;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EA.Client.EAChat.UI
{
    [CallbackBehavior(
    ConcurrencyMode = ConcurrencyMode.Single,
    UseSynchronizationContext = false)]
    public partial class ChatWindow : Form, IChatCallback
    {
        public SynchronizationContext _uiSyncContext = System.Threading.SynchronizationContext.Current;
        IUnityContainer container = new UnityContainer();
        
        IEAChatService proxy;
        
        public ChatWindow()
        {
            InitializeComponent();
            container.RegisterInstance(typeof(SynchronizationContext), SynchronizationContext.Current);
            
        }

        #region Event Handlers

        private void SetPortButton_Click(object sender, EventArgs e)
        {
            string portNumber = SetPortTextBox.Text;

            try
            {
                if (String.IsNullOrEmpty(portNumber) ||
                    !Validator.isValidPort(portNumber))
                {
                    MessageBox.Show("Please enter a port number");
                }
                else
                {
                    ChatClient chatClient = new ChatClient(portNumber.ToString(),this);
                    proxy = chatClient.GetProxy();
                    bool isSuccss = proxy.Connect();
                    if (isSuccss)
                    {
                        MessageBox.Show("Client Connected");
                        EnableChatHandleControls();
                    }
                    else
                        MessageBox.Show("Client Not Connected. Retry!");
                }
            }
            catch (CommunicationException cEx)
            {
                MessageBox.Show("Could connect to server : " + cEx.Message);
            }
        }

        private void ChatHandleSetButton_Click(object sender, EventArgs e)
        {
            User user;

            try
            {
                if (String.IsNullOrEmpty(ChatHandleTextBox.Text))
                    MessageBox.Show("Please set a chat handle for yourself.");
                else
                {
                    user = new User()
                    {
                        UserId = ChatHandleTextBox.Text
                    };

                    proxy.Register(user);
                    EnableChatControls();
                }
            }
            catch (FaultException<EAChatServiceFault> cf)
            {
                MessageBox.Show(cf.Reason.ToString());
            }
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            EA.Common.Contract.Request.Message message;
            try
            {
                
                if (!String.IsNullOrEmpty(ChatMessageTextBox.Text))
                {
                    message = new Common.Contract.Request.Message()
                    {
                        Self = new User() { UserId = ChatHandleTextBox.Text },
                        ToUser = new User() { UserId = OnlineUserListBox.SelectedItem == null ? string.Empty : OnlineUserListBox.SelectedItem.ToString()},
                        SimpleMessage = ChatMessageTextBox.Text
                    };

                    if (OnlineUserListBox.SelectedItem != null)
                    {
                        if (OnlineUserListBox.SelectedItem.ToString().Trim().Equals(ChatHandleTextBox.Text.Trim()))
                        {
                            MessageBox.Show("You cannot select yourself for a chat.");
                            return;
                        }
                        else if (ChatHandleTextBox.Text.Trim().Equals(OnlineUserListBox.SelectedItem.ToString().Trim()))
                        {
                            message.ToUser.UserId = string.Empty;
                        }
                    }

                    MessageConsoleListBox.Items.Add("Me : " + ChatMessageTextBox.Text + " -- Time -- " + DateTime.Now);
                    ChatMessageTextBox.Clear();
                    proxy.Send(message);
                }
            }
            catch (FaultException<EAChatServiceFault> cF)
            {
                UpdateMessageConsole(cF.Reason.ToString());
            }
            catch (FaultException<EAChatGeneralFault> gf)
            {
                UpdateMessageConsole("Unknown Error occured. Details : " + gf.Reason);
            }
            catch (CommunicationObjectFaultedException cEx)
            {
                UpdateMessageConsole("Communication with host is lost. Please close this window and reconnect");
            }
        }

        

        private void ChatWindow_Load(object sender, EventArgs e)
        {

        }

        private void ChatWindow_Closed(object sender, FormClosedEventArgs e)
        {
            User user = new User()
            {
                UserId = ChatHandleTextBox.Text
            };
            proxy.DeRegister(user);

            if (proxy != null)
            {
                ((ICommunicationObject)proxy).Abort();
            }
        }

        #endregion

        #region Common Functions
        private void ClearOnlineUserList()
        {
            SendOrPostCallback callback =
            delegate(object state)
            {
                this.OnlineUserListBox.Items.Clear();
            };

            _uiSyncContext = (SynchronizationContext)container.Resolve(typeof(SynchronizationContext));
            _uiSyncContext.Post(callback,"");
        }

        private void UpdateMessageConsole(string friendlyReason)
        {
            SendOrPostCallback callback =
            delegate(object state)
            {
                this.MessageConsoleListBox.Items.Add(friendlyReason);
            };

            _uiSyncContext = (SynchronizationContext)container.Resolve(typeof(SynchronizationContext));
            _uiSyncContext.Post(callback, friendlyReason);
        }

        #endregion

        #region IChatCallback Members

        public void RefreshUserList(List<User> onlineUsers)
        {
            ClearOnlineUserList();

            foreach (User user in onlineUsers)
            {

                SendOrPostCallback callback =
                delegate(object state)
                {
                    this.OnlineUserListBox.Items.Add(user.UserId);
                };

                _uiSyncContext = (SynchronizationContext)container.Resolve(typeof(SynchronizationContext));
                _uiSyncContext.Post(callback, user.UserId);
            }
        }

     

        public void ResponseMessage(ResponsePacket response)
        {
            SendOrPostCallback callback =
              delegate(object state)
              {
                  this.MessageConsoleListBox.Items.Add(response.UserId + " says : " +  response.ResponseMessage + " -- Time -- " + response.TimeStamp);
              };

            _uiSyncContext = (SynchronizationContext)container.Resolve(typeof(SynchronizationContext));
            _uiSyncContext.Post(callback, response.ResponseMessage);
        }


        #endregion

        #region Control Enable/Disable
        private void EnableChatControls()
        {
            DisableChatHandleControl();
            ChatMessageTextBox.Enabled = true;
            SendMessageButton.Enabled = true;
            OnlineUserListBox.Enabled = true;
            MessageConsoleListBox.Enabled = true;
        }
        
        private void EnableChatHandleControls()
        {
            DisablePortControl();
            ChatHandleTextBox.Enabled = true;
            ChatHandleSetButton.Enabled = true;
        }
        private void DisableChatHandleControl()
        {
            ChatHandleSetButton.Enabled = false;
            ChatHandleTextBox.Enabled = false;
        }
        private void DisablePortControl()
        {
            SetPortButton.Enabled = false;
            SetPortTextBox.Enabled = false;
        }

        #endregion

        private void ClearSelectionButton_Click(object sender, EventArgs e)
        {
            OnlineUserListBox.ClearSelected();
        }

      
    }
}
