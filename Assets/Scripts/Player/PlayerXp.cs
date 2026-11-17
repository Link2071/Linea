using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    public static PlayerXp instance { get; private set; }
    [SerializeField] private int currentXp;
    [SerializeField] private int maxXp;
    public int currentLvl;
    public float lvlCompletionPercent;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }

    public void AddXp(int amount)
    {
        currentXp += amount;
        if (currentXp >= maxXp)
        {
            int levelsToUpgrade = currentXp / maxXp;
            currentLvl += levelsToUpgrade;
            currentXp = currentXp % maxXp;
            maxXp += currentLvl * 10;
        }
        lvlCompletionPercent = (float)currentXp / (float)maxXp;
    }
}
