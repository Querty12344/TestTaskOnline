using System.Linq;
using Architecture.UI.UIElements;
using Architecture.Utilits;
using Constants;
using Gameplay.CubeLogic;
using UnityEngine;

namespace Gameplay.FieldLogic
{
    public class PuzzlePanel : MonoBehaviour
    {
        [SerializeField] private CubeHandler[] _cubePoses;
        private Field _field;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Cube cube))
                if (!cube.Holding)
                {
                    var pos = _cubePoses.OrderBy(x => Vector3.Distance(x.transform.position, cube.transform.position))
                        .ToArray()[0];
                    cube.SetPos(pos);
                    CheckComplete();
                }
        }

        public void Construct(Field field)
        {
            _field = field;
        }

        public void CheckComplete()
        {
            var solvedPuzzle = _cubePoses.Where(x => x.HasCube).Select(x => x.Index).ToList();
            if (PuzzleCode.GetPuzzleCode(_field.GetActivePuzzle()) == PuzzleCode.GetPuzzleCode(solvedPuzzle))
            {
                MessageUI.Singleton.ShowMessage(MessageTexts.PuzzleComplete);
                _field.UpdatePuzzle();
            }
        }
    }
}