using System;
using ZoEazy.Api.Model.Branch;

namespace ZoEazy.Api.Model
{
    public class RequestResult
    {
        public RequestResult()
        {
            State = RequestState.Success;
        }
        public RequestResult(RequestState state, string msg = "") {
            State = state;
            Msg = msg;
            Data = null;
        }

        public RequestResult(RequestState state, LoginData data, string msg = "")
        {
            State = state;
            Msg = msg;
            Data = data;
        }
        public RequestResult(RequestState state, AdminData data, string msg = "")
        {
            State = state;
            Msg = msg;
            Data = data;
        }
        public RequestResult(RequestState state, BranchData data, string msg = "")
        {
            State = state;
            Msg = msg;
            Data = data;
        }
        public RequestResult(RequestState state, SchedulesData data, string msg = "")
        {
            State = state;
            Msg = msg;
            Data = data;
        }
        public RequestResult(RequestState state, ContractData data, string msg = "")
        {
            State = state;
            Msg = msg;
            Data = data;
        }
        public RequestState State { get; set; }
        public string Msg { get; set; }
        public Object Data { get; set; }
    }
}
