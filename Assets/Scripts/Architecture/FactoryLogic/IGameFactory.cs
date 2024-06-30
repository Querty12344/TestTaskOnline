namespace Architecture.FactoryLogic
{
    public interface IGameFactory
    {
        public void CreatePlayer(IInputService input);
        public void CreateField();
    }
}