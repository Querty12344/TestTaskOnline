using System;

namespace Architecture.SceneLoading
{
    public interface ISceneLoader
    {
        void LoadScene(string name, Action callBack = null);
    }
}