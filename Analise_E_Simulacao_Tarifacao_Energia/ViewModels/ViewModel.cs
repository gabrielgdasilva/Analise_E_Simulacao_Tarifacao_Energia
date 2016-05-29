using Analise_E_Simulacao_Tarifacao_Energia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analise_E_Simulacao_Tarifacao_Energia.ViewModels
{
    public class ViewModel
    {
        UsuarioModel usuario;
        ClienteModel cliente;
        FabricaModel fabrica;

        public ViewModel(UsuarioModel _usuario, ClienteModel _cliente, FabricaModel _fabrica)
        {
            usuario = _usuario;
            cliente = _cliente;
            fabrica = _fabrica;
        }
    }
}