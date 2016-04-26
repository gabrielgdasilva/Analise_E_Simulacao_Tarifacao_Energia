using Analise_E_Simulacao_Tarifacao_Energia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analise_E_Simulacao_Tarifacao_Energia.Utilities
{
    public class Conversor
    {
        //----------------------------Bandeira-----------------------------------------------------------------
        //Recepção de Bandeira
        internal static BandeiraModel bandeiraRecebida(ServiceReference1.Bandeira _Bandeira)
        {
            BandeiraModel bandeiraReceptor = new BandeiraModel();

            bandeiraReceptor.BandeiraID = _Bandeira.BandeiraID;
            bandeiraReceptor.BandeiraString = _Bandeira.BandeiraString;


            return bandeiraReceptor;
        }
        //Criação de Nova Bandeira
        internal static ServiceReference1.Bandeira NovaBandeira(BandeiraModel bandeira)
        {
            ServiceReference1.Bandeira bandeiraOut = new ServiceReference1.Bandeira();
            bandeiraOut.BandeiraString = bandeira.BandeiraString;

            return bandeiraOut;
        }
        //Lista Todas as Bandeiras
        internal static List<BandeiraModel> ListaBandeira(List<ServiceReference1.Bandeira> _ListaBandeiraEntrada)
        {
            List<BandeiraModel> listaBandeiraReceptor = new List<BandeiraModel>();
            foreach (var item in _ListaBandeiraEntrada)
            {
                BandeiraModel bandeiraReceptor = new BandeiraModel();
                bandeiraReceptor.BandeiraID = item.BandeiraID;
                bandeiraReceptor.BandeiraString = item.BandeiraString;
                listaBandeiraReceptor.Add(bandeiraReceptor);
            }
            return listaBandeiraReceptor;
        }
        //----------------------------Cliente-------------------------------------------------------------------
        //Recepção de Clientes
        internal static ClienteModel clienteRecebido(ServiceReference1.Cliente _Cliente)
        {
            ClienteModel clienteReceptor = new ClienteModel();

            clienteReceptor.ClienteID = _Cliente.ClienteID;
            clienteReceptor.Nome  = _Cliente.Nome;
            clienteReceptor.Cnpj = _Cliente.Cnpj;
            clienteReceptor.RazaoSocial = _Cliente.RazaoSocial;
            clienteReceptor.Endereco = _Cliente.Endereco;
            
            return clienteReceptor;
        }

        internal static ServiceReference1.Cliente novoCliente(ClienteModel cliente)
        {
            ServiceReference1.Cliente clienteSaida = new ServiceReference1.Cliente();
            clienteSaida.Nome = clienteSaida.Nome;
            clienteSaida.Cnpj = clienteSaida.Cnpj;
            clienteSaida.RazaoSocial = clienteSaida.RazaoSocial;
            clienteSaida.Endereco = clienteSaida.Endereco;

            return clienteSaida;
        }

    }
}