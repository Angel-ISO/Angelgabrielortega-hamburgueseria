using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Dominio.Entities;

namespace API.Controllers;


 public class ChefController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public ChefController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ChefDto>>> Get([FromQuery] Params chefnParams)
    {
        var category = await _unitofwork.Chefs.GetAllAsync(chefnParams.PageIndex, chefnParams.PageSize, chefnParams.Search);
        var lstchef = _mapper.Map<List<ChefDto>>(category.registros);
        return new Pager<ChefDto>(lstchef, category.totalRegistros, chefnParams.PageIndex, chefnParams.PageSize, chefnParams.Search);
    }

  
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ChefDto>> Post(ChefDto ChefDto){
        var chef = _mapper.Map<Chef>(ChefDto);
        this._unitofwork.Chefs.Add(chef);
        await _unitofwork.SaveAsync();
        if(chef == null)
        {
            return BadRequest();
        }
        ChefDto.Id = chef.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= ChefDto.Id}, ChefDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Chef>> Put(int id, [FromBody]Chef chef){
        if(chef == null)
            return NotFound();
        _unitofwork.Chefs.Update(chef);
        await _unitofwork.SaveAsync();
        return chef;
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Chefs.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Chefs.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }
}
