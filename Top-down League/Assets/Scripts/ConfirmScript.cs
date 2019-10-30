using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfirmScript : MonoBehaviour
{
    public GameObject grid;
    public GameObject imageBehind;
    public GameObject shade;
    public GameObject championName;
    public TextMeshProUGUI title;
    public GameObject timer;

    private void Start()
    {
        title = title.GetComponent<TextMeshProUGUI>();
    }

    public void ConfirmButtonClicked()
    {
        grid.gameObject.SetActive(false);
        shade.gameObject.SetActive(false);
        imageBehind.GetComponent<Image>().color = new Color(255f, 255f, 255f);

        championName.gameObject.SetActive(true);

        title.text = "ESCOLHA SUA PREPARACAO";
        timer.GetComponent<TimerCountdown>().countdown = 10f;
        gameObject.SetActive(false);
    }
}
