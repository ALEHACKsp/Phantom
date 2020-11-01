using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phantom.API
{
    public class VRChatPlayer
    {
        public string DisplayName { get; set; }

        public string UserID { get; set; }

        public int ActorID { get; set; }

        public string AvatarID { get; set; }

        public bool IsMaster { get; set; }

        public bool HasCloningEnabled { get; set; }

        public bool IsModerator { get; set; }

        public string SteamID { get; set; }
    }
}
