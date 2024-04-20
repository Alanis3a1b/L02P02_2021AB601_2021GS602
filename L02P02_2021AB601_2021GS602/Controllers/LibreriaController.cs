using L02P02_2021AB601_2021GS602.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Firebase.Auth;
using Firebase.Storage;

namespace L02P02_2021AB601_2021GS602.Controllers
{
    public class LibreriaController : Controller
    {
        //private readonly equiposDbContext _equiposDbContext;

        //public EquiposController(equiposDbContext equiposDbContext)
        //{
        //    _equiposDbContext = equiposDbContext;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        ////Función para guardar equipos
        //public IActionResult CrearEquipos(equipos nuevoLibro)
        //{
        //    _equiposDbContext.Add(nuevoLibro);
        //    _equiposDbContext.SaveChanges();

        //    return RedirectToAction("Index");

        //}

        //////Metodo para eliminar
        //[HttpPut]
        //[Route("Eliminar/{id}")]
        //public IActionResult EliminarCliente(int id)
        //{
        //    clientes? cliente = (from e in _clientesContexto.clientes
        //                         where e.clienteId == id
        //                         select e).FirstOrDefault();

        //    if (cliente == null)
        //    { return NotFound(); }

        //    _clientesContexto.clientes.Attach(cliente);
        //    _clientesContexto.clientes.Remove(cliente);
        //    _clientesContexto.SaveChanges();

        //    return Ok(cliente);

        //}

        //Guardar imagen del libro
        [HttpPost]
        public async Task<ActionResult> SubirArchivo(IFormFile archivo)
        {
            //Leemos el archivo subido
            Stream archivoASubir = archivo.OpenReadStream();

            //Configuramos la conexion hacia el FireBase
            string email = "alanis.alvarez@catolica.edu.sv";
            string clave = "Thewoomy1029";
            string ruta = "gs://libreriaimagen-2d35c.appspot.com"; //Se ve en storage
            string api_key = "AIzaSyDyGc5KurD4sx6eQ96mbZiQmDmyxXZuC3Y"; //Se ve en configuración

            //Esto es para poder autenticarse con el correo y contraseña
            var auth = new FirebaseAuthProvider(new FirebaseConfig(api_key));
            var authenticarFireBase = await auth.SignInWithEmailAndPasswordAsync(email, clave);

            //token de cancelacion y de usuario requeridpos para enviar el archivo
            var cancellation = new CancellationTokenSource();
            var tokenUser = authenticarFireBase.FirebaseToken;

            //Configuramos la ruta de envío al storage (ni idea de porque me da error)
            var tareaCargarArchivo = new FirebaseStorage(ruta,
                                                               new FirebaseStorageOptions
                                                               {
                                                                   AuthTokenAsyncFactory = () => Task.FromResult(tokenUser),
                                                                   ThrowOnCancel = true

                                                               }
                                                         ).Child("Archivo").Child(archivo.FileName).PutAsync(archivoASubir, cancellation.Token);

            var urlArchivoCargado = await tareaCargarArchivo;


            return RedirectToAction("VerImagen");

        }


    }
}
