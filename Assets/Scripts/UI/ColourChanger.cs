using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    [SerializeField] private TMP_Text targetGraphic;
    [SerializeField] private List<Color> colors;
    [SerializeField] private float duration = 1f;
    private float _progress;
    private int _currentIndex = 0;
    private int _nextIndex = 1;
    private bool _colorChanged => targetGraphic.color == colors[_nextIndex];

    void Update()
    {
        _progress += Time.deltaTime / duration;
        float d = EaseInOutCubic(Mathf.Clamp01(_progress));
        targetGraphic.color = Color.Lerp(colors[_currentIndex], colors[_nextIndex], d);
        if (_colorChanged)
        {
            _progress = 0f;
            if (_nextIndex == colors.Count - 1)
            {
                _currentIndex = _nextIndex;
                _nextIndex = 0;
            }
            else
            {
                _currentIndex++;
                _nextIndex++;
            }
            if (_currentIndex == colors.Count)
            {
                _currentIndex = 0;
            }
        }
    }

    private float EaseInOutCubic(float t) { return t < 0.5f ? 4f * t * t * t : 1f - Mathf.Pow(-2f * t + 2f, 3f) / 2f; }
}
