using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;

namespace Architecture.Online
{
    internal class NetworkConnector : INetworkConnector
    {
        private Action<string> _onFailure;
        private Action _onSuccess;

        public void OnConnectedToMaster()
        {
            _onSuccess?.Invoke();
            _onFailure = null;
            _onSuccess = null;
        }

        public void OnDisconnected(DisconnectCause cause)
        {
            _onFailure?.Invoke(cause.ToString());
            _onFailure = null;
            _onSuccess = null;
        }

        public void StartConnect(Action onSuccess, Action<string> onFailure)
        {
            _onFailure = onFailure;
            _onSuccess = onSuccess;
            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings();
        }

        public void OnConnected()
        {
        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
        }
    }
}