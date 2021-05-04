using System.Text.Json;
using System.Threading.Tasks;
using EventDriven.SchemaRegistry.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventDriven.SchemaRegistry.Api.Controllers
{
    [ApiController]
    [Route("api/schema")]
    public class SchemaRegistryController : ControllerBase
    {
        private readonly ISchemaRegistry _schemaRegistry;
        private readonly ILogger<SchemaRegistryController> _logger;

        public SchemaRegistryController(ISchemaRegistry schemaRegistry,
            ILogger<SchemaRegistryController> logger)
        {
            _schemaRegistry = schemaRegistry;
            _logger = logger;
        }
        
        // GET api/schema/topic
        [HttpGet]
        [Route("{topic}")]
        public async Task<IActionResult> GetSchema([FromRoute] string topic)
        {
            var schema = await _schemaRegistry.GetSchema(topic);
            if (schema == null) return NotFound();
            return Ok(schema);
        }
        
        // POST api/schema/topic
        [HttpPost]
        [Route("{topic}")]
        public async Task<IActionResult> AddSchema([FromRoute] string topic, [FromBody] JsonElement element)
        {
            var schema = element.ToString();
            var result = await _schemaRegistry.AddSchema(topic, schema);
            return !result ? BadRequest() : Ok();
        }
        
        // PUT api/schema/topic
        [HttpPut]
        [Route("{topic}")]
        public async Task<IActionResult> UpdateSchema([FromRoute] string topic, [FromBody] JsonElement element)
        {
            var schema = element.ToString();
            var result = await _schemaRegistry.UpdateSchema(topic, schema);
            return !result ? BadRequest() : Ok();
        }
        
        // DELETE api/schema/topic
        [HttpDelete]
        [Route("{topic}")]
        public async Task<IActionResult> RemoveSchema([FromRoute] string topic)
        {
            var result = await _schemaRegistry.RemoveSchema(topic);
            return !result ? BadRequest() : Ok();
        }
    }
}