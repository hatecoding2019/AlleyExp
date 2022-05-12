using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIEnd : MonoBehaviour
{
    public static UIEnd Instance;
    private Button BtnOK;
    [SerializeField] GameControl control;
    int index = 0;
    void Awake()
    {
        Instance = this;
        BtnOK = transform.Find("BtnOK").GetComponent<Button>();
        PlayerPrefs.SetInt("taskIndex", 1);
        BtnOK.onClick.AddListener(delegate ()
        {
            int index = PlayerPrefs.GetInt("taskIndex") +1;
            if (index <= 5)
            {
                PlayerPrefs.SetInt("taskIndex", index);
            }
            else
            {
                PlayerPrefs.SetInt("taskIndex", 1);
            }
            transform.localScale = Vector3.zero;
            control.InitItemPos();
        });

    }

    private void Start()
    {
        control.InitItemPos();
    }

    public void ShowUI()
    {
        transform.localScale = Vector3.one;
    }
}
