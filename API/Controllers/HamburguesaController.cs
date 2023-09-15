using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Dominio.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class HamburguesaController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public HamburguesaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

 
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<HamburguesaDto>>> Get([FromQuery] Params hamburguesaParams)
    {
        var category = await _unitofwork.Hamburguesas.GetAllAsync(hamburguesaParams.PageIndex, hamburguesaParams.PageSize, hamburguesaParams.Search);
        var lstchef = _mapper.Map<List<HamburguesaDto>>(category.registros);
        return new Pager<HamburguesaDto>(lstchef, category.totalRegistros, hamburguesaParams.PageIndex, hamburguesaParams.PageSize, hamburguesaParams.Search);
    }


   
    
        //var Con = await  _unitofwork.Hamburguesas.GetHamburguesaIntegral();
        

  
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HamburguesaDto>> Post(HamburguesaDto HamburguesaDto){
        var Hamburguesa = _mapper.Map<Hamburguesa>(HamburguesaDto);
        this._unitofwork.Hamburguesas.Add(Hamburguesa);
        await _unitofwork.SaveAsync();
        if(Hamburguesa == null)
        {
            return BadRequest();
        }
        HamburguesaDto.Id = Hamburguesa.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= HamburguesaDto.Id}, HamburguesaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Hamburguesa>> Put(int id, [FromBody]Hamburguesa Hamburguesa){
        if(Hamburguesa == null)
            return NotFound();
        _unitofwork.Hamburguesas.Update(Hamburguesa);
        await _unitofwork.SaveAsync();
        return Hamburguesa;
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Hamburguesas.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Hamburguesas.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }
}
