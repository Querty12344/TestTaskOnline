using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Architecture.UI.UIElements
{
    public class RoomNameText : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_Text _text;

        private void Start()
        {
            _text.text = PhotonNetwork.CurrentRoom.Name;
        }
    }
}