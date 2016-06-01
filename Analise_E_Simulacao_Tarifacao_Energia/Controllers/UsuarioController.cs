using Analise_E_Simulacao_Tarifacao_Energia.Models;
using Analise_E_Simulacao_Tarifacao_Energia.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Security;
using Analise_E_Simulacao_Tarifacao_Energia.Validacoes;
using System.Web.Routing;

namespace Analise_E_Simulacao_Tarifacao_Energia.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Login()
        {
            UsuarioModel usuarioLogin = new UsuarioModel();
            return View(usuarioLogin);
        }
        //POST: Usuario
        [HttpPost]
        public ActionResult Login(UsuarioModel modeloUsuario)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Usuario usuario = Conversor.AutenticaUsuario(modeloUsuario);
                    UsuarioModel resultado = Conversor.UsuarioRecebido(client.VerificaAutenticacao(usuario.Email, usuario.Senha));
                    if (resultado!=null)
                    {
                        Session["usuario"] = resultado;
                        FormsAuthentication.SetAuthCookie(resultado.Nome, false);

                        if (string.IsNullOrWhiteSpace(resultado.Nome))
                            return RedirectToAction("Edit");
                        else
                            return RedirectToAction("List", "Fabrica");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Usuario ou Senha invalidos!");
                        return View(modeloUsuario);
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }

        [VerificaAutenticacao]
        public ActionResult Logout()
        {
            Session["usuario"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //GET: Usuario/List
        [VerificaAutenticacao]
        public ActionResult List()
        {
            try
            {
                List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();
                List<UsuarioModel> listaFiltrados = new List<UsuarioModel>();
                UsuarioModel usuario = Session["usuario"] as UsuarioModel;
                int clienteID = usuario.ClienteID;

                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    List<ServiceReference1.Usuario> ListaDeEntrada = client.ListarUsuarios(clienteID).ToList();
                    listaUsuarios = Conversor.ListarUsuarios(ListaDeEntrada);
                    foreach (var u in listaUsuarios)
                    {
                        if (u.Email != usuario.Email)
                        {
                            listaFiltrados.Add(u);
                        }
                    }

                }
                return View(listaFiltrados);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }

        // GET: Usuario/Details/5
        [VerificaAutenticacao]
        public ActionResult Details()
        {
            UsuarioModel login = Session["usuario"] as UsuarioModel;
            
            return View(login);
        }

        // GET: Usuario/Create
        [VerificaAutenticacao]
        public ActionResult Create()
        {
            UsuarioModel usuarioModelo = new UsuarioModel();
            return View(usuarioModelo);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioModel modeloUsuario)
        {
            try
            {
                UsuarioModel login = Session["usuario"] as UsuarioModel;
                modeloUsuario.ClienteID = login.ClienteID;
                modeloUsuario.Senha = Senha.Generate();
                modeloUsuario.Ativo = true;

                UsuarioValidacao.ValidaCriacaoUsuario(modeloUsuario);

                if (UsuarioValidacao.Valido())
                {
                    using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                    {
                        ServiceReference1.Usuario usuario = Conversor.NovoUsuario(modeloUsuario);
                        bool resultado = client.CadastrarUsuario(usuario);
                        if (resultado)
                        {
                            Session["UsuarioCriado"] = modeloUsuario;
                            return RedirectToAction("Created");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Erro", new { area = "" });
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, UsuarioValidacao.ObterMensagem());
                    return View(modeloUsuario);
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }

        [VerificaAutenticacao]
        public ActionResult Created()
        {
            UsuarioModel u = Session["UsuarioCriado"] as UsuarioModel;
            Session["UsuarioCriado"] = null;
            return View(u);
        }

        // GET: Usuario/Edit/5
        [VerificaAutenticacao]
        public ActionResult Edit()
        {
            UsuarioModel login = Session["usuario"] as UsuarioModel;

            return View(login);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioModel modeloUsuario)
        {
            try
            {
                UsuarioValidacao.ValidaAtualizacaoUsuario(modeloUsuario);

                if (UsuarioValidacao.Valido())
                {
                    using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                    {
                        ServiceReference1.Usuario usuario = Conversor.AtualizarUsuario(modeloUsuario);
                        bool resultado = client.AtualizarUsuario(usuario);
                        if (resultado)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Erro", new { area = "" });
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, UsuarioValidacao.ObterMensagem());
                    return View(modeloUsuario);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }

        // GET: Usuario/Delete/5
        [VerificaAutenticacao]
        public ActionResult Delete(string email)
        {
            try
            {
                UsuarioModel usuarioModelo = new UsuarioModel();

                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Usuario usuarioEntrada = client.DestalhesDoUsuario(email);
                    usuarioModelo = Conversor.UsuarioRecebido(usuarioEntrada);
                }
                return View(usuarioModelo);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(UsuarioModel modeloUsuario)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Usuario usuario = Conversor.ExcluirUsuario(modeloUsuario);
                    usuario.Ativo = !usuario.Ativo;
                    bool resultado = client.DeletarUsuario(usuario);
                    if (resultado)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Erro", new { area = "" });
                    }
                }


            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }
    }
}
