using System;
using Photon.Realtime;

namespace Architecture.Online
{
    public interface IClientConnection : IMatchmakingCallbacks
    {
        public event Action Disconnect;
        void TryConnect(Action onSuccess, Action<string> onFail, string roomName = "");
    }
}