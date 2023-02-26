using AutoMapper;

namespace Application.Mappings
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<UserTransaction, TransactionDto>()

                       .ForMember(dest => dest.Amount,
                       opt => opt.MapFrom(src => src.Amount))

                        .ForMember(dest => dest.Currency,
                        opt => opt.MapFrom(src => src.Currency))

                         .ForMember(dest => dest.CreatedAt,
                         opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}