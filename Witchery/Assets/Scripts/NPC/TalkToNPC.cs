using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToNPC : MonoBehaviour
{
    [SerializeField]DisplayDialog dialogManager;
    [SerializeField] GameObject dialogUI;
    [SerializeField] GameObject cameraNPC;
    public bool isKillable = false;// move to npc info script
    public UIManager uIManager;

    private void OnTriggerStay(Collider other)
    {
        
        
        //if player is nearby and no conversation is ongoing start dialog
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && dialogManager.convoFinished == false)
        {
            dialogManager.enabled = true;
            uIManager.UIStatus = UIManager.UIState.Dialog;
            cameraNPC.SetActive(true);
            uIManager.UIStateChanged = true;
        }
        //if conversation is finish
        else if (dialogManager.convoFinished)
        {
            uIManager.UIStatus = UIManager.UIState.Game;
            dialogManager.enabled = false;
            cameraNPC.SetActive(false);
            uIManager.UIStateChanged = true;
        }
    }
}
