using UnityEngine;
using UnityEngine.UI;

public class QuizScript : MonoBehaviour
{
    public GameObject correctAnswer;
    public GameObject faulseAnswerUno;
    public GameObject faulseAnswerDos;
    public GameObject vinkje;
    public GameObject kruisje1;
    public GameObject kruisje2;
    public GameObject uitleg;


    public Button correctButton;
    public Button faulseButtonUno;
    public Button faulseButtonDos;
    public Button resetQuiz;

    void Start()
    {
        Reset();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        uitleg.SetActive(false);

        kruisje1.SetActive(false);
        kruisje2.SetActive(false);
        vinkje.SetActive(false);
        faulseAnswerUno.SetActive(true);
        faulseAnswerDos.SetActive(true);


    }

    public void CorrectButton()
    {

        faulseAnswerUno.SetActive(false);
        faulseAnswerDos.SetActive(false);
        vinkje.SetActive(true);
        uitleg.SetActive(true);
    }
    public void FaulseAnswerUno() 
    {

        vinkje.SetActive(true);
        faulseAnswerDos.SetActive(false);
        uitleg.SetActive(true);
        kruisje1.SetActive(true);

    }
    public void FaulseAnswerDos()
    {
        vinkje.SetActive(true);
        faulseAnswerUno.SetActive(false);
        uitleg.SetActive(true);
        kruisje2 .SetActive(true);
    }

}
