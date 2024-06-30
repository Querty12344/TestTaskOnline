using System;
using Photon.Realtime;

namespace Architecture.Online
{
    public interface IRoomCreator : IMatchmakingCallbacks
    {
        public void CreateRoom(Action successCallback, Action<string> failCallback, string roomName);
    }
}