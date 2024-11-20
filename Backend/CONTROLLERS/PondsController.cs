using KoiFishManager.Api.Services;
using KoiFishManager.Models.Pond;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KoiFishManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PondController : ControllerBase
    {
        private readonly IPondService _pondService;
        private readonly IUserContextService _userContextService;
        private readonly ILogger<PondController> _logger;

        public PondController(IPondService pondService, IUserContextService userContextService, ILogger<PondController> logger)
        {
            _pondService = pondService;
            _userContextService = userContextService;
            _logger = logger;
        }

    
        [HttpPost]
        public async Task<IActionResult> CreatePond([FromBody] PondRequest createRequest)
        {
            if (createRequest == null || !ModelState.IsValid)
            {
                _logger.LogWarning("Invalid pond data received for creation.");
                return BadRequest(new { message = "Invalid pond data." });
            }

            var userId = _userContextService.GetCurrentUserId();
            try
            {
                var createdPond = await _pondService.AddAsync(userId, createRequest);
                _logger.LogInformation($"Pond created successfully with ID: {createdPond.Id} for user {userId}.");
                return CreatedAtAction(nameof(GetPondById), new { id = createdPond.Id }, createdPond);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating the pond.");
                return StatusCode(500, new { message = "An error occurred while creating the pond." });
            }
        }

        
        [HttpGet("all")]
        public async Task<IActionResult> GetAllPonds()
        {
            var userId = _userContextService.GetCurrentUserId();
            try
            {
                var ponds = await _pondService.GetAllByUserIdAsync(userId);

                if (ponds == null || ponds.Count == 0)
                {
                    _logger.LogInformation($"No ponds found for user {userId}.");
                    return NoContent();
                }

                _logger.LogInformation($"Found {ponds.Count} ponds for user {userId}.");
                return Ok(ponds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all ponds.");
                return StatusCode(500, new { message = "An error occurred while fetching the ponds." });
            }
        }

        
        [HttpGet("page")]
        public async Task<IActionResult> GetPagedPonds([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var userId = _userContextService.GetCurrentUserId();

            try
            {
               
                var result = await _pondService.GetPagedByUserIdAsync(userId, page, pageSize);

                
                _logger.LogInformation("Paged ponds retrieved for user {UserId}, page {Page}, pageSize {PageSize}.", userId, page, pageSize);

              
                return Ok(result);
            }
            catch (Exception ex)
            {
               
                _logger.LogError(ex, "Error occurred while fetching paged ponds for user {UserId}.", userId);

                
                return StatusCode(500, new { message = "An error occurred while fetching the paged ponds." });
            }
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPondById(int id)
        {
            try
            {
                var pond = await _pondService.GetByIdAsync(id);

                if (pond == null)
                {
                    _logger.LogWarning($"Pond with ID {id} not found.");
                    return NotFound(new { message = "Pond not found." });
                }

                _logger.LogInformation($"Pond with ID {id} retrieved successfully.");
                return Ok(pond);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching pond with ID {id}.");
                return StatusCode(500, new { message = "An error occurred while fetching the pond." });
            }
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePond(int id, [FromBody] PondRequest updateRequest)
        {
            if (updateRequest == null || !ModelState.IsValid)
            {
                _logger.LogWarning($"Invalid pond data received for update on pond with ID {id}.");
                return BadRequest(new { message = "Invalid pond data." });
            }

            try
            {
                await _pondService.UpdateAsync(id, updateRequest);
                _logger.LogInformation($"Pond with ID {id} updated successfully.");
                return Ok(new { message = "Pond updated successfully." });
            }
            catch (KeyNotFoundException)
            {
                _logger.LogWarning($"Pond with ID {id} not found for update.");
                return NotFound(new { message = "Pond not found." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating pond with ID {id}.");
                return StatusCode(500, new { message = "An error occurred while updating the pond." });
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePond(int id)
        {
            try
            {
                await _pondService.DeleteAsync(id);
                _logger.LogInformation($"Pond with ID {id} deleted successfully.");
                return Ok(new { message = "Pond deleted successfully." });
            }
            catch (KeyNotFoundException)
            {
                _logger.LogWarning($"Pond with ID {id} not found for deletion.");
                return NotFound(new { message = "Pond not found." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting pond with ID {id}.");
                return StatusCode(500, new { message = "An error occurred while deleting the pond." });
            }
        }
    }
}
