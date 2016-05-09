using Analise_E_Simulacao_Tarifacao_Energia.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analise_E_Simulacao_Tarifacao_Energia.Utilities
{
    public static class Calendario
    {
        private static DateTime[] datas = {
            Convert.ToDateTime("01/01/2015"),
            Convert.ToDateTime("01/02/2015"),
            Convert.ToDateTime("01/03/2015"),
            Convert.ToDateTime("01/04/2015"),
            Convert.ToDateTime("01/05/2015"),
            Convert.ToDateTime("01/06/2015"),
            Convert.ToDateTime("01/07/2015"),
            Convert.ToDateTime("01/08/2015"),
            Convert.ToDateTime("01/09/2015"),
            Convert.ToDateTime("01/10/2015"),
            Convert.ToDateTime("01/11/2015"),
            Convert.ToDateTime("01/12/2015")
            };

        public static IEnumerable<Mes> ListaDeMeses()
        {
            List<Mes> meses = new List<Mes>();

            for(int i = 0; i < datas.Length; i++)
            {
                meses.Add(new Mes {
                    NomeMes = datas[i].ToString("MMM", CultureInfo.CurrentCulture),
                    NumeroMes = datas[i].ToString("MM")
                });
            }

            return meses;
        }
    }
}
