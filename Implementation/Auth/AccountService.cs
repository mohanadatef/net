using AAITHelper;
using AAITHelper.Enums;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Helper;
using KhadimiEssa.Interfaces.Auth;
using KhadimiEssa.Models.AuthModel;
using KhadimiEssa.Response.ResponseModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;
using static KhadimiEssa.Helper.HelperMethods;

namespace KhadimiEssa.Implementation.Auth
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationDbUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly IUploadImage _uploadImage;
        private readonly ICurrentUserService _currentUserService;


        public AccountService(ApplicationDbContext db, UserManager<ApplicationDbUser> userManager, IConfiguration configuration, IUploadImage uploadImage, ICurrentUserService currentUserService)

        {
            _userManager = userManager;
            _configuration = configuration;
            _db = db;
            _uploadImage = uploadImage;
            _currentUserService = currentUserService;
        }


        public async Task<Response<ResponseUserInfo>> RegisterClientAsync(RegisterDto userModel)
        {
            try
            {
                var oldUser = await _db.Users.Where(u => u.InvitationCode == userModel.InvitationCode).FirstOrDefaultAsync();

                #region ValidateEmailAndPhone
                if (!string.IsNullOrEmpty(userModel.InvitationCode))
                {
                    if (oldUser == null)
                    {
                        return new Response<ResponseUserInfo>(HelperMsg.creatMessage(userModel.lang, "من فضلك تأكد من كود الدعوة", "Please check the invitation code"));
                    }
                }
                string englishPhoneNumber = HelperNumber.ConvertArabicNumberToEnglish(userModel.phone);
                bool userWithSamePhoneNumber = await CheckValidatePhoneAsync(englishPhoneNumber);
                if (userWithSamePhoneNumber)
                {
                    return new Response<ResponseUserInfo>(HelperMsg.MsgValidation(EnumValidMsg.Auth.PhoneExisting.ToNumber(), userModel.lang));
                }
                bool userWithSameEmail = await CheckValidateEmailAsync(englishPhoneNumber);
                if (userWithSameEmail)
                {
                    return new Response<ResponseUserInfo>(HelperMsg.MsgValidation(EnumValidMsg.Auth.EmailExisting.ToNumber(), userModel.lang));
                }
                #endregion
                int code = await GenerateCode(1234);
                string invitationCode = RandomString(6);
                #region AddUser
                var user = new ApplicationDbUser
                {
                    Email = "",
                    UserName = englishPhoneNumber + HelperNumber.GetRandomNumber() + "@yahoo.com",
                    user_Name = userModel.userName,
                    ShowPassword = userModel.password,
                    ImgProfile = HelperMethods.BaisUrlHoste + "/images/Users/generic-user.png",
                    IsActive = true,
                    ActiveCode = false,
                    CloseNotify = false,
                    PublishDate = HelperDate.GetCurrentDate(3),
                    Code = code,
                    PhoneNumber = englishPhoneNumber,
                    TypeUser = (int)User_Type.Client,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    InvitationCode = invitationCode,
                    Lang = userModel.lang,
                    
                };
                var result = await _userManager.CreateAsync(user, userModel.password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Mobile");
                }
                else
                {
                    return new Response<ResponseUserInfo>(HelperMsg.creatMessage(userModel.lang, result.ToString(), result.ToString()));
                }

                if (oldUser != null)
                {
                    var InvitationBouns = await _db.Settings.FirstOrDefaultAsync();
                    UserInvitation userInvitation = new UserInvitation()
                    {
                        InvitationCode = userModel.InvitationCode,
                        UserId = oldUser.Id,
                        NewUserId = user.Id
                    };

                    _db.UserInvitations.Add(userInvitation);

                    oldUser.Wallet = oldUser.Wallet + InvitationBouns.InvitationBouns;
                    _db.Users.Update(oldUser);
                    await _db.SaveChangesAsync();

                    await HelperMethods.SendNotifyAsync(_db, $"تم اضافة مبلغ {InvitationBouns.InvitationBouns} للمحفظة الخاصة بك", $"An amount {InvitationBouns.InvitationBouns} has been added to your wallet", oldUser.Id, (int)NotifyTypes.NotiyFromDashBord);

                }


                #endregion
                bool resultAddDevice = await AddDeviceId(user.Id, userModel.deviceId, userModel.deviceType, userModel.projectName);
                string resultSms = await SendSms(code, englishPhoneNumber);

                return new Response<ResponseUserInfo>(data: await GetUserInfoAsync(user.Id, false, userModel.lang), msg: HelperMsg.MsgValidation(EnumValidMsg.Auth.RegisterSuccessfully.ToNumber(), userModel.lang));
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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<ResponseUserInfo>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang));
            }
        }


        //public async Task<Response<ResponseDelegetInfo>> RegisterDelegetAsync(RegisterDto userModel)
        //{
        //    try
        //    {
        //        #region ValidateEmailAndPhone
        //        string englishPhoneNumber = HelperNumber.ConvertArabicNumberToEnglish(userModel.phone);
        //        Task<bool> userWithSamePhoneNumber = CheckValidatePhoneAsync(englishPhoneNumber);
        //        if (userWithSamePhoneNumber.Result)
        //        {
        //            return new Response<ResponseDelegetInfo>(HelperMsg.MsgValidation(EnumValidMsg.Auth.PhoneExisting.ToNumber(), userModel.lang));

        //        }
        //        Task<bool> userWithSameEmail = CheckValidateEmailAsync(englishPhoneNumber);
        //        if (userWithSameEmail.Result)
        //        {
        //            return new Response<ResponseDelegetInfo>(HelperMsg.MsgValidation(EnumValidMsg.Auth.EmailExisting.ToNumber(), userModel.lang));

        //        }
        //        #endregion
        //        Task<int> code = GenerateCode(1234);
        //        #region AddUser
        //        var user = new ApplicationDbUser
        //        {
        //            Email = "",
        //            UserName = englishPhoneNumber + HelperNumber.GetRandomNumber() + "@yahoo.com",
        //            user_Name = userModel.userName,
        //            ShowPassword = userModel.password,
        //            ImgProfile = HelperMethods.BaisUrlHoste + "/images/User/generic-user.png",
        //            IsActive = true,
        //            ActiveCode = false,
        //            CloseNotify = false,
        //            PublishDate = HelperDate.GetCurrentDate(),
        //            Code = code.Result,
        //            PhoneNumber = englishPhoneNumber,
        //            TypeUser = (int)User_Type.deleget,
        //            SecurityStamp = Guid.NewGuid().ToString(),
        //            Lang = userModel.lang
        //        };
        //        var result = await _userManager.CreateAsync(user, userModel.password);
        //        if (result.Succeeded)
        //        {
        //            await _userManager.AddToRoleAsync(user, "Mobile");
        //        }
        //        else
        //        {
        //            return new Response<ResponseDelegetInfo>(HelperMsg.creatMessage(userModel.lang, result.ToString(), result.ToString()));

        //        }
        //        #endregion
        //        Task<bool> resultAddDevice = AddDeviceId(user.Id, userModel.deviceId, userModel.deviceType, userModel.projectName);
        //        Task<string> resultSms = SendSms(code.Result, englishPhoneNumber);
        //        return new Response<ResponseDelegetInfo>(data: await GetDelegtInfoAsync(user.Id, false, userModel.lang), msg: HelperMsg.MsgValidation(EnumValidMsg.Auth.RegisterSuccessfully.ToNumber(), userModel.lang));

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
        //        await _db.LogExption.AddAsync(logExption);
        //        await _db.SaveChangesAsync();
        //        return new Response<ResponseDelegetInfo>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang));
        //    }
        //}

        public async Task<Response<dynamic>> ConfirmCodeRegisterAsync(ConfirmCodeDto userModel)
        {
            try
            {
                var codeuser = (await _db.Users.SingleOrDefaultAsync(x => x.Id == userModel.userId));
                if (codeuser != null)
                {
                    if (codeuser.Code == userModel.code)
                    {
                        codeuser.ActiveCode = true;
                        await _db.SaveChangesAsync();
                        if (codeuser.TypeUser == User_Type.Client.ToNumber())
                        {
                            return new Response<dynamic>(data: await GetUserInfoAsync(codeuser.Id, false, userModel.lang), msg: HelperMsg.MsgValidation(EnumValidMsg.Auth.CodeActivatedSuccessfully.ToNumber(), userModel.lang));

                        }
                        else
                        {
                            return new Response<dynamic>(data: await GetDelegtInfoAsync(codeuser.Id, false, userModel.lang), msg: HelperMsg.MsgValidation(EnumValidMsg.Auth.CodeActivatedSuccessfully.ToNumber(), userModel.lang));

                        }
                    }
                    else
                    {
                        return new Response<dynamic>(HelperMsg.MsgValidation(EnumValidMsg.Auth.CodeNotCorrect.ToNumber(), userModel.lang));
                    }
                }
                else
                {
                    return new Response<dynamic>(HelperMsg.MsgValidation(EnumValidMsg.Auth.UserNotFound.ToNumber(), userModel.lang));

                }

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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<dynamic>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang));
            }
        }
        public async Task<Response<ResponseResendCode>> ResendCodeAsync(ResendCodeDto userModel)
        {
            try
            {
                var codeuser = (await _db.Users.SingleOrDefaultAsync(x => x.Id == userModel.userId));
                if (codeuser != null)
                {
                    int code = await GenerateCode(1234);
                    string resultSms = await SendSms(code, codeuser.PhoneNumber);
                    codeuser.Code = code;
                    await _db.SaveChangesAsync();
                    return new Response<ResponseResendCode>(data: new ResponseResendCode { code = code, userId = codeuser.Id, phone = codeuser.PhoneNumber }, HelperMsg.MsgValidation(EnumValidMsg.Auth.CodeSent.ToNumber(), userModel.lang));

                }
                else
                {
                    return new Response<ResponseResendCode>(HelperMsg.MsgValidation(EnumValidMsg.Auth.PhoneNotFound.ToNumber(), userModel.lang));
                }

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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<ResponseResendCode>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang));
            }
        }
        public async Task<dynamic> LoginAsync(int checkType, LoginDto userModel)
        {
            try
            {

                #region validation
                string englishPhoneNumber = HelperNumber.ConvertArabicNumberToEnglish(userModel.phone);
                var user = (await _db.Users.Where(x => x.PhoneNumber == englishPhoneNumber).FirstOrDefaultAsync());
                if (user == null)
                {
                    return (new
                    {
                        key = 0,
                        msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.CheckData.ToNumber(), userModel.lang)
                    });
                }
                if (userModel.password != user.ShowPassword)
                {
                    return (new
                    {
                        key = 0,
                        msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.PasswordNotFound.ToNumber(), userModel.lang)
                    });
                }

                if (!user.IsActive && user.ActiveCode)
                {
                    return (new
                    {
                        key = 0,
                        data = new { },
                        msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.Accountblocked.ToNumber(), userModel.lang)
                    });
                }

                if (user.IsDeleted && user.ActiveCode)
                {
                    return (new
                    {
                        key = 0,
                        data = new { },
                        msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.Accountblocked.ToNumber(), userModel.lang)
                    });
                }

                if (!user.ActiveCode)
                {
                    return (new
                    {
                        key = 1,
                        data = new
                        {
                            id = user.Id,
                            status = false,
                            user.Code
                        },
                        msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.NotActive.ToNumber(), userModel.lang)
                    });
                }

                #endregion
                if (user != null && await _userManager.CheckPasswordAsync(user, userModel.password))
                {
                    //use jwt to generate token

                    JwtSecurityToken token = GetToken(user);
                    bool resultAddDevice = await AddDeviceId(user.Id, userModel.deviceId, userModel.deviceType, userModel.projectName);
                    if (user.TypeUser == User_Type.Client.ToNumber() && checkType == User_Type.Client.ToNumber())
                    {
                        return (new
                        {
                            key = 1,
                            data = await GetUserInfoAsync(user.Id, true, userModel.lang, new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo),

                            msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.LoginSuccessfully.ToNumber(), userModel.lang)
                        });
                    }
                    else if (user.TypeUser == User_Type.deleget.ToNumber() && checkType == User_Type.deleget.ToNumber())
                    {
                        return (new
                        {
                            key = 1,
                            data = await GetDelegtInfoAsync(user.Id, true, userModel.lang, new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo),

                            msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.LoginSuccessfully.ToNumber(), userModel.lang)
                        });
                    }
                }
                return (new
                {

                    key = 0,
                    msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.CheckData.ToNumber(), userModel.lang)
                });
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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return (new { key = 0, msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang) });
            }
        }

        public async Task<Response<string>> ChangePasswordAsync(string UserId, ChangePasswordDto userModel)
        {
            try
            {
                var user = (await _userManager.FindByIdAsync(UserId));

                if (user.ShowPassword != userModel.oldPassword)
                {
                    return new Response<string>(HelperMsg.MsgValidation(EnumValidMsg.Auth.OldPasswordNotCorrect.ToNumber(), userModel.lang));

                }


                var changePasswordResult = await _userManager.ChangePasswordAsync(user, userModel.oldPassword, userModel.newPassword);
                if (!changePasswordResult.Succeeded)
                {
                    return new Response<string>(HelperMsg.creatMessage(userModel.lang, changePasswordResult.ToString(), "Something went wrong"));
                }
                user.ShowPassword = userModel.newPassword;
                await _db.SaveChangesAsync();

                return new Response<string>("", HelperMsg.MsgValidation(EnumValidMsg.Auth.Passwordchanged.ToNumber(), userModel.lang));

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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<string>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang));
            }
        }

        public async Task<Response<ResponseForgetPassword>> ForgetPasswordAsync(ForgetPasswordDto userModel)
        {
            try
            {
                string englishPhoneNumber = HelperNumber.ConvertArabicNumberToEnglish(userModel.phone);

                var codeuser = await _db.Users.SingleOrDefaultAsync(x => x.PhoneNumber == englishPhoneNumber);

                if (codeuser != null)
                {
                    if (!codeuser.IsActive)
                    {
                        return new Response<ResponseForgetPassword>(HelperMsg.MsgValidation(EnumValidMsg.Auth.Accountblocked.ToNumber(), userModel.lang));

                    }
                    int code = await GenerateCode(1234);
                    codeuser.Code = code;
                    await _db.SaveChangesAsync();
                    return new Response<ResponseForgetPassword>(data: new ResponseForgetPassword { code = code, userId = codeuser.Id }, HelperMsg.MsgValidation(EnumValidMsg.Auth.CodeSent.ToNumber(), userModel.lang));

                }
                else
                {
                    return new Response<ResponseForgetPassword>(HelperMsg.MsgValidation(EnumValidMsg.Auth.UserNotFound.ToNumber(), userModel.lang));

                }
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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<ResponseForgetPassword>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang));

            }
        }
        public async Task<Response<string>> ChangePasswordByCodeAsync(ChangePasswordByCodeDto userModel)
        {
            try
            {

                try
                {
                    var codeuser = await _db.Users.SingleOrDefaultAsync(x => x.Id == userModel.userId);

                    if (codeuser != null)
                    {
                        if (userModel.code != codeuser.Code)
                        {
                            return new Response<string>(HelperMsg.MsgValidation(EnumValidMsg.Auth.CodeNotCorrect.ToNumber(), userModel.lang));

                        }
                        var changePasswordResult = await _userManager.ChangePasswordAsync(codeuser, codeuser.ShowPassword, userModel.newPassword);
                        if (!changePasswordResult.Succeeded)
                        {
                            return new Response<string>(HelperMsg.creatMessage(userModel.lang, changePasswordResult.ToString(), "Something went wrong"));

                        }
                        codeuser.ShowPassword = userModel.newPassword;
                        await _db.SaveChangesAsync();

                        return new Response<string>("", HelperMsg.MsgValidation(EnumValidMsg.Auth.Passwordchanged.ToNumber(), userModel.lang));
                    }
                    else
                    {
                        return new Response<string>(HelperMsg.MsgValidation(EnumValidMsg.Auth.CodeNotCorrect.ToNumber(), userModel.lang));
                    }
                }
                catch (Exception)
                {
                    return new Response<string>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang));
                }
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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<string>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang));
            }
        }
        public async Task<Response<string>> ChangeLanguageAsync(ChangeLanguageDto userModel, string UserId)
        {
            try
            {
                var Users = await _db.Users.SingleOrDefaultAsync(x => x.Id == UserId);
                if (Users != null)
                {
                    Users.Lang = userModel.lang;
                    await _db.SaveChangesAsync();
                    return new Response<string>("", HelperMsg.MsgValidation(EnumValidMsg.Auth.UpdateSuccessfully.ToNumber(), userModel.lang));

                }
                else
                {
                    return new Response<string>(HelperMsg.MsgValidation(EnumValidMsg.Auth.UpdateSuccessfully.ToNumber(), userModel.lang));

                }
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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<string>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang));


            }
        }
        public async Task<Response<dynamic>> ChangeNotifyAsync(ChangeNotifyDto userModel, string UserId)
        {
            try
            {
                var Users = await _db.Users.SingleOrDefaultAsync(x => x.Id == UserId);
                if (Users != null)
                {
                    Users.CloseNotify = userModel.notify;
                    await _db.SaveChangesAsync();
                    if (Users.TypeUser == User_Type.Client.ToNumber())
                    {
                        return new Response<dynamic>(await GetUserInfoAsync(Users.Id, true, userModel.lang), HelperMsg.MsgValidation(EnumValidMsg.Auth.UpdateSuccessfully.ToNumber(), userModel.lang));

                    }
                    else
                    {
                        return new Response<dynamic>(await GetDelegtInfoAsync(Users.Id, true, userModel.lang), HelperMsg.MsgValidation(EnumValidMsg.Auth.UpdateSuccessfully.ToNumber(), userModel.lang));


                    }

                }
                else
                {
                    return new Response<dynamic>(HelperMsg.MsgValidation(EnumValidMsg.Auth.CheckData.ToNumber(), userModel.lang));

                }
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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<dynamic>(HelperMsg.MsgValidation(EnumValidMsg.Auth.CheckData.ToNumber(), userModel.lang));
            }
        }
        public async Task<Response<string>> LogoutAsync(LogoutDto userModel, string UserId)
        {
            try
            {
                var info = await _db.DeviceIds.Where(st => st.DeviceId_ == userModel.deviceId && st.FkUser == UserId).ToListAsync();
                if (info.Count > 0)
                {
                    foreach (var item in info)
                    {
                        _db.DeviceIds.Remove(item);
                        await _db.SaveChangesAsync();
                    }
                    return new Response<string>("", HelperMsg.MsgValidation(EnumValidMsg.Auth.LogOutSuccessfully.ToNumber(), userModel.lang));

                }
                else
                {
                    return new Response<string>("", HelperMsg.MsgValidation(EnumValidMsg.Auth.LogOutSuccessfully.ToNumber(), userModel.lang));

                }
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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<string>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang));
            }
        }

        public async Task<Response<List<ResponseListOfNotify>>> ListOfNotifyAsync(string UserId, string lang = "ar")
        {
            try
            {
                var user = (await _db.Users.FirstOrDefaultAsync(x => x.Id == UserId));
                if (user.TypeUser == User_Type.Client.ToNumber())
                {
                    var Notify = await _db.NotifyClients.Where(x => x.FKUser == UserId).Select(x => new ResponseListOfNotify
                    {
                        id = x.Id,
                        text = HelperMsg.creatMessage(lang, x.TextAr, x.TextEn),
                        date = x.Date.ToString("dd/MM/yyyy h:mm tt"),
                        type = x.Type,
                        orderId = x.OrderId

                    }).OrderByDescending(x => x.id).ToListAsync();
                    var updateNotfy = await _db.NotifyClients.Where(x => x.Show == false && x.FKUser == UserId).ToListAsync();
                    updateNotfy.ForEach(a => a.Show = true);
                    await _db.SaveChangesAsync();
                    return new Response<List<ResponseListOfNotify>>(Notify, HelperMsg.MsgValidation(EnumValidMsg.Auth.SendSuccessfully.ToNumber(), lang));

                }
                else
                {
                    var Notify = await _db.NotifyDelegts.Where(x => x.FKUser == UserId).Select(x => new ResponseListOfNotify
                    {
                        id = x.Id,
                        text = HelperMsg.creatMessage(lang, x.TextAr, x.TextEn),
                        date = x.Date.ToString("dd/MM/yyyy h:mm tt"),
                        type = x.Type

                    }).OrderByDescending(x => x.id).ToListAsync();
                    var updateNotfy = await _db.NotifyClients.Where(x => x.Show == false && x.FKUser == UserId).ToListAsync();
                    updateNotfy.ForEach(a => a.Show = true);
                    await _db.SaveChangesAsync();
                    return new Response<List<ResponseListOfNotify>>(Notify, HelperMsg.MsgValidation(EnumValidMsg.Auth.SendSuccessfully.ToNumber(), lang));

                }

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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<List<ResponseListOfNotify>>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));

            }
        }

        public async Task<Response<dynamic>> GetDataOfUser(string UserId, string lang = "ar")
        {
            var user = (await _db.Users.FirstOrDefaultAsync(x => x.Id == UserId));
            if (user.TypeUser == User_Type.Client.ToNumber())
            {
                return new Response<dynamic>(await GetUserInfoAsync(user.Id, true, lang), HelperMsg.MsgValidation(EnumValidMsg.Auth.SendSuccessfully.ToNumber(), lang));

            }
            else
            {
                return new Response<dynamic>(await GetDelegtInfoAsync(user.Id, true, lang), HelperMsg.MsgValidation(EnumValidMsg.Auth.SendSuccessfully.ToNumber(), lang));


            }
        }
        public async Task<Response<dynamic>> UpdateAsyncDataUser(UpdateDataUserDto userModel)
        {
            try
            {

                var user = (await _db.Users.Where(x => x.Id == _currentUserService.UserId).FirstOrDefaultAsync());
                string englishPhoneNumber = HelperNumber.ConvertArabicNumberToEnglish(userModel.phone);

                if (userModel.phone != null)
                {
                    var phoneExist = await CheckValidatePhoneAsync(userModel.phone, _currentUserService.UserId);
                    if (phoneExist)
                    {
                        return new Response<dynamic>(HelperMsg.MsgValidation(EnumValidMsg.Auth.PhoneExisting.ToNumber(), userModel.lang));
                    }
                }
                if (userModel.email != null)
                {
                    var emailExist = await CheckValidateEmailAsync(userModel.email, _currentUserService.UserId);
                    if (emailExist)
                    {
                        return new Response<dynamic>(HelperMsg.MsgValidation(EnumValidMsg.Auth.EmailExisting.ToNumber(), userModel.lang));
                    }
                }

                user.user_Name = userModel.userName ?? user.user_Name;
                user.PhoneNumber = englishPhoneNumber ?? user.PhoneNumber;
                user.Email = userModel.email ?? user.Email;
                if (userModel.imgProfile != null)
                {
                    user.ImgProfile = _uploadImage.Upload(userModel.imgProfile, (int)FileName.Users);
                }
                else
                {
                    user.ImgProfile = user.ImgProfile;
                }
                await _db.SaveChangesAsync();

                return new Response<dynamic>(await GetUserInfoAsync(user.Id, true, userModel.lang), HelperMsg.MsgValidation(EnumValidMsg.Auth.UpdateSuccessfully.ToNumber(), userModel.lang));
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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<dynamic>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang));
            }
        }

        public async Task<Response<dynamic>> UpdateAsyncDataDelegt(UpdateDataDelegtViewModel userModel)
        {
            try
            {
                var user = (await _db.Users.Where(x => x.Id == _currentUserService.UserId).FirstOrDefaultAsync());

                string englishPhoneNumber = HelperNumber.ConvertArabicNumberToEnglish(userModel.phone);
                if (userModel.phone != null)
                {
                    var phoneExist = await CheckValidatePhoneAsync(userModel.phone, _currentUserService.UserId);
                    if (phoneExist)
                    {
                        return new Response<dynamic>(HelperMsg.MsgValidation(EnumValidMsg.Auth.PhoneExisting.ToNumber(), userModel.lang));
                    }
                }
                if (userModel.email != null)
                {
                    var emailExist = await CheckValidateEmailAsync(userModel.email, _currentUserService.UserId);
                    if (emailExist)
                    {
                        return new Response<dynamic>(HelperMsg.MsgValidation(EnumValidMsg.Auth.EmailExisting.ToNumber(), userModel.lang));
                    }
                }

                user.user_Name = userModel.userName ?? user.user_Name;
                user.PhoneNumber = englishPhoneNumber ?? user.PhoneNumber;
                user.Email = userModel.email ?? user.Email;


                if (userModel.imgProfile != null)
                {
                    user.ImgProfile = _uploadImage.Upload(userModel.imgProfile, (int)FileName.Users);
                }
                else
                {
                    user.ImgProfile = user.ImgProfile;
                }
                await _db.SaveChangesAsync();

                return new Response<dynamic>(await GetDelegtInfoAsync(user.Id, true, userModel.lang), HelperMsg.MsgValidation(EnumValidMsg.Auth.UpdateSuccessfully.ToNumber(), userModel.lang));
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
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<dynamic>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), userModel.lang));
            }
        }

        #region Helper
        private async Task<bool> CheckValidatePhoneAsync(string phone)
        {
            var checkPhone = await _db.Users.Where(x => x.PhoneNumber == phone).FirstOrDefaultAsync();
            return checkPhone != null;
        }
        private async Task<bool> CheckValidatePhoneAsync(string phone, string userId)
        {
            var checkPhone = await _db.Users.Where(x => x.PhoneNumber == phone && x.Id != userId).FirstOrDefaultAsync();
            return checkPhone != null;
        }
        private async Task<bool> CheckValidateEmailAsync(string email)
        {
            var checkemail = await _db.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            return checkemail != null;
        }
        private async Task<bool> CheckValidateEmailAsync(string email, string userId)
        {
            var checkemail = await _db.Users.Where(x => x.Email == email && x.Id != userId).FirstOrDefaultAsync();
            return checkemail != null;
        }
        private async Task<int> GenerateCode(int currentCode)
        {
            int code = HelperNumber.GetRandomNumber(currentCode);
            var GetInfoSms = await _db.Settings.FirstOrDefaultAsync();
            if (GetInfoSms != null)
            {
                if (GetInfoSms.SenderName != "test")
                {
                    code = HelperNumber.GetRandomNumber();
                }
            }
            return code;
        }
        private async Task<bool> AddDeviceId(string userId, string deviceId, string deviceType, string projectName)
        {
            var check_device_id = await _db.DeviceIds.Where(st => st.DeviceId_ == deviceId && st.FkUser == userId).AnyAsync();
            if (!check_device_id)
            {
                DeviceId d = new DeviceId()
                {
                    DeviceId_ = deviceId,
                    FkUser = userId,
                    DeviceType = deviceType,
                    ProjectName = projectName
                };
                await _db.DeviceIds.AddAsync(d);
            }
            await _db.SaveChangesAsync();
            return true;
        }
        private async Task<string> SendSms(int code, string englishPhoneNumber)
        {
            var GetInfoSms = _db.Settings.FirstOrDefault();
            if (GetInfoSms != null)
            {
                if (GetInfoSms.SenderName != "test")
                {
                    string resultSms = await HelperSms.SendMessageBy4jawaly(code.ToString(), englishPhoneNumber, GetInfoSms.SenderName, GetInfoSms.UserNameSms, GetInfoSms.PasswordSms);
                    return resultSms;
                }
            }
            return "";
        }
        private async Task<ResponseUserInfo> GetUserInfoAsync(string userId, bool status, string lang = "ar", string token = "", DateTime? expiration = null)
        {
            var UserDB = await _db.Users.Where(x => x.Id == userId).Select(x => new ResponseUserInfo
            {
                id = x.Id,
                userName = x.user_Name,
                phone = x.PhoneNumber,
                typeUser = x.TypeUser,
                closeNotify = x.CloseNotify,
                email = x.Email,
                imgProfile = x.ImgProfile,
                lang = lang,
                code = x.Code,
                status = status,
                expiration = expiration,
                token = token,
                invitationCode = x.InvitationCode

            }).FirstOrDefaultAsync();

            return UserDB;
        }
        public async Task<ResponseDelegetInfo> GetDelegtInfoAsync(string userId, bool status, string lang = "ar", string token = "", DateTime? expiration = null)
        {
            var UserDB = await _db.Users.Where(x => x.Id == userId).Select(x => new ResponseDelegetInfo
            {
                id = x.Id,
                userName = x.user_Name,
                phone = x.PhoneNumber,
                typeUser = x.TypeUser,
                closeNotify = x.CloseNotify,
                email = x.Email,
                imgProfile = x.ImgProfile,
                lang = lang,
                code = x.Code,
                status = status,
                expiration = expiration,
                token = token
            }).FirstOrDefaultAsync();
            return UserDB;
        }
        public JwtSecurityToken GetToken(ApplicationDbUser user)
        {

            var claim = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim("user_id", user.Id),
                    new Claim("type_user", user.TypeUser.ToString())
                };

            var signinKey = new SymmetricSecurityKey(
             Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

            int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

            var token = new JwtSecurityToken(
              issuer: _configuration["Jwt:Site"],
              audience: _configuration["Jwt:Site"],
              claims: claim,
              expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
              signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        public async Task<bool> RemoveAccount(string userId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                return true;

            user.IsDeleted = true;
            user.IsActive = false;
            user.Email = user.Email + Guid.NewGuid();
            user.NormalizedEmail = user.NormalizedEmail + Guid.NewGuid();
            user.PhoneNumber = user.PhoneNumber + Guid.NewGuid();
            user.NormalizedUserName = user.NormalizedUserName + Guid.NewGuid();
            user.UserName = user.UserName + Guid.NewGuid();

            _db.Update(user);
            return await _db.SaveChangesAsync() > 0;
        }



        #endregion
    }
}
