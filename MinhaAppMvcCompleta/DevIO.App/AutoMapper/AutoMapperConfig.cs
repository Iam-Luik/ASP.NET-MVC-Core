using AppMvcBasica.Models;
using AutoMapper;
using DevIO.App.ViewsModels;

namespace DevIO.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, FornecedorViewModel>().ReverseMap();
        }
    }
}
