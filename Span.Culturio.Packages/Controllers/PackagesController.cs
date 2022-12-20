﻿using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Core.Models.Package;
using Span.Culturio.Packages.Services;

namespace Span.Culturio.Packages.Controllers
{
    [Tags("Packages")]
    [Route("packages")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        /// <summary>
        /// Create package
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CreatePackageDto>> CreatePackageAsync([FromBody] CreatePackageDto createPackageDto)
        {
            var package = await _packageService.CreatePackageAsync(createPackageDto);
            return Ok(package);
        }

        /// <summary>
        /// Get packages
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<PackageDto>>> GetPackagesAsync()
        {
            var packages = await _packageService.GetPackagesAsync();
            return Ok(packages);
        }
    }
}
