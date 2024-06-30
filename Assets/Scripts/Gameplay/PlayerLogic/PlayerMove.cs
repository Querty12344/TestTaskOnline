using UnityEngine;

namespace Gameplay.PlayerLogic
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _watchSpeed;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private CharacterController _controller;
        private IInputService _input;

        private void FixedUpdate()
        {
            Rotate();
            Move();
        }

        public void Construct(IInputService input)
        {
            _input = input;
        }

        private void Rotate()
        {
            var wantRotate = _input.GetForwardVector() * _watchSpeed;
            var horizontalRotation = Quaternion.AngleAxis(wantRotate.x, Vector3.up);
            var verticalRotation = Quaternion.AngleAxis(-wantRotate.y, transform.right);
            var newForwardDirection = verticalRotation * horizontalRotation * transform.forward;
            transform.forward = newForwardDirection;
        }

        private void Move()
        {
            var forwardMoveVector = transform.forward;
            var rightMoveVector = transform.right;
            forwardMoveVector.y = 0;
            forwardMoveVector.y = 0;
            var wantMove = _input.GetMoveVector();
            var move = forwardMoveVector * wantMove.y + rightMoveVector * wantMove.x;
            move.y = 0;
            _controller.Move(move.normalized * _moveSpeed);
        }
    }
}