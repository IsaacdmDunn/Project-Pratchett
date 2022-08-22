using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDialog : MonoBehaviour
{
    [SerializeField] Text dialogTxt;
    [SerializeField] float normalTypingSpeed = 0.02f;
    float typingSpeed = 0.02f;
    [SerializeField] string[] sentances;//replace with better options
    int index = 0;
    public bool convoFinished = false;
    [SerializeField] AudioSource eh;
    

    IEnumerator Type()
    {
        foreach (char letter in sentances[index].ToCharArray())
        {
            dialogTxt.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        eh.Play();
        typingSpeed = normalTypingSpeed;
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //if typing
            if (dialogTxt.text == sentances[index])
            {
                Debug.Log("damjd");
                GetNewSentence();
            }
            else
            {
                
                StopCoroutine(Type());
                typingSpeed = 0.005f;
            }
        }
        
    }

    //improve with dialog options 
    void GetNewSentence()
    {
        if (index < sentances.Length-1)
        {
            eh.Play();
            typingSpeed = normalTypingSpeed;
            index++;
            dialogTxt.text = "";
            StartCoroutine(Type());
        }
        else
        {
            dialogTxt.text = "";
            convoFinished = true;
        }
    }
}
