using GestionDeRecetas.BC.Modelos;
using GestionDeRecetas.BC.ReglasDeNegocio;
using GestionDeRecetas.BW.Interfaces.BW;
using GestionDeRecetas.BW.Interfaces.DA;

namespace GestionDeRecetas.BW.CU
{
    public class GestionarRecetaBW : IGestionarRecetasBW
    {
        private readonly IGestionarRecetasDA _gestionarRecetasDA;
        public GestionarRecetaBW(IGestionarRecetasDA _gestionarRecetasDA)
        {
            this._gestionarRecetasDA = _gestionarRecetasDA;
        }

        public async Task<bool> ActualizarIngredienteReceta(int recetaId, int ingredienteId, RecetaIngrediente dto)
        {
            if(!ReglasDeReceta.elIdEsValido(recetaId) || !ReglasDeIngrediente.elIdEsValido(ingredienteId))
            {
                return false;
            }

            if(dto.Cantidad <= 0)
            {
                return false;
            }

            return await _gestionarRecetasDA.ActualizarIngredienteReceta(recetaId, ingredienteId, dto);
        }

        public Task<bool> actualizarReceta(int id, Receta receta)
        {
            if (!ReglasDeReceta.elIdEsValido(id) || !ReglasDeReceta.laRecetaEsValida(receta))
            {
                return Task.FromResult(false);
            }
            return _gestionarRecetasDA.actualizarReceta(id, receta);
        }

        public async Task<bool> AregarIngredienteReceta(int recetaId, RecetaIngrediente dto)
        {
            if(!ReglasDeReceta.elIdEsValido(recetaId))
            {
                return false;
            }

            if(dto.Cantidad <= 0)
            {
                return false;
            }

            return await _gestionarRecetasDA.AregarIngredienteReceta(recetaId, dto);
        }

        public async Task<bool> EliminarIngredienteReceta(int recetaId, int ingredienteId)
        {
            if(!ReglasDeReceta.elIdEsValido(recetaId) || !ReglasDeIngrediente.elIdEsValido(ingredienteId))
            {
                return false;
            }

            return await _gestionarRecetasDA.EliminarIngredienteReceta(recetaId, ingredienteId);
        }

        public Task<bool> eliminarReceta(int id)
        {
            return !ReglasDeReceta.elIdEsValido(id) ?
                _gestionarRecetasDA.eliminarReceta(id) :
                Task.FromResult(false);
        }

        public Task<bool> obtenerReceta(int id)
        {
            return !ReglasDeReceta.elIdEsValido(id) ?
                _gestionarRecetasDA.obtenerReceta(id) :
                Task.FromResult(false);
        }

        public Task<List<Receta>> obtenerRecetas()
        {
            return _gestionarRecetasDA.obtenerRecetas();
        }

        public Task<bool> registrarReceta(Receta receta)
        {
            return !ReglasDeReceta.laRecetaEsValida(receta) ?
                _gestionarRecetasDA.registrarReceta(receta) :
                Task.FromResult(false);
        }
    }
}
