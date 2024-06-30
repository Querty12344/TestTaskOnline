using System;
using System.Collections.Generic;
using Constants;
using Photon.Pun;
using Photon.Realtime;

namespace Architecture.Online
{
    internal class ClientConnection : IClientConnection
    {
        private Action<string> _onFail;
        private Action _onSuccess;
        public event Action Disconnect;

        public void TryConnect(Action onSuccess, Action<string> onFail, string roomName = "")
        {
            if (PhotonNetwork.CountOfRooms == 0)
            {
                onFail?.Invoke(MessageTexts.NoRoomsAvailable);
                return;
            }

            _onFail = onFail;
            _onSuccess = onSuccess;
            if (roomName.Length == 0)
                PhotonNetwork.JoinRandomRoom();
            else
                PhotonNetwork.JoinRoom(roomName);
        }

        public void OnJoinedRoom()
        {
            _onSuccess?.Invoke();
        }


        public void OnJoinRoomFailed(short returnCode, string message)
        {
            _onFail?.Invoke(message);
        }

        public void OnLeftRoom()
        {
            if (PhotonNetwork.IsMasterClient) Disconnect?.Invoke();
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
        }

        public void OnCreatedRoom()
        {
        }

        public void OnCreateRoomFailed(short returnCode, string message)
        {
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
        }
    }
}