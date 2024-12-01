using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    // Start is called before the first frame update
    void Start()
    {
        GameObject textObject = GameObject.Find("PromptText");
        if (textObject != null)
        {
            promptText = textObject.GetComponent<TextMeshProUGUI>();
            Debug.Log("PromptText found and assigned!");
        }
    }

    // Update is called once per frame
    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
}
