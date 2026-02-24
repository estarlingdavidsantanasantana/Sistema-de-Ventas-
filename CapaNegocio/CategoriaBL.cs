using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CategoriaBL
    {
        CategoriaDAL dal = new CategoriaDAL();

        public List<Categoria> Listar()
        {
            return dal.Listar();
        }

        public void Guardar(Categoria c)
        {
            if (c.ID_categoria == 0)
                dal.Insertar(c);
            else
                dal.Actualizar(c);
        }

        public void Eliminar(int id)
        {
            dal.Eliminar(id);
        }
    }

}
