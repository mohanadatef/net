using AAITHelper;
using AutoMapper;
using KhadimiEssa.ApiModels;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Helper;
using KhadimiEssa.ModelDTO.AboutUsDTO;
using KhadimiEssa.ModelDTO.CondtionsDTO;
using KhadimiEssa.ModelDTO.ListFavouriteDTO;
using KhadimiEssa.ModelDTO.ListQuestionsDTO;
using KhadimiEssa.ModelDTO.ListSocialMediaDTO;
using KhadimiEssa.ModelDTO.SettinDTO;
using KhadimiEssa.Models.AutoMapperViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMedia, ListSocialMediaDto>().ReverseMap();
            CreateMap<Questions, ListQuestionsDto>().ReverseMap();

        }

        public static MapperConfiguration UserProfile(string lang)
        {
            var configuration = new MapperConfiguration(cfg =>

                cfg.CreateMap<RateDelget, ListRateDelegetDTO>()
                    .ForMember(dto => dto.ImgProfile, conf => conf.MapFrom(ol => ol.ApplicationDbUser.ImgProfile))
                    .ForMember(dto => dto.Rate, conf => conf.MapFrom(ol => ol.Rate))
                    .ForMember(dto => dto.user_Name, conf => conf.MapFrom(ol => ol.ApplicationDbUser.user_Name))
                    .ForMember(dto => dto.date, conf => conf.MapFrom(ol => ol.Date.ToString("dd/MM/yyyy")))
            );
            return configuration;
        }

        #region ClientApp


        public static MapperConfiguration SettingsClientProfile(string lang)
        {
            var configuration = new MapperConfiguration(cfg =>

                cfg.CreateMap<Setting, SettingClientDto>()
                    .ForMember(dto => dto.Phone, conf => conf.MapFrom(ol => ol.Phone))
                    .ForMember(dto => dto.email, conf => conf.MapFrom(ol => ol.Email))
                    //.ForMember(dto => dto.aboutUs, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.AboutUsArClient, ol.AboutUsEnClient)))
                    //.ForMember(dto => dto.condtions, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.CondtionsArClient, ol.CondtionsEnClient)))
                    //.ForMember(dto => dto.privacy, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.PrivacyArClient, ol.PrivacyEnClient)))
                    .ForMember(dto => dto.lat, conf => conf.MapFrom(ol => ol.Lat))
                    .ForMember(dto => dto.lng, conf => conf.MapFrom(ol => ol.Lng))
                    .ForMember(dto => dto.location, conf => conf.MapFrom(ol => ol.Location))
                    .ForMember(dto => dto.rateBouns, conf => conf.MapFrom(ol => ol.RateBouns))
                    .ForMember(dto => dto.invitationBouns, conf => conf.MapFrom(ol => ol.InvitationBouns))
                    .ForMember(dto => dto.depositPrice, conf => conf.MapFrom(ol => ol.DepositPrice))
                    .ForMember(dto => dto.tax, conf => conf.MapFrom(ol => ol.Tax))
                    .ForMember(dto => dto.isShowDepositPrice, conf => conf.MapFrom(ol => ol.IsShowDepositPrice))
            );
            return configuration;
        }

        public static MapperConfiguration CondtionsClientProfile(string lang)
        {
            var configuration = new MapperConfiguration(cfg =>

                cfg.CreateMap<Setting, CondtionsClientDto>()
                    .ForMember(dto => dto.condtions, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.CondtionsArClient, ol.CondtionsEnClient)))
            );
            return configuration;
        }

        public static MapperConfiguration PrivacyClientProfile(string lang)
        {
            var configuration = new MapperConfiguration(cfg =>

                cfg.CreateMap<Setting, PrivacyClientDto>()
                    .ForMember(dto => dto.privacy, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.PrivacyArClient, ol.PrivacyEnClient)))
            );
            return configuration;
        }

        public static MapperConfiguration AboutUsClientProfile(string lang)
        {
            var configuration = new MapperConfiguration(cfg =>

                cfg.CreateMap<Setting, AboutUsClientDto>()
                    .ForMember(dto => dto.aboutUs, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.AboutUsArClient, ol.AboutUsEnClient)))
            );
            return configuration;
        }


        public static MapperConfiguration QAnswersProfile(string lang)
        {
            var configuration = new MapperConfiguration(cfg =>

                cfg.CreateMap<Questions, ListQuestionsDto>()
                    .ForMember(dto => dto.Question, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.Question, ol.QuestionEn)))
                    .ForMember(dto => dto.Answer, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.Answer, ol.AnswerEn)))

            );
            return configuration;
        }

        #endregion

        #region DelegetApp


        public static MapperConfiguration SettingsDelegetProfile(string lang)
        {
            var configuration = new MapperConfiguration(cfg =>

                cfg.CreateMap<Setting, SettingDelegetDto>()
                    .ForMember(dto => dto.Phone, conf => conf.MapFrom(ol => ol.Phone))
                    .ForMember(dto => dto.email, conf => conf.MapFrom(ol => ol.Email))
            //.ForMember(dto => dto.aboutUs, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.AboutUsArDelegt, ol.AboutUsEnDelegt)))
            //.ForMember(dto => dto.condtions, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.CondtionsArDelegt, ol.CondtionsEnDelegt)))
            //.ForMember(dto => dto.privacy, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.PrivacyArDelegt, ol.PrivacyEnDelegt)))
            );
            return configuration;
        }

        public static MapperConfiguration CondtionsDelegetProfile(string lang)
        {
            var configuration = new MapperConfiguration(cfg =>

                cfg.CreateMap<Setting, CondtionsDelegetDto>()
                    .ForMember(dto => dto.condtions, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.CondtionsArDelegt, ol.CondtionsEnDelegt)))
            );
            return configuration;
        }

        public static MapperConfiguration AboutUsDelegetProfile(string lang)
        {
            var configuration = new MapperConfiguration(cfg =>

                cfg.CreateMap<Setting, AboutUDelegetDto>()
                    .ForMember(dto => dto.aboutUs, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.AboutUsArDelegt, ol.AboutUsEnDelegt)))
            );
            return configuration;
        }


        public static MapperConfiguration PrivacyDelegetProfile(string lang)
        {
            var configuration = new MapperConfiguration(cfg =>

                cfg.CreateMap<Setting, PrivacyDelegetDto>()
                    .ForMember(dto => dto.privacy, conf => conf.MapFrom(ol => HelperMsg.creatMessage(lang, ol.PrivacyArDelegt, ol.PrivacyEnDelegt)))
            );
            return configuration;
        }


        #endregion

        #region Logic

        public static MapperConfiguration ListClientOrders(string lang)
        {
            var configuration = new MapperConfiguration(cfg =>

                cfg.CreateMap<Orders, OrderDto>()
                    .ForMember(dto => dto.id, conf => conf.MapFrom(ol => ol.Id))
                    .ForMember(dto => dto.orderDate, conf => conf.MapFrom(ol => ol.OrderDate.ToString("dd/MM/yyyy")))
                    .ForMember(dto => dto.location, conf => conf.MapFrom(ol => ol.Location))
                    .ForMember(dto => dto.lat, conf => conf.MapFrom(ol => ol.Lat))
                    .ForMember(dto => dto.lng, conf => conf.MapFrom(ol => ol.Lng))
                    .ForMember(dto => dto.price, conf => conf.MapFrom(ol => ol.DepositPrice))
                    .ForMember(dto => dto.distance, conf => conf.MapFrom(ol => ol.Distance))
                    .ForMember(dto => dto.userId, conf => conf.MapFrom(ol => ol.Provider.Id))
                    .ForMember(dto => dto.userName, conf => conf.MapFrom(ol => ol.Provider.user_Name))
                    .ForMember(dto => dto.userImg, conf => conf.MapFrom(ol => ol.Provider.ImgProfile))
                    .ForMember(dto => dto.providerId, conf => conf.MapFrom(ol => ol.ProviderId))
                    .ForMember(dto => dto.stutesId, conf => conf.MapFrom(ol => ol.Status))
                    .ForMember(dto => dto.excutionDate, conf => conf.MapFrom(ol => ol.ExecutionDate.ToString("dd/MM/yyyy")))
                    .ForMember(dto => dto.carBrand, conf => conf.MapFrom(ol => ol.CarBrand.ChangeLangName(lang)))
                    .ForMember(dto => dto.status, conf => conf.MapFrom(ol => HelperMethods.StutesText(ol.Status, lang)))
                    .ForMember(dto => dto.time, conf => conf.MapFrom(ol => ol.Availabletime.time.ToString("hh:mm tt")))
                    .ForMember(dto => dto.packageprice, conf => conf.MapFrom(ol => ol.Package.Price))
                    .ForMember(dto => dto.coponprice, conf => conf.MapFrom(ol => ol.Copon.Discount != null ? ol.Copon.Discount : 0))
                    .ForMember(dto => dto.total, conf => conf.MapFrom(ol => ol.Total))
                    .ForMember(dto => dto.phone, conf => conf.MapFrom(ol => ol.Provider.PhoneNumber))
                    .ForMember(dto => dto.isPaid, conf => conf.MapFrom(ol => ol.IsPaid))
                    .ForMember(dto => dto.payStatus, conf => conf.MapFrom(ol => ol.IsPaid ? HelperMsg.creatMessage(lang, "تم الدفع", "Paid") : HelperMsg.creatMessage(lang, "لم يتم الدفع", "Not Paid")))
                    .ForMember(dto => dto.typePay, conf => conf.MapFrom(ol => ol.IsPaid ? HelperMethods.PayStutes(ol.TypePay, lang):""))
                    .ForMember(dto => dto.package, conf => conf.MapFrom(ol => ol.Package.ChangeLangName(lang)))
                    .ForMember(dto => dto.orderDateTime, conf => conf.MapFrom(ol => ol.OrderDate))
                    .ForMember(dto => dto.Copon, conf => conf.MapFrom(ol => (ol.Copon != null ? ol.Copon.CoponCode : "")))


                    );
            return configuration;
        }

        public static MapperConfiguration ListProviderOrders(string lang)
        {
            var configuration = new MapperConfiguration(cfg =>

                cfg.CreateMap<Orders, OrderDto>()
                    .ForMember(dto => dto.id, conf => conf.MapFrom(ol => ol.Id))
                    .ForMember(dto => dto.orderDate, conf => conf.MapFrom(ol => ol.OrderDate.ToString("dd/MM/yyyy")))
                    .ForMember(dto => dto.location, conf => conf.MapFrom(ol => ol.Location))
                    .ForMember(dto => dto.lat, conf => conf.MapFrom(ol => ol.Lat))
                    .ForMember(dto => dto.lng, conf => conf.MapFrom(ol => ol.Lng))
                    .ForMember(dto => dto.price, conf => conf.MapFrom(ol => ol.DepositPrice))
                    .ForMember(dto => dto.distance, conf => conf.MapFrom(ol => ol.Distance))
                    .ForMember(dto => dto.userId, conf => conf.MapFrom(ol => ol.User.Id))
                    .ForMember(dto => dto.userName, conf => conf.MapFrom(ol => ol.User.user_Name))
                    .ForMember(dto => dto.userImg, conf => conf.MapFrom(ol => ol.User.ImgProfile))
                    .ForMember(dto => dto.providerId, conf => conf.MapFrom(ol => ol.ProviderId))
                    .ForMember(dto => dto.stutesId, conf => conf.MapFrom(ol => ol.Status))
                    .ForMember(dto => dto.excutionDate, conf => conf.MapFrom(ol => ol.ExecutionDate.ToString("dd/MM/yyyy")))
                    .ForMember(dto => dto.carBrand, conf => conf.MapFrom(ol => ol.CarBrand.ChangeLangName(lang)))
                    .ForMember(dto => dto.status, conf => conf.MapFrom(ol => HelperMethods.StutesText(ol.Status, lang)))
                    .ForMember(dto => dto.time, conf => conf.MapFrom(ol => ol.Availabletime.time.ToString("hh:mm tt")))
                    .ForMember(dto => dto.packageprice, conf => conf.MapFrom(ol => ol.Package.Price))
                    .ForMember(dto => dto.coponprice, conf => conf.MapFrom(ol => ol.Copon.Discount != null ? ol.Copon.Discount : 0))
                    .ForMember(dto => dto.total, conf => conf.MapFrom(ol => ol.Total))
                    .ForMember(dto => dto.phone, conf => conf.MapFrom(ol => ol.User.PhoneNumber))
                    .ForMember(dto => dto.isPaid, conf => conf.MapFrom(ol => ol.IsPaid))
                    .ForMember(dto => dto.payStatus, conf => conf.MapFrom(ol => ol.IsPaid ? HelperMsg.creatMessage(lang, "تم الدفع", "Paid") : HelperMsg.creatMessage(lang, "لم يتم الدفع", "Not Paid")))
                    .ForMember(dto => dto.typePay, conf => conf.MapFrom(ol => ol.IsPaid ? HelperMethods.PayStutes(ol.TypePay, lang) : ""))
                    .ForMember(dto => dto.package, conf => conf.MapFrom(ol => ol.Package.ChangeLangName(lang)))
                    .ForMember(dto => dto.orderDateTime, conf => conf.MapFrom(ol => ol.OrderDate))
                    .ForMember(dto => dto.Copon, conf => conf.MapFrom(ol => (ol.Copon != null ? ol.Copon.CoponCode : "")))
                    );
            return configuration;
        }


        #endregion



    }
}
