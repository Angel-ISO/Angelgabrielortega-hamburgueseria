using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace API.Dtos;

    public class IngredienteStock400
    {
    public string Id {get; set;}    
    public string Nombre {get; set;}
    public string Descripcion {get; set;}
    public string Precio {get; set;}
    public string Stock {get; set;}
    }
