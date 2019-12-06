using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HidePanel : MonoBehaviour
{

    public GameObject panel;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;

    void Start()
    {
        Cursor.visible = false;
        panel.gameObject.SetActive(false);
        panel2.gameObject.SetActive(false);
        panel3.gameObject.SetActive(false);
        panel4.gameObject.SetActive(false);
        text1.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
    }

}
