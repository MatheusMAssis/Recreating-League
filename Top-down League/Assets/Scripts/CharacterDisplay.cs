using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDisplay : MonoBehaviour
{
    public Character character;

    public TextMeshProUGUI characterName;
    public Image characterImage;

    void Start()
    {
        characterName.GetComponent<TextMeshProUGUI>().text = character.characterName;
        characterImage.GetComponent<Image>().sprite = character.characterImage;

        characterImage.transform.position = new Vector2(characterImage.transform.position.x + character.horizontalOffset, characterImage.transform.position.y + character.verticalOffset);
    }
}
