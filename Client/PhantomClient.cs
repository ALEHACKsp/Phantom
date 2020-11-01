using ExitGames.Client.Photon;
using Phantom.Settings;
using Phantom.Utils;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phantom.Client
{
    public class PhantomClient : LoadBalancingClient, IConnectionCallbacks, ILobbyCallbacks, IInRoomCallbacks, IMatchmakingCallbacks
    {
        private string Token, User, Avatar;
        private int ClientIndex;

        public PhantomClient(string token, string user, string avatar) : base(ConnectionProtocol.Udp)
        {
            ClientIndex = GeneralUtils.Clients.Count();
            Token = token;
            User = user;
            Avatar = avatar;
            AppId = "bf0942f7-9935-4192-b359-f092fa85bef1";
            NameServerHost = "ns.exitgames.com";
            AppVersion = ClientUtils.GetCurrentReleaseServer() + "_2.5";
            AuthValues = new AuthenticationValues() { AuthType = CustomAuthenticationType.Custom };
            AuthValues.AddAuthParameter("token", Token);
            AuthValues.AddAuthParameter("user", User);
            this.RegisterTypes();
            ConsoleUtils.Log($"[Client #{ClientIndex}] Created new PhantomClient");
            AddCallbackTarget(this);
            ConsoleUtils.Log($"[Client #{ClientIndex}] Subscribed to Client Callbacks");
            ConsoleUtils.Log($"[Client #{ClientIndex}] Connecting to Region Master USW");
            new Thread(() => UpdateThread()) { IsBackground = true }.Start();
            ConnectToRegionMaster("USW");
        }

        private void UpdateThread()
        {
            while(true)
            {
                Thread.Sleep(25);
                this.Service();
            }
        }

        public void OnConnected() 
        {

        }

        public void OnConnectedToMaster()
        {
            ConsoleUtils.Log($"[Client #{ClientIndex}] Connected to Region Master USW");
            this.SetCustomProperties(Token, User, Avatar);
            ConsoleUtils.Log($"[Client #{ClientIndex}] Set Custom Properties");
        }

        public void OnCreatedRoom()
        {

        }

        public void OnCreateRoomFailed(short returnCode, string message)
        {

        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {

        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {

        }

        public void OnDisconnected(DisconnectCause cause)
        {
            ConsoleUtils.Log("Disconnected -> " + cause.ToString());
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {

        }

        public void OnJoinedLobby()
        {

        }

        public void OnJoinedRoom()
        {
            GeneralUtils.CurrentRoom = CurrentRoom.Name;
            ConsoleUtils.Log($"[Client #{ClientIndex}] Joined Room.");
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {

        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {

        }

        public void OnLeftLobby()
        {

        }

        public void OnLeftRoom()
        {
            GeneralUtils.CurrentRoom = "None";
            GeneralUtils.CurrentRoomName = "None";
            ConsoleUtils.Log($"[Client #{ClientIndex}] Left Room.");
        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
        {

        }

        public void OnMasterClientSwitched(Player newMasterClient)
        {

        }

        public void OnPlayerEnteredRoom(Player newPlayer)
        {

        }

        public void OnPlayerLeftRoom(Player otherPlayer)
        {

        }

        public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {

        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {

        }

        public void OnRoomListUpdate(List<RoomInfo> roomList)
        {

        }

        public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {

        }
    }
}
