using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDialog : MonoBehaviour
{
    [SerializeField] Text dialogTxt;
    [SerializeField] GameObject dialogUI;
    [SerializeField] float normalTypingSpeed = 0.02f;
    float typingSpeed = 0.02f;
    float typingPauseSpeed = 0.52f;
    [SerializeField] Dialog sentances;//replace with better options
    int index = 0;
    public bool convoFinished = false;
    [SerializeField] AudioSource eh;
    private ResponceHandler responceHandler;
    string currentSentence;
    public NPC_UI NPC_UI_Emotes;

    //creates a typing effect by outputing one letter at a time via coroutine
    IEnumerator TypingEffect()
    {
        if (sentances.Emotes.Length > 0)
        {
            NPC_UI_Emotes.ChangeEmote((NPC_UI.Emotions)sentances.Emotes[index]);
        }
        currentSentence = "";
        foreach (char letter in sentances.Dialogue[index].ToCharArray())
        {
            //uses $ for punctuation with $ being ignored for the UI text and extra pause time given
            currentSentence += letter;
            if (letter=='$')
            {
                yield return new WaitForSeconds(typingPauseSpeed);
            }
            else
            {
                dialogTxt.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (sentances.Emotes.Length > 0)
        {
            NPC_UI_Emotes.ChangeEmote((NPC_UI.Emotions)sentances.Emotes[index]);
        }

        responceHandler = dialogUI.GetComponent<ResponceHandler>();

        //if (TryGetComponent(out DialogResponseEvents responseEvents))
        //{
        //    AddResponseEvent(responseEvents.Events);
        //}

        //start conversation on initialisation
        eh.Play();
        typingSpeed = normalTypingSpeed;
        StartCoroutine(TypingEffect());
    }

    // Update is called once per frame
    void Update()
    {
        //continue text
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            //if typing is complete then get new sentance
            if (currentSentence == sentances.Dialogue[index])
            {
                GetNewSentence();
            }
            //if already typing display full sentence
            else
            {
                
                StopCoroutine(TypingEffect());
                typingSpeed = 0.005f;
            }
        }
        
    }

    //gets a new sentance to display
    void GetNewSentence()
    {
       
        //if sentance is available display is
        if (index < sentances.Dialogue.Length-1)
        {
            eh.Play();
            typingSpeed = normalTypingSpeed;
            index++;
            dialogTxt.text = "";
            StartCoroutine(TypingEffect());
        }
        //at end of dialog display all responces
        else if (sentances.Responces.Length > 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            responceHandler.ShowResponces(sentances.Responces);
        }
        //end conversation
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            dialogTxt.text = "";
            convoFinished = true;
        }
    }

    //sets a new dialogue for character to speak
    public void SetNewDialogue(Dialog dialog)
    {
        sentances = dialog;
        index = 0;
        dialogTxt.text = "";
        eh.Play();
        typingSpeed = normalTypingSpeed;
        StopAllCoroutines();
        StartCoroutine(TypingEffect());

        if (TryGetComponent(out DialogResponseEvents responseEvents))
        {
            AddResponseEvent(responseEvents.Events);
        }

    }

    public void AddResponseEvent(ResponseEvent[] responseEvents)
    {
        responceHandler.AddReponseEvent(responseEvents);
    }
}
