using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpUi : MonoBehaviour
{
    [SerializeField] private Image xpBar;
    [SerializeField] private TMP_Text lvlText;

    void Update()
    {
        xpBar.fillAmount = PlayerXp.instance.lvlCompletionPercent;
        lvlText.text = PlayerXp.instance.currentLvl.ToString();
    }
}
