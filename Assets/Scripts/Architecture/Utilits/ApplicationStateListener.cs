using System;
using UnityEngine;

namespace Architecture.Utilits
{
    public class ApplicationStateListener : MonoBehaviour, IApplicationStateListener
    {
        private void OnApplicationQuit()
        {
            //       QuitApplication?.Invoke();
        }

        public event Action QuitApplication;
    }
}