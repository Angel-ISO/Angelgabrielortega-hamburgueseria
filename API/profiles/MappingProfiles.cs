using Dominio.Entities;
using AutoMapper;
using API.Dtos;




namespace API.Profiles;

    public class MappingPofiles : Profile
    {
      public MappingPofiles(){
          CreateMap<Categoria, CategoriaDto>().ReverseMap();
          CreateMap<Chef, ChefDto>().ReverseMap();
          CreateMap<Hamburguesa, HamburguesaDto>().ReverseMap();
          CreateMap<Ingrediente, IngredienteDto>().ReverseMap();
          CreateMap<Ingrediente, IngredienteStock400>().ReverseMap();   

      }
    }