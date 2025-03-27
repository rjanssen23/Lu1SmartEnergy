using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    public Slider progressBar;
    public Image[] bolletjes;
    public int totalVakjes = 6;
    private int completedVakjes = 0;

    void Start()
    {
        // Initialiseer de slider
        progressBar.maxValue = totalVakjes;
        progressBar.value = completedVakjes;
        UpdateBolletjes();
    }

    public void VakjeAfronden()
    {
        if (completedVakjes < totalVakjes)
        {
            // Verhoog het aantal voltooide vakjes
            completedVakjes++;
            // Update de slider waarde
            progressBar.value = completedVakjes;
            UpdateBolletjes();
        }
    }

    void UpdateBolletjes()
    {
        for (int i = 0; i < bolletjes.Length; i++)
        {
            if (i < completedVakjes)
            {
                bolletjes[i].color = Color.green; // Gekleurd bolletje
            }
            else
            {
                bolletjes[i].color = Color.gray; // Ongedaan bolletje
            }
        }
    }
}
