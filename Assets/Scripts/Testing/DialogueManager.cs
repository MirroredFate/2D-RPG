using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] Button showTextButton;

    [SerializeField] string text;
    [SerializeField] bool isShowing;
    [SerializeField] float letterDelay = 0.02f;

    string text2;
    WaitForSeconds wait;


    // Start is called before the first frame update
    void Start()
    {
        showTextButton.onClick.AddListener(() => ShowText());
        text2 = "";
        wait = new WaitForSeconds(letterDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowing)
        {
            showTextButton.enabled = false;
        }
        else
        {
            showTextButton.enabled = true;
            StopCoroutine(DisplayText());
        }

        label.text = text2;
    }

    public void ShowText()
    {
        text2 = "";
        StartCoroutine(DisplayText());
    }
    
    IEnumerator DisplayText()
    {
        isShowing = true;
        for (int i = 0; i < text.Length; i++)
        {
            text2 += text.Substring(i, 1);
            yield return wait;
            
        }
        isShowing = false;
    }

}
