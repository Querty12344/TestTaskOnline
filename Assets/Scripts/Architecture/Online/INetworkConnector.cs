using System;
using Photon.Realtime;

namespace Architecture.Online
{
    public interface INetworkConnector : IConnectionCallbacks
    {
        public void StartConnect(Action onSuccess, Action<string> onFailure);
    }
}