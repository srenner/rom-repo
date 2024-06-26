﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RomRepo.service.Services.Interfaces;
using RomRepo.console.Models;
using System.IO.Compression;
using System.Net;
using System.Net.Mime;
using System.IO;
using System;
using System.Runtime.CompilerServices;
using RomRepo.service.Services;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Builder;
using System.Diagnostics;

namespace RomRepo.console.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RomController : ControllerBase
    {
        private ILogger<RomController> _logger;
        private readonly IRomService _service;
        private readonly ICoreService _coreService;

        public RomController(ILogger<RomController> logger, IRomService service, ICoreService coreService)
        {
            _logger = logger;
            _service = service;
            _coreService = coreService;
        }

        [HttpGet]
        public async Task<ActionResult<Rom>> GetRom(int romID)
        {
            var rom = await _service.GetRom(romID);
            return Ok(rom);
        }

        /// <summary>
        /// Retrieves list of potential Roms found in a Core's folder that are not in the database
        /// </summary>
        /// <param name="coreID"></param>
        /// <returns></returns>
        [HttpGet("discover")]
        public async Task<ActionResult<IEnumerable<Rom>>> DiscoverCoreRomsAsync(int coreID)
        {
            var core = await _coreService.GetCore(coreID);
            if(core != null)
            {
                var roms = await _service.DiscoverRoms(core);
                return Ok(roms);
            }
            else
            {
                return BadRequest("Core not found");
            }
        }

        [HttpGet("crc32")]
        public async Task<ActionResult<string>> GetCRCChecksum(int romID)
        {
            var rom = await _service.GetRom(romID);
            if(rom.IsArchive())
            {
                var files = rom.ExtractToFile(isTemporary: true);
                if(files?.Count() > 0)
                {
                    return ChecksumService.CalculateCRC(files[0]);
                }
                else
                {
                    return BadRequest("Archive is empty");
                }
            }
            else
            {
                return ChecksumService.CalculateCRC(rom.Path);
            }
        }

        [HttpGet("md5")]
        public async Task<ActionResult<string>> GetMD5Checksum(int romID)
        {
            var rom = await _service.GetRom(romID);
            if (rom.IsArchive())
            {
                var files = rom.ExtractToFile(isTemporary: true);
                if (files?.Count() > 0)
                {
                    return ChecksumService.CalculateHashString<MD5>(MD5.Create(), files[0]);
                }
                else
                {
                    return BadRequest("Archive is empty");
                }
            }
            else
            {
                return ChecksumService.CalculateHashString<MD5>(MD5.Create(), rom.Path);
            }
        }

        [HttpGet("sha1")]
        public async Task<ActionResult<string>> GetSHA1Checksum(int romID)
        {
            var rom = await _service.GetRom(romID);
            if (rom.IsArchive())
            {
                var files = rom.ExtractToFile(isTemporary: true);
                if (files?.Count() > 0)
                {
                    return ChecksumService.CalculateHashString<SHA1>(SHA1.Create(), files[0]);
                }
                else
                {
                    return BadRequest("Archive is empty");
                }
            }
            else
            {
                return ChecksumService.CalculateHashString<SHA1>(SHA1.Create(), rom.Path);
            }
        }

        [HttpGet("sha256")]
        public async Task<ActionResult<string>> GetSHA256Checksum(int romID)
        {
            var rom = await _service.GetRom(romID);
            if (rom.IsArchive())
            {
                var files = rom.ExtractToFile(isTemporary: true);
                if (files?.Count() > 0)
                {
                    return ChecksumService.CalculateHashString<SHA256>(SHA256.Create(), files[0]);
                }
                else
                {
                    return BadRequest("Archive is empty");
                }
            }
            else
            {
                return ChecksumService.CalculateHashString<SHA256>(SHA256.Create(), rom.Path);
            }
        }

        [HttpPost("addrange")]
        public async Task<ActionResult<int>> AddRoms(IEnumerable<Rom> roms)
        {
            int result = await _service.AddRoms(roms);
            return Ok(result);
        }

        /// <summary>
        /// Packages up all roms in a core folder in a zip file for download
        /// </summary>
        /// <param name="coreID"></param>
        /// <param name="unzipFirst"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("download-all")]
        public async Task<IActionResult> DownloadEntireCore(int coreID, bool unzipFirst)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var core = await _coreService.GetCore(coreID);
            if (core != null)
            {
                var roms = await _service.GetRomsForCore(coreID);
                var ms = _service.ExtractAndPack(roms);
                stopwatch.Stop();
                Directory.CreateDirectory("/app-cache/tmp");
                using (FileStream file = new FileStream("/app-cache/tmp/" + core.Name + ".zip", FileMode.Create, System.IO.FileAccess.Write))
                {
                    ms.WriteTo(file);
                    file.Close();
                }
                return File(ms, "application/octet-stream", core.Name + ".zip");
            }
            else
            {
                return BadRequest("Core not found");
            }
            throw new NotImplementedException($"coreID: {coreID}, unzipFirst: {unzipFirst}");
        }

        [HttpPost("extract")]
        public async Task<IActionResult> ExtractRom(int romID, bool isTemporary)
        {
            var rom = await _service.GetRom(romID);
            if(rom.IsArchive())
            {
                var paths = rom.ExtractToFile(isTemporary);
                return File(System.IO.File.ReadAllBytes(paths[0]), "application/octet-stream", System.IO.Path.GetFileName(paths[0]));
            }
            else
            {
                throw new IOException("Archive type not recognized: " + rom.Path);
            }
        }

    }
}
