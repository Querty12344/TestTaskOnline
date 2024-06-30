using Gameplay.CubeLogic;
using UnityEngine;

namespace Gameplay.PlayerLogic
{
    public class PlayerBoxHolder : MonoBehaviour
    {
        [SerializeField] private float _richDistance;
        [SerializeField] private float _holdDistance;
        private Cube _activeBlock;
        private Camera _camera;
        private IInputService _inputService;

        private void FixedUpdate()
        {
            if (_activeBlock)
                _activeBlock.transform.position = _camera.transform.position + transform.forward * _holdDistance;
        }

        private void OnDestroy()
        {
            _inputService.BlockHoldButtonPressed -= ChangeBoxHoldingMode;
        }

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.BlockHoldButtonPressed += ChangeBoxHoldingMode;
            _camera = Camera.main;
        }

        private void ChangeBoxHoldingMode()
        {
            if (_activeBlock == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _richDistance))
                    if (hit.collider.gameObject.TryGetComponent(out _activeBlock))
                        _activeBlock.Pick();
            }
            else
            {
                _activeBlock.ThrowOut();
                _activeBlock = null;
            }
        }
    }
}