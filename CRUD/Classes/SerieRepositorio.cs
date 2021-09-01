using System;
using System.Collections.Generic;
using CRUD.Series.Interfaces; 

namespace CRUD.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Series> listaSeries = new List<Series>();

        public void Atualiza(int id, Series objeto)
        {
            listaSeries[id] = objto;
        }

         public void Excluir(int id)
        {
            listaSeries[id].Excluir();
        }

         public void Insere(Series objeto)
        {
            listaSeries.Add(objeto)
        }

         public List<Series> Lista()
        {
           return listaSeries;
        }

         public int ProximoId()
        {
            return listaSeries.Count;
        }

         public Series RetornaPorId(int id)
        {
            return listaSeries[id];
        }
    }
}