using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Backend.Webapi.Data;
using SocialApp.Backend.Webapi.Dtos;
using SocialApp.Backend.Webapi.Helpers;
using SocialApp.Backend.Webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialApp.Backend.Webapi.Controllers
{
    [ServiceFilter(typeof(LastActiveActionFilter))]
    [Authorize]
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ISocialRepository _repository;
        private readonly IMapper _mapper;

        public MessagesController(ISocialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(int userId, MessageForCreateDto messageForCreateDTO)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            messageForCreateDTO.SenderId = userId;

            var recipient = await _repository.GetUser(messageForCreateDTO.RecipientId);

            if (recipient == null) return BadRequest("MEsaj göndermek istediğiniz kullanıcı yok");

            var message = _mapper.Map<Message>(messageForCreateDTO);

            _repository.Add(message);

            if(await _repository.SaveChanges())
            {
                var messageDto = _mapper.Map<MessageForCreateDto>(message);
                return Ok(messageDto);
            }

            throw new System.Exception("errror");

        }
    }
}
