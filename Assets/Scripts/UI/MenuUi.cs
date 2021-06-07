using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

public class MenuUi : MonoBehaviour
{
    public bool menuOpen;
    public bool hideLevel3Content;

    [Header("Medals")]
    public static bool[] achievmentLogShown = new bool[3];
    public AudioClip medalUnlockClip;

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

    [Header("Cursor")]
    public Texture2D[] cursor = new Texture2D[4];

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
            if (GameManager.weaponUpgrades[i])
            {
                weaponUpgradeBox[i].interactable = true;
            }
            else weaponUpgradeBox[i].interactable = false;

        }


        for (int i1 = 0; i1 < documentBox.GetLength(0); i1++)
        {
            //Check if all 3 documents of each collecion have been recovered
            if (GameManager.documents[i1, 0] && GameManager.documents[i1, 1] && GameManager.documents[i1, 2]) GameManager.documents[i1, 3] = true;

            for (int i2 = 0; i2 < documentBox.GetLength(1); i2++)
            {
                if (GameManager.documents[i1, i2])
                {
                    documentBox[i1, i2].interactable = true;
                }
                else documentBox[i1, i2].interactable = false;

            }
        }


        for (int i = 0; i < medalBox.Length; i++)
        {
            if (GameManager.medals[i]) medalBox[i].interactable = true;
            else medalBox[i].interactable = false;

        }

    }

    public void AchievmentCheck()
    {
        int collectableCount = 0;

        for (int i1 = 0; i1 < documentBox.GetLength(0); i1++)
        {
            for (int i2 = 0; i2 < documentBox.GetLength(1); i2++)
            {
                if (GameManager.documents[i1, i2]) collectableCount++;
            }
        }

        for (int i = 0; i < GameManager.weaponUpgrades.Length; i++)
        {
            if (GameManager.weaponUpgrades[i]) collectableCount++;

        }

        for (int i = 0; i < GameManager.unlockedWeapon.Length; i++)
        {
            if (GameManager.unlockedWeapon[i]) collectableCount++;

        }

        if (hideLevel3Content)
        {
            if (collectableCount >= 13)
            {
                GameManager.medals[1] = true;
                AchievmentLog(1);
            }
        }
        else
        {
            if (collectableCount >= 24)
            {
                GameManager.medals[1] = true;
                AchievmentLog(1);
            }
        }

        int resourcesCount = GameManager.ItemHeal + GameManager.ItemGrenade + GameManager.AmmoClips[1] + GameManager.AmmoClips[2];

        if (resourcesCount >= 30)
        {
            GameManager.medals[2] = true;
            AchievmentLog(2);
        }

        //CHANGE THIS TRIGGER
        if (SavedData.cutscenesSeen.Contains(3003)) GameManager.medals[0] = true;

    }

    public void AchievmentLog(int id)
    {
        if (!achievmentLogShown[id] && !GameManager.scriptLog.textActive)
        {
            achievmentLogShown[id] = true;

            AudioManager.PlaySfx(medalUnlockClip, 1, Vector2.one);

            GameManager.scriptLog.Write(LibraryMenu.LogMedal(LibraryMenu.ReturnMedalInfo(true,id)));
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

    public void ButtonOptions()
    {
        optionsAnim.SetBool("active", !optionsAnim.GetBool("active"));

        if (descriptionAnim.GetBool("active")) descriptionAnim.SetBool("active", false);

    }


    public void DescriptionOpenClose(bool open)
    {
        descriptionAnim.SetBool("active", open);

        if (open && optionsAnim.GetBool("active")) optionsAnim.SetBool("active", false);
    }

    public void Description()
    {
        
        descriptionAnim.SetBool("active", !descriptionAnim.GetBool("active"));

        if (optionsAnim.GetBool("active")) optionsAnim.SetBool("active", false);
    }

    public void ButtonExit()
    {
        MenuClose();
        FadeOut();
        Invoke(nameof(Exit), 2);
        if (descriptionAnim.GetBool("active")) descriptionAnim.SetBool("active", false);
        if (optionsAnim.GetBool("active")) optionsAnim.SetBool("active", false);

    }

    private void Exit()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void MenuOpen()
    {
        UpdateSceneInfo();

        InventoryOpen();


        GameManager.PauseGame(true);

        menuOpen = true;
    }

    public void FadeOut()
    {
        overlay.GetComponent<Animator>().SetInteger("state", 1);
    }

    public void MenuClose()
    {
        if (optionsAnim.GetBool("active")) optionsAnim.SetBool("active", false);
        if (descriptionAnim.GetBool("active")) descriptionAnim.SetBool("active", false);

        InventoryClose();

        GameManager.PauseGame(false);

        menuOpen = false;
    }

    public void UpdateCursor()
    {
        if (menuOpen) Cursor.SetCursor(cursor[0], new Vector2(0, 0),CursorMode.Auto);
        else 
        {
            int id = PlayerWeapons.equipedWeapon;
            
            switch (id)
            {

                case -1:
                    Cursor.SetCursor(cursor[0], new Vector2(0, 0), CursorMode.Auto);
                    break;
                case 0:
                    Cursor.SetCursor(cursor[1], new Vector2(8.5f, 8.5f), CursorMode.Auto);
                    break;

                default:
                    if(PlayerWeapons.ammo[id] == 0)
                        Cursor.SetCursor(cursor[4], new Vector2(8.5f, 8.5f), CursorMode.Auto);
                    else if (PlayerWeapons.ammo[id] <= PlayerWeapons.magazineSize[id] * 0.25)
                        Cursor.SetCursor(cursor[3], new Vector2(8.5f, 8.5f), CursorMode.Auto);
                    else if (PlayerWeapons.ammo[id] <= PlayerWeapons.magazineSize[id] * 0.5)
                        Cursor.SetCursor(cursor[2], new Vector2(8.5f, 8.5f), CursorMode.Auto);
                    else
                        Cursor.SetCursor(cursor[1], new Vector2(8.5f, 8.5f), CursorMode.Auto);

                    break;
            }
        }

    }

    void Update()
    {
        UpdateCursor();

        AchievmentCheck();
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

            else if (menuOpen == false && GameManager.scriptPlayer.dead == false && Input.GetKeyDown(KeyCode.Escape))
            {
                MenuOpen();
            }
        }

    }

}
