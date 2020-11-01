using Phantom.Client;
using Phantom.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phantom.Utils
{
    public static class GeneralUtils
    {
        public static string BotStatus = "Idle";

        public static string CurrentRoom = "None";

        public static string CurrentRoomName = "None";

        public static List<PhantomClient> Clients = new List<PhantomClient>();

        public static void DisconnectAll() => Clients.ForEach(x => x.Disconnect());

        public static void JoinRoom(string roomID) => Clients.ForEach(x => x.JoinRoom(roomID));

        public static void LeaveRoom() => Clients.ForEach(x => x.OpLeaveRoom(false));

        internal static void InstantiateAll() => Clients.ForEach(x => x.Instantiate("VRCPlayer", new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 1f), new int[] { 1, 2, 3 }));
    }
}
