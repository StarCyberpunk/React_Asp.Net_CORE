using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using reactsite.DAL.Interfaces;
using reactsite.Domain.Entity;
using reactsite.Domain.Enum;
using reactsite.Domain.Helpers;
using reactsite.Domain.Response;
using reactsite.Domain.ViewModels;
using reactsite.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly ILogger<AccountService> _logger;
        private readonly IOptions<AuthOptions> _authOptions;

        public AccountService(IBaseRepository<User> userRepository, ILogger<AccountService> logger, IOptions<AuthOptions> at)
        {
            _userRepository = userRepository;
            _logger = logger;
            _authOptions = at;
        }

        public async Task<BaseResponse<string>> Register(RegisterViewModel model)
        {

            try
            {
                /*var user = await _userRepository.GetByLogin(model.Login);*/
                var user = await _userRepository.Select().FirstOrDefaultAsync(x => x.Login == model.Login);
                if (user != null)
                {
                    return new BaseResponse<string>()
                    {
                        Description = "Пользователь с таким логином уже есть",
                        StatusCode = StatusCode.NotFound
                    };
                }

                user = new User()
                {
                    Login = model.Login,
                    Role = Role.User,
                    Password = HashPasswordHelper.HashPassword(model.Password),
                };

                await _userRepository.Create(user);

                var result = GenerateJWT(user);

                return new BaseResponse<string>()
                {
                    Data = result,
                    Description = "Объект добавился",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Register]: {ex.Message}");
                return new BaseResponse<string>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<string>> Login(LoginViewModel model)
        {
            try
            {
                var user = await _userRepository.Select().FirstOrDefaultAsync(x => x.Login == model.Login);
                if (user == null)
                {
                    return new BaseResponse<string>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.NotFound
                    };
                }

                if (user.Password != HashPasswordHelper.HashPassword(model.Password))
                {
                    return new BaseResponse<string>()
                    {
                        Description = "Неверный пароль или логин",
                        StatusCode = StatusCode.WrongData
                    };
                }
                var result = GenerateJWT(user);

                return new BaseResponse<string>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Login]: {ex.Message}");
                return new BaseResponse<string>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<User>>> GetAllUsers()
        {
            var baseResponse = new BaseResponse<IEnumerable<User>>();
            try
            {
                var users = _userRepository.Select().ToList();
                if (users.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 эл-в";
                }
                else
                {
                    baseResponse.Description = "";
                    baseResponse.Data = users;
                }
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<IEnumerable<User>>();
                z.Description = $"[GetUsers]:{ex.Message}";

                return z;
            }
        }

        /*public async Task<BaseResponse<User>> GetUserByName(string name)
        {
            var baseResponse = new BaseResponse<User>();
            try
            {
                var user = await _userRepository.Select().FirstOrDefaultAsync(x => x.Login == name);
                if (user == null)
                {
                    baseResponse.Description = "Не найдено";
                }
                else
                {
                    baseResponse.Data = user;
                }
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<User>();
                z.Description = $"[GetUserByName]:{ex.Message}";

                return z;
            }
        }*/
        public async Task<BaseResponse<User>> GetUserById(long id)
        {
            var baseResponse = new BaseResponse<User>();
            try
            {
                var user = await _userRepository
                    .Select()
                    .Include(x=>x.Profile).FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                {
                    baseResponse.Description = "Не найдено";
                }
                else
                {
                    baseResponse.Data = user;
                }
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<User>();
                z.Description = $"[GetUserById]:{ex.Message}";

                return z;
            }
        }
        private string GenerateJWT(User user)
        {
            var authParams = _authOptions.Value;
            var securityKey = authParams.GetSemmetricSecurityKey();
            var credemtials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Login),
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new Claim("role",user.Role.ToString())
            };
            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credemtials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        
    }
}
