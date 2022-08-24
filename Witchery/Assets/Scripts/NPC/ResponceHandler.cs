using UnityEngine;
using UnityEngine.UI;

public class ResponceHandler : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] DisplayDialog dialogUI;

    private ResponseEvent[] responseEvents;

    //shows responces on buttons and sets active needed buttons
    public void ShowResponces(Responce[] responces)
    {
        for (int index = 0; index < responces.Length; index++)
        {
            Responce responce = responces[index];
            int i = index;

            buttons[index].gameObject.SetActive(true);
            buttons[index].GetComponentInChildren<Text>().text = responces[index].ResponceText;
            buttons[index].onClick.AddListener(() => OnPickedResponce(responce, i));
        }
        
    }

    public void AddReponseEvent(ResponseEvent[] responces)
    {
        this.responseEvents = responces;
    }

    //when button is pressed show respounce dialogue
    void OnPickedResponce(Responce responce, int responseIndex)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }

        if (responseEvents != null && responseIndex <= responseEvents.Length)
        {
            Debug.Log(responseIndex);
            responseEvents[responseIndex].OnPickedResponce?.Invoke();
        }

        responseEvents = null;

        dialogUI.SetNewDialogue(responce.dialogObject);
    }
}
