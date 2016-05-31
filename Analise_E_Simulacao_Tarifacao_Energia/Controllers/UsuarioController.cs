using Analise_E_Simulacao_Tarifacao_Energia.Models;
using Analise_E_Simulacao_Tarifacao_Energia.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Security;

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

                throw new InvalidOperationException("O Serviço não pode Logar o usuario"); 
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
            List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();
            List<UsuarioModel> listaFiltrados = new List<UsuarioModel>();
            UsuarioModel usuario = Session["usuario"] as UsuarioModel;
            int clienteID = usuario.ClienteID;

            using (ServiceReference1.TEECRUDServiceClient client =new ServiceReference1.TEECRUDServiceClient())
            {
                List<ServiceReference1.Usuario> ListaDeEntrada = client.ListarUsuarios(clienteID).ToList();
                listaUsuarios = Conversor.ListarUsuarios(ListaDeEntrada);
                foreach(var u in listaUsuarios)
                {
                    if (u.Email != usuario.Email)
                    {
                        listaFiltrados.Add(u);
                    }
                }

            }
            return View(listaFiltrados);
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

                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Usuario usuario = Conversor.NovoUsuario(modeloUsuario);
                    bool resultado = client.CadastrarUsuario(usuario);
                    if (resultado)
                    {
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
                ViewBag.CadastrarUsuario = false;
                ViewBag.ErroCadastrarUsuario = ex.Message;
                return View();
            }
        }

        [VerificaAutenticacao]
        public ActionResult Created(UsuarioModel usuario)
        {
            return View(usuario);
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
                        throw new InvalidOperationException("O Serviço não pode cadastrar o Objeto. Verifique se o mesmo encontra-se preenchido corretamente");
                    }
                }


            }
            catch (Exception ex)
            {
                ViewBag.AtualizarUsuario = false;
                ViewBag.ErroAtualizarUsuario = ex.Message;
                return View();
            }
        }

        // GET: Usuario/Delete/5
        [VerificaAutenticacao]
        public ActionResult Delete(string email)
        {
            UsuarioModel usuarioModelo = new UsuarioModel();

            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Usuario usuarioEntrada = client.DestalhesDoUsuario(email);
                usuarioModelo = Conversor.UsuarioRecebido(usuarioEntrada);
            }
            return View(usuarioModelo);
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
                        throw new InvalidOperationException("O Serviço não pode cadastrar o Objeto. Verifique se o mesmo encontra-se preenchido corretamente");
                    }
                }


            }
            catch (Exception ex)
            {
                ViewBag.DeletarUsuario = false;
                ViewBag.ErroDeletarUsuario = ex.Message;
                return View();
            }
        }
    }
}
