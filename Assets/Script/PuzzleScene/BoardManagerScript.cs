using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManagerScript : MonoBehaviour
{
    public static BoardManagerScript instance;

    public List<Sprite> characters = new List<Sprite>();
    public GameObject tile;
    public int xSize, ySize;

    private GameObject[,] tiles;

    public bool isShifting { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        instance = GetComponent<BoardManagerScript>();

        Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
        CreateBoard(offset.x, offset.y);
    }

    private void CreateBoard(float xOffset, float yOffset)
    {
        tiles = new GameObject[xSize, ySize];

        float startX = transform.position.x;
        float startY = transform.position.y;

        Sprite[] previousLeft = new Sprite[ySize];
        Sprite previousBelow = null;

        for(int i=0; i<xSize; i++)
        {
            for(int j=0; j<ySize; j++)
            {
                GameObject newTile = Instantiate(tile, new Vector2(startX + (xOffset * i), startY + (yOffset * j)), tile.transform.rotation);
                tiles[i, j] = newTile;
                newTile.transform.parent = transform;

                List<Sprite> possibleCharacters = new List<Sprite>(0);
                possibleCharacters.AddRange(characters);

                possibleCharacters.Remove(previousLeft[j]);
                possibleCharacters.Remove(previousBelow);

                Sprite newSprite = possibleCharacters[Random.Range(0,possibleCharacters.Count)];
                newTile.GetComponent<SpriteRenderer>().sprite = newSprite;

                previousLeft[j] = newSprite;
                previousBelow = newSprite;
            }
        }
    }
}