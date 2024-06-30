using Gameplay.CubeLogic;
using UnityEngine;

namespace Gameplay.FieldLogic
{
    public class CubeHandler : MonoBehaviour
    {
        [SerializeField] private int _index;
        private Cube _cube;
        private PuzzlePanel _puzzlePanel;
        public int Index => _index;
        public bool HasCube => _cube;

        public void Construct(PuzzlePanel puzzlePanel)
        {
            _puzzlePanel = puzzlePanel;
        }

        public void SetCube(Cube cube)
        {
            _cube = cube;
        }

        public void RemoveCube()
        {
            _cube = null;
            _puzzlePanel.CheckComplete();
        }
    }
}