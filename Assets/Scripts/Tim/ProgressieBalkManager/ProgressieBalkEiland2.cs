using UnityEngine;
using UnityEngine.UI;

public class ProgressieBalkEiland2 : MonoBehaviour
{
    public Slider progressBar;
    public Image[] bolletjes;
    public int totalVakjes = 9;
    private int completedVakjes = 0;
    private bool[] vakjesAfrondStatus;
    private Color[] origineleKleuren;
    public SchatkistAnimatieController schatkistAnimatieController;

    void Start()
    {
        // Initialiseer de slider
        progressBar.maxValue = totalVakjes;
        progressBar.value = completedVakjes;
        vakjesAfrondStatus = new bool[totalVakjes];
        origineleKleuren = new Color[bolletjes.Length];

        // Sla de oorspronkelijke kleuren van de bolletjes op
        for (int i = 0; i < bolletjes.Length; i++)
        {
            origineleKleuren[i] = bolletjes[i].color;
        }

        UpdateBolletjes();
    }

    public void VakjeAfronden(int vakjeIndex)
    {
        if (vakjeIndex < 0 || vakjeIndex >= totalVakjes)
        {
            Debug.LogError("Ongeldige vakje index");
            return;
        }

        if (!vakjesAfrondStatus[vakjeIndex])
        {
            // Markeer het vakje als afgerond
            vakjesAfrondStatus[vakjeIndex] = true;
            // Verhoog het aantal voltooide vakjes
            completedVakjes++;
            // Update de slider waarde
            progressBar.value = completedVakjes;
            UpdateBolletjes();

            // Start de schatkist animatie als het laatste vakje is afgerond
            if (completedVakjes == totalVakjes)
            {
                schatkistAnimatieController.StartAnimatie();
            }
        }
    }

    void UpdateBolletjes()
    {
        for (int i = 0; i < bolletjes.Length; i++)
        {
            if (vakjesAfrondStatus[i])
            {
                bolletjes[i].color = origineleKleuren[i]; // Zet terug naar oorspronkelijke kleur
            }
            else
            {
                bolletjes[i].color = Color.gray; // Zet naar grijs
            }
        }
    }
}

