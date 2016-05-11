using Analise_E_Simulacao_Tarifacao_Energia.Models;
using Analise_E_Simulacao_Tarifacao_Energia.Utilities;
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
        public ActionResult List(int id)
        {
            List<ContaModel> listaConta = new List<ContaModel>();
            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                List<ServiceReference1.Conta> listaDeEntrada = client.TodasContas(id).ToList();
                listaConta = Conversor.ListaContas(listaDeEntrada);
            }

            ContaViewModel cvm = new ContaViewModel(id, listaConta);

            return View(cvm);
        }

        // GET: Conta/Details/5
        public ActionResult Details(DateTime dataReferencia, int id)
        {
            ContaModel contaModelo = new ContaModel();
            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Conta contaEntrada = client.DestalhesDaConta(dataReferencia, id);
                contaModelo = Conversor.ContaRecebida(contaEntrada);

            }
            return View(contaModelo);
        }

        // GET: Conta/Create
        public ActionResult CreateConta(ContaViewModel contaViewModel)
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
            cvm.conta.FabricaID = contaViewModel.conta.FabricaID;
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
                contaModelo.FabricaID = ViewBag.IdFabrica;

                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Conta conta = Conversor.CadastrarConta(contaModelo);
                    bool resultado = client.CadastrarConta(conta);
                    if (resultado)
                    {
                        TempData["CadastrarConta"] = true;
                        return RedirectToAction("List");
                    }
                    else
                    {
                        throw new InvalidOperationException("O Serviço não pode cadastrar o Objeto. Verifique se o mesmo encontra-se preenchido corretamente");
                    }
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
        public ActionResult Edit(DateTime dataReferencia, int id)
        {
            ContaModel contaModelo = new ContaModel();
            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Conta contaEntrada = client.DestalhesDaConta(dataReferencia, id);
                contaModelo = Conversor.ContaRecebida(contaEntrada);

            }
            return View(contaModelo);
        }

        // POST: Conta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContaModel contaModelo)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Conta conta = Conversor.AtualizarConta(contaModelo);
                    bool resultado = client.AtualizarConta(conta);
                    if (resultado)
                    {
                        TempData["AtualizarConta"] = true;
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
                ViewBag.AtualizarConta = false;
                ViewBag.ErroAtualizarConta = ex.Message;
                return View();
            }
        }

        // GET: Conta/Delete/5
        public ActionResult Delete(DateTime dataReferencia, int id)
        {
            ContaModel contaModelo = new ContaModel();
            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Conta contaEntrada = client.DestalhesDaConta(dataReferencia, id);
                contaModelo = Conversor.ContaRecebida(contaEntrada);

            }
            return View(contaModelo);
        }

        // POST: Conta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ContaModel contaModelo)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Conta conta = Conversor.ExcluirConta(contaModelo);
                    bool resultado = client.DeletarConta(conta);
                    if (resultado)
                    {
                        TempData["DeletarConta"] = true;
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
                ViewBag.DeletarConta = false;
                ViewBag.ErroDeletarConta = ex.Message;
                return View();
            }
        }
    }
}
