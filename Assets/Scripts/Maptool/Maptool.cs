using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Maptool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Tiles;
    [SerializeField]
    private GameObject TilePrefab;
    
    int Width = 20;
    int Vertical = 10;
    int hight = 0;
    int TileIndex = 0;
    private bool obstacle = false;
    private bool spawnAditorOn = false;
    private int clickcount = 0;
    [SerializeField]
    CSVWriter _csvWriter;
    

    void Start()
    {
        TileInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            spawnAditorOn = !spawnAditorOn;
            Debug.Log($"에디터 가능상태 :{spawnAditorOn}");
        }
        if(spawnAditorOn)
        {
        ChoiceTile();
        }
        
    }

   void ChoiceTile ()
    {

        if (Input.GetKey(KeyCode.Alpha1))
        {
            hight = 1;
            TilePrefab = Tiles[(int)ETile.Wall];
            TileIndex = (int)ETile.Wall;
            obstacle = true;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            hight = 0;
            TilePrefab = Tiles[(int)ETile.River];
            obstacle = false;
            TileIndex = (int)ETile.River;
        }
       

        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.transform.gameObject.CompareTag("Obstacle"))
                {
                    return;
                }
                
                int posIndex = int.Parse(hit.transform.gameObject.name);
                Tile tile = new Tile();
                tile.Pos = posIndex;
                tile.Type = TileIndex;
                _csvWriter.Temp.Tiles.Add(tile);
                
                Vector3 ChoicePos = new Vector3(hit.transform.position.x, hight, hit.transform.position.z);
                if(!obstacle)
                {
                    Destroy(hit.transform.gameObject);
                }

                Instantiate(TilePrefab, ChoicePos, TilePrefab.transform.localRotation).transform.parent = gameObject.transform;
                clickcount++;
                
            }
      

        }
        
    }
    public void TileInit() //기본맵
    {
        int Size = Width * Vertical;

        for (int i = 0; i < Size; i++) // 맵생성
        {
            int x = i + (i / Vertical);
            int y = 0;

            if (x % 2 == 1)
            {
                TilePrefab = Tiles[(int)ETile.LightGrass];
            }
            if (i < 9 || i % 10 == 0 || i % 10 == 9)
            {
                TilePrefab = Tiles[(int)ETile.Wall];
                y += 1;
            }
            else if(191 <= i && i <=198)
            {
                TilePrefab = Tiles[(int)ETile.Wall];
                y += 1;
            }
            Vector3 TilePos = new Vector3(i % Vertical, y, i / Vertical);
            GameObject TileInfo = Instantiate(TilePrefab, TilePos, Quaternion.identity);
            TileInfo.name = i.ToString();
            TilePrefab = Tiles[(int)ETile.Grass];
            TileInfo.transform.parent = gameObject.transform;
        }
    }

    public void ObstacleInit()
    {
       
    }
}
