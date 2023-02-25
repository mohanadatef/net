using KhadimiEssa.ApiModels;
using KhadimiEssa.Helper;
using KhadimiEssa.ModelDTO.AboutUsDTO;
using KhadimiEssa.ModelDTO.CondtionsDTO;
using KhadimiEssa.ModelDTO.ListQuestionsDTO;
using KhadimiEssa.ModelDTO.ListSocialMediaDTO;
using KhadimiEssa.ModelDTO.SettinDTO;
using KhadimiEssa.Models.AuthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Interfaces.App
{
    public interface IAppDelegetService
    {
        Task<Response<CondtionsDelegetDto>> CondtionsAsync(string lang = "ar");
        Task<Response<AboutUDelegetDto>> AboutUsAsync(string lang = "ar");
        Task<Response<PrivacyDelegetDto>> PrivacyAsync(string lang = "ar");

        Task<Response<SettingDelegetDto>> GetSettingAsync(string lang = "ar");
        Task<Response<string>> Addcomplaints(ContactUsDto contactUsModel, string lang = "ar");
        //Task<Response<List<ListSocialMediaDto>>> ListSocialMedia(string lang = "ar");
        //Task<Response<List<ListQuestionsDto>>> ListQuestions(string lang = "ar");
    }
}
