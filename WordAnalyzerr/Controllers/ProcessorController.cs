using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WordAnalyzer.Domain.Models;
using WordAnalyzer.Domain.Services;

namespace WordAnalyzerr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class ProcessorController : ControllerBase
    {
        private readonly IProcessorTextService service;
        public ProcessorController(IProcessorTextService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("SendText")]
        public MessageModel<List<WordModel>> Proccess([FromBody] TextModel text)
        {
            return service.Process(text);
        }
    }
}
