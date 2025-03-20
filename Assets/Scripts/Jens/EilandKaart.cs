using UnityEngine;

public class EilandKaart : MonoBehaviour
{
    public GameObject Eiland1;
    public GameObject Eiland2;
    public GameObject Eiland3;
    public GameObject Home;
    public GameObject Schatkaart;
    public void ToEiland1()
    {
        Eiland1.SetActive(true);
        Schatkaart.SetActive(false);
    }

    public void ToEiland2()
    {
        Eiland2.SetActive(true);
        Schatkaart.SetActive(false);
    }

    public void ToEiland3()
    {
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
