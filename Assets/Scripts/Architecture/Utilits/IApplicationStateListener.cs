using System;

namespace Architecture.Utilits
{
    public interface IApplicationStateListener
    {
        public event Action QuitApplication;
    }
}