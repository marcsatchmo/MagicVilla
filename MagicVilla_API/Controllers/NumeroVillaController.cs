using AutoMapper;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeroVillaController : ControllerBase
    {
        private readonly ILogger<NumeroVillaController> _logger;
        private readonly IVillaRepository _villaRepo;
        private readonly INumeroVillaRepository _numeroVillaRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public NumeroVillaController(ILogger<NumeroVillaController> logger, IVillaRepository villaRepo, INumeroVillaRepository numeroVillaRepo, IMapper mapper)
        {
            _logger = logger;
            _villaRepo = villaRepo;
            _numeroVillaRepo = numeroVillaRepo;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetNumeroVillas()
        {
            try
            {
                _logger.LogInformation("Obtener Numero Villas");

                IEnumerable<NumeroVilla> numeroVillaList = await _numeroVillaRepo.GetAll();

                _response.Result = _mapper.Map<IEnumerable<VillaDto>>(numeroVillaList);
                _response.IsSuccessful = true;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("id:int", Name ="GetNumeroVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetNumeroVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Error al traer Numero Villa con Id " + id);
                    _response.IsSuccessful = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var numeroVilla = await _numeroVillaRepo.Get(x => x.VillaNro == id);

                if (numeroVilla == null)
                {
                    _response.IsSuccessful = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<IEnumerable<NumeroVillaDto>>(numeroVilla);
                _response.IsSuccessful = true;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateNumeroVilla([FromBody] NumeroVillaCreateDto createDto) 
        {
            try
            {
                if (!ModelState.IsValid) { return BadRequest(ModelState); }

                if (await _numeroVillaRepo.Get(v => v.VillaNro == createDto.VillaNro) != null)
                {
                    ModelState.AddModelError("NombreExiste", "El numero de villa ya existe!");
                    return BadRequest(ModelState);
                }

                if(await _villaRepo.Get(v => v.Id ==  createDto.VillaId) == null) 
                {
                    ModelState.AddModelError("ClaveForanea", "El Id de la villa no existe!");
                    return BadRequest(ModelState);
                }

                if (createDto == null) { return BadRequest(createDto); }

                NumeroVilla modelo = _mapper.Map<NumeroVilla>(createDto);
                modelo.FechaCreacion = DateTime.Now;
                modelo.FechaActualizacion = DateTime.Now;

                await _numeroVillaRepo.Create(modelo);

                _response.Result = modelo;
                _response.IsSuccessful = true;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetNumeroVilla", new { id = modelo.VillaNro }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteNumeroVilla(int id)
        {
            try
            {
                if (id == 0) 
                {
                    _response.IsSuccessful = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var numeroVilla = await _numeroVillaRepo.Get(v => v.VillaNro == id);

                if (numeroVilla == null) 
                {
                    _response.IsSuccessful = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response); 
                }

                await  _numeroVillaRepo.Remove(numeroVilla);

                _response.IsSuccessful = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                
                return Ok(_response);
            }
            catch (Exception  ex)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return BadRequest(_response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateNumeroVilla(int id, [FromBody] NumeroVillaUpdateDto updateDto) 
        {
            try
            {
                if (updateDto == null || id != updateDto.VillaNro)
                {
                    _response.IsSuccessful = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                if(await _villaRepo.Get(v => v.Id  ==  updateDto.VillaId) == null)
                {
                    ModelState.AddModelError("ClaveFooranea", "El Id de la Villa no existe!");
                    return BadRequest(ModelState);
                }

                NumeroVilla modelo = _mapper.Map<NumeroVilla>(updateDto);

                await _numeroVillaRepo.Update(modelo);

                _response.IsSuccessful = true;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return BadRequest(_response);
        }
    }
}
