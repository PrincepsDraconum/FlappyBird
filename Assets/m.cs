using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using static m;

public class m : MonoBehaviour
{
    public static m n;
    public int Money;



    private void Awake()
    {
        if (n != null)
        {
            Destroy(gameObject);
            return;
        }
        n = this;
        DontDestroyOnLoad(gameObject);


    }    
}
