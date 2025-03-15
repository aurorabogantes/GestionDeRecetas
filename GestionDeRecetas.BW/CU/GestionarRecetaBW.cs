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

        public Task<bool> actualizarReceta(int id, Receta receta)
        {
            if (!ReglasDeReceta.elIdEsValido(id) || !ReglasDeReceta.laRecetaEsValida(receta))
            {
                return Task.FromResult(false);
            }
            return _gestionarRecetasDA.actualizarReceta(id, receta);
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
