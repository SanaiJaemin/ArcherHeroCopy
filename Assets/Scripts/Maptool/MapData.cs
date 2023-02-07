using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    public static MapData instance;
    public List<Dictionary<string, object>> MapDataRead;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        MapDataRead = CSVReader.Read("Map");
    }

    private void Start()
    {
   

        for(int i = 0; i < MapDataRead.Count; i++)
        {

            Debug.Log($"{MapDataRead[i]["Stage"]}�������� : ��ġ :{MapDataRead[i]["Pos"]} Ÿ�� :{MapDataRead[i]["Type"]} ");
        }
    }

}
