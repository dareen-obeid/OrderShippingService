using System;
using Application.DTOs;
using Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderShippingsController : ControllerBase
    {
        private readonly IOrderShippingService _orderShippingService;

        public OrderShippingsController(IOrderShippingService orderShippingService)
        {
            _orderShippingService = orderShippingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderShippingById(int id)
        {
            var orderShipping = await _orderShippingService.GetOrderShippingByIdAsync(id);
            return Ok(orderShipping);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderShippings()
        {
            var orderShippings = await _orderShippingService.GetAllOrderShippingsAsync();
            return Ok(orderShippings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderShipping([FromBody] OrderShippingDto orderShippingDto)
        {
            await _orderShippingService.CreateOrderShippingAsync(orderShippingDto);
            return CreatedAtAction(nameof(GetOrderShippingById), new { id = orderShippingDto.OrderShippingId }, orderShippingDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderShipping(int id, [FromBody] OrderShippingDto orderShippingDto)
        {
            await _orderShippingService.UpdateOrderShippingAsync(orderShippingDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeactivateOrderShipping(int id)
        {
            await _orderShippingService.DeactivateOrderShippingAsync(id);
            return NoContent();
        }

        //[HttpPost("shipping-status")]
        //public async Task<IActionResult> CreateShippingStatus([FromBody] ShippingStatusDto shippingStatusDto)
        //{
        //    await _orderShippingService.CreateShippingStatusAsync(shippingStatusDto);
        //    return CreatedAtAction("GetShippingStatus", new { id = shippingStatusDto.ShippingStatusId }, shippingStatusDto);
        //}
    }
}