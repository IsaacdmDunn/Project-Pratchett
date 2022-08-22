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
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            dialogManager.enabled = true;
            dialogUI.SetActive(true);
            cameraNPC.SetActive(true);
        }
        else if (dialogManager.convoFinished)
        {
            dialogManager.enabled = false;
            dialogUI.SetActive(false);
            cameraNPC.SetActive(false);
        }
    }
}
