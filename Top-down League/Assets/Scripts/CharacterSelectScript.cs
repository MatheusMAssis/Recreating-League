using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterSelectScript : MonoBehaviour
{
    GameObject imageBehindObj;

    public Image smallImage;

    private Button[] buttonsFinal;
    private List<Button> buttons = new List<Button>();
    private GameObject[] characters;

    float horizontalOffsetSelectedCharacter = 0f;
    float verticalOffsetSelectedCharacter = 0f;

    void Start()
    {
        characters = GameObject.FindGameObjectsWithTag("CharacterClickable");

        foreach (GameObject character in characters)
        {
            buttons.Add(character.transform.GetChild(0).GetComponent<Button>());
        }

        buttonsFinal = buttons.ToArray();

        imageBehindObj = GameObject.FindGameObjectWithTag("ImageBehind");
    }

    void Update()
    {
        foreach (Button button in buttons)
        {
            if (button.interactable == false) {
                Sprite selectedCharacter = characters[System.Array.IndexOf(buttonsFinal, button)].GetComponent<CharacterDisplay>().character.characterImage;
                horizontalOffsetSelectedCharacter = characters[System.Array.IndexOf(buttonsFinal, button)].GetComponent<CharacterDisplay>().character.horizontalOffset;
                verticalOffsetSelectedCharacter = characters[System.Array.IndexOf(buttonsFinal, button)].GetComponent<CharacterDisplay>().character.verticalOffset;

                smallImage.GetComponent<Image>().sprite = selectedCharacter;
                imageBehindObj.GetComponent<Image>().sprite = selectedCharacter;

                smallImage.transform.localPosition = new Vector2(horizontalOffsetSelectedCharacter, verticalOffsetSelectedCharacter);
            }
        }
    }
}
