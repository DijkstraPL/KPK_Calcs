﻿using AutoMapper;
using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_Web.Controllers.Resources;
using Build_IT_Web.Core;
using Build_IT_Web.Core.Models;
using Build_IT_Web.Core.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Interpreter = Build_IT_ScriptInterpreter.Scripts;

namespace Build_IT_Web.Controllers
{
    [Route("/api/tags")]
    public class TagController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagController(
            IMapper mapper, 
            ITagRepository tagRepository, 
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _tagRepository.GetTags();

            if (tags?.Count == 0)
                return NotFound();

            tags = tags.OrderBy(t => t.Name).ToList();
            var scriptViewModels = _mapper.Map<List<Tag>, List<TagResource>>(tags);
            return Ok(scriptViewModels);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateTag([FromBody] TagResource tagResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tag = _mapper.Map<TagResource, Tag>(tagResource);

            _tagRepository.Add(tag);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Tag, TagResource>(tag);
            return Ok(result);
        }
    }
}