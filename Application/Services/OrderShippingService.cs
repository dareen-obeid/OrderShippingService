using System;
using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Services.Interface;
using Application.Validation;
using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.RepositoriyInterfaces;

namespace Application.Services
{
    public class OrderShippingService : IOrderShippingService
    {
        private readonly IOrderShippingRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<OrderShippingDto> _orderShippingValidator;
        private readonly IValidator<ShippingStatusDto> _shippingStatusValidator;

        public OrderShippingService(
            IOrderShippingRepository repository,
            IMapper mapper,
            IValidator<OrderShippingDto> orderShippingValidator,
            IValidator<ShippingStatusDto> shippingStatusValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _orderShippingValidator = orderShippingValidator;
            _shippingStatusValidator = shippingStatusValidator;
        }

        public async Task<OrderShippingDto> GetOrderShippingByIdAsync(int orderShippingId)
        {
            var orderShipping = await _repository.GetOrderShippingByIdAsync(orderShippingId);
            if (orderShipping == null)
                throw new NotFoundException("Order shipping not found.");

            return _mapper.Map<OrderShippingDto>(orderShipping);
        }

        public async Task<IEnumerable<OrderShippingDto>> GetAllOrderShippingsAsync()
        {
            var orderShippings = await _repository.GetAllOrderShippingsAsync();
            if (!orderShippings.Any())
                throw new NotFoundException("No order shippings found.");

            return _mapper.Map<IEnumerable<OrderShippingDto>>(orderShippings);
        }

        public async Task CreateOrderShippingAsync(OrderShippingDto orderShippingDto)
        {
            _orderShippingValidator.Validate(orderShippingDto);

            var shippingStatus = await _repository.GetShippingStatusByIdAsync(orderShippingDto.ShippingStatus.ShippingStatusId);
            if (shippingStatus == null)
            {
                throw new ValidationException($"ShippingStatus with ID {orderShippingDto.ShippingStatus.ShippingStatusId} does not exist.");
            }

            var orderShipping = _mapper.Map<OrderShipping>(orderShippingDto);
            orderShipping.ShippingStatus = shippingStatus; 
            await _repository.CreateOrderShippingAsync(orderShipping);
        }

        public async Task UpdateOrderShippingAsync(OrderShippingDto orderShippingDto)
        {
            _orderShippingValidator.Validate(orderShippingDto);

            var existingOrderShipping = await _repository.GetOrderShippingByIdAsync(orderShippingDto.OrderShippingId);
            if (existingOrderShipping == null)
                throw new NotFoundException("Order shipping not found.");

            // Check and update the ShippingStatus only if the ID has changed to prevent unnecessary database calls
            if (existingOrderShipping.ShippingStatusId != orderShippingDto.ShippingStatus.ShippingStatusId)
            {
                var shippingStatus = await _repository.GetShippingStatusByIdAsync(orderShippingDto.ShippingStatus.ShippingStatusId);
                if (shippingStatus == null)
                    throw new ValidationException($"ShippingStatus with ID {orderShippingDto.ShippingStatus.ShippingStatusId} does not exist.");

                existingOrderShipping.ShippingStatus = shippingStatus;
            }

            _mapper.Map(orderShippingDto, existingOrderShipping);
            await _repository.UpdateOrderShippingAsync(existingOrderShipping);
        }


        public async Task DeactivateOrderShippingAsync(int orderShippingId)
        {
            var orderShipping = await _repository.GetOrderShippingByIdAsync(orderShippingId);
            if (orderShipping == null)
                throw new NotFoundException("Order shipping to deactivate not found.");

            orderShipping.IsActive = false;
            await _repository.UpdateOrderShippingAsync(orderShipping);
        }

        public async Task CreateShippingStatusAsync(ShippingStatusDto shippingStatusDto)
        {
            _shippingStatusValidator.Validate(shippingStatusDto);
            var shippingStatus = _mapper.Map<ShippingStatus>(shippingStatusDto);
            await _repository.CreateShippingStatusAsync(shippingStatus);
        }
    }
}