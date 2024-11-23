using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Entities.Pages;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.ContactDto;

namespace WebApi.Controllers
{
    //[controller] ifadesi, sınıfın adını alır (bu örnekte About), dolayısıyla bu denetleyiciye gelen
    //isteklerin rotası api/about olacaktır.
    [Route("api/[controller]")]

    //sınıfın bir API denetleyicisi olduğunu belirtir.
    [ApiController]
    public class ContactController:ControllerBase
    {
        private IContactService _contactService;
        private IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _contactService.GetAll();
            _mapper.Map<List<ResultContactDto>>(values);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Add(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
          _contactService.Add(value);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _contactService.Get(id);
            _contactService.Delete(value);
            return Ok(Messages.Deleted);
        }
        [HttpPut]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.Update(value);
            return Ok(Messages.Updated);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _contactService.Get(id);
            return Ok(value);
        }
    }
}
