using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
    }
}
