using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ModashClient.API {

    public class ModashApi : IDisposable {

        public ApiClient Api {  get; private set; }

        public ModashApi() {
            Api = new ApiClient();
        }

        public void Dispose() {
            Api.Dispose();
            GC.SuppressFinalize(this);
        }

    }

}
