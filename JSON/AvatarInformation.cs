using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phantom.JSON
{
    public class AvatarInformation
    {
        public string name { get; set; }
        public string description { get; set; }
        public string authorId { get; set; }
        public string authorName { get; set; }
        public string imageUrl { get; set; }
        public string thumbnailImageUrl { get; set; }
        public string assetUrl { get; set; }
        public object[] tags { get; set; }
        public string releaseStatus { get; set; }
        public int version { get; set; }
        public string unityPackageUrl { get; set; }
        public object unityPackageUrlObject { get; set; }
        public string unityVersion { get; set; }
        public int assetVersion { get; set; }
        public string platform { get; set; }
        public bool featured { get; set; }
        public bool imported { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string id { get; set; }
        public Unitypackage[] unityPackages { get; set; }

        public class Unitypackage
        {
            public string id { get; set; }
            public string assetUrl { get; set; }
            public object assetUrlObject { get; set; }
            public string unityVersion { get; set; }
            public long unitySortNumber { get; set; }
            public int assetVersion { get; set; }
            public string platform { get; set; }
            public DateTime created_at { get; set; }
        }
    }
}
