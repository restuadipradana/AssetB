using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using AssetB.Services;
using AssetB.DTO;
using AssetB.Models;
using AssetB.Helpers;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace AssetB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AssetController : ControllerBase
    {
        private IAssetService _assetService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AssetController(
            IAssetService assetService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _assetService = assetService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var assets = _assetService.GetAll();
            //var model = _mapper.Map<IList<AssetMaintainDTO>>(assets);
            return Ok(assets);
        }

        [HttpGet("getassetkind")]
        public IActionResult GetAssetKind(string kindno)
        {
            var assetkind = _assetService.GetAssetKind(kindno);
            return Ok(assetkind);
        }

        [HttpGet("getSingle")]
        public IActionResult GetById(string idx) //used deng //no use, id nya masih string bukan int, tabel nya gaada id pk ai
        {
            var asset = _assetService.GetByAssno(idx);
            //var model = _mapper.Map<AssetMaintainDTO>(asset);
            return Ok(asset);
        }

        [HttpPost("add")]
        public IActionResult Create([FromBody]AssetMaintainDTO model)
        {
            // map model to entity
            var asset = _mapper.Map<AssetMaintain>(model);

            try
            {
                // create user
                _assetService.Create(asset);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("edit")]
        public IActionResult Update([FromBody]AssetMaintainDTO model)
        {
            // map model to entity and set id
            var asset = _mapper.Map<AssetMaintain>(model);

            try
            {
                // update user 
                _assetService.Update(asset);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _assetService.Delete(id);
            return Ok();
        }
    }
}