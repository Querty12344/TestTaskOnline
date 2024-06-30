using UnityEngine;

namespace Architecture.RemoteController
{
    public abstract class WindowBase : MonoBehaviour
    {
        public virtual void Remove()
        {
            if (this != null)
                Destroy(gameObject);
        }
    }
}