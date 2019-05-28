namespace pathways_api.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Entities;
    using Data.Mappers;
    using Microsoft.AspNetCore.Mvc;
    using pathways_common.Controllers;
    using Services.Interfaces;

    public class RoleLevelRuleController : ApiController
    {
        private readonly IMapper mapper;
        private readonly IRoleLevelRuleService service;

        public RoleLevelRuleController(IRoleLevelRuleService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<RoleLevelRule> results = this.service.GetAll();
            IList<RoleLevelRuleDto> ruleDtos = this.mapper.Map<IList<RoleLevelRuleDto>>(results);
            return this.Ok(ruleDtos);
        }

        [HttpPost("update")]
        public IActionResult UpdateRange([FromBody] IList<RoleLevelRuleDto> collection)
        {
            IList<RoleLevelRule> entityCollection = this.mapper.Map<IList<RoleLevelRule>>(collection);
            this.service.UpdateRange(entityCollection);
            return this.Ok(entityCollection.Count);
        }
    }
}