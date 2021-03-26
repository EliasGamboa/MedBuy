using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedBuy.Api.Responses;
using MedBuy.Domain.DTOs;
using MedBuy.Domain.Entities;
using MedBuy.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedBuy.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _service;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pedidos = await _service.GetPedidos();
            var pedidoDto = _mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoResponseDto>>(pedidos);

            var response = new ApiResponse<IEnumerable<PedidoResponseDto>>(pedidoDto);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var pedido = await _service.GetPedido(id);
            var pedidoDto = _mapper.Map<Pedido, PedidoResponseDto>(pedido);

            var response = new ApiResponse<PedidoResponseDto>(pedidoDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PedidoRequestDto pedidoDto, List<int> lista)
        {
            var pedido = _mapper.Map<PedidoRequestDto, Pedido>(pedidoDto);
            await _service.AddPedido(pedido, lista);
            var pedidoresponseDto = _mapper.Map<Pedido, PedidoResponseDto>(pedido);
            var response = new ApiResponse<PedidoResponseDto>(pedidoresponseDto);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePedido(id);

            var response = new ApiResponse<bool>(true);

            return Ok(response);

        }
    }
}
