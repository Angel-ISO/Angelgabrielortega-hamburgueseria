using Dominio.Interfaces;
using Persistencia;
using Aplication.Repository;

namespace Aplicacion.UnitOfWork;

    public class UnitOfWork : IUnitOfWork, IDisposable 
    {
        private readonly PAppContext _context;

        private UsuarioRepository _Usuario;
        private RolRepository _Rol;
        private CategoriaRepository _Categoria;
        private ChefRepository _Chef;
        private IngredienteRepository _Ingrediente;
       private HamburguesaRepository _Hamburguesa;
        public UnitOfWork(PAppContext context)
        {
            _context = context;
        }

        public IUsuario Usuarios
    {
        get
        {
            if (_Usuario is not null)
            {
                return _Usuario;
            }
            return _Usuario = new UsuarioRepository(_context);
        }
    }


    
        public ICategoria Categorias
    {
        get
        {
            if (_Categoria is not null)
            {
                return _Categoria;
            }
            return _Categoria = new CategoriaRepository(_context);
        }
    }


    
        public IChef Chefs
    {
        get
        {
            if (_Chef is not null)
            {
                return _Chef;
            }
            return _Chef = new ChefRepository(_context);
        }
    }



    
        public IIngrediente Ingredientes
    {
        get
        {
            if(_Ingrediente is not null)
            {
                return _Ingrediente;
            }
            return _Ingrediente = new IngredienteRepository(_context);
        }
    }


    
        public IHamburguesa Hamburguesas
    {
        get
        {
            if (_Hamburguesa is not null)
            {
                return _Hamburguesa;
            }
            return _Hamburguesa = new HamburguesaRepository(_context);
        }
    }


    public IRol Roles
    {
        get
        {
            if (_Rol is not null)
            {
                return _Rol;
            }
            return _Rol = new RolRepository(_context);
        }
    }


    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync(){
        return await _context.SaveChangesAsync();
    }

} 