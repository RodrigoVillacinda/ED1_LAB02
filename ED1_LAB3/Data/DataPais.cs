using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ED1_LAB3.Models;
namespace ED1_LAB3.Data
{
    public class DataPais
    {

        private static DataPais instance;
        public static DataPais Instance
        {
            get
            {
                if (instance == null) instance = new DataPais();
                return instance;
            }
        }

        public AVL<Pais> arbol;

        public DataPais()
        {
            arbol = new AVL<Pais>();

        }

    }
}