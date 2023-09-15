namespace Dominio.Interfaces;
public interface IUnitOfWork
{
    IUsuario Usuarios {get;}  
    IRol Roles {get;}  
    IIngrediente Ingredientes {get;}  
    ICategoria Categorias {get;}  
    IHamburguesa Hamburguesas {get;} 
    IChef   Chefs {get;}
    Task<int> SaveAsync();
}