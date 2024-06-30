using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;

namespace Architecture.Online
{
    internal class RoomCreator : IRoomCreator
    {
        private Action<string> _failCallback;
        private Action _successCallback;

        public void CreateRoom(Action successCallback, Action<string> failCallback, string roomName)
        {
            _failCallback = failCallback;
            _successCallback = successCallback;
            PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = 2 });
        }

        public void OnCreatedRoom()
        {
            _successCallback?.Invoke();
            _successCallback = null;
        }

        public void OnCreateRoomFailed(short returnCode, string message)
        {
            _failCallback.Invoke(message);
        }

        public void OnJoinedRoom()
        {
        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
        }

        public void OnLeftRoom()
        {
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
        }
    }
}