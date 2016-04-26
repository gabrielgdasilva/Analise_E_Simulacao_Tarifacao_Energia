using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Analise_E_Simulacao_Tarifacao_Energia.Models
{
    public class TipoSubGrupoModel
    {
        [ScaffoldColumn(false)]
        public int TipoSubGrupoID { get; set; }
        public string TipoSubGrupoString { get; set; }
    }
}