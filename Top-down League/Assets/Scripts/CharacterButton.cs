using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    GameObject imageBehindObj;

    private Button[] buttonsFinal;
    private List<Button> buttons = new List<Button>();
    private GameObject[] characters;

    private void Start()
    {
        characters = GameObject.FindGameObjectsWithTag("CharacterClickable");

        foreach (GameObject character in characters)
        {
            buttons.Add(character.transform.GetChild(0).GetComponent<Button>());
        }

        buttonsFinal = buttons.ToArray();

        imageBehindObj = GameObject.FindGameObjectWithTag("ImageBehind");
    }

    public void SetAllButtonsInteractable()
    {
        foreach (Button button in buttonsFinal)
        {
            button.interactable = true;
        }
    }

    public void OnButtonClicked(Button clickedButton)
    {
        int buttonIndex = System.Array.IndexOf(buttonsFinal, clickedButton);

        if (buttonIndex == -1)
        {
            return;
        }

        SetAllButtonsInteractable();

        clickedButton.interactable = false;

        imageBehindObj.GetComponent<Animator>().Play("ImageBehindAnimation");
    }
}
