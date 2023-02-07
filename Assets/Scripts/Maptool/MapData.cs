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

            Debug.Log($"{MapDataRead[i]["Stage"]}스테이지 : 위치 :{MapDataRead[i]["Pos"]} 타입 :{MapDataRead[i]["Type"]} ");
        }
    }

}
