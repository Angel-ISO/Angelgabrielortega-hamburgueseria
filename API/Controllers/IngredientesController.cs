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

 public class IngredienteController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public IngredienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<IngredienteDto>>> Get([FromQuery] Params ingredienteParams)
    {
        var ingrediente = await _unitofwork.Ingredientes.GetAllAsync(ingredienteParams.PageIndex, ingredienteParams.PageSize, ingredienteParams.Search);
        var lst = _mapper.Map<List<IngredienteDto>>(ingrediente.registros);
        return new Pager<IngredienteDto>(lst, ingrediente.totalRegistros, ingredienteParams.PageIndex, ingredienteParams.PageSize, ingredienteParams.Search);
    }


    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<IngredienteStock400>>> Get11([FromQuery] Params productParams)
    {
        var result = await _unitofwork.Ingredientes
                                    .GetAllAsync(productParams.PageIndex, productParams.PageSize,
                                    productParams.Search);

        var ingredienteslst = _mapper.Map<List<IngredienteStock400>>(result.registros);
        Response.Headers.Add("X-InlineCount", result.totalRegistros.ToString()); 

        return new Pager<IngredienteStock400>(ingredienteslst, result.totalRegistros, 
            productParams.PageIndex, productParams.PageSize, productParams.Search);

    }
      
    // [HttpGet]
    // [MapToApiVersion("1.1")]    
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<IEnumerable<IngredienteDto>>> Get()
    // {
    //     var Con = await  _unitofwork.Ingredientes.GetProductosAgotados();
    //     return _mapper.Map<List<IngredienteDto>>(Con);
    // }




    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IngredienteDto>> Post(IngredienteDto IngredienteDto){
        var ingrediente = _mapper.Map<Ingrediente>(IngredienteDto);
        this._unitofwork.Ingredientes.Add(ingrediente);
        await _unitofwork.SaveAsync();
        if(ingrediente == null)
        {
            return BadRequest();
        }
        IngredienteDto.Id = ingrediente.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= IngredienteDto.Id}, IngredienteDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Ingrediente>> Put(int id, [FromBody]Ingrediente Ingrediente){
        if(Ingrediente == null)
            return NotFound();
        _unitofwork.Ingredientes.Update(Ingrediente);
        await _unitofwork.SaveAsync();
        return Ingrediente;
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Ingredientes.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Ingredientes.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }




}
