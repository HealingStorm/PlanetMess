using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasScript : MonoBehaviour
{
    private UICanvasScript Instance;
    #region Singlton:Profile
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
