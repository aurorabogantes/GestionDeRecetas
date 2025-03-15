
using GestionDeRecetas.BC.Modelos;
using GestionDeRecetas.BC.ReglasDeNegocio;
using GestionDeRecetas.BW.Interfaces.BW;
using GestionDeRecetas.BW.Interfaces.DA;

namespace GestionDeRecetas.BW.CU
{
    public class GestionarIngredienteBW : IGestionarIngredientesBW
    {
        private readonly IGestionarIngredienteDA _gestionarIngredienteDA;
        public GestionarIngredienteBW(IGestionarIngredienteDA _gestionarIngredienteDA)
        {
            this._gestionarIngredienteDA = _gestionarIngredienteDA;
        }

        public Task<bool> actualizarIngrediente(int id, Ingrediente ingrediente)
        {
            if (!ReglasDeIngrediente.elIdEsValido(id) || !ReglasDeIngrediente.elIngredienteEsValido(ingrediente))
            {
                return Task.FromResult(false);
            }
            return _gestionarIngredienteDA.actualizarIngrediente(id, ingrediente);
        }

        public Task<bool> eliminarIngrediente(int id)
        {
            return !ReglasDeIngrediente.elIdEsValido(id) ?
                _gestionarIngredienteDA.eliminarIngrediente(id) :
                Task.FromResult(false);
        }

        public Task<bool> obtenerIngrediente(int id)
        {
            return !ReglasDeIngrediente.elIdEsValido(id) ?
                _gestionarIngredienteDA.obtenerIngrediente(id) :
                Task.FromResult(false);
        }

        public Task<List<Ingrediente>> obtenerIngredientes()
        {
            return _gestionarIngredienteDA.obtenerIngredientes();
        }

        public Task<bool> registrarIngrediente(Ingrediente ingrediente)
        {
            return !ReglasDeIngrediente.elIngredienteEsValido(ingrediente) ?
                _gestionarIngredienteDA.registrarIngrediente(ingrediente) :
                Task.FromResult(false);
        }
    }
}
