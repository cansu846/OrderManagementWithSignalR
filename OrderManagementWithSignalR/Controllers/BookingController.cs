using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete.Pages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.BookingDto;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController:ControllerBase
    {
        private IBookingService _bookingService;
        private IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;

        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult GetAll()
        { 
            var values = _bookingService.GetAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _bookingService.Get(id);
            _bookingService.Delete(value);
            return Ok(Messages.Deleted);
        }
      
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _bookingService.Get(id);
            return Ok(_mapper.Map<ResultBookingDto>(value));
        }
        [HttpPost]
        public IActionResult Add(CreateBookingDto createBookingDto)
        {
            var validatorResult = _validator.Validate(createBookingDto);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }
            var value = _mapper.Map<Booking>(createBookingDto);
            _bookingService.Add(value);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult Update(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.Update(value);
            return Ok(Messages.Updated);
        }

     
    }
}
