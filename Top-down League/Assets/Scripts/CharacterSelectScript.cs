using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CharacterSelectScript : MonoBehaviour
{
    GameObject imageBehindObj;

    public Image smallImage;
    public ParticleSystem effect;
    public TextMeshProUGUI championName;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterName2;
    public TextMeshProUGUI timeText;
    public Image selectImage;
    public Image squareImage;

    private Button[] buttonsFinal;
    private List<Button> buttons = new List<Button>();
    private GameObject[] characters;
    private Button confirmButton;

    float horizontalOffsetSelectedCharacter = 0f;
    float verticalOffsetSelectedCharacter = 0f;

    void Start()
    {
        characters = GameObject.FindGameObjectsWithTag("CharacterClickable");
        characterName = characterName.GetComponent<TextMeshProUGUI>();
        timeText = timeText.GetComponent<TextMeshProUGUI>();

        foreach (GameObject character in characters)
        {
            buttons.Add(character.transform.GetChild(0).GetComponent<Button>());
        }

        buttonsFinal = buttons.ToArray();

        imageBehindObj = GameObject.FindGameObjectWithTag("ImageBehind");

        confirmButton = GameObject.FindGameObjectWithTag("ConfirmButton").GetComponent<Button>();
        confirmButton.interactable = false;
    }

    void Update()
    {
        timeText.text = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>().text;

        foreach (Button button in buttons)
        {
            if (button.interactable == false) {
                confirmButton.interactable = true;

                Sprite selectedCharacter = characters[System.Array.IndexOf(buttonsFinal, button)].GetComponent<CharacterDisplay>().character.characterImage;
                string selectedName      = characters[System.Array.IndexOf(buttonsFinal, button)].GetComponent<CharacterDisplay>().character.characterName;

                horizontalOffsetSelectedCharacter = characters[System.Array.IndexOf(buttonsFinal, button)].GetComponent<CharacterDisplay>().character.horizontalOffset / 2;
                verticalOffsetSelectedCharacter = characters[System.Array.IndexOf(buttonsFinal, button)].GetComponent<CharacterDisplay>().character.verticalOffset / 2;

                smallImage.GetComponent<Image>().sprite = selectedCharacter;
                imageBehindObj.GetComponent<Image>().sprite = selectedCharacter;
  
                characterName.text = selectedName;
                characterName2.text = selectedName;

                if (characterName.gameObject.activeInHierarchy)
                {
                    selectImage.gameObject.SetActive(false);

                    Color aux = squareImage.GetComponent<Image>().color;
                    squareImage.GetComponent<Image>().color = new Color(aux.r, aux.g, aux.b, .05f);

                    effect.gameObject.SetActive(false);
                    championName.text = selectedName;
                    timeText.gameObject.SetActive(false);
                }
                else
                {
                    championName.text = "Escolhendo...";
                }


                smallImage.transform.localPosition = new Vector2(horizontalOffsetSelectedCharacter, verticalOffsetSelectedCharacter);
            }
        }
    }
}
