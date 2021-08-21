using AutoMapper;
using Blue.Domain.Interface;
using Blue.Domain.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blue.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
       
        private readonly ILogger<ContatoController> _logger;
        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;


        public ContatoController(ILogger<ContatoController> logger, IContatoService contatoService, IMapper mapper)
        {
            _logger = logger;
            _contatoService = contatoService;
            _mapper = mapper;
        }

        [HttpGet("/contatos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ViewModels.Contato>> List()
        {
            var contato = await _contatoService.List();

            if (!contato.Any())
            {
                return NotFound();
            }

            var contatoViewModel = _mapper.Map<IEnumerable<ViewModels.Contato>>(contato);

            return Ok(contatoViewModel);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ViewModels.Contato>> Get(Guid id)
        {
            var contato = await _contatoService.Get(id);

            if(contato == null)
            {
                return NotFound();
            }

            var contatoViewModel = _mapper.Map<ViewModels.Contato>(contato);

            return Ok(contatoViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ViewModels.Contato>> Post(ViewModels.ContatoForCreate contatoForCreate)
        {
            var domainContato = _mapper.Map<Contato>(contatoForCreate);

            var contato = await _contatoService.Post(domainContato);

            if (contato == null)
            {
                return NotFound();
            }

            var contatoViewModel = _mapper.Map<ViewModels.Contato>(contato);

            return Ok(contatoViewModel);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ViewModels.Contato>> Delete(Guid Id)
        {

            var domainContato = _mapper.Map<Contato>(Id);

            var contato = await _contatoService.Delete(domainContato);

            if (contato == false)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ViewModels.Contato>> Put(Guid id, ViewModels.ContatoForPatch contatoForPatch)
        {

            var domainContato = _mapper.Map<Contato>(contatoForPatch);

            var contato = await _contatoService.Put(domainContato, id);

            if (contato == null)
            {
                return NotFound();
            }

            var contatoViewModel = _mapper.Map<ViewModels.Contato>(contato);

            return Ok(contatoViewModel);
        }
    }
}
