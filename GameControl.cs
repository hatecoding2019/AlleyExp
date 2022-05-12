using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] ItemInfo Q1;
    [SerializeField] ItemInfo Q2;
    [SerializeField] ItemInfo P;
    [SerializeField] ItemInfo Q3;
    [SerializeField] ItemInfo Q4;

    string FileName = string.Empty;
    string FileData = string.Empty;
    
    private void Start()
    {
        FileName = System.DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "").Trim() + System.DateTime.Now.ToString("hh:mm:ss").Replace(":", "").Trim() + ".txt";
    }

    public void InitItemPos()
    {
        Q1.InitPos();
        Q2.InitPos();
        P.InitPos();
        Q3.InitPos();
        Q4.InitPos();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("记录坐标");
            UIEnd.Instance.ShowUI();

            string filePath = Application.streamingAssetsPath;
            string fileName = FileName;

            string targetDataAll = "Q1坐标位置：" + Q1.GetPos() + "\n"
                + "Q2坐标位置：" + Q2.GetPos() + "\n"
                + "P 坐标位置 ：" + P.GetPos() + "\n"
                + "Q3坐标位置：" + Q3.GetPos() + "\n"
                + "Q4坐标位置：" + Q4.GetPos() + "\n";

            FileData += targetDataAll+"\n";
            CreateTextToFile(filePath, fileName, FileData);
        }
    }

    /// <summary>
    /// 创建文件
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="data"></param>
    public void CreateTextToFile(string filePath, string fileName, string data)
    {
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        string fileAllPath = Path.Combine(filePath, fileName);
        StreamWriter swAll = new StreamWriter(fileAllPath, false, Encoding.UTF8);
        swAll.WriteLine(data);
        swAll.Close();
        swAll.Dispose();

    }
}
