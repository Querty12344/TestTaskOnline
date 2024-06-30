using System;
using System.Collections;
using Architecture.Utilits;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.SceneLoading
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadScene(string name, Action callBack = null)
        {
            _coroutineRunner.StartCoroutine(Load(name, callBack));
        }

        private IEnumerator Load(string name, Action callBack = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                callBack?.Invoke();
                yield break;
            }

            var loading = SceneManager.LoadSceneAsync(name);
            yield return new WaitUntil(() => loading.isDone);
            callBack?.Invoke();
        }
    }
}