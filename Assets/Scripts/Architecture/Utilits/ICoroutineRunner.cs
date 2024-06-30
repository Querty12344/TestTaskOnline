using System.Collections;
using UnityEngine;

namespace Architecture.Utilits
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
        void StopAllCoroutines();
    }
}