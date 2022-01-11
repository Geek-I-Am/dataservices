using AutoMapper;
using Geekiam.Database.Entities;
using Geekiam.Domain.Mapping;
using Geekiam.Domain.Responses.Tags;
using Threenine.Data;


namespace Geekiam.Data.Services;

public class TagDataService : IDataService<Geekiam.Domain.Requests.Tags.Tag, Domain.Responses.Tags.Tag>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TagDataService(IUnitOfWork unitOfWork)
    {
        var mapperConfiguration =
            new MapperConfiguration(configuration => configuration.AddProfile<TagMappingProfile>());
        mapperConfiguration.AssertConfigurationIsValid();
        _mapper = mapperConfiguration.CreateMapper();
        _unitOfWork = unitOfWork;
    }

    public async Task<Tag> Process(Domain.Requests.Tags.Tag aggregate)
    {
        var newTag = _mapper.Map<Tags>(aggregate);
        var tagRepository = _unitOfWork.GetRepository<Tags>();

        var tag = tagRepository.InsertNotExists(x => x.Name == newTag.Name, newTag.Created());
        await _unitOfWork.CommitAsync();

        return new Tag(tag.Name, tag.Permalink);
    }
}
