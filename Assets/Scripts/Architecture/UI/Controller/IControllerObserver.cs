using UnityEngine;

namespace Architecture.UI.JoysticController
{
    public interface IControllerObserver
    {
        void SetMoveVector(Vector3 moveVector);
        void SetLookVector(Vector3 lookVector);
        void HoldBox();
    }
}