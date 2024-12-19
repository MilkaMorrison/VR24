using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Saveload : MonoBehaviour
{
    public GameObject Cil;
    public sdata data;
    public byte ra, ga, ba;


    public void ColorChange()
    {
        ra = (byte)Random.Range(0, 255);
        ga = (byte)Random.Range(0, 255);
        ba = (byte)Random.Range(0, 255);
        Cil.GetComponent<Renderer>().material.color = new Color32(ra, ga, ba, 255);
    }

    public void Loading()
    {
        data = JsonUtility.FromJson<sdata>(File.ReadAllText(Application.streamingAssetsPath + "/data.json"));
        Cil.transform.position = new Vector3(data.x, data.y, data.z);
        Cil.transform.rotation = new Quaternion(data.xr, data.yr, data.zr, 1);
        Cil.GetComponent<Renderer>().material.color = new Color32(data.r, data.g, data.b, 255);
        Debug.Log("Выгрузка из пути: " + Application.streamingAssetsPath + "/data.json");

    }

    public void Saving()
    {
        data.x = Cil.transform.position.x;
        data.y = Cil.transform.position.y;
        data.z = Cil.transform.position.z;

        data.xr = Cil.transform.rotation.x;
        data.yr = Cil.transform.rotation.y;
        data.zr = Cil.transform.rotation.z;

        data.r = ra;
        data.g = ga;
        data.b = ba;

        File.WriteAllText(Application.streamingAssetsPath + "/data.json", JsonUtility.ToJson(data));
        Debug.Log("Сохранение по пути: " + Application.streamingAssetsPath + "/data.json");
    }

    [System.Serializable]
    public class sdata
    {
        public float x, y, z, xr, yr, zr;
        public byte r, g, b;
    }
}
