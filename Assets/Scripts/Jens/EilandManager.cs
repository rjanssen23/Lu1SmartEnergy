using UnityEngine;
using UnityEngine.SceneManagement;

public class EilandManager : MonoBehaviour
{
    public void toIsland1()
    {
        SceneManager.LoadScene("Eiland1");
    }

    public void toIsland2()
    {
        SceneManager.LoadScene("Eiland2");
    }

    public void toIsland3()
    {
        SceneManager.LoadScene("Eiland3");
    }
}
