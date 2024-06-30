using System.Collections.Generic;
using Architecture.Utilits;
using UnityEngine;

namespace Gameplay.FieldLogic
{
    public class Field : MonoBehaviour
    {
        [SerializeField] private Transform _playerPlace;
        [SerializeField] private ShowPuzzlePanel _showPuzzlePanel;
        [SerializeField] private PuzzlePanel _puzzlePanel;
        private List<int> _puzzle;

        public Vector3 PlayerPlace => _playerPlace.position;

        public void Construct()
        {
            UpdatePuzzle();
            _puzzlePanel.Construct(this);
        }

        public List<int> GetActivePuzzle()
        {
            return _puzzle;
        }

        public void UpdatePuzzle()
        {
            _puzzle = PuzzleGenerator.GetRandomPuzzle();
            _showPuzzlePanel.ShowPanel(_puzzle);
        }
    }
}