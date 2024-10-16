using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private UI_Manager uiManager;
    private void Awake()
    {
        uiManager = FindObjectOfType<UI_Manager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            uiManager.Victory();
        }
    }
}
