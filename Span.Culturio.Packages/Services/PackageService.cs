using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Core.Models.Package;
using Span.Culturio.Packages.Data;
using Span.Culturio.Packages.Data.Entities;

namespace Span.Culturio.Packages.Services
{
    public class PackageService : IPackageService
    {
        private readonly IMapper _iMapper;
        private readonly DataContext _dataContext;

        public PackageService(IMapper mapper, DataContext dataContext)
        {
            _iMapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<PackageDto> CreatePackageAsync(CreatePackageDto createPackageDto)
        {
            var createPackageItemsDto = createPackageDto.CultureObjects;

            var package = _iMapper.Map<Package>(createPackageDto);
            var packageItems = _iMapper.Map<List<PackageItem>>(createPackageItemsDto);

            await _dataContext.AddAsync(package);
            await _dataContext.SaveChangesAsync();

            packageItems.ForEach(x => x.PackageId = package.Id);

            await _dataContext.AddRangeAsync(packageItems);
            await _dataContext.SaveChangesAsync();

            var packageItemsDto = _iMapper.Map<IEnumerable<PackageItemDto>>(packageItems);

            var packageDto = new PackageDto()
            {
                CultureObjects = packageItemsDto,
                ValidDays = package.ValidDays,
                Id = package.Id,
                Name = package.Name,
            };

            return packageDto;
        }

        public async Task<List<PackageDto>> GetPackagesAsync()
        {
            var packages = await _dataContext.Packages.ToListAsync();
            var packageDtos = _iMapper.Map<List<PackageDto>>(packages);

            packageDtos.ForEach(x =>
            {
                var packageItems = _dataContext.PackageItems.Where(y => y.PackageId == x.Id).ToList();
                var packageItemDtos = _iMapper.Map<List<PackageItemDto>>(packageItems);
                x.CultureObjects = packageItemDtos;
            });

            return packageDtos;
        }
    }
}