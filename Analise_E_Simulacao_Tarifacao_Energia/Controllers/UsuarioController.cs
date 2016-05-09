using Analise_E_Simulacao_Tarifacao_Energia.Models;
using Analise_E_Simulacao_Tarifacao_Energia.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

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
                        TempData["AutenticaUsuario"] = true;
                        ViewBag.usuarioLogado = resultado;
                        return RedirectToAction("List", "Fabrica", resultado);
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

        //GET: Usuario/List
        public ActionResult List(int id, UsuarioModel usuarioLogado)
        {
            List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();
            using (ServiceReference1.TEECRUDServiceClient client =new ServiceReference1.TEECRUDServiceClient())
            {
                List<ServiceReference1.Usuario> ListaDeEntrada = client.ListarUsuarios(id).ToList();
                listaUsuarios = Conversor.ListarUsuarios(ListaDeEntrada);

            }
            return View(listaUsuarios);
        }
        
        // GET: Usuario/Details/5
        public ActionResult Details(string email, UsuarioModel usuarioLogado)
        {
            UsuarioModel usuarioModelo = new UsuarioModel();
            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Usuario usuarioEntrada = client.DestalhesDoUsuario(email);
                usuarioModelo = Conversor.UsuarioRecebido(usuarioEntrada);
            }
            return View(usuarioModelo);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            UsuarioModel usuarioModelo = new UsuarioModel();
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioModel modeloUsuario)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Usuario usuario = Conversor.NovoUsuario(modeloUsuario);
                    bool resultado = client.CadastrarUsuario(usuario);
                    if (resultado)
                    {
                        TempData["CadastrarUsuario"] = true;
                        return View("HomeLogada");
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

        // GET: Usuario/Create
        public ActionResult SubCreate(UsuarioModel usuarioAdmin, int clienteID)
        {   
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult SubCreate(UsuarioModel modeloUsuario)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Usuario usuario = Conversor.NovoUsuario(modeloUsuario);
                    bool resultado = client.CadastrarUsuario(usuario);
                    if (resultado)
                    {
                        TempData["CadastrarUsuario"] = true;
                        return View("HomeLogada");
                    }
                    else
                    {
                        throw new InvalidOperationException("O Serviço não pode cadastrar o Objeto. Verifique se o mesmo encontra-se preenchido corretamente");
                    }
                }


            }
            catch (Exception ex)
            {
                ViewBag.CadastrarUsuario = false;
                ViewBag.ErroNovoUsuario = ex.Message;
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id, string email, UsuarioModel usuarioLogado)
        {
            UsuarioModel usuarioModelo = new UsuarioModel();
            using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
            {
                ServiceReference1.Usuario usuarioEntrada = client.DestalhesDoUsuario(email);
                usuarioModelo = Conversor.UsuarioRecebido(usuarioEntrada);
            }
            return View(usuarioModelo);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UsuarioModel modeloUsuario, UsuarioModel usuarioLogado)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Usuario usuario = Conversor.AtualizarUsuario(modeloUsuario);
                    bool resultado = client.AtualizarUsuario(usuario);
                    if (resultado)
                    {
                        TempData["AtualizarUsuario"] = true;
                        return View("HomeLogada");
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
        public ActionResult Delete(int id,string email, UsuarioModel usuarioLogado)
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
        public ActionResult Delete(int id, UsuarioModel modeloUsuario, UsuarioModel usuarioLogado)
        {
            try
            {
                using (ServiceReference1.TEECRUDServiceClient client = new ServiceReference1.TEECRUDServiceClient())
                {
                    ServiceReference1.Usuario usuario = Conversor.ExcluirUsuario(modeloUsuario);
                    bool resultado = client.DeletarUsuario(usuario);
                    if (resultado)
                    {
                        TempData["DeletarUsuario"] = true;
                        return View("HomeLogada");
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
