using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.DTOs.HomePageDTOs.FaqSection;

namespace Business.Services.Concrete
{
    public class FaqManager : IFaqService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FaqManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<FaqSectionDto>> GetFaqSectionAsync()
        {
            var faqs = await _unitOfWork.FaqRepository.GetAllAsync();

            var activeFaqs = faqs
                .Where(x => x.IsActive)
                .OrderBy(x => x.Order)
                .ToList();

            var items = _mapper.Map<List<FaqItemDto>>(activeFaqs);

            var section = new FaqSectionDto
            {
                SectionTitle = "Suallarınız var?",
                SectionDescription = "Ən çox verilən sualların cavablarını burada tapa bilərsiniz.",
                Items = items
            };

            return new SuccessDataResult<FaqSectionDto>(section);
        }
    }
}
