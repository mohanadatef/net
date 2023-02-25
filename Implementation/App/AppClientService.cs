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
using KhadimiEssa.ModelDTO.ListFavouriteDTO;
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
    public class AppClientService : IAppClientService
    {

        private readonly ApplicationDbContext db;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public AppClientService(ApplicationDbContext db, IMapper mapper, ICurrentUserService currentUserService)
        {
            this.db = db;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<List<ListSocialMediaDto>>> ListSocialMedia(string lang = "ar")
        {
            try
            {
                List<SocialMedia> socialMedia = await db.SocialMedias.Where(s => s.IsActive).ToListAsync();

                List<ListSocialMediaDto> result = _mapper.Map<List<ListSocialMediaDto>>(socialMedia);
                return new Response<List<ListSocialMediaDto>>(result, "");
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
                return new Response<List<ListSocialMediaDto>>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }

        public async Task<Response<ContactDto>> Contacts(string lang = "ar")
        {
            try
            {
                List<SocialMedia> socialMedia = await db.SocialMedias.Where(s => s.IsActive).ToListAsync();
                SettingClientDto Settinsresult = await db.Settings.AsQueryable().ProjectTo<SettingClientDto>(MappingProfiles.SettingsClientProfile(lang)).FirstOrDefaultAsync();

                List<ListSocialMediaDto> result = _mapper.Map<List<ListSocialMediaDto>>(socialMedia);
                ContactDto contactUsDto = new ContactDto()
                {
                    SocialMedias = result,
                    Setting = Settinsresult
                };
                return new Response<ContactDto>(contactUsDto, "");
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
                return new Response<ContactDto>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }

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
                    Phone = contactUsModel.phone,
                };
                await db.ContactUs.AddAsync(contactU);
                await db.SaveChangesAsync();
                return new Response<string>("", HelperMsg.MsgValidation(EnumValidMsg.Auth.SendSuccessfully.ToNumber(), lang));



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
                db.SaveChanges();
                return new Response<string>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }

        public async Task<Response<AboutUsClientDto>> AboutUsAsync(string lang = "ar")
        {
            try
            {
                AboutUsClientDto data = await db.Settings.AsQueryable().ProjectTo<AboutUsClientDto>(MappingProfiles.AboutUsClientProfile(lang)).FirstOrDefaultAsync();
                return new Response<AboutUsClientDto>(data);
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
                return new Response<AboutUsClientDto>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }
        public async Task<Response<CondtionsClientDto>> CondtionsAsync(string lang = "ar")
        {
            try
            {

                CondtionsClientDto data = await db.Settings.AsQueryable().ProjectTo<CondtionsClientDto>(MappingProfiles.CondtionsClientProfile(lang)).FirstOrDefaultAsync();

                return new Response<CondtionsClientDto>(data);
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
                return new Response<CondtionsClientDto>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }

        public async Task<Response<PrivacyClientDto>> PrivacyAsync(string lang = "ar")
        {
            try
            {
                PrivacyClientDto data = await db.Settings.AsQueryable().ProjectTo<PrivacyClientDto>(MappingProfiles.PrivacyClientProfile(lang)).FirstOrDefaultAsync();
                return new Response<PrivacyClientDto>(data);
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
                return new Response<PrivacyClientDto>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }

        public async Task<Response<SettingClientDto>> GetSettingAsync(string lang = "ar")
        {
            try
            {
                var code = db.Users.Where(x => x.Id == _currentUserService.UserId).FirstOrDefault().InvitationCode;
                SettingClientDto result = await db.Settings.AsQueryable().ProjectTo<SettingClientDto>(MappingProfiles.SettingsClientProfile(lang)).FirstOrDefaultAsync();
                result.invititionCode = code;
                return new Response<SettingClientDto>(result);

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
                return new Response<SettingClientDto>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }

        public async Task<Response<FinanceDto>> FinanceAsync(string lang = "ar")
        {
            try
            {
                FinanceDto data = await db.Users.Where(x => x.Id == _currentUserService.UserId).Select(x => new FinanceDto
                {
                    price = x.Wallet
                }).FirstOrDefaultAsync();
                return new Response<FinanceDto>(data);
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
                return new Response<FinanceDto>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }

    }
}
