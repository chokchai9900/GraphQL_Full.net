using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL_Full.net.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_Full.net.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executer;
        public GraphQLController(ISchema schema, IDocumentExecuter executer)
        {
            _schema = schema;
            _executer = executer;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQueryDto query)
        {
            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;

            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            return Ok(result.Data);
        }
    }
}