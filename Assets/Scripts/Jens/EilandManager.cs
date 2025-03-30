using UnityEngine;
using System.Collections;

public class EilandKaart : MonoBehaviour
{
    public GameObject Eiland1;
    public GameObject Eiland2;
    public GameObject Eiland3;
    public GameObject Home;
    public GameObject Schatkaart;

    public GameObject[] piratenbotenEiland1; // Array voor piratenboot1 t/m piratenboot6 voor Eiland1
    public GameObject[] piratenbotenEiland2; // Array voor piratenboot1 t/m piratenboot6 voor Eiland2
    public GameObject[] piratenbotenEiland3; // Array voor piratenboot1 t/m piratenboot6 voor Eiland3

    public void ToEiland1()
    {
        StartCoroutine(AnimateToEiland1());
    }

    private IEnumerator AnimateToEiland1()
    {
        for (int i = 0; i < piratenbotenEiland1.Length - 1; i++)
        {
            piratenbotenEiland1[i].SetActive(true);
            yield return new WaitForSeconds(0.8f); // Wacht 0.8 seconden
            piratenbotenEiland1[i].SetActive(false);
        }

        // Laat de laatste piratenboot actief
        piratenbotenEiland1[piratenbotenEiland1.Length - 1].SetActive(true);

        yield return new WaitForSeconds(1f); // Wacht 1 seconde na de laatste piratenboot

        Eiland1.SetActive(true);
        Schatkaart.SetActive(false);
    }

    public void ToEiland2()
    {
        StartCoroutine(AnimateToEiland2());
    }

    private IEnumerator AnimateToEiland2()
    {
        for (int i = 0; i < piratenbotenEiland2.Length - 1; i++)
        {
            piratenbotenEiland2[i].SetActive(true);
            yield return new WaitForSeconds(0.8f); // Wacht 0.8 seconden
            piratenbotenEiland2[i].SetActive(false);
        }

        // Laat de laatste piratenboot actief
        piratenbotenEiland2[piratenbotenEiland2.Length - 1].SetActive(true);

        yield return new WaitForSeconds(1f); // Wacht 1 seconde na de laatste piratenboot

        Eiland2.SetActive(true);
        Schatkaart.SetActive(false);
    }

    public void ToEiland3()
    {
        StartCoroutine(AnimateToEiland3());
    }

    private IEnumerator AnimateToEiland3()
    {
        for (int i = 0; i < piratenbotenEiland3.Length - 1; i++)
        {
            piratenbotenEiland3[i].SetActive(true);
            yield return new WaitForSeconds(0.8f); // Wacht 0.8 seconden
            piratenbotenEiland3[i].SetActive(false);
        }

        // Laat de laatste piratenboot actief
        piratenbotenEiland3[piratenbotenEiland3.Length - 1].SetActive(true);

        yield return new WaitForSeconds(1f); // Wacht 1 seconde na de laatste piratenboot

        Eiland3.SetActive(true);
        Schatkaart.SetActive(false);
    }

    public void ToHome()
    {
        Home.SetActive(true);
        Schatkaart.SetActive(false);
    }

    public void ToSchatkaart()
    {
        Schatkaart.SetActive(true);
        Eiland1.SetActive(false);
        Eiland2.SetActive(false);
        Eiland3.SetActive(false);
        Home.SetActive(false);
    }
}
