using AutoMapper;
using MedBuy.Api.Responses;
using MedBuy.Domain.DTOs;
using MedBuy.Domain.Entities;
using MedBuy.Domain.Interfaces;
using MedBuy.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedBuy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _repository.GetUsuarios();
            var usuariosDto = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResponseDto>>(usuarios);
            var response = new ApiResponse<IEnumerable<UsuarioResponseDto>>(usuariosDto);
            return Ok(response);
        }
        [HttpGet("(id:int)")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _repository.GetUsuario(id);
            var usuarioDto = _mapper.Map<Usuario, UsuarioResponseDto>(usuario);
            var response = new ApiResponse<UsuarioResponseDto>(usuarioDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioRequestDto usuarioDto)
        {
            var usuario = _mapper.Map<UsuarioRequestDto, Usuario>(usuarioDto);
            await _repository.AddUsuario(usuario);
            var usuarioresponseDto = _mapper.Map<Usuario, UsuarioResponseDto>(usuario);
            var response = new ApiResponse<UsuarioResponseDto>(usuarioresponseDto);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _repository.DeleteUsuario(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, UsuarioRequestDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.Id = id;
            var result = await _repository.UpdateUsuario(usuario);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
    
    
}