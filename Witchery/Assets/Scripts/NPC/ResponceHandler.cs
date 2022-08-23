using UnityEngine;
using UnityEngine.UI;

public class ResponceHandler : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] DisplayDialog dialogUI;

    //shows responces on buttons and sets active needed buttons
    public void ShowResponces(Responce[] responces)
    {
        
        int index = 0;

        foreach (Responce responce in responces)
        {
            buttons[index].gameObject.SetActive(true);
            buttons[index].GetComponentInChildren<Text>().text = responce.ResponceText;
            buttons[index].onClick.AddListener(() => OnPickedResponce(responce));
            index++;
        }
    }

    //when button is pressed show respounce dialogue
    void OnPickedResponce(Responce responce)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        dialogUI.SetNewDialogue(responce.dialogObject);
    }
}
