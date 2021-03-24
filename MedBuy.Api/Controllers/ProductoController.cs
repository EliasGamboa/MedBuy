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
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedBuy.Api.Controllers
{
    
    [ApiController]
    
    
    [Route("api/[controller]")]
    [AllowAnonymous]
    [EnableCors("AnotherPolicy")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;
        private readonly IMapper _mapper;

        public ProductoController(IProductoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _service.GetProductos();
            var productDto = _mapper.Map<IEnumerable<Producto>, IEnumerable<ProductoResponseDto>>(products);

            var response = new ApiResponse<IEnumerable<ProductoResponseDto>>(productDto);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _service.GetProducto(id);
            var productDto = _mapper.Map<Producto, ProductoResponseDto>(product);

            var response = new ApiResponse<ProductoResponseDto>(productDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductoRequestDto productoDto)
        {
            var product = _mapper.Map<ProductoRequestDto, Producto>(productoDto);
            await _service.AddProducto(product);
            var productresponseDto = _mapper.Map<Producto, ProductoResponseDto>(product);
            var response = new ApiResponse<ProductoResponseDto>(productresponseDto);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteProducto(id);

            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm] ProductoRequestDto productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto);
            producto.ProductoId = id;

            await _service.UpdateProducto(producto);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
    }
}