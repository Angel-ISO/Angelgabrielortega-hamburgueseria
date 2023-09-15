using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Dominio.Entities;

namespace API.Controllers;


 public class CategoriaController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CategoriaDto>>> Get([FromQuery] Params categorynParams)
    {
        var category = await _unitofwork.Categorias.GetAllAsync(categorynParams.PageIndex, categorynParams.PageSize, categorynParams.Search);
        var lstPersons = _mapper.Map<List<CategoriaDto>>(category.registros);
        return new Pager<CategoriaDto>(lstPersons, category.totalRegistros, categorynParams.PageIndex, categorynParams.PageSize, categorynParams.Search);
    }


  
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaDto>> Post(CategoriaDto categoriaDto){
        var categoria = _mapper.Map<Categoria>(categoriaDto);
        this._unitofwork.Categorias.Add(categoria);
        await _unitofwork.SaveAsync();
        if(categoria == null)
        {
            return BadRequest();
        }
        categoriaDto.Id = categoria.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= categoriaDto.Id}, categoriaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Categoria>> Put(int id, [FromBody]Categoria categoria){
        if(categoria == null)
            return NotFound();
        _unitofwork.Categorias.Update(categoria);
        await _unitofwork.SaveAsync();
        return categoria;
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Categorias.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Categorias.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }
}
