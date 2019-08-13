using System.Collections.Generic;
using System.Text;

namespace ZoEazy.Api.Model
{
    public class LoginResult
    {
        public LoginResult()
        {
            State = RequestState.Success;
        }

        public LoginResult(RequestState state, string msg = "", LoginData data = null)
        {
            State = state;
            Msg = msg;
            Data = data;
        }

        public RequestState State { get; set; }
        public string Msg { get; set; }
        public LoginData Data { get; set; }
    }
}
