using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject DialogPanel;
    public GameObject PlayerInventory;
    public GameObject Hotbar;
    public GameObject Description;
    public GameObject Cauldron;
    public GameObject Storage;

    public CameraLook cameraLook;
    public bool lockCamera = true;

    public List<GameObject> caudrons;//place in asset manager
    public List<GameObject> storages;//place in asset manager

    public InventoryStorage currentSecondaryInventory;
    public UIState UIStatus;
    public bool UIStateChanged = true;
    public enum UIState
    {
        None = 0,
        Game,
        Dialog,
        Inventory,
        Cauldron,
        Storage,
        Shop,
    }

    public void ChangeInventory(InventoryStorage _currentSecondaryInventory)
    {
        PlayerInventory.GetComponent<InventoryStorage>().otherInventory = _currentSecondaryInventory;
    }

    public void ChangeStorage(GameObject _storage)
    {
        Storage = _storage;
    }

    public void ChangeCauldron(int _cauldron)
    {
        //Cauldron = caudrons[_cauldron];
    }
    //locks camera and cursor
    public void LockCursor()
    {

        if (!lockCamera)
        {
            cameraLook.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            cameraLook.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void FixedUpdate()
    {
        if (UIStateChanged)
        {
            DialogPanel.SetActive(false);
            PlayerInventory.SetActive(false);
            Hotbar.SetActive(false);
            Description.SetActive(false);
            Cauldron.SetActive(false);
            Storage.SetActive(false);
            switch (UIStatus)
            {
                case UIState.None:
                    break;
                case UIState.Game:
                    Hotbar.SetActive(true);
                    lockCamera = true;
                    break;
                case UIState.Dialog:
                    DialogPanel.SetActive(true);
                    lockCamera = false;
                    break;
                case UIState.Inventory:
                    PlayerInventory.SetActive(true);
                    Hotbar.SetActive(true);
                    Description.SetActive(true);
                    lockCamera = false;
                    break;
                case UIState.Cauldron:
                    PlayerInventory.SetActive(true);
                    Hotbar.SetActive(true);
                    Cauldron.SetActive(true);
                    lockCamera = false;
                    break;
                case UIState.Storage:
                    PlayerInventory.SetActive(true);
                    Hotbar.SetActive(true);
                    Storage.SetActive(true);
                    lockCamera = false;
                    break;
                case UIState.Shop:
                    PlayerInventory.SetActive(true);
                    Hotbar.SetActive(true);
                    lockCamera = false;
                    //shop menu here
                    break;
                default:
                    break;
            }
            LockCursor();
            UIStateChanged = false;
        }
        
    }

   
}
