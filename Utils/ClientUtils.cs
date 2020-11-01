using ExitGames.Client.Photon;
using Newtonsoft.Json;
using Phantom.API;
using Phantom.Client;
using Phantom.JSON;
using Phantom.Position;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Phantom.Utils
{
    public static class ClientUtils
    {
        private static List<Type> ILHFIJHBPKK = new List<Type>
        {
            typeof(byte),
            typeof(bool),
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(string)
        };

        public static int GetCapacityOfWorld(string roomID)
        {
            string worldID = roomID.Split(':')[0];
            HttpClient _client = new HttpClient();
            var response = _client.GetAsync($"https://vrchat.com/api/1/worlds/{worldID}?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26");
            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                GeneralUtils.CurrentRoomName = JsonConvert.DeserializeObject<WorldInformation>(response.Result.Content.ReadAsStringAsync().Result).name;
                return JsonConvert.DeserializeObject<WorldInformation>(response.Result.Content.ReadAsStringAsync().Result).capacity;
            }

            return 0;
        }

        public static void JoinRoom(this PhantomClient client, string RoomID)
        {
            EnterRoomParams parms = new EnterRoomParams()
            {
                RoomName = RoomID,
                CreateIfNotExists = true,
            };
            RoomOptions options = new RoomOptions()
            {
                IsOpen = true,
                IsVisible = true,
                MaxPlayers = Convert.ToByte(GetCapacityOfWorld(RoomID) * 2)
            };
            Hashtable table = new Hashtable()
            {
                ["name"] = "name"
            };
            options.CustomRoomProperties = table;
            parms.RoomOptions = options;
            string[] customroompropertiesforlobby = new string[]
            {
                "name"
            };
            options.CustomRoomPropertiesForLobby = customroompropertiesforlobby;
            options.EmptyRoomTtl = 0;
            options.DeleteNullProperties = true;
            options.PublishUserId = false;
            client.OpJoinRoom(parms);
        }

        public static string GetCurrentRoom()
        {
            var di = new DirectoryInfo($"C:\\Users\\{Environment.UserName}\\AppData\\LocalLow\\VRChat\\VRChat");
            var file = di.EnumerateFiles("*.*", SearchOption.AllDirectories).OrderByDescending(f => f.LastWriteTime).Where(x => x.Extension.Contains("txt")).First();

            using (var stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string contents = reader.ReadToEnd();

                    string toBeSearched = "[RoomManager] Joining w";
                    int ix = contents.LastIndexOf(toBeSearched);

                    if (ix != -1)
                    {
                        string roomID = contents.Substring(ix + toBeSearched.Length).Split('\n')[0];
                        return "w" + roomID.ToString();
                    }
                }
            }
            return null;
        }

        public static string GetCurrentReleaseServer()
        {
            var di = new DirectoryInfo($"C:\\Users\\{Environment.UserName}\\AppData\\LocalLow\\VRChat\\VRChat");
            var file = di.EnumerateFiles("*.*", SearchOption.AllDirectories).OrderByDescending(f => f.LastWriteTime).Where(x => x.Extension.Contains("txt")).First();

            using (var stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string contents = reader.ReadToEnd();

                    string toBeSearched = "[VRCFlowNetworkManager] Using server url: ";
                    int ix = contents.LastIndexOf(toBeSearched);

                    if (ix != -1)
                    {
                        string release = contents.Substring(ix + toBeSearched.Length).Split('\n')[0];
                        return release.ToString();
                    }
                }
            }
            return null;
        }

        public static void RegisterTypes(this PhantomClient client)
        {
            Type typeFromHandle = typeof(Vector3);
            byte code = 86;
            SerializeMethod Serialize1 = new SerializeMethod(JFAFAPNBFLC);
            DeserializeMethod DeSerialize1 = new DeserializeMethod(IKFICLDHAOI);
            PhotonPeer.RegisterType(typeFromHandle, code, Serialize1, DeSerialize1);
            Type typeFromHandle2 = typeof(Quaternion);
            byte code2 = 81;
            SerializeMethod Serialize2 = new SerializeMethod(FECGOFBPKPP);
            DeserializeMethod DeSerialize2 = new DeserializeMethod(KCFONHKNDJH);
            PhotonPeer.RegisterType(typeFromHandle2, code2, Serialize2, DeSerialize2);
            byte b = 100;
            Type typeFromHandle3 = typeof(Vector2);
            SerializeMethod Serialize3 = new SerializeMethod(KMIBNBFAHEN);
            DeserializeMethod DeSerialize3 = new DeserializeMethod(HHBPLJKDKPI);
            GCJHKDFNJEA(typeFromHandle3, ref b, Serialize3, DeSerialize3);
            Type typeFromHandle4 = typeof(Vector4);
            SerializeMethod Serialize4 = new SerializeMethod(DFMLPAEPHJD);
            DeserializeMethod DeSerialize4 = new DeserializeMethod(GPJDPFFENPL);
            GCJHKDFNJEA(typeFromHandle4, ref b, Serialize4, DeSerialize4);
        }

        private static object GPJDPFFENPL(byte[] FBNNBMOEGOK)
        {
            int num = 0;
            float x;
            Protocol.Deserialize(out x, FBNNBMOEGOK, ref num);
            float y;
            Protocol.Deserialize(out y, FBNNBMOEGOK, ref num);
            float z;
            Protocol.Deserialize(out z, FBNNBMOEGOK, ref num);
            float w;
            Protocol.Deserialize(out w, FBNNBMOEGOK, ref num);
            return new Vector4(x, y, z, w);
        }

        private static byte[] DFMLPAEPHJD(object LIFOGCIHAMI)
        {
            byte[] array = new byte[16];
            int num = 0;
            Protocol.Serialize(((Vector4)LIFOGCIHAMI).x, array, ref num);
            Protocol.Serialize(((Vector4)LIFOGCIHAMI).y, array, ref num);
            Protocol.Serialize(((Vector4)LIFOGCIHAMI).z, array, ref num);
            Protocol.Serialize(((Vector4)LIFOGCIHAMI).w, array, ref num);
            return array;
        }

        private static void GCJHKDFNJEA(Type GMLMGAFFKEL, ref byte JGJGAENECKO, SerializeMethod HNDHEEONDNN, DeserializeMethod EBMBMGANEJJ)
        {
            byte code;
            JGJGAENECKO = Convert.ToByte((code = JGJGAENECKO) + 1);
            if (PhotonPeer.RegisterType(GMLMGAFFKEL, code, HNDHEEONDNN, EBMBMGANEJJ) && !ILHFIJHBPKK.Contains(GMLMGAFFKEL))
            {
                ILHFIJHBPKK.Add(GMLMGAFFKEL);
            }
        }

        private static object HHBPLJKDKPI(byte[] FBNNBMOEGOK)
        {
            int num = 0;
            float x;
            Protocol.Deserialize(out x, FBNNBMOEGOK, ref num);
            float y;
            Protocol.Deserialize(out y, FBNNBMOEGOK, ref num);
            return new Vector2(x, y);
        }

        private static byte[] KMIBNBFAHEN(object LIFOGCIHAMI)
        {
            byte[] array = new byte[8];
            int num = 0;
            Protocol.Serialize(((Vector2)LIFOGCIHAMI).x, array, ref num);
            Protocol.Serialize(((Vector2)LIFOGCIHAMI).y, array, ref num);
            return array;
        }

        private static object KCFONHKNDJH(byte[] FBNNBMOEGOK)
        {
            int num = 0;
            float x;
            Protocol.Deserialize(out x, FBNNBMOEGOK, ref num);
            float y;
            Protocol.Deserialize(out y, FBNNBMOEGOK, ref num);
            float z;
            Protocol.Deserialize(out z, FBNNBMOEGOK, ref num);
            float w;
            Protocol.Deserialize(out w, FBNNBMOEGOK, ref num);
            return new Quaternion(x, y, z, w);
        }

        private static byte[] FECGOFBPKPP(object LIFOGCIHAMI)
        {
            byte[] array = new byte[16];
            int num = 0;
            Protocol.Serialize(((Quaternion)LIFOGCIHAMI).x, array, ref num);
            Protocol.Serialize(((Quaternion)LIFOGCIHAMI).y, array, ref num);
            Protocol.Serialize(((Quaternion)LIFOGCIHAMI).z, array, ref num);
            Protocol.Serialize(((Quaternion)LIFOGCIHAMI).w, array, ref num);
            return array;
        }

        private static object IKFICLDHAOI(byte[] FBNNBMOEGOK)
        {
            int num = 0;
            float x;
            Protocol.Deserialize(out x, FBNNBMOEGOK, ref num);
            float y;
            Protocol.Deserialize(out y, FBNNBMOEGOK, ref num);
            float z;
            Protocol.Deserialize(out z, FBNNBMOEGOK, ref num);
            return new Vector3(x, y, z);
        }

        private static byte[] JFAFAPNBFLC(object LIFOGCIHAMI)
        {
            byte[] array = new byte[12];
            int num = 0;
            Protocol.Serialize(((Vector3)LIFOGCIHAMI).x, array, ref num);
            Protocol.Serialize(((Vector3)LIFOGCIHAMI).y, array, ref num);
            Protocol.Serialize(((Vector3)LIFOGCIHAMI).z, array, ref num);
            return array;
        }

        public static void SetCustomProperties(this PhantomClient client, string authCookie, string userID, string avatarID)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            Uri target = new Uri("https://www.vrchat.com");
            handler.CookieContainer.Add(new Cookie("auth", authCookie) { Domain = target.Host });
            HttpClient http = new HttpClient(handler);
            _ = http.PutAsync($"https://www.vrchat.com/api/1/users/{userID}/avatar?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26", new StringContent("{\"avatarId\":\"" + avatarID + "\"}", Encoding.UTF8, "application/json"));

            Dictionary<string, object> userProperties = new Dictionary<string, object>();
            userProperties["id"] = userID;

            var json = JsonConvert.DeserializeObject<AvatarInformation>(http.GetAsync($"https://www.vrchat.com/api/1/avatars/{avatarID}?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26").Result.Content.ReadAsStringAsync().Result);
            Dictionary<string, object> avatarProperties = new Dictionary<string, object>();
            Dictionary<string, object> UnityPackages = new Dictionary<string, object>();

            var unityPackage = json.unityPackages[0];
            UnityPackages.Add("id", unityPackage.id);
            UnityPackages.Add("assetUrl", unityPackage.assetUrl);
            UnityPackages.Add("assetUrlObject", "{}");
            UnityPackages.Add("unityVersion", unityPackage.unityVersion);
            UnityPackages.Add("unitySortNumber", unityPackage.unitySortNumber);
            UnityPackages.Add("assetVersion", unityPackage.assetVersion);
            UnityPackages.Add("platform", unityPackage.platform);
            UnityPackages.Add("created_at", unityPackage.created_at.ToShortDateString());

            avatarProperties.Add("name", json.name);
            avatarProperties.Add("description", json.description);
            avatarProperties.Add("authorId", json.authorId);
            avatarProperties.Add("authorName", json.authorName);
            avatarProperties.Add("imageUrl", json.imageUrl);
            avatarProperties.Add("thumbnailImageUrl", json.thumbnailImageUrl);
            avatarProperties.Add("assetUrl", json.assetUrl);
            avatarProperties.Add("assetUrlObject", "{}");
            avatarProperties.Add("tags", json.tags);
            avatarProperties.Add("releaseStatus", json.releaseStatus);
            avatarProperties.Add("version", json.version);
            avatarProperties.Add("unityPackageUrl", json.unityPackageUrl);
            avatarProperties.Add("unityVersion", json.unityVersion);
            avatarProperties.Add("assetVersion", json.assetVersion);
            avatarProperties.Add("platform", json.platform);
            avatarProperties.Add("featured", json.featured);
            avatarProperties.Add("imported", json.imported);
            avatarProperties.Add("id", json.id);
            avatarProperties.Add("created_at", json.created_at.ToShortDateString());
            avatarProperties.Add("updated_at", json.updated_at.ToShortDateString());
            avatarProperties.Add("unityPackages", UnityPackages);

            Hashtable hashtable = new Hashtable();
            hashtable["user"] = userProperties;
            hashtable["avatarDict"] = avatarProperties;
            hashtable["modTag"] = string.Empty;
            hashtable["isInvisible"] = false;
            hashtable["avatarVariations"] = avatarProperties["id"];
            hashtable["status"] = "active";
            hashtable["statusDescription"] = "oi";
            hashtable["inVRMode"] = false;
            hashtable["showSocialRank"] = true;
            hashtable["steamUserID"] = "0";

            client.LocalPlayer.SetCustomProperties(hashtable);
        }

        public static Player GetPlayer(this PhantomClient client, int actorID)
        {
            foreach (var Player in client.CurrentRoom.Players.Values)
            {
                if (Player.ActorNumber == actorID)
                    return Player;
            }

            return null;
        }

        public static VRChatPlayer AsVRChatPlayer(this Player player)
        {
            var tag = player.CustomProperties["modTag"];
            var user = player.CustomProperties["user"] as Dictionary<string, object>;
            var avatar = player.CustomProperties["avatarDict"] as Dictionary<string, object>;
            var userID = user["id"];
            var AvatarID = avatar["id"];
            var displayname = user["displayName"];
            var AvatarCopying = user["allowAvatarCopying"];
            var IsModerator = (tag.ToString() == string.Empty ? false : true);
            string steamID = player.CustomProperties["steamUserID"] == null ? "0" : player.CustomProperties["steamUserID"].ToString();
            return new VRChatPlayer()
            {
                DisplayName = displayname.ToString(),
                ActorID = player.ActorNumber,
                AvatarID = AvatarID.ToString(),
                SteamID = steamID,
                UserID = userID.ToString(),
                IsMaster = player.IsMasterClient,
                IsModerator = IsModerator,
                HasCloningEnabled = bool.Parse(AvatarCopying.ToString())
            };
        }

        public static Hashtable Instantiate(this PhantomClient client, string prefabName, Vector3 position, Quaternion rotation, int[] viewIDs)
        {
            Hashtable hashtable = new Hashtable();
            hashtable[(byte)0] = prefabName;
            hashtable[(byte)1] = position;
            hashtable[(byte)2] = rotation;
            hashtable[(byte)4] = viewIDs;
            hashtable[(byte)6] = client.LoadBalancingPeer.ServerTimeInMilliSeconds;
            hashtable[(byte)7] = viewIDs[0];
            hashtable[(byte)8] = 1;

            client.OpRaiseEvent(202, hashtable, new RaiseEventOptions
            {
                CachingOption = EventCaching.AddToRoomCache,
                Receivers = ReceiverGroup.Others,
            }, new SendOptions()
            {
                DeliveryMode = DeliveryMode.Reliable,
                Reliability = true,
                Encrypt = false,
                Channel = 1
            });

            return hashtable;
        }
    }
}
