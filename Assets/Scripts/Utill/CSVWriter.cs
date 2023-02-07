using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Stage
{
    public List<Tile> Tiles = new List<Tile>();
}

public class CSVWriter : MonoBehaviour
{
    

   
    string FileName = "";

    public List<Stage> stages = new List<Stage>(); // �������� �ȿ� Ÿ�Ͽ� ������ �������

    public Stage Temp = new Stage();

    public bool FinishStage { get; private set; }

    

    private void Start()
    {

        FileName = Application.dataPath + "/Resources/Map.csv";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            WriteCSV();
        }
    }
    public void WriteCSV()
    {
        
        stages.Add(Temp);

       if(stages.Count > 0)
        {
            TextWriter tw = new StreamWriter(FileName, false);
            tw.WriteLine("Stage,Pos,Type");
            tw.Close();

            tw = new StreamWriter(FileName, true);

            for(int i = 0; i < stages.Count; i ++)
            {
                for(int j = 0; j < stages[i].Tiles.Count; j++) // �������� ��ġ Ÿ��
                {
                    tw.WriteLine(i + "," + stages[i].Tiles[j].Pos + "," + stages[i].Tiles[j].Type);
                }
            }

            tw.Close();
        }


        for(int i = 0; i < stages.Count; i++) // �˻�
        {
           for (int j = 0; j < stages[i].Tiles.Count; j++)
            {

            Debug.Log($"{i} �������� :, ��ġ :{stages[i].Tiles[j].Pos} , ��ֹ� Ÿ�� :{stages[i].Tiles[j].Type}");
            }
        }
    }
    
       
}
