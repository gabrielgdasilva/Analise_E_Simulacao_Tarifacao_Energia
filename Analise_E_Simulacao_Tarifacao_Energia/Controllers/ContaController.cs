using Analise_E_Simulacao_Tarifacao_Energia.Models;
using Analise_E_Simulacao_Tarifacao_Energia.Utilities;
using Analise_E_Simulacao_Tarifacao_Energia.Validacoes;
using Analise_E_Simulacao_Tarifacao_Energia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analise_E_Simulacao_Tarifacao_Energia.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        [VerificaAutenticacao]
        public ActionResult List(int? id)
        {
            int fabricaID = 0;

            if (id != null)
            {
                fabricaID = (int)id;
            }
            else if (Session["IdFabrica"] != null)
            {
                fabricaID = (int)Session["IdFabrica"];
            }

            List<ContaModel> listaConta = new List<ContaModel>();
            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                List<ServiceReference1.Conta> listaDeEntrada = client.TodasContas(fabricaID).ToList();
                listaConta = Conversor.ListaContas(listaDeEntrada);
            }

            Session["IdFabrica"] = fabricaID;

            return View(listaConta);
        }

        // GET: Conta/Details/5
        [VerificaAutenticacao]
        public ActionResult Details(DateTime data)
        {
            ContaModel contaModelo = new ContaModel();
            int fabricaID = (int)Session["IdFabrica"];

            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Conta contaEntrada = client.DestalhesDaConta(data, fabricaID);
                contaModelo = Conversor.ContaRecebida(contaEntrada);
            }
            
            return View(contaModelo);
        }

        // GET: Conta/Create
        [VerificaAutenticacao]
        public ActionResult Create()
        {
            List<DistribuidoraModel> distribuidoras = new List<DistribuidoraModel>();
            List<Mes> meses = Calendario.ListaDeMeses().ToList();
            List<TipoContratoModel> contratos = new List<TipoContratoModel>();
            List<TipoSubGrupoModel> grupos = new List<TipoSubGrupoModel>();
            List<BandeiraModel> bandeiras = new List<BandeiraModel>();

            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                List<ServiceReference1.Distribuidora> listaDeDistribuidoras = client.TodasDistribuidoras().ToList();
                distribuidoras = Conversor.ListaDistribuidoras(listaDeDistribuidoras);

                List<ServiceReference1.TipoContrato> listaDeContratos = client.TodosContratos().ToList();
                contratos = Conversor.ListaContratos(listaDeContratos);

                List<ServiceReference1.TipoSubGrupo> listaDeGrupos = client.TodosSubGrupos().ToList();
                grupos = Conversor.ListaSubGrupos(listaDeGrupos);

                List<ServiceReference1.Bandeira> listaDeBandeiras = client.TodasBandeiras().ToList();
                bandeiras = Conversor.ListaBandeira(listaDeBandeiras);

            }

            ContaViewModel cvm = new ContaViewModel(null, bandeiras, meses, distribuidoras, contratos, grupos);
            
            return View(cvm);
        }

        // POST: Conta/Create
        [HttpPost]
        public ActionResult Create(ContaViewModel cvm)
        {
            try
            {
                List<TarifaModel> tarifas = new List<TarifaModel>();

                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    List<ServiceReference1.Tarifa> listaDeTarifas = client.TodasTarifas().ToList();
                    tarifas = Conversor.TodasTarifas(listaDeTarifas);
                }

                ContaModel contaModelo = cvm.ObterConta();
                contaModelo.TarifaID = tarifas.Where(x => x.TipoContratoID == contaModelo.TipoContratoID && x.TipoSubGrupoID == contaModelo.TipoSubGrupoID && x.BandeiraID == contaModelo.BandeiraID).Select(x => x.TarifaID).FirstOrDefault();
                int? fabricaID = Session["IdFabrica"] as int?;
                contaModelo.FabricaID = (fabricaID != null) ? (int)fabricaID : 0;

                //Validacao de dados
                ContaValidacao.ValidaCriacaoConta(contaModelo);

                if (ContaValidacao.Valido())
                {
                    using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                    {
                        ServiceReference1.Conta conta = Conversor.CadastrarConta(contaModelo);
                        bool resultado = client.CadastrarConta(conta);
                        if (resultado)
                        {
                            return RedirectToAction("List", new { id = conta.FabricaID });
                        }
                        else
                        {
                            throw new InvalidOperationException("O Serviço não pode cadastrar o Objeto. Verifique se o mesmo encontra-se preenchido corretamente");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ContaValidacao.ObterMensagem());
                    return View(cvm);
                }

            }
            catch(Exception ex)
            {
                ViewBag.CadastrarConta = false;
                ViewBag.ErroCadastrarConta = ex.Message;
                return View();
            }
        }

        // GET: Conta/Edit/5
        [VerificaAutenticacao]
        public ActionResult Edit(DateTime data)
        {
            ContaModel contaModelo = new ContaModel();
            List<DistribuidoraModel> distribuidoras = new List<DistribuidoraModel>();
            List<Mes> meses = Calendario.ListaDeMeses().ToList();
            List<TipoContratoModel> contratos = new List<TipoContratoModel>();
            List<TipoSubGrupoModel> grupos = new List<TipoSubGrupoModel>();
            List<BandeiraModel> bandeiras = new List<BandeiraModel>();
            int fabricaID = (int)Session["IdFabrica"];

            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Conta contaEntrada = client.DestalhesDaConta(data, fabricaID);
                contaModelo = Conversor.ContaRecebida(contaEntrada);

                List<ServiceReference1.Distribuidora> listaDeDistribuidoras = client.TodasDistribuidoras().ToList();
                distribuidoras = Conversor.ListaDistribuidoras(listaDeDistribuidoras);

                List<ServiceReference1.TipoContrato> listaDeContratos = client.TodosContratos().ToList();
                contratos = Conversor.ListaContratos(listaDeContratos);

                List<ServiceReference1.TipoSubGrupo> listaDeGrupos = client.TodosSubGrupos().ToList();
                grupos = Conversor.ListaSubGrupos(listaDeGrupos);

                List<ServiceReference1.Bandeira> listaDeBandeiras = client.TodasBandeiras().ToList();
                bandeiras = Conversor.ListaBandeira(listaDeBandeiras);

            }

            ContaViewModel cvm = new ContaViewModel(contaModelo, bandeiras, meses, distribuidoras, contratos, grupos);

            return View(cvm);
        }

        // POST: Conta/Edit/5
        [HttpPost]
        public ActionResult Edit(ContaViewModel cvm)
        {
            try
            {
                List<TarifaModel> tarifas = new List<TarifaModel>();

                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    List<ServiceReference1.Tarifa> listaDeTarifas = client.TodasTarifas().ToList();
                    tarifas = Conversor.TodasTarifas(listaDeTarifas);
                }

                ContaModel contaModelo = cvm.ObterConta();
                contaModelo.TarifaID = tarifas.Where(x => x.TipoContratoID == contaModelo.TipoContratoID && x.TipoSubGrupoID == contaModelo.TipoSubGrupoID && x.BandeiraID == contaModelo.BandeiraID).Select(x => x.TarifaID).FirstOrDefault();

                ContaValidacao.ValidaAtualizacaoConta(contaModelo);

                if (ContaValidacao.Valido())
                {
                    using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                    {
                        ServiceReference1.Conta conta = Conversor.AtualizarConta(contaModelo);
                        bool resultado = client.AtualizarConta(conta);
                        if (resultado)
                        {
                            return RedirectToAction("List", new { id = contaModelo.FabricaID });
                        }
                        else
                        {
                            throw new InvalidOperationException("O Serviço não pode atualizar o Objeto. Verifique se o mesmo encontra-se preenchido corretamente");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ContaValidacao.ObterMensagem());
                    return View(cvm);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErroAtualizarConta = ex.Message;
                return View();
            }
        }

        // GET: Conta/Delete/5
        [VerificaAutenticacao]
        public ActionResult Delete(DateTime data)
        {
            ContaViewModel cvm = new ContaViewModel();
            cvm.conta.dataReferencia = data;
            return View(cvm);
        }

        // POST: Conta/Delete/5
        [HttpPost]
        public ActionResult ConfirmaDelete(ContaViewModel cvm)
        {
            try
            {
                ContaModel contaModelo = new ContaModel();
                int fabricaID = (int)Session["IdFabrica"];

                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Conta contaEntrada = client.DestalhesDaConta(cvm.conta.dataReferencia, fabricaID);
                    contaModelo = Conversor.ContaRecebida(contaEntrada);

                    ServiceReference1.Conta conta = Conversor.ExcluirConta(contaModelo);
                    bool resultado = client.DeletarConta(conta);
                    if (resultado)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        throw new InvalidOperationException("O Serviço não pode atualizar o Objeto. Verifique se o mesmo encontra-se preenchido corretamente");
                    }
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErroDeletarConta = ex.Message;
                return View();
            }
        }
    }
}
