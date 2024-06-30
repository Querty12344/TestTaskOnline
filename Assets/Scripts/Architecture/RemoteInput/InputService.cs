using System;
using Architecture.UI.JoysticController;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Architecture.RemoteController
{
    public class InputService : MonoBehaviourPunCallbacks, IInputService, IControllerObserver
    {
        private IController _controller;
        private Vector3 _moveVector;
        private PhotonView _photonView;
        private bool _receiving;
        private bool _sending;
        private Vector3 _watchVector;


        public InputService(PhotonView photonView)
        {
            _photonView = photonView;
        }

        [PunRPC]
        public void SetMoveVector(Vector3 moveVector)
        {
            _moveVector = moveVector;
            if (_sending)
                photonView.RPC(nameof(SetMoveVector), RpcTarget.Others, moveVector);
        }

        [PunRPC]
        public void SetLookVector(Vector3 lookVector)
        {
            _watchVector = lookVector;
            if (_sending)
                photonView.RPC(nameof(SetLookVector), RpcTarget.Others, lookVector);
        }

        public void HoldBox()
        {
            var options = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
            var sendOptions = SendOptions.SendReliable;
            PhotonNetwork.RaiseEvent((int)PhotonEvents.HoldBox, null, options, sendOptions);
        }

        public event Action ControllerDisconnected;

        public event Action ControllerConnected;

        public event Action BlockHoldButtonPressed;

        public Vector3 GetMoveVector()
        {
            return _moveVector;
        }

        public Vector3 GetForwardVector()
        {
            return _watchVector;
        }

        public void SetController(IController controller)
        {
            _sending = true;
            _controller = controller;
            _controller.SetObserver(this);
            var options = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
            var sendOptions = SendOptions.SendReliable;
            PhotonNetwork.RaiseEvent((int)PhotonEvents.ControllerConnected, null, options, sendOptions);
        }

        public void RemoveController()
        {
            _sending = false;
            _controller = null;
            var options = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
            var sendOptions = SendOptions.SendReliable;
            PhotonNetwork.RaiseEvent((int)PhotonEvents.ControllerDisconnected, null, options, sendOptions);
        }

        public void OnEvent(EventData photonEvent)
        {
            if (photonEvent.Code == (int)PhotonEvents.ControllerConnected)
            {
                _receiving = true;
                ControllerConnected?.Invoke();
            }

            if (photonEvent.Code == (int)PhotonEvents.ControllerDisconnected)
            {
                _receiving = false;
                ControllerDisconnected?.Invoke();
            }

            if (photonEvent.Code == (int)PhotonEvents.HoldBox) BlockHoldButtonPressed?.Invoke();
        }
    }
}