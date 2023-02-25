using AAITHelper;
using AAITHelper.Enums;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using KhadimiEssa.ApiModels;
using KhadimiEssa.AutoMapper;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Helper;
using KhadimiEssa.Interfaces.App;
using KhadimiEssa.Interfaces.Auth;
using KhadimiEssa.ModelDTO.AboutUsDTO;
using KhadimiEssa.ModelDTO.CondtionsDTO;
using KhadimiEssa.ModelDTO.ListQuestionsDTO;
using KhadimiEssa.ModelDTO.ListSocialMediaDTO;
using KhadimiEssa.ModelDTO.SettinDTO;
using KhadimiEssa.Models.AuthModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KhadimiEssa.Implementation.App
{
    public class AppDelegetService : IAppDelegetService
    {

        private readonly ApplicationDbContext db;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public AppDelegetService(ApplicationDbContext db, IMapper mapper, ICurrentUserService currentUserService)
        {
            this.db = db;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<AboutUDelegetDto>> AboutUsAsync(string lang = "ar")
        {
            try
            {
                var data = await db.Settings.AsQueryable().ProjectTo<AboutUDelegetDto>(MappingProfiles.AboutUsDelegetProfile(lang)).FirstOrDefaultAsync();
                return new Response<AboutUDelegetDto>(data);
            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                LogExption logExption = new LogExption()
                {
                    Date = DateTime.Now,
                    Exption = ex.Message,
                    ServiceName = m.Name,
                    UserId = ""
                };
                await db.LogExption.AddAsync(logExption);
                await db.SaveChangesAsync();
                return new Response<AboutUDelegetDto>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }

        public async Task<Response<string>> Addcomplaints(ContactUsDto contactUsModel, string lang = "ar")
        {
            try
            {
                ContactUs contactU = new ContactUs()
                {
                    Date = DateTime.Now,
                    Email = contactUsModel.email,
                    UserName = contactUsModel.userName,
                    Msg = contactUsModel.msg,
                    Phone=contactUsModel.phone,
                };
                await db.ContactUs.AddAsync(contactU);
                await db.SaveChangesAsync();
                return new Response<string>("",HelperMsg.MsgValidation(EnumValidMsg.Auth.SendSuccessfully.ToNumber(), lang));

            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                LogExption logExption = new LogExption()
                {
                    Date = DateTime.Now,
                    Exption = ex.Message,
                    ServiceName = m.Name,
                    UserId = ""
                };
                await db.LogExption.AddAsync(logExption);
                await db.SaveChangesAsync();
                return new Response<string>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }

        public async Task<Response<CondtionsDelegetDto>> CondtionsAsync(string lang = "ar")
        {
            try
            {
                CondtionsDelegetDto data = await db.Settings.AsQueryable().ProjectTo<CondtionsDelegetDto>(MappingProfiles.CondtionsDelegetProfile(lang)).FirstOrDefaultAsync();
                return new Response<CondtionsDelegetDto>(data);

            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                LogExption logExption = new LogExption()
                {
                    Date = DateTime.Now,
                    Exption = ex.Message,
                    ServiceName = m.Name,
                    UserId = ""
                };
                await db.LogExption.AddAsync(logExption);
                await db.SaveChangesAsync();
                return new Response<CondtionsDelegetDto>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }


        public async Task<Response<PrivacyDelegetDto>> PrivacyAsync(string lang = "ar")
        {
            try
            {
                PrivacyDelegetDto data = await db.Settings.AsQueryable().ProjectTo<PrivacyDelegetDto>(MappingProfiles.PrivacyDelegetProfile(lang)).FirstOrDefaultAsync();
                return new Response<PrivacyDelegetDto>(data);
            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                LogExption logExption = new LogExption()
                {
                    Date = DateTime.Now,
                    Exption = ex.Message,
                    ServiceName = m.Name,
                    UserId = ""
                };
                await db.LogExption.AddAsync(logExption);
                await db.SaveChangesAsync();
                return new Response<PrivacyDelegetDto>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }

        public async Task<Response<SettingDelegetDto>> GetSettingAsync(string lang = "ar")
        {
            try
            {
                SettingDelegetDto result = await db.Settings.AsQueryable().ProjectTo<SettingDelegetDto>(MappingProfiles.SettingsDelegetProfile(lang)).FirstOrDefaultAsync();
                return new Response<SettingDelegetDto>(result);

            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                LogExption logExption = new LogExption()
                {
                    Date = DateTime.Now,
                    Exption = ex.Message,
                    ServiceName = m.Name,
                    UserId = ""
                };
                await db.LogExption.AddAsync(logExption);
                await db.SaveChangesAsync();
                return new Response<SettingDelegetDto>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }

        //public async Task<Response<List<ListSocialMediaDto>>> ListSocialMedia(string lang = "ar")
        //{
        //    try
        //    {
        //        List<SocialMedia> socialMedia = await db.SocialMedias.Where(s => s.IsActive).ToListAsync();

        //        List<ListSocialMediaDto> result = _mapper.Map<List<ListSocialMediaDto>>(socialMedia);
        //        return new Response<List<ListSocialMediaDto>>(result, "");
        //    }

        //    catch (Exception ex)
        //    {
        //        MethodBase m = MethodBase.GetCurrentMethod();
        //        LogExption logExption = new LogExption()
        //        {
        //            Date = DateTime.Now,
        //            Exption = ex.Message,
        //            ServiceName = m.Name,
        //            UserId = ""
        //        };
        //        await db.LogExption.AddAsync(logExption);
        //        await db.SaveChangesAsync();
        //        return new Response<List<ListSocialMediaDto>>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
        //    }
        //}



        //public async Task<Response<List<ListQuestionsDto>>> ListQuestions(string lang = "ar")
        //{
        //    try
        //    {
        //        var questions = await db.Questions.Where(q => q.IsActive).AsQueryable().ProjectTo<ListQuestionsDto>(MappingProfiles.QAnswersProfile(lang)).ToListAsync();

        //        //List<ListQuestionsDto> result = _mapper.Map<List<ListQuestionsDto>>(questions);
        //        return new Response<List<ListQuestionsDto>>(questions, "");

        //    }

        //    catch (Exception ex)
        //    {
        //        MethodBase m = MethodBase.GetCurrentMethod();
        //        LogExption logExption = new LogExption()
        //        {
        //            Date = DateTime.Now,
        //            Exption = ex.Message,
        //            ServiceName = m.Name,
        //            UserId = ""
        //        };
        //        await db.LogExption.AddAsync(logExption);
        //        await db.SaveChangesAsync();
        //        return new Response<List<ListQuestionsDto>>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
        //    }
        //}
    }
}
