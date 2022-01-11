using AutoMapper;
using Geekiam.Database.Entities;
using Geekiam.Domain.Mapping;
using Geekiam.Domain.Requests.Categories;
using Threenine.Data;

namespace Geekiam.Data.Services;

public class CategoryDataService : IDataService<Category, Domain.Responses.Categories.Category>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public CategoryDataService(IUnitOfWork unitOfWork)
    {
        var mapperConfiguration =
            new MapperConfiguration(configuration => configuration.AddProfile<CategoryMappingProfile>());
        mapperConfiguration.AssertConfigurationIsValid();
        _mapper = mapperConfiguration.CreateMapper();
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Domain.Responses.Categories.Category> Process(Category aggregate)
    {
        var newCat = _mapper.Map<Categories>(aggregate);
        var catRepository = _unitOfWork.GetRepository<Categories>();

        var tag = catRepository.InsertNotExists(x => x.Name == newCat.Name, newCat.Created());
        await _unitOfWork.CommitAsync();

        return new Domain.Responses.Categories.Category(tag.Name, tag.Permalink);
    }
}