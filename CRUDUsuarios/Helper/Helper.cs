using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CRUDUsuarios.Helper
{
    public class Helper
    {
        public class UsuariosAPI 
        {
            public HttpClient Initial()
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44384/api/");
                return client;
            }

        }
    }
}
