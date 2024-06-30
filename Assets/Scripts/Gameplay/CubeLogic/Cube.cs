using Gameplay.FieldLogic;
using UnityEngine;

namespace Gameplay.CubeLogic
{
    public class Cube : MonoBehaviour
    {
        [SerializeField] private BoxCollider _boxCollider;
        [SerializeField] private GameObject _opaque;
        [SerializeField] private GameObject _transparent;
        [SerializeField] private Rigidbody _rigidbody;
        private CubeHandler _cubeHandler;
        public bool Holding { get; private set; }

        private void Start()
        {
            transform.SetParent(null);
        }

        public void ThrowOut()
        {
            _rigidbody.WakeUp();
            _rigidbody.useGravity = true;
            _boxCollider.enabled = true;
            _opaque.SetActive(true);
            _transparent.SetActive(false);
            Holding = false;
        }

        public void Pick()
        {
            _rigidbody.Sleep();
            _cubeHandler?.RemoveCube();
            _rigidbody.useGravity = false;
            _boxCollider.enabled = false;
            _opaque.SetActive(false);
            _transparent.SetActive(true);
            Holding = true;
        }

        public void SetPos(CubeHandler cubeHandler)
        {
            _rigidbody.velocity = Vector3.zero;
            _cubeHandler = cubeHandler;
            transform.position = cubeHandler.transform.position;
            _cubeHandler.SetCube(this);
            _rigidbody.useGravity = false;
            _boxCollider.isTrigger = true;
        }
    }
}