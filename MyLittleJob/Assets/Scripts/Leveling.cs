using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Leveling : MonoBehaviour {

    [SerializeField] // deixa colocar qual objeto como se o tile fosse public
    private GameObject[] tilefabs;

    //recebe o tamanho do x do objeto, é um quadrado x=y
    public float Tilesize
    {
        get { return tilefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.y; }
    }
    public Dictionary<Point,TileScript> Tiles { get; set; }

	// Use this for initialization
	void Start ()
    {
        CreateLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //Cria o chão
    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();
        string[] mapData = LoadMapText();

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;
        //pega a posição 0 da camera
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        
        for (int y=0; y<mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();
            for(int x=0; x<mapX; x++)
            {
                PlaceTile(newTiles[x].ToString(),x,y,worldStart);
            }
        }
    }

    //cria um gameobject do piso, e manda ele pra posição certa
    private void PlaceTile(string tileType, int x, int y, Vector3 worldStart)
    {
        int tileindex = int.Parse(tileType);
        TileScript newTile = Instantiate(tilefabs[tileindex]).GetComponent<TileScript>();
        newTile.GetComponent<TileScript>().Setup(new Point(x, y), new Vector3(worldStart.x + (Tilesize * x), worldStart.y - (Tilesize * y), 0));
        Tiles.Add(new Point(x, y), newTile);
    }
    //carrega o arquivo de mapa
    private string[] LoadMapText()
    {
        TextAsset data = Resources.Load("Level") as TextAsset;
        //divide em linhas
        string tmpData = data.text.Replace(Environment.NewLine, string.Empty);
        return tmpData.Split('-');
    }
}
