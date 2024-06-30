using System;
using Architecture.UI.JoysticController;
using Photon.Realtime;
using UnityEngine;

public interface IInputService : IOnEventCallback
{
    public event Action ControllerDisconnected;
    public event Action ControllerConnected;
    public event Action BlockHoldButtonPressed;
    public Vector3 GetMoveVector();
    public Vector3 GetForwardVector();
    void SetController(IController controller);
    void RemoveController();
}