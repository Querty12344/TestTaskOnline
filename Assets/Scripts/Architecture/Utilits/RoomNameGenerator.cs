using UnityEngine;

namespace Architecture.Utilits
{
    public static class RoomNameGenerator
    {
        public static string GetRoomName()
        {
            var randomIndex = Random.Range(1000, 9999);
            return "Room_" + randomIndex;
        }
    }
}