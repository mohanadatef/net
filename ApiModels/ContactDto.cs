using KhadimiEssa.Data.TableDb;
using KhadimiEssa.ModelDTO.ListSocialMediaDTO;
using KhadimiEssa.ModelDTO.SettinDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.ApiModels
{
    public class ContactDto
    {
        public SettingClientDto Setting { get; set; }
        public List<ListSocialMediaDto> SocialMedias { get; set; }
    }
}
