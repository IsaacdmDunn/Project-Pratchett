using System;
using UnityEngine;

public class DialogResponseEvents : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    [SerializeField] private ResponseEvent[] events;

    public ResponseEvent[] Events  => events;

    public void OnValidate()
    {
        //checks if objects exist if not return
        if (dialog == null) return;
        if (dialog.Responces == null) return;
        if (events != null && events.Length == dialog.Responces.Length) return;

        //adds new events
        if (events == null)
        {
            events = new ResponseEvent[dialog.Responces.Length];
        }
        //idk 
        else
        {
            Array.Resize(ref events, dialog.Responces.Length);
        }

        //checks dialog responces for events
        for (int i = 0; i < dialog.Responces.Length; i++)
        {
            Responce responce = dialog.Responces[i];

            if (events[i] != null)
            {
                events[i].name = responce.ResponceText;
                continue;
            }

            events[i] = new ResponseEvent() { name = responce.ResponceText };
        }
    }
}
