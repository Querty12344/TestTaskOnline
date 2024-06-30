using UnityEngine;

namespace Architecture.UI.JoysticController
{
    public class JoystickController : MonoBehaviour, IController
    {
        [SerializeField] private Joystick _watchJoystick;
        [SerializeField] private Joystick _moveJoystick;
        private bool _inputEnabled;
        private IControllerObserver _observer;

        private void Update()
        {
            if (_observer == null)
                return;
            _observer.SetLookVector(_watchJoystick.Direction);
            _observer.SetMoveVector(_moveJoystick.Direction);
        }

        public void SetObserver(IControllerObserver observer)
        {
            _observer = observer;
        }

        public void HoldBox()
        {
            _observer.HoldBox();
        }
    }
}