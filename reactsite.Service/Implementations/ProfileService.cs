using reactsite.DAL.Interfaces;
using reactsite.Domain.Entity;
using reactsite.Domain.Enum;
using reactsite.Domain.Response;
using reactsite.Domain.ViewModels;
using reactsite.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.Service.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IBaseRepository<Profile> _PrRepo;
        private readonly IBaseRepository<User> _ac;

        public ProfileService(IBaseRepository<Profile> repo, IBaseRepository<User> us)
        {
            _PrRepo = repo;
            _ac = us;
        }
        /// <summary>
        /// Доделано
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> CreateProfile(ProfileViewModel p)
        {
            var baseRepository = new BaseResponse<bool>();
            try
            {

                var uss = await _ac.Get((int)p.UserId);
                Profile r = new Profile()
                {
                    Address = p.Address,
                    Age = p.Age,
                    Id = p.Id,
                    UserId = p.UserId,
                    User = uss
                };
                await _PrRepo.Create(r);
                baseRepository.Description = "Saved";
                baseRepository.StatusCode = StatusCode.OK;
                baseRepository.Data = true;
            }
            catch (Exception ex)
            {
                var z = new BaseResponse<bool>();
                z.Description = $"[CreateProfile]:{ex.Message}";
                z.Data = false;
                return z;
            }
            return baseRepository;
        }
        /// <summary>
        /// Удаление пока не планируется
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> DeleteProfile(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                Profile resp = await _PrRepo.Get(id);
                if (resp == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.ErrorDB;
                    baseResponse.Data = false;
                    return baseResponse;
                }
                else
                {
                    await _PrRepo.Delete(resp);
                    baseResponse.Description = "Удалено";
                    baseResponse.Data = true;
                    baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                    return baseResponse;
                }

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<bool>();
                z.Description = $"[DeleteProfile]:{ex.Message}";

                return z;
            }
        }

        public async Task<BaseResponse<Profile>> EditProfile(ProfileViewModel pvm)
        {
            var baseResponse = new BaseResponse<Profile>();
            try
            {
                var profile = await _PrRepo.Get((int)pvm.UserId);
                if (profile == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.ErrorDB;
                }
                else
                {
                    profile.Id = pvm.Id;
                    profile.Address = pvm.Address;
                    profile.Age = pvm.Age;



                    await _PrRepo.Update(profile);

                    baseResponse.Data = profile;
                    baseResponse.Description = "Найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                }

                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<Profile>();
                z.Description = $"[EditProfile]:{ex.Message}";

                return z;
            }
        }

        public async Task<BaseResponse<Profile>> GetProfileByUserId(int id)
        {
            var baseResponse = new BaseResponse<Profile>();
            try
            {
                var profile = await _PrRepo.Get(id);
                if (profile == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.ErrorDB;

                }
                else
                {
                    baseResponse.Description = "Найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                    baseResponse.Data = profile;
                }

                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<Profile>();
                z.Description = $"[GetProfileById]:{ex.Message}";

                return z;
            }
        }

        public ProfileViewModel ProfileToPWM(Profile data)
        {
            ProfileViewModel pw = new ProfileViewModel();
            pw.Address = data.Address;
            pw.Age = data.Age;
            pw.UserId = data.UserId;
            pw.Id = (int)data.Id;
            return pw;
        }
    }
}
