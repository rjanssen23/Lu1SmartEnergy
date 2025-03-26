using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string SceneNameBack;
    public string SceneNameStart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeSceneToBack()
    {
        SceneManager.LoadScene(SceneNameBack);
    }
    public void changeSceneToStart()
    {
        SceneManager.LoadScene(SceneNameStart);
    }
}



