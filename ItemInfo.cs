using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] bool isP = false;
    private Vector3 OldPos;
    private float Scale = 10f;

    void Awake()
    {
        OldPos = transform.position;
    }

    public void InitPos()
    {
        if (isP)
        {
            int value = PlayerPrefs.GetInt("taskIndex");
            transform.position = new Vector3(OldPos.x, 0, (value * Scale));
        }
        else
        {
            int v = PlayerPrefs.GetInt("taskIndex");
            float value = Random.Range(v * Scale - Scale, v * Scale + Scale);
            transform.position = new Vector3(OldPos.x, 0, value);
        }
    }

    /// <summary>
    /// 获取坐标位置
    /// </summary>
    /// <returns></returns>
    public string GetPos()
    {
        float targetZ = (transform.position.z) / Scale;
        string PosX = string.Format("{0:f2}", targetZ);
        string PosY = ((int)OldPos.x).ToString();
        string PosZ = "0";
        string resStr = "PosX=" + PosX + "    PosY=" + PosY + "   PosZ=" + PosZ;
        return resStr;
    }
}
