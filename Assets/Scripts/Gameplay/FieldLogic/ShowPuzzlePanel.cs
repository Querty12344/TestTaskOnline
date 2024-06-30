using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.FieldLogic
{
    public class ShowPuzzlePanel : MonoBehaviour
    {
        [SerializeField] private GameObject[] _puzzleCubes;

        public void ShowPanel(List<int> puzzle)
        {
            foreach (var puzzleCube in _puzzleCubes) puzzleCube.gameObject.SetActive(false);
            foreach (var i in puzzle) _puzzleCubes[i].SetActive(true);
        }
    }
}