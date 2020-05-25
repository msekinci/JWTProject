using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.Business.StringInfos;
using MSESoftware.JWTProject.Entities.Concrete;
using MSESoftware.JWTProject.Entities.DTOs.AppUserDTOs;
using MSESoftware.JWTProject.Entities.Token;
using MSESoftware.JWTProject.WebAPI.CustomFilters;
using System.Linq;
using System.Threading.Tasks;

namespace MSESoftware.JWTProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJWTService _jwtService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AuthController(IJWTService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _mapper = mapper;
        }


        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserSignInDTO appUserSignInDTO)
        {
            var user = await _appUserService.FindByUserName(appUserSignInDTO.UserName);
            if (user == null)
            {
                return BadRequest("Please double check your Username");
            }

            if (!await _appUserService.CheckPassword(appUserSignInDTO))
            {
                return BadRequest("Please double check your Password");
            }

            var roles = await _appUserService.GetRolesByUserName(appUserSignInDTO.UserName);
            var token = _jwtService.GenerateJWT(user, roles);
            JWTAccessToken jwtAccessToken = new JWTAccessToken();
            jwtAccessToken.Token = token;
            return Created("", jwtAccessToken);
        }


        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserSignUpDTO appUserSignUpDTO,
            [FromServices] IAppUserRoleService appUserRoleService,
            [FromServices] IAppRoleService appRoleService)
        {
            var user = await _appUserService.FindByUserName(appUserSignUpDTO.UserName);

            if (user != null)
            {
                return BadRequest($"{appUserSignUpDTO.UserName} is already in use");
            }

            await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserSignUpDTO));

            var appUser = await _appUserService.FindByUserName(appUserSignUpDTO.UserName);
            var appRole = await appRoleService.FindByName(RoleInfo.Member);

            await appUserRoleService.AddAsync(new AppUserRole { AppUserId = appUser.Id, AppRoleId = appRole.Id });
            return Created("", appUserSignUpDTO);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> CurrentUser()
        {
            var user = await _appUserService.FindByUserName(User.Identity.Name);
            var roles = await _appUserService.GetRolesByUserName(user.UserName);

            AppUserListDTO appUserListDTO = new AppUserListDTO
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Roles = roles.Select(x => x.Name).ToList()
            };

            return Ok(appUserListDTO);
        }
    }
}