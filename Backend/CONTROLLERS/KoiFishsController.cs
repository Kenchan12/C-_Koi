using KoiFishManager.Api.Controllers;
using KoiFishManager.Api.Services;
using KoiFishManager.API.Services;
using KoiFishManager.Models.KoiFish;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFishManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class KoiFishController : ControllerBase
    {
        private readonly IKoiFishService _koiFishService;
        private readonly IUserContextService _userContextService;
        private readonly ILogger<PondController> _logger;

        public KoiFishController(IKoiFishService koiFishService, IUserContextService userContextService, ILogger<PondController> logger)
        {
            _koiFishService = koiFishService;
            _userContextService = userContextService;
            _logger = logger;
        }


        // Thêm cá koi mới vào hồ
        [HttpPost("{pondId}")]
        public async Task<ActionResult<KoiFishResponse>> AddKoiFishAsync(int pondId, KoiFishRequest request)
        {
            try
            {
                var response = await _koiFishService.AddAsync(pondId, request);
                return CreatedAtAction(nameof(GetKoiFishByIdAsync), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Lấy danh sách cá koi của người dùng
        [HttpGet()]
        public async Task<ActionResult<List<KoiFishResponse>>> GetAllKoiFishByUserIdAsync()
        {
            var userId = _userContextService.GetCurrentUserId();
            try
            {
               
                var response = await _koiFishService.GetAllByUserIdAsync(userId);
                if (response == null || response.Count == 0)
                {
                    return NotFound(new { message = "No koi fish found for this user." });
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Lấy cá koi theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<KoiFishDetailResponse>> GetKoiFishByIdAsync(int id)
        {
            try
            {
                var response = await _koiFishService.GetByIdAsync(id);
                if (response == null)
                {
                    return NotFound(new { message = "Koi fish not found." });
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Cập nhật thông tin cá koi
        [HttpPut("{id}")]
        public async Task<ActionResult<KoiFishResponse>> UpdateKoiFishAsync(int id, KoiFishRequest request)
        {
            try
            {
                var response = await _koiFishService.UpdateAsync(id, request);
                if (response == null)
                {
                    return NotFound(new { message = "Koi fish not found." });
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Xóa cá koi
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteKoiFishAsync(int id)
        {
            try
            {
                var success = await _koiFishService.DeleteAsync(id);
                if (!success)
                {
                    return NotFound(new { message = "Koi fish not found." });
                }
                return NoContent(); // Trả về HTTP 204 nếu xóa thành công
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
