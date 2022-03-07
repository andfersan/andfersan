using DioSeries.Interface;
using DioSeries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DioSeries.Repositorio
{
    // Responsabildade do repositorio é fazer o meio de campo entre o programa e o banco de dados que seria a listaserie
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        // Considerando o indice do vetor da propria lista
        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
         // Posso implementar o envio de email ao exluir uma informacao ou criar uma classe de negocio que acessa o repositorio uma classe chamando a outra
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;

        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }



}
