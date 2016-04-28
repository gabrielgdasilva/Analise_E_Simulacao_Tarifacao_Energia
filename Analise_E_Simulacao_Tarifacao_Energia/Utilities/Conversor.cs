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
        internal static BandeiraModel BandeiraRecebida(ServiceReference1.Bandeira _Bandeira)
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
        internal static ClienteModel ClienteRecebido(ServiceReference1.Cliente _Cliente)
        {
            ClienteModel clienteReceptor = new ClienteModel();

            clienteReceptor.ClienteID = _Cliente.ClienteID;
            clienteReceptor.Nome = _Cliente.Nome;
            clienteReceptor.Cnpj = _Cliente.Cnpj;
            clienteReceptor.RazaoSocial = _Cliente.RazaoSocial;
            clienteReceptor.Endereco = _Cliente.Endereco;

            return clienteReceptor;
        }

        internal static ServiceReference1.Cliente NovoCliente(ClienteModel cliente)
        {
            ServiceReference1.Cliente clienteSaida = new ServiceReference1.Cliente();
            clienteSaida.Nome = clienteSaida.Nome;
            clienteSaida.Cnpj = clienteSaida.Cnpj;
            clienteSaida.RazaoSocial = clienteSaida.RazaoSocial;
            clienteSaida.Endereco = clienteSaida.Endereco;

            return clienteSaida;
        }

        internal static ServiceReference1.Cliente AtualizarCliente(ClienteModel cliente)
        {
            ServiceReference1.Cliente clienteSaida = new ServiceReference1.Cliente();
            clienteSaida.ClienteID = clienteSaida.ClienteID;
            clienteSaida.Nome = clienteSaida.Nome;
            clienteSaida.Cnpj = clienteSaida.Cnpj;
            clienteSaida.RazaoSocial = clienteSaida.RazaoSocial;
            clienteSaida.Endereco = clienteSaida.Endereco;

            return clienteSaida;
        }

        //----------------------------Fabrica-------------------------------------------------------------------
        //Recepção de Fabricas

        internal static FabricaModel FabricaRecebida(ServiceReference1.Fabrica _Fabrica)
        {
            FabricaModel fabricaReceptor = new FabricaModel();
            fabricaReceptor.FabricaID = _Fabrica.FabricaID;
            fabricaReceptor.ClienteID = _Fabrica.ClienteID;
            fabricaReceptor.Cnpj = _Fabrica.Cnpj;
            fabricaReceptor.Endereco = _Fabrica.Endereco;
            fabricaReceptor.DistribuidoraID = _Fabrica.DistribuidoraID;

            return fabricaReceptor;
        }

        internal static ServiceReference1.Fabrica NovaFabrica(FabricaModel fabrica)
        {
            ServiceReference1.Fabrica fabricaSaida = new ServiceReference1.Fabrica();

            fabricaSaida.ClienteID = fabrica.ClienteID;
            fabricaSaida.Cnpj = fabrica.Cnpj;
            fabricaSaida.Endereco = fabrica.Endereco;
            fabricaSaida.DistribuidoraID = fabrica.DistribuidoraID;

            return fabricaSaida;
        }

        internal static List<FabricaModel> ListaFabricas(List<ServiceReference1.Fabrica> _ListaFabricaEntrada)
        {
            List<FabricaModel> lista = new List<FabricaModel>();
            foreach (var item in _ListaFabricaEntrada)
            {
                FabricaModel fabricaReceptor = new FabricaModel();
                fabricaReceptor.FabricaID = item.FabricaID;
                fabricaReceptor.ClienteID = item.ClienteID;
                fabricaReceptor.Cnpj = item.Cnpj;
                fabricaReceptor.Endereco = item.Endereco;
                fabricaReceptor.DistribuidoraID = item.DistribuidoraID;
                lista.Add(fabricaReceptor);

            }
            return lista;
        }

        internal static ServiceReference1.Fabrica ExcluirFabrica(FabricaModel fabrica)
        {
            ServiceReference1.Fabrica fabricaSaida = new ServiceReference1.Fabrica();

            fabricaSaida.ClienteID = fabrica.ClienteID;
            fabricaSaida.Cnpj = fabrica.Cnpj;
            fabricaSaida.Endereco = fabrica.Endereco;
            fabricaSaida.DistribuidoraID = fabrica.DistribuidoraID;

            return fabricaSaida;
        }

        internal static ServiceReference1.Fabrica AlterarFabrica(FabricaModel fabrica)
        {
            ServiceReference1.Fabrica fabricaSaida = new ServiceReference1.Fabrica();

            fabricaSaida.ClienteID = fabrica.ClienteID;
            fabricaSaida.Cnpj = fabrica.Cnpj;
            fabricaSaida.Endereco = fabrica.Endereco;
            fabricaSaida.DistribuidoraID = fabrica.DistribuidoraID;

            return fabricaSaida;
        }

        //----------------------------Contrato-------------------------------------------------------------------

        internal static TipoContratoModel ContratoRecebido(ServiceReference1.TipoContrato _Contrato)
        {
            TipoContratoModel contratoReceptor = new TipoContratoModel();
            contratoReceptor.TipoContratoID = _Contrato.TipoContratoID;
            contratoReceptor.TipoContratoString = _Contrato.TipoContratoString;

            return contratoReceptor;
        }

        internal static ServiceReference1.TipoContrato NovoContrato(TipoContratoModel contrato)
        {
            ServiceReference1.TipoContrato contratoSaida = new ServiceReference1.TipoContrato();
            contratoSaida.TipoContratoID = contrato.TipoContratoID;
            contratoSaida.TipoContratoString = contrato.TipoContratoString;

            return contratoSaida;
        }

        internal static List<TipoContratoModel> ListaContratos(List<ServiceReference1.TipoContrato> _ListaContratoEntrada)
        {
            List<TipoContratoModel> listaContratos = new List<TipoContratoModel>();
            foreach (var item in _ListaContratoEntrada)
            {
                TipoContratoModel contrato = new TipoContratoModel();
                contrato.TipoContratoID = item.TipoContratoID;
                contrato.TipoContratoString = item.TipoContratoString;
                listaContratos.Add(contrato);
            }
            return listaContratos;
        }

        //----------------------------Distribuidora----------------------------------------------------------------

        internal static DistribuidoraModel DistribuidoraRecebida(ServiceReference1.Distribuidora _Distribuidora)
        {
            DistribuidoraModel distribuidora = new DistribuidoraModel();
            distribuidora.DistribuidoraID = _Distribuidora.DistribuidoraID;
            distribuidora.Nome = _Distribuidora.Nome;
            distribuidora.Cnpj = _Distribuidora.Cnpj;

            return distribuidora;
        }

        internal static ServiceReference1.Distribuidora NovaDistribuidora(DistribuidoraModel distribuidora)
        {
            ServiceReference1.Distribuidora distribuidoraSaida = new ServiceReference1.Distribuidora();
            distribuidoraSaida.DistribuidoraID = distribuidora.DistribuidoraID;
            distribuidoraSaida.Nome = distribuidora.Nome;
            distribuidoraSaida.Cnpj = distribuidora.Cnpj;

            return distribuidoraSaida;
        }

        internal static List<DistribuidoraModel> ListaDistribuidoras(List<ServiceReference1.Distribuidora> _ListaDistribuidoraEntrada)
        {
            List<DistribuidoraModel> listaDistribuidora = new List<DistribuidoraModel>();
            foreach (var item in _ListaDistribuidoraEntrada)
            {
                DistribuidoraModel distribuidora = new DistribuidoraModel();
                distribuidora.DistribuidoraID = item.DistribuidoraID;
                distribuidora.Nome = item.Nome;
                distribuidora.Cnpj = item.Cnpj;
                listaDistribuidora.Add(distribuidora);
            }
            return listaDistribuidora;
        }
        //----------------------------Subgrupo---------------------------------------------------------------------

        internal static TipoSubGrupoModel SubGrupoRecebido(ServiceReference1.TipoSubGrupo _SubGrupo)
        {
            TipoSubGrupoModel subGrupo = new TipoSubGrupoModel();
            subGrupo.TipoSubGrupoID = _SubGrupo.TipoSubGrupoID;
            subGrupo.TipoSubGrupoString = _SubGrupo.TipoSubGrupoString;

            return subGrupo;
        }

        internal static ServiceReference1.TipoSubGrupo NovoSubGrupo(TipoSubGrupoModel subGrupo)
        {
            ServiceReference1.TipoSubGrupo subGrupoSaida = new ServiceReference1.TipoSubGrupo();
            subGrupoSaida.TipoSubGrupoID = subGrupo.TipoSubGrupoID;
            subGrupoSaida.TipoSubGrupoString = subGrupo.TipoSubGrupoString;

            return subGrupoSaida;
        }

        internal static List<TipoSubGrupoModel> ListaSubGrupos(List<ServiceReference1.TipoSubGrupo> _ListaSubGrupoEntrada)
        {
            List<TipoSubGrupoModel> listaSubGrupo = new List<TipoSubGrupoModel>();
            foreach (var item in _ListaSubGrupoEntrada)
            {
                TipoSubGrupoModel subGrupo = new TipoSubGrupoModel();
                subGrupo.TipoSubGrupoID = item.TipoSubGrupoID;
                subGrupo.TipoSubGrupoString = item.TipoSubGrupoString;
                listaSubGrupo.Add(subGrupo);
            }
            return listaSubGrupo;
        }

        //----------------------------Tarifa---------------------------------------------------------------------

        internal static TarifaModel TarifaRecebida(ServiceReference1.Tarifa _Tarifa)
        {
            TarifaModel tarifa = new TarifaModel();
            tarifa.TarifaID = _Tarifa.TarifaID;
            tarifa.DistribuidoraID = _Tarifa.DistribuidoraID;
            tarifa.TipoContratoID = _Tarifa.TipoContratoID;
            tarifa.TipoSubGrupoID = _Tarifa.TipoSubGrupoID;
            tarifa.DataReferencia = _Tarifa.DataReferencia;
            tarifa.PotenciaMin = _Tarifa.PotenciaMin;
            tarifa.PotenciaMax = _Tarifa.PotenciaMax;
            tarifa.ConsumoNaPontaTUSD_TarifaPreco = _Tarifa.ConsumoNaPontaTUSD_TarifaPreco;
            tarifa.ConsumoForaPontaTUSD_TarifaPreco = _Tarifa.ConsumoForaPontaTUSD_TarifaPreco;
            tarifa.ConsumoNaPontaTE_TarifaPreco = _Tarifa.ConsumoNaPontaTE_TarifaPreco;
            tarifa.ConsumoForaPontaTE_TarifaPreco = _Tarifa.ConsumoForaPontaTE_TarifaPreco;
            tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco = _Tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco;
            tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco = _Tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco;
            tarifa.DemandaTUSD_TarifaPreco = _Tarifa.DemandaTUSD_TarifaPreco;
            tarifa.BandeiraID = _Tarifa.BandeiraID;

            return tarifa;

        }

        internal static ServiceReference1.Tarifa NovaTarifa(TarifaModel tarifa)
        {
            ServiceReference1.Tarifa tarifaSaida = new ServiceReference1.Tarifa();

            tarifaSaida.TarifaID = tarifa.TarifaID;
            tarifaSaida.DistribuidoraID = tarifa.DistribuidoraID;
            tarifaSaida.TipoContratoID = tarifa.TipoContratoID;
            tarifaSaida.TipoSubGrupoID = tarifa.TipoSubGrupoID;
            tarifaSaida.DataReferencia = tarifa.DataReferencia;
            tarifaSaida.PotenciaMin = tarifa.PotenciaMin;
            tarifaSaida.PotenciaMax = tarifa.PotenciaMax;
            tarifaSaida.ConsumoNaPontaTUSD_TarifaPreco = tarifa.ConsumoNaPontaTUSD_TarifaPreco;
            tarifaSaida.ConsumoForaPontaTUSD_TarifaPreco = tarifa.ConsumoForaPontaTUSD_TarifaPreco;
            tarifaSaida.ConsumoNaPontaTE_TarifaPreco = tarifa.ConsumoNaPontaTE_TarifaPreco;
            tarifaSaida.ConsumoForaPontaTE_TarifaPreco = tarifa.ConsumoForaPontaTE_TarifaPreco;
            tarifaSaida.ConsumoUltrapassagemNaPonta_TarifaPreco = tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco;
            tarifaSaida.ConsumoUltrapassagemForaPonta_TarifaPreco = tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco;
            tarifaSaida.DemandaTUSD_TarifaPreco = tarifa.DemandaTUSD_TarifaPreco;
            tarifaSaida.BandeiraID = tarifa.BandeiraID;

            return tarifaSaida;
        }

        internal static List<TarifaModel> TodasTarifas(List<ServiceReference1.Tarifa> _ListaTarifaEntrada)
        {
            List<TarifaModel> listaTarifas = new List<TarifaModel>();
            foreach (var item in _ListaTarifaEntrada)
            {
                TarifaModel tarifa = new TarifaModel();
                tarifa.TarifaID = item.TarifaID;
                tarifa.DistribuidoraID = item.DistribuidoraID;
                tarifa.TipoContratoID = item.TipoContratoID;
                tarifa.TipoSubGrupoID = item.TipoSubGrupoID;
                tarifa.DataReferencia = item.DataReferencia;
                tarifa.PotenciaMin = item.PotenciaMin;
                tarifa.PotenciaMax = item.PotenciaMax;
                tarifa.ConsumoNaPontaTUSD_TarifaPreco = item.ConsumoNaPontaTUSD_TarifaPreco;
                tarifa.ConsumoForaPontaTUSD_TarifaPreco = item.ConsumoForaPontaTUSD_TarifaPreco;
                tarifa.ConsumoNaPontaTE_TarifaPreco = item.ConsumoNaPontaTE_TarifaPreco;
                tarifa.ConsumoForaPontaTE_TarifaPreco = item.ConsumoForaPontaTE_TarifaPreco;
                tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco = item.ConsumoUltrapassagemNaPonta_TarifaPreco;
                tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco = item.ConsumoUltrapassagemForaPonta_TarifaPreco;
                tarifa.DemandaTUSD_TarifaPreco = item.DemandaTUSD_TarifaPreco;
                tarifa.BandeiraID = item.BandeiraID;

                listaTarifas.Add(tarifa);
            }
            return listaTarifas;
        }

        internal static ServiceReference1.Tarifa AtualizarTarifa(TarifaModel tarifa)
        {
            ServiceReference1.Tarifa tarifaSaida = new ServiceReference1.Tarifa();

            tarifaSaida.TarifaID = tarifa.TarifaID;
            tarifaSaida.DistribuidoraID = tarifa.DistribuidoraID;
            tarifaSaida.TipoContratoID = tarifa.TipoContratoID;
            tarifaSaida.TipoSubGrupoID = tarifa.TipoSubGrupoID;
            tarifaSaida.DataReferencia = tarifa.DataReferencia;
            tarifaSaida.PotenciaMin = tarifa.PotenciaMin;
            tarifaSaida.PotenciaMax = tarifa.PotenciaMax;
            tarifaSaida.ConsumoNaPontaTUSD_TarifaPreco = tarifa.ConsumoNaPontaTUSD_TarifaPreco;
            tarifaSaida.ConsumoForaPontaTUSD_TarifaPreco = tarifa.ConsumoForaPontaTUSD_TarifaPreco;
            tarifaSaida.ConsumoNaPontaTE_TarifaPreco = tarifa.ConsumoNaPontaTE_TarifaPreco;
            tarifaSaida.ConsumoForaPontaTE_TarifaPreco = tarifa.ConsumoForaPontaTE_TarifaPreco;
            tarifaSaida.ConsumoUltrapassagemNaPonta_TarifaPreco = tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco;
            tarifaSaida.ConsumoUltrapassagemForaPonta_TarifaPreco = tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco;
            tarifaSaida.DemandaTUSD_TarifaPreco = tarifa.DemandaTUSD_TarifaPreco;
            tarifaSaida.BandeiraID = tarifa.BandeiraID;

            return tarifaSaida;
        }

        internal static ServiceReference1.Tarifa ExcluirTarifa(TarifaModel tarifa)
        {
            ServiceReference1.Tarifa tarifaSaida = new ServiceReference1.Tarifa();

            tarifaSaida.TarifaID = tarifa.TarifaID;
            tarifaSaida.DistribuidoraID = tarifa.DistribuidoraID;
            tarifaSaida.TipoContratoID = tarifa.TipoContratoID;
            tarifaSaida.TipoSubGrupoID = tarifa.TipoSubGrupoID;
            tarifaSaida.DataReferencia = tarifa.DataReferencia;
            tarifaSaida.PotenciaMin = tarifa.PotenciaMin;
            tarifaSaida.PotenciaMax = tarifa.PotenciaMax;
            tarifaSaida.ConsumoNaPontaTUSD_TarifaPreco = tarifa.ConsumoNaPontaTUSD_TarifaPreco;
            tarifaSaida.ConsumoForaPontaTUSD_TarifaPreco = tarifa.ConsumoForaPontaTUSD_TarifaPreco;
            tarifaSaida.ConsumoNaPontaTE_TarifaPreco = tarifa.ConsumoNaPontaTE_TarifaPreco;
            tarifaSaida.ConsumoForaPontaTE_TarifaPreco = tarifa.ConsumoForaPontaTE_TarifaPreco;
            tarifaSaida.ConsumoUltrapassagemNaPonta_TarifaPreco = tarifa.ConsumoUltrapassagemNaPonta_TarifaPreco;
            tarifaSaida.ConsumoUltrapassagemForaPonta_TarifaPreco = tarifa.ConsumoUltrapassagemForaPonta_TarifaPreco;
            tarifaSaida.DemandaTUSD_TarifaPreco = tarifa.DemandaTUSD_TarifaPreco;
            tarifaSaida.BandeiraID = tarifa.BandeiraID;

            return tarifaSaida;
        }

        //----------------------------Usuario---------------------------------------------------------------------

        internal static UsuarioModel UsuarioRecebido(ServiceReference1.Usuario _Usuario)
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario.Email = _Usuario.Email;
            usuario.ClienteID = _Usuario.ClienteID;
            usuario.Cpf = _Usuario.Cpf;
            usuario.Nome = _Usuario.Nome;
            usuario.Senha = _Usuario.Senha;
            usuario.Ativo = _Usuario.Ativo;
            usuario.DataRegistro = _Usuario.DataRegistro;
            usuario.Tipo = _Usuario.Tipo;

            return usuario;
        }

        internal static ServiceReference1.Usuario NovoUsuario(UsuarioModel usuario)
        {
            ServiceReference1.Usuario usuarioSaida = new ServiceReference1.Usuario();
            usuarioSaida.Email = usuario.Email;
            usuarioSaida.ClienteID = usuario.ClienteID;
            usuarioSaida.Cpf = usuario.Cpf;
            usuarioSaida.Nome = usuario.Nome;
            usuarioSaida.Senha = usuario.Senha;
            usuarioSaida.Ativo = usuario.Ativo;
            usuarioSaida.DataRegistro = usuario.DataRegistro;
            usuarioSaida.Tipo = usuario.Tipo;

            return usuarioSaida;
        }

        internal static ServiceReference1.Usuario AtualizarUsuario(UsuarioModel usuario)
        {
            ServiceReference1.Usuario usuarioSaida = new ServiceReference1.Usuario();
            usuarioSaida.Email = usuario.Email;
            usuarioSaida.ClienteID = usuario.ClienteID;
            usuarioSaida.Cpf = usuario.Cpf;
            usuarioSaida.Nome = usuario.Nome;
            usuarioSaida.Senha = usuario.Senha;
            usuarioSaida.Ativo = usuario.Ativo;
            usuarioSaida.DataRegistro = usuario.DataRegistro;
            usuarioSaida.Tipo = usuario.Tipo;

            return usuarioSaida;
        }

        internal static ServiceReference1.Usuario ExcluirUsuario(UsuarioModel usuario)
        {
            ServiceReference1.Usuario usuarioSaida = new ServiceReference1.Usuario();
            usuarioSaida.Email = usuario.Email;
            usuarioSaida.ClienteID = usuario.ClienteID;
            usuarioSaida.Cpf = usuario.Cpf;
            usuarioSaida.Nome = usuario.Nome;
            usuarioSaida.Senha = usuario.Senha;
            usuarioSaida.Ativo = usuario.Ativo;
            usuarioSaida.DataRegistro = usuario.DataRegistro;
            usuarioSaida.Tipo = usuario.Tipo;

            return usuarioSaida;
        }

        //----------------------------Contas---------------------------------------------------------------------
        internal static ContaModel ContaRecebida(ServiceReference1.Conta _Conta)
        {
            ContaModel conta = new ContaModel();

            conta.dataReferencia = _Conta.dataReferencia;
            conta.TarifaID = _Conta.TarifaID;
            conta.FabricaID = _Conta.FabricaID;
            conta.DistribuidoraID = _Conta.DistribuidoraID;
            conta.TipoContratoID = _Conta.TipoContratoID;
            conta.TipoSubGrupoID = _Conta.TipoSubGrupoID;
            conta.ConsumoNaPontaTUSD_Registrado = _Conta.ConsumoNaPontaTUSD_Registrado;
            conta.ConsumoForaPontaTUSD_Registrado = _Conta.ConsumoForaPontaTUSD_Registrado;
            conta.ConsumoNaPontaTE_Registrado = _Conta.ConsumoNaPontaTE_Registrado;
            conta.ConsumoForaPontaTE_Registrado = _Conta.ConsumoForaPontaTE_Registrado;
            conta.ConsumoUltrapassagemNaPonta_Registrado = _Conta.ConsumoUltrapassagemNaPonta_Registrado;
            conta.ConsumoUltrapassagemForaPonta_Registrado = _Conta.ConsumoUltrapassagemForaPonta_Registrado;
            conta.DemandaTUSD_Registrado = _Conta.DemandaTUSD_Registrado;
            conta.ConsumoNaPontaTUSD_Contratado = _Conta.ConsumoNaPontaTUSD_Contratado;
            conta.ConsumoForaPontaTUSD_Contratado = _Conta.ConsumoForaPontaTUSD_Contratado;
            conta.ConsumoForaPontaTE_Contratado = _Conta.ConsumoForaPontaTE_Contratado;
            conta.DemandaTUSD_Contratado = _Conta.DemandaTUSD_Contratado;
            conta.ConsumoNaPontaTUSD_Faturado = _Conta.ConsumoNaPontaTUSD_Faturado;
            conta.ConsumoForaPontaTUSD_Faturado = _Conta.ConsumoForaPontaTUSD_Faturado;
            conta.ConsumoNaPontaTE_Faturado = _Conta.ConsumoNaPontaTE_Faturado;
            conta.ConsumoForaPontaTE_Faturado = _Conta.ConsumoForaPontaTE_Faturado;
            conta.ConsumoUltrapassagemNaPonta_Faturado = _Conta.ConsumoUltrapassagemNaPonta_Faturado;
            conta.ConsumoUltrapassagemForaPonta_Faturado = _Conta.ConsumoUltrapassagemForaPonta_Faturado;
            conta.DemandaTUSD_Faturado = _Conta.DemandaTUSD_Faturado;
            conta.ConsumoNaPontaTUSD_TarifaPreco = _Conta.ConsumoNaPontaTUSD_TarifaPreco;
            conta.ConsumoForaPontaTUSD_TarifaPreco = _Conta.ConsumoForaPontaTUSD_TarifaPreco;
            conta.ConsumoNaPontaTE_TarifaPreco = _Conta.ConsumoNaPontaTE_TarifaPreco;
            conta.ConsumoForaPontaTE_TarifaPreco = _Conta.ConsumoForaPontaTE_TarifaPreco;
            conta.ConsumoUltrapassagemNaPonta_TarifaPreco = _Conta.ConsumoUltrapassagemNaPonta_TarifaPreco;
            conta.ConsumoUltrapassagemForaPonta_TarifaPreco = _Conta.ConsumoUltrapassagemForaPonta_TarifaPreco;
            conta.DemandaTUSD_TarifaPreco = _Conta.DemandaTUSD_TarifaPreco;
            conta.ConsumoNaPontaTUSD_Valor = _Conta.ConsumoNaPontaTUSD_Valor;
            conta.ConsumoForaPontaTUSD_Valor = _Conta.ConsumoForaPontaTUSD_Valor;
            conta.ConsumoNaPontaTE_Valor = _Conta.ConsumoNaPontaTE_Valor;
            conta.ConsumoForaPontaTE_Valor = _Conta.ConsumoForaPontaTE_Valor;
            conta.ConsumoUltrapassagemNaPonta_Valor = _Conta.ConsumoUltrapassagemNaPonta_Valor;
            conta.ConsumoUltrapassagemForaPonta_Valor = _Conta.ConsumoUltrapassagemForaPonta_Valor;
            conta.DemandaTUSD_Valor = _Conta.DemandaTUSD_Valor;
            conta.SubTotal = _Conta.SubTotal;
            conta.ValorTotal = _Conta.ValorTotal;
            conta.BandeiraID = _Conta.BandeiraID;

            return conta;
        }

        internal static ServiceReference1.Conta CadastrarConta(ContaModel conta)
        {
            ServiceReference1.Conta contaSaida = new ServiceReference1.Conta();

            contaSaida.dataReferencia = conta.dataReferencia;
            contaSaida.TarifaID = conta.TarifaID;
            contaSaida.FabricaID = conta.FabricaID;
            contaSaida.DistribuidoraID = conta.DistribuidoraID;
            contaSaida.TipoContratoID = conta.TipoContratoID;
            contaSaida.TipoSubGrupoID = conta.TipoSubGrupoID;
            contaSaida.ConsumoNaPontaTUSD_Registrado = conta.ConsumoNaPontaTUSD_Registrado;
            contaSaida.ConsumoForaPontaTUSD_Registrado = conta.ConsumoForaPontaTUSD_Registrado;
            contaSaida.ConsumoNaPontaTE_Registrado = conta.ConsumoNaPontaTE_Registrado;
            contaSaida.ConsumoForaPontaTE_Registrado = conta.ConsumoForaPontaTE_Registrado;
            contaSaida.ConsumoUltrapassagemNaPonta_Registrado = conta.ConsumoUltrapassagemNaPonta_Registrado;
            contaSaida.ConsumoUltrapassagemForaPonta_Registrado = conta.ConsumoUltrapassagemForaPonta_Registrado;
            contaSaida.DemandaTUSD_Registrado = conta.DemandaTUSD_Registrado;
            contaSaida.ConsumoNaPontaTUSD_Contratado = conta.ConsumoNaPontaTUSD_Contratado;
            contaSaida.ConsumoForaPontaTUSD_Contratado = conta.ConsumoForaPontaTUSD_Contratado;
            contaSaida.ConsumoForaPontaTE_Contratado = conta.ConsumoForaPontaTE_Contratado;
            contaSaida.DemandaTUSD_Contratado = conta.DemandaTUSD_Contratado;
            contaSaida.ConsumoNaPontaTUSD_Faturado = conta.ConsumoNaPontaTUSD_Faturado;
            contaSaida.ConsumoForaPontaTUSD_Faturado = conta.ConsumoForaPontaTUSD_Faturado;
            contaSaida.ConsumoNaPontaTE_Faturado = conta.ConsumoNaPontaTE_Faturado;
            contaSaida.ConsumoForaPontaTE_Faturado = conta.ConsumoForaPontaTE_Faturado;
            contaSaida.ConsumoUltrapassagemNaPonta_Faturado = conta.ConsumoUltrapassagemNaPonta_Faturado;
            contaSaida.ConsumoUltrapassagemForaPonta_Faturado = conta.ConsumoUltrapassagemForaPonta_Faturado;
            contaSaida.DemandaTUSD_Faturado = conta.DemandaTUSD_Faturado;
            contaSaida.ConsumoNaPontaTUSD_TarifaPreco = conta.ConsumoNaPontaTUSD_TarifaPreco;
            contaSaida.ConsumoForaPontaTUSD_TarifaPreco = conta.ConsumoForaPontaTUSD_TarifaPreco;
            contaSaida.ConsumoNaPontaTE_TarifaPreco = conta.ConsumoNaPontaTE_TarifaPreco;
            contaSaida.ConsumoForaPontaTE_TarifaPreco = conta.ConsumoForaPontaTE_TarifaPreco;
            contaSaida.ConsumoUltrapassagemNaPonta_TarifaPreco = conta.ConsumoUltrapassagemNaPonta_TarifaPreco;
            contaSaida.ConsumoUltrapassagemForaPonta_TarifaPreco = conta.ConsumoUltrapassagemForaPonta_TarifaPreco;
            contaSaida.DemandaTUSD_TarifaPreco = conta.DemandaTUSD_TarifaPreco;
            contaSaida.ConsumoNaPontaTUSD_Valor = conta.ConsumoNaPontaTUSD_Valor;
            contaSaida.ConsumoForaPontaTUSD_Valor = conta.ConsumoForaPontaTUSD_Valor;
            contaSaida.ConsumoNaPontaTE_Valor = conta.ConsumoNaPontaTE_Valor;
            contaSaida.ConsumoForaPontaTE_Valor = conta.ConsumoForaPontaTE_Valor;
            contaSaida.ConsumoUltrapassagemNaPonta_Valor = conta.ConsumoUltrapassagemNaPonta_Valor;
            contaSaida.ConsumoUltrapassagemForaPonta_Valor = conta.ConsumoUltrapassagemForaPonta_Valor;
            contaSaida.DemandaTUSD_Valor = conta.DemandaTUSD_Valor;
            contaSaida.SubTotal = conta.SubTotal;
            contaSaida.ValorTotal = conta.ValorTotal;
            contaSaida.BandeiraID = conta.BandeiraID;

            return contaSaida;
        }

        internal static List<ContaModel> ListaContas(List<ServiceReference1.Conta> _ListaContasEntrada)
        {
            List<ContaModel> listaContas = new List<ContaModel>();
            foreach (var item in _ListaContasEntrada)
            {
                ContaModel conta = new ContaModel();
                conta.dataReferencia = item.dataReferencia;
                conta.TarifaID = item.TarifaID;
                conta.FabricaID = item.FabricaID;
                conta.DistribuidoraID = item.DistribuidoraID;
                conta.TipoContratoID = item.TipoContratoID;
                conta.TipoSubGrupoID = item.TipoSubGrupoID;
                conta.ConsumoNaPontaTUSD_Registrado = item.ConsumoNaPontaTUSD_Registrado;
                conta.ConsumoForaPontaTUSD_Registrado = item.ConsumoForaPontaTUSD_Registrado;
                conta.ConsumoNaPontaTE_Registrado = item.ConsumoNaPontaTE_Registrado;
                conta.ConsumoForaPontaTE_Registrado = item.ConsumoForaPontaTE_Registrado;
                conta.ConsumoUltrapassagemNaPonta_Registrado = item.ConsumoUltrapassagemNaPonta_Registrado;
                conta.ConsumoUltrapassagemForaPonta_Registrado = item.ConsumoUltrapassagemForaPonta_Registrado;
                conta.DemandaTUSD_Registrado = item.DemandaTUSD_Registrado;
                conta.ConsumoNaPontaTUSD_Contratado = item.ConsumoNaPontaTUSD_Contratado;
                conta.ConsumoForaPontaTUSD_Contratado = item.ConsumoForaPontaTUSD_Contratado;
                conta.ConsumoForaPontaTE_Contratado = item.ConsumoForaPontaTE_Contratado;
                conta.DemandaTUSD_Contratado = item.DemandaTUSD_Contratado;
                conta.ConsumoNaPontaTUSD_Faturado = item.ConsumoNaPontaTUSD_Faturado;
                conta.ConsumoForaPontaTUSD_Faturado = item.ConsumoForaPontaTUSD_Faturado;
                conta.ConsumoNaPontaTE_Faturado = item.ConsumoNaPontaTE_Faturado;
                conta.ConsumoForaPontaTE_Faturado = item.ConsumoForaPontaTE_Faturado;
                conta.ConsumoUltrapassagemNaPonta_Faturado = item.ConsumoUltrapassagemNaPonta_Faturado;
                conta.ConsumoUltrapassagemForaPonta_Faturado = item.ConsumoUltrapassagemForaPonta_Faturado;
                conta.DemandaTUSD_Faturado = item.DemandaTUSD_Faturado;
                conta.ConsumoNaPontaTUSD_TarifaPreco = item.ConsumoNaPontaTUSD_TarifaPreco;
                conta.ConsumoForaPontaTUSD_TarifaPreco = item.ConsumoForaPontaTUSD_TarifaPreco;
                conta.ConsumoNaPontaTE_TarifaPreco = item.ConsumoNaPontaTE_TarifaPreco;
                conta.ConsumoForaPontaTE_TarifaPreco = item.ConsumoForaPontaTE_TarifaPreco;
                conta.ConsumoUltrapassagemNaPonta_TarifaPreco = item.ConsumoUltrapassagemNaPonta_TarifaPreco;
                conta.ConsumoUltrapassagemForaPonta_TarifaPreco = item.ConsumoUltrapassagemForaPonta_TarifaPreco;
                conta.DemandaTUSD_TarifaPreco = item.DemandaTUSD_TarifaPreco;
                conta.ConsumoNaPontaTUSD_Valor = item.ConsumoNaPontaTUSD_Valor;
                conta.ConsumoForaPontaTUSD_Valor = item.ConsumoForaPontaTUSD_Valor;
                conta.ConsumoNaPontaTE_Valor = item.ConsumoNaPontaTE_Valor;
                conta.ConsumoForaPontaTE_Valor = item.ConsumoForaPontaTE_Valor;
                conta.ConsumoUltrapassagemNaPonta_Valor = item.ConsumoUltrapassagemNaPonta_Valor;
                conta.ConsumoUltrapassagemForaPonta_Valor = item.ConsumoUltrapassagemForaPonta_Valor;
                conta.DemandaTUSD_Valor = item.DemandaTUSD_Valor;
                conta.SubTotal = item.SubTotal;
                conta.ValorTotal = item.ValorTotal;
                conta.BandeiraID = item.BandeiraID;

                listaContas.Add(conta);
            }
            return listaContas;
        }

        internal static ServiceReference1.Conta AtualizarConta(ContaModel conta)
        {
            ServiceReference1.Conta contaSaida = new ServiceReference1.Conta();

            contaSaida.dataReferencia = conta.dataReferencia;
            contaSaida.TarifaID = conta.TarifaID;
            contaSaida.FabricaID = conta.FabricaID;
            contaSaida.DistribuidoraID = conta.DistribuidoraID;
            contaSaida.TipoContratoID = conta.TipoContratoID;
            contaSaida.TipoSubGrupoID = conta.TipoSubGrupoID;
            contaSaida.ConsumoNaPontaTUSD_Registrado = conta.ConsumoNaPontaTUSD_Registrado;
            contaSaida.ConsumoForaPontaTUSD_Registrado = conta.ConsumoForaPontaTUSD_Registrado;
            contaSaida.ConsumoNaPontaTE_Registrado = conta.ConsumoNaPontaTE_Registrado;
            contaSaida.ConsumoForaPontaTE_Registrado = conta.ConsumoForaPontaTE_Registrado;
            contaSaida.ConsumoUltrapassagemNaPonta_Registrado = conta.ConsumoUltrapassagemNaPonta_Registrado;
            contaSaida.ConsumoUltrapassagemForaPonta_Registrado = conta.ConsumoUltrapassagemForaPonta_Registrado;
            contaSaida.DemandaTUSD_Registrado = conta.DemandaTUSD_Registrado;
            contaSaida.ConsumoNaPontaTUSD_Contratado = conta.ConsumoNaPontaTUSD_Contratado;
            contaSaida.ConsumoForaPontaTUSD_Contratado = conta.ConsumoForaPontaTUSD_Contratado;
            contaSaida.ConsumoForaPontaTE_Contratado = conta.ConsumoForaPontaTE_Contratado;
            contaSaida.DemandaTUSD_Contratado = conta.DemandaTUSD_Contratado;
            contaSaida.ConsumoNaPontaTUSD_Faturado = conta.ConsumoNaPontaTUSD_Faturado;
            contaSaida.ConsumoForaPontaTUSD_Faturado = conta.ConsumoForaPontaTUSD_Faturado;
            contaSaida.ConsumoNaPontaTE_Faturado = conta.ConsumoNaPontaTE_Faturado;
            contaSaida.ConsumoForaPontaTE_Faturado = conta.ConsumoForaPontaTE_Faturado;
            contaSaida.ConsumoUltrapassagemNaPonta_Faturado = conta.ConsumoUltrapassagemNaPonta_Faturado;
            contaSaida.ConsumoUltrapassagemForaPonta_Faturado = conta.ConsumoUltrapassagemForaPonta_Faturado;
            contaSaida.DemandaTUSD_Faturado = conta.DemandaTUSD_Faturado;
            contaSaida.ConsumoNaPontaTUSD_TarifaPreco = conta.ConsumoNaPontaTUSD_TarifaPreco;
            contaSaida.ConsumoForaPontaTUSD_TarifaPreco = conta.ConsumoForaPontaTUSD_TarifaPreco;
            contaSaida.ConsumoNaPontaTE_TarifaPreco = conta.ConsumoNaPontaTE_TarifaPreco;
            contaSaida.ConsumoForaPontaTE_TarifaPreco = conta.ConsumoForaPontaTE_TarifaPreco;
            contaSaida.ConsumoUltrapassagemNaPonta_TarifaPreco = conta.ConsumoUltrapassagemNaPonta_TarifaPreco;
            contaSaida.ConsumoUltrapassagemForaPonta_TarifaPreco = conta.ConsumoUltrapassagemForaPonta_TarifaPreco;
            contaSaida.DemandaTUSD_TarifaPreco = conta.DemandaTUSD_TarifaPreco;
            contaSaida.ConsumoNaPontaTUSD_Valor = conta.ConsumoNaPontaTUSD_Valor;
            contaSaida.ConsumoForaPontaTUSD_Valor = conta.ConsumoForaPontaTUSD_Valor;
            contaSaida.ConsumoNaPontaTE_Valor = conta.ConsumoNaPontaTE_Valor;
            contaSaida.ConsumoForaPontaTE_Valor = conta.ConsumoForaPontaTE_Valor;
            contaSaida.ConsumoUltrapassagemNaPonta_Valor = conta.ConsumoUltrapassagemNaPonta_Valor;
            contaSaida.ConsumoUltrapassagemForaPonta_Valor = conta.ConsumoUltrapassagemForaPonta_Valor;
            contaSaida.DemandaTUSD_Valor = conta.DemandaTUSD_Valor;
            contaSaida.SubTotal = conta.SubTotal;
            contaSaida.ValorTotal = conta.ValorTotal;
            contaSaida.BandeiraID = conta.BandeiraID;

            return contaSaida;
        }

        internal static ServiceReference1.Conta ExcluirConta(ContaModel conta)
        {
            ServiceReference1.Conta contaSaida = new ServiceReference1.Conta();

            contaSaida.dataReferencia = conta.dataReferencia;
            contaSaida.TarifaID = conta.TarifaID;
            contaSaida.FabricaID = conta.FabricaID;
            contaSaida.DistribuidoraID = conta.DistribuidoraID;
            contaSaida.TipoContratoID = conta.TipoContratoID;
            contaSaida.TipoSubGrupoID = conta.TipoSubGrupoID;
            contaSaida.ConsumoNaPontaTUSD_Registrado = conta.ConsumoNaPontaTUSD_Registrado;
            contaSaida.ConsumoForaPontaTUSD_Registrado = conta.ConsumoForaPontaTUSD_Registrado;
            contaSaida.ConsumoNaPontaTE_Registrado = conta.ConsumoNaPontaTE_Registrado;
            contaSaida.ConsumoForaPontaTE_Registrado = conta.ConsumoForaPontaTE_Registrado;
            contaSaida.ConsumoUltrapassagemNaPonta_Registrado = conta.ConsumoUltrapassagemNaPonta_Registrado;
            contaSaida.ConsumoUltrapassagemForaPonta_Registrado = conta.ConsumoUltrapassagemForaPonta_Registrado;
            contaSaida.DemandaTUSD_Registrado = conta.DemandaTUSD_Registrado;
            contaSaida.ConsumoNaPontaTUSD_Contratado = conta.ConsumoNaPontaTUSD_Contratado;
            contaSaida.ConsumoForaPontaTUSD_Contratado = conta.ConsumoForaPontaTUSD_Contratado;
            contaSaida.ConsumoForaPontaTE_Contratado = conta.ConsumoForaPontaTE_Contratado;
            contaSaida.DemandaTUSD_Contratado = conta.DemandaTUSD_Contratado;
            contaSaida.ConsumoNaPontaTUSD_Faturado = conta.ConsumoNaPontaTUSD_Faturado;
            contaSaida.ConsumoForaPontaTUSD_Faturado = conta.ConsumoForaPontaTUSD_Faturado;
            contaSaida.ConsumoNaPontaTE_Faturado = conta.ConsumoNaPontaTE_Faturado;
            contaSaida.ConsumoForaPontaTE_Faturado = conta.ConsumoForaPontaTE_Faturado;
            contaSaida.ConsumoUltrapassagemNaPonta_Faturado = conta.ConsumoUltrapassagemNaPonta_Faturado;
            contaSaida.ConsumoUltrapassagemForaPonta_Faturado = conta.ConsumoUltrapassagemForaPonta_Faturado;
            contaSaida.DemandaTUSD_Faturado = conta.DemandaTUSD_Faturado;
            contaSaida.ConsumoNaPontaTUSD_TarifaPreco = conta.ConsumoNaPontaTUSD_TarifaPreco;
            contaSaida.ConsumoForaPontaTUSD_TarifaPreco = conta.ConsumoForaPontaTUSD_TarifaPreco;
            contaSaida.ConsumoNaPontaTE_TarifaPreco = conta.ConsumoNaPontaTE_TarifaPreco;
            contaSaida.ConsumoForaPontaTE_TarifaPreco = conta.ConsumoForaPontaTE_TarifaPreco;
            contaSaida.ConsumoUltrapassagemNaPonta_TarifaPreco = conta.ConsumoUltrapassagemNaPonta_TarifaPreco;
            contaSaida.ConsumoUltrapassagemForaPonta_TarifaPreco = conta.ConsumoUltrapassagemForaPonta_TarifaPreco;
            contaSaida.DemandaTUSD_TarifaPreco = conta.DemandaTUSD_TarifaPreco;
            contaSaida.ConsumoNaPontaTUSD_Valor = conta.ConsumoNaPontaTUSD_Valor;
            contaSaida.ConsumoForaPontaTUSD_Valor = conta.ConsumoForaPontaTUSD_Valor;
            contaSaida.ConsumoNaPontaTE_Valor = conta.ConsumoNaPontaTE_Valor;
            contaSaida.ConsumoForaPontaTE_Valor = conta.ConsumoForaPontaTE_Valor;
            contaSaida.ConsumoUltrapassagemNaPonta_Valor = conta.ConsumoUltrapassagemNaPonta_Valor;
            contaSaida.ConsumoUltrapassagemForaPonta_Valor = conta.ConsumoUltrapassagemForaPonta_Valor;
            contaSaida.DemandaTUSD_Valor = conta.DemandaTUSD_Valor;
            contaSaida.SubTotal = conta.SubTotal;
            contaSaida.ValorTotal = conta.ValorTotal;
            contaSaida.BandeiraID = conta.BandeiraID;

            return contaSaida;
        }
        //----------------------------Simulacao---------------------------------------------------------------------
        internal static ServiceReference1.Fabrica IniciarSimulacao(FabricaModel fabrica)
        {
            ServiceReference1.Fabrica fabricaSaida = new ServiceReference1.Fabrica();
            fabricaSaida.FabricaID = fabrica.FabricaID;
            fabricaSaida.ClienteID = fabrica.ClienteID;
            fabricaSaida.Cnpj = fabrica.Cnpj;
            fabricaSaida.Endereco = fabrica.Endereco;
            fabricaSaida.DistribuidoraID = fabrica.DistribuidoraID;

            return fabricaSaida;
        }

        //----------------------------Grafico----------------------------------------------------------------------
        internal static List<GraficoModel> DadosGrafico(List<ServiceReference1.Grafico> _ListaEntradaGrafico)
        {
            List<GraficoModel> listaGrafico = new List<GraficoModel>();
            foreach (var item in _ListaEntradaGrafico)
            {
                GraficoModel grafico = new GraficoModel();

                grafico.SimulacaoID = item.SimulacaoID;
                grafico.DataDaSimulacao = item.DataDaSimulacao;
                grafico.DataReferencia = item.DataReferencia;
                grafico.TarifaOrigemID = item.TarifaOrigemID;
                grafico.TarifaDestinoID = item.TarifaDestinoID;
                grafico.FabricaID = item.FabricaID;
                grafico.DistribuidoraID = item.DistribuidoraID;
                grafico.TipoContratoID = item.TipoContratoID;
                grafico.TipoSubGrupoID = item.TipoSubGrupoID;
                grafico.BandeiraID = item.BandeiraID;
                grafico.ConsumoNaPontaTUSD_Registrado = item.ConsumoNaPontaTUSD_Registrado;
                grafico.ConsumoForaPontaTUSD_Registrado = item.ConsumoForaPontaTUSD_Registrado;
                grafico.ConsumoNaPontaTE_Registrado = item.ConsumoNaPontaTE_Registrado;
                grafico.ConsumoForaPontaTE_Registrado = item.ConsumoForaPontaTE_Registrado;
                grafico.ConsumoUltrapassagemNaPonta_Registrado = item.ConsumoUltrapassagemNaPonta_Registrado;
                grafico.ConsumoUltrapassagemForaPonta_Registrado = item.ConsumoUltrapassagemForaPonta_Registrado;
                grafico.DemandaTUSD_Registrado = item.DemandaTUSD_Registrado;
                grafico.ConsumoNaPontaTUSD_Contratado = item.ConsumoNaPontaTUSD_Contratado;
                grafico.ConsumoForaPontaTUSD_Contratado = item.ConsumoForaPontaTUSD_Contratado;
                grafico.ConsumoNaPontaTE_Contratado = item.ConsumoNaPontaTE_Contratado;
                grafico.ConsumoForaPontaTE_Contratado = item.ConsumoForaPontaTE_Contratado;
                grafico.DemandaTUSD_Contratado = item.DemandaTUSD_Contratado;
                grafico.ConsumoNaPontaTUSD_Faturado = item.ConsumoNaPontaTUSD_Faturado;
                grafico.ConsumoForaPontaTUSD_Faturado = item.ConsumoForaPontaTUSD_Faturado;
                grafico.ConsumoNaPontaTE_Faturado = item.ConsumoNaPontaTE_Faturado;
                grafico.ConsumoForaPontaTE_Faturado = item.ConsumoForaPontaTE_Faturado;
                grafico.ConsumoUltrapassagemNaPonta_Faturado = item.ConsumoUltrapassagemNaPonta_Faturado;
                grafico.ConsumoUltrapassagemForaPonta_Faturado = item.ConsumoUltrapassagemForaPonta_Faturado;
                grafico.DemandaTUSD_Faturado = item.DemandaTUSD_Faturado;
                grafico.ConsumoNaPontaTUSD_TarifaPreco = item.ConsumoNaPontaTUSD_TarifaPreco;
                grafico.ConsumoForaPontaTUSD_TarifaPreco = item.ConsumoForaPontaTUSD_TarifaPreco;
                grafico.ConsumoNaPontaTE_TarifaPreco = item.ConsumoNaPontaTE_TarifaPreco;
                grafico.ConsumoForaPontaTE_TarifaPreco = item.ConsumoForaPontaTE_TarifaPreco;
                grafico.ConsumoUltrapassagemNaPonta_TarifaPreco = item.ConsumoUltrapassagemNaPonta_TarifaPreco;
                grafico.ConsumoUltrapassagemForaPonta_TarifaPreco = item.ConsumoUltrapassagemForaPonta_TarifaPreco;
                grafico.DemandaTUSD_TarifaPreco = item.DemandaTUSD_TarifaPreco;
                grafico.ConsumoNaPontaTUSD_Valor = item.ConsumoNaPontaTUSD_Valor;
                grafico.ConsumoForaPontaTUSD_Valor = item.ConsumoForaPontaTUSD_Valor;
                grafico.ConsumoNaPontaTE_Valor = item.ConsumoNaPontaTE_Valor;
                grafico.ConsumoForaPontaTE_Valor = item.ConsumoForaPontaTE_Valor;
                grafico.ConsumoUltrapassagemNaPonta_Valor = item.ConsumoUltrapassagemNaPonta_Valor;
                grafico.ConsumoUltrapassagemForaPonta_Valor = item.ConsumoUltrapassagemForaPonta_Valor;
                grafico.DemandaTUSD_Valor = item.DemandaTUSD_Valor;
                grafico.SubTotal = item.SubTotal;
                grafico.ValorTotal = item.ValorTotal;
                grafico.TipoContratoDestinoID = item.TipoContratoDestinoID;
                listaGrafico.Add(grafico);
            }
            return listaGrafico;
        }

    }
}