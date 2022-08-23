using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToNPC : MonoBehaviour
{
    [SerializeField]DisplayDialog dialogManager;
    [SerializeField] GameObject dialogUI;
    [SerializeField] GameObject cameraNPC;

    private void OnTriggerStay(Collider other)
    {
        //if player is nearby and no conversation is ongoing start dialog
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && dialogManager.convoFinished == false)
        {
            dialogManager.enabled = true;
            dialogUI.SetActive(true);
            cameraNPC.SetActive(true);
        }
        //if conversation is finish
        else if (dialogManager.convoFinished)
        {
            dialogManager.enabled = false;
            dialogUI.SetActive(false);
            cameraNPC.SetActive(false);
        }
    }
}
