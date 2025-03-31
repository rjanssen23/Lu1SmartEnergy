using UnityEngine;
using UnityEngine.UI;

public class ButtonDisabler : MonoBehaviour
{
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject button4;
    [SerializeField] private GameObject button5;
    [SerializeField] private GameObject button6;
    [SerializeField] private GameObject button7;
    [SerializeField] private GameObject button8;
    [SerializeField] private GameObject button9;
    [SerializeField] private GameObject button10;
    [SerializeField] private GameObject button11;
    [SerializeField] private GameObject button12;
    [SerializeField] private GameObject button13;
    [SerializeField] private GameObject button14;
    [SerializeField] private GameObject button15;
    [SerializeField] private GameObject button16;
    [SerializeField] private GameObject button17;
    [SerializeField] private GameObject button18;
    [SerializeField] private GameObject button19;

    private void Start()
    {
        AddListener(button1, DisableButton1);
        AddListener(button2, DisableButton2);
        AddListener(button3, DisableButton3);
        AddListener(button4, DisableButton4);
        AddListener(button5, DisableButton5);
        AddListener(button6, DisableButton6);
        AddListener(button7, DisableButton7);
        AddListener(button8, DisableButton8);
        AddListener(button9, DisableButton9);
        AddListener(button10, DisableButton10);
        AddListener(button11, DisableButton11);
        AddListener(button12, DisableButton12);
        AddListener(button13, DisableButton13);
        AddListener(button14, DisableButton14);
        AddListener(button15, DisableButton15);
        AddListener(button16, DisableButton16);
        AddListener(button17, DisableButton17);
        AddListener(button18, DisableButton18);
        AddListener(button19, DisableButton19);
    }

    private void AddListener(GameObject buttonObj, UnityEngine.Events.UnityAction action)
    {
        Button btn = buttonObj.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(action);
        }
    }

    public void DisableButton1() => button1.SetActive(false);
    public void DisableButton2() => button2.SetActive(false);
    public void DisableButton3() => button3.SetActive(false);
    public void DisableButton4() => button4.SetActive(false);
    public void DisableButton5() => button5.SetActive(false);
    public void DisableButton6() => button6.SetActive(false);
    public void DisableButton7() => button7.SetActive(false);
    public void DisableButton8() => button8.SetActive(false);
    public void DisableButton9() => button9.SetActive(false);
    public void DisableButton10() => button10.SetActive(false);
    public void DisableButton11() => button11.SetActive(false);
    public void DisableButton12() => button12.SetActive(false);
    public void DisableButton13() => button13.SetActive(false);
    public void DisableButton14() => button14.SetActive(false);
    public void DisableButton15() => button15.SetActive(false);
    public void DisableButton16() => button16.SetActive(false);
    public void DisableButton17() => button17.SetActive(false);
    public void DisableButton18() => button18.SetActive(false);
    public void DisableButton19() => button19.SetActive(false);
}