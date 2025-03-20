using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject PapegaaiFAQ;
    public GameObject antwoordenFAQ;
    public GameObject antwoord1;
    public GameObject antwoord2;
    public GameObject antwoord3;

    void Start()
    {
        Reset();
    }
    public void Reset()
    {
        PapegaaiFAQ.SetActive(false);
        antwoordenFAQ.SetActive(false);

    }
    public void PapegaaiButton()
    {
        PapegaaiFAQ.SetActive(true);

    }
    public void antwoord1Methode()
    {
        PapegaaiFAQ.SetActive(false);
        antwoord1.SetActive(false);

    }
    public void antwoord2Methode()
    {
        PapegaaiFAQ.SetActive(false);
        antwoord2.SetActive(false);
    }
    public void antwoord3Methode()
    {
        PapegaaiFAQ.SetActive(false);
        antwoord3.SetActive(false);
    }
    public void terugKnop()
    {
        Reset ();
    }
    public void terugknop2() 
    {
        Reset();
        PapegaaiFAQ.SetActive(true);
    }

}
