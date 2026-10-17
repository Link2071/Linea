using UnityEngine;
using UnityEngine.UI;

public class XpUi : MonoBehaviour
{
    [SerializeField] private Image xpBar;
    private int _currentXp;
    private int _maxXp;

    public void AddXp(int amount)
    {
        _currentXp += amount;
        xpBar.fillAmount = _currentXp / _maxXp;
    }

    public void AddMaxXp(int amount)
    {
        _maxXp += amount;
        xpBar.fillAmount = _currentXp / _maxXp;
    }
}
