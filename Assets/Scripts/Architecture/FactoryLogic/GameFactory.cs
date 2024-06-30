using Architecture.ResourceManagement;
using Gameplay.FieldLogic;
using Gameplay.PlayerLogic;
using UnityEngine;

namespace Architecture.FactoryLogic
{
    internal class GameFactory : IGameFactory
    {
        private Field _field;
        private Player _player;
        private readonly IPrefabLoader _prefabLoader;

        public GameFactory(IPrefabLoader prefabLoader)
        {
            _prefabLoader = prefabLoader;
        }

        public void CreatePlayer(IInputService input)
        {
            var prefab = _prefabLoader.GetPlayer();
            _player = Object.Instantiate(prefab, _field.PlayerPlace, Quaternion.identity);
            _player.GetComponent<PlayerMove>().Construct(input);
            _player.GetComponent<PlayerBoxHolder>().Construct(input);
        }


        public void CreateField()
        {
            var prefab = _prefabLoader.GetField();
            _field = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            _field.Construct();
        }
    }
}