﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordAnalyzer.Domain.Models;
using WordAnalyzer.Domain.Services;

namespace WordAnalyzer.Controllers
{
    [ApiController]
    [Route("[controller]")]
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