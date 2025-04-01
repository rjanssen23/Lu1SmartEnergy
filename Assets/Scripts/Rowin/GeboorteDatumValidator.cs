using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeboorteDatumValidator : MonoBehaviour
{
    public TMP_InputField geboortedatumInput; // UI Input Field
    public TMP_Text foutmelding; // Optioneel: een UI-element om fouten te tonen

    public void ValideerGeboortedatum()
    {
        if (DateTime.TryParse(geboortedatumInput.text, out DateTime geboortedatum))
        {
            int huidigeJaar = DateTime.Now.Year;
            int leeftijd = huidigeJaar - geboortedatum.Year;

            // Controleer of de leeftijd binnen de geldige grenzen valt
            if (leeftijd < 4 || leeftijd > 12)
            {
                foutmelding.text = "Leeftijd moet tussen 4 en 12 jaar zijn!";
                Debug.LogError("Leeftijd moet tussen 4 en 12 jaar zijn!");
                return;
            }

            // Datum is correct en de leeftijd is binnen de limieten
            foutmelding.text = ""; // Verwijder foutmelding als alles goed is
            Debug.Log($"Geldige geboortedatum: {geboortedatum.ToShortDateString()}");
        }
        else
        {
            foutmelding.text = "Ongeldige datum! Gebruik formaat: dd-MM-yyyy";
            Debug.LogError("Ongeldige datum! Gebruik formaat: dd-MM-yyyy");
        }
    }
}

