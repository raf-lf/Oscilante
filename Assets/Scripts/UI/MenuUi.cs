using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

public class MenuUi : MonoBehaviour
{
    private bool menuOpen;
    public bool hideLevel3Content;

    [Header("SubMenus")]
    public Animator submenuAnim;
    public Animator inventoryAnim;
    public Animator descriptionAnim;
    public Animator optionsAnim;

    [Header("Descriptions")]
    public Text descriptionBoxText;
    public Text descriptionBoxTitle;

    [Header("Inventory")]
    public Text locationText;
    public Text assignmentText;
    public Animator weapons;
    public Animator documents;

    [Header("Inventory Items")]
    public Selectable[] weaponUpgradeBox = new Selectable[5];
    public Selectable[,] documentBox = new Selectable[4, 4];
    public Selectable[] medalBox = new Selectable[3];

    [Header("Components")]
    public GameObject overlay;
    public AudioSource sfxSource;
    public AudioSource bgmSource;

    [Header("Portraits")]
    public Sprite[] characterPortraitSprites = new Sprite[7];

    private void Start()
    {
        GameManager.scriptMenu = GetComponent<MenuUi>();
        GameManager.overlay = overlay;

        for (int i = 0; i < LibraryDialogue.characterPortrait.Length; i++)
        {
            LibraryDialogue.characterPortrait[i] = characterPortraitSprites[i];
        }

    }

    public void UpdateSceneInfo()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level 1":
                locationText.text = "Deserto Radiaotivo";
                assignmentText.text = "Preciso encontrar uma maneira de chegar até a cidade e ajudar Reina.";
                break;
            case "Level 2":
                locationText.text = "Cidade Devastada";
                if (SavedData.cutscenesSeen.Contains(2005)) assignmentText.text = "ENCONTRAR A ENTRADA DO METRÔ E ELIMINAR LÍDER DO NOVO GOVERNO ANTES DE CHEGAR AO OBJETIVO.";
                else if (SavedData.cutscenesSeen.Contains(2002)) assignmentText.text = "ENCONTRAR A ENTRADA DO METRÔ E CHEGAR AO OBJETIVO.";
                else assignmentText.text = "Preciso encontrar a entrada do metrô, onde fica a base da Resistência, e chegar até Reina.";
                break;
            case "Final Boss":
                locationText.text = "Base da Resistência";
                assignmentText.text = "ELIMINAR OBJETIVOS NA ÁREA.";
                break;

        }

    }

    public void UpdateMenuSelectables()
    {
        for (int i = 0; i < weaponUpgradeBox.Length; i++)
        {
            if (GameManager.weaponUpgrades[i]) weaponUpgradeBox[i].interactable = true;
            else weaponUpgradeBox[i].interactable = false;

        }

        for (int i = 0; i < medalBox.Length; i++)
        {
            if (GameManager.medals[i]) medalBox[i].interactable = true;
            else medalBox[i].interactable = false;

        }

        for (int i1 = 0; i1 < documentBox.GetLength(0); i1++)
        {
            //Check if all 3 documents of each collecion have been recovered
            if (GameManager.documents[i1, 0] && GameManager.documents[i1, 1] && GameManager.documents[i1, 2]) GameManager.documents[i1, 3] = true;

            for (int i2 = 0; i2 < documentBox.GetLength(1); i2++)
            {
                if (GameManager.documents[i1, i2]) documentBox[i1, i2].interactable = true;
                else documentBox[i1, i2].interactable = false;

            }
        }

    }

    public void InventoryOpen()
    {
        descriptionBoxTitle.text = null;
        descriptionBoxText.text = null;
        inventoryAnim.SetBool("active", true);
        submenuAnim.SetBool("active", true);
        // Cursor.visible = true;

        UpdateMenuSelectables();


    }
    public void InventoryClose()
    {

        inventoryAnim.SetBool("active", false);
        submenuAnim.SetBool("active", false);
        //  Cursor.visible = false;

    }

    public void OptionsOpen()
    {
        optionsAnim.SetBool("active", true);

        if (descriptionAnim.GetBool("active")) DescriptionClose();

    }

    public void OptionsClose()
    {
        optionsAnim.SetBool("active", false);

    }

    public void DescriptionOpen()
    {
        descriptionAnim.SetBool("active", true);

        if (optionsAnim.GetBool("active")) OptionsClose();
    }

    public void DescriptionClose()
    {
        descriptionAnim.SetBool("active", false);
    }

    public void MenuOpen()
    {
        InventoryOpen();

        GameManager.PauseGame(true);

        menuOpen = true;
    }
    public void MenuClose()
    {
        if (descriptionAnim.GetBool("active")) DescriptionClose();
        if (optionsAnim.GetBool("active")) OptionsClose();
        
        InventoryClose();

        GameManager.PauseGame(false);

        menuOpen = false;
    }

    void Update()
    {
        UpdateSceneInfo();
        weapons.SetBool("hasRifle", GameManager.unlockedWeapon[2]);
        weapons.SetBool("hideLevel3Content", hideLevel3Content);
        documents.SetBool("hideLevel3Content", hideLevel3Content);

        if (GameManager.CutscenePlaying == false)
        {
            if (menuOpen)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MenuClose();
                }
            }

            else if (menuOpen == false && Input.GetKeyDown(KeyCode.Escape))
            {
                MenuOpen();
            }
        }

    }

}
