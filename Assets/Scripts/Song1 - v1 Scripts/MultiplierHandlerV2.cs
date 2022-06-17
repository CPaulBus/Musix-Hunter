using UnityEngine;
using TMPro;

public class MultiplierHandler : MonoBehaviour, IMultiplierHandler
{
    [SerializeField] private int currentMultiplier;
    [SerializeField] private int multiplierTracker;
    [SerializeField] private int[] multiplierTresholds;

    public TMP_Text multiText;

    private void Update()
    {
        multiText.text = "Multiplier: " + currentMultiplier + "x";
    }

    public void SetMultiplier(int multi)
    {
        currentMultiplier = multi;
    }

    public int GetMultiplier()
    {
        return currentMultiplier;
    }

    public void MultiplierChecker()
    {
        if (currentMultiplier - 1 < multiplierTresholds.Length)
        {
            multiplierTracker++;

            if (multiplierTresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
    }
}