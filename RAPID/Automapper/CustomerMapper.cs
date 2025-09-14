using AutoMapper;
using RAPID.DTOs.Customer;
using RAPID.Models;

namespace RAPID.Automapper;

public class CustomerMapper: Profile
{
    public CustomerMapper()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
        CreateMap<Document, DocumentDTO>().ReverseMap();
    }
}
