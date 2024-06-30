using System.Collections;
using TMPro;
using UnityEngine;

namespace Architecture.UI.UIElements
{
    public class MessageUI : MonoBehaviour
    {
        public static MessageUI Singleton;
        [SerializeField] private float _fadeDuration = 1f;
        [SerializeField] private float _showTime = 2f;
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private CanvasGroup _canvasGroup;

        private void Awake()
        {
            if (Singleton == null)
            {
                DontDestroyOnLoad(gameObject);
                Singleton = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ShowMessage(string message)
        {
            StopAllCoroutines();
            _messageText.text = message;
            StartCoroutine(FadeAnim());
        }

        private IEnumerator FadeAnim()
        {
            float progress = 0;
            _canvasGroup.alpha = 0f;
            while (progress < _fadeDuration)
            {
                progress += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(0f, 1f, progress / _fadeDuration);
                yield return null;
            }

            _canvasGroup.alpha = 1f;
            yield return new WaitForSeconds(_showTime);
            while (progress > 0)
            {
                progress -= Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(0f, 1f, progress / _fadeDuration);
                yield return null;
            }

            _canvasGroup.alpha = 0f;
        }
    }
}