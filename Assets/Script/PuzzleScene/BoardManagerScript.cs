using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManagerScript : MonoBehaviour
{
    public static BoardManagerScript instance;
    private Match3Script M3S;

    public List<Sprite> characters = new List<Sprite>();
    public Sprite boom;
    public GameObject tile;
    public int xSize, ySize;

    private GameObject[,] tiles;

    private int tempX1, tempY1;
    private int tempX2, tempY2;
    private GameObject tempObj;

    public bool isShifting { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        instance = GetComponent<BoardManagerScript>();

        M3S = GameObject.Find("Match3Manager").GetComponent<Match3Script>();

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

    public void changeTiles(GameObject selectObj1, GameObject selectObj2)       // tiles에 저장된 오브젝트 함께 변경
    {
        tempX1 = (int)selectObj1.transform.position.x;
        tempY1 = (int)selectObj1.transform.position.y;

        tempX2 = (int)selectObj2.transform.position.x;
        tempY2 = (int)selectObj2.transform.position.y;

        tempObj = tiles[tempX2, tempY2];

        tiles[tempX2, tempY2] = tiles[tempX1, tempY1];
        tiles[tempX1, tempY1] = tempObj;
    }

    public IEnumerator FindNullTiles()
    {
        for(int i=0; i<xSize; i++)
        {
            for(int j=0; j<ySize; j++)
            {
                if(tiles[i,j].GetComponent<SpriteRenderer>().sprite == null)
                {
                    yield return StartCoroutine(ShiftTilesDown(i, j));
                    break;
                }
            }
        }

        checkAllTiles();        // 3단계 터지는것 확인
    }

    private IEnumerator ShiftTilesDown(int x, int y, float shiftDelay = .03f)
    {
        isShifting = true;
        List<SpriteRenderer> renders = new List<SpriteRenderer>();
        int nullCount = 0;

        for(int i = y; i<ySize; i++)
        {
            SpriteRenderer render = tiles[x, i].GetComponent<SpriteRenderer>();

            if (render.sprite == null)
                nullCount++;

            renders.Add(render);
        }

        for(int i=0; i<nullCount; i++)
        {
            yield return new WaitForSeconds(shiftDelay);

            for (int j = 0; j < renders.Count-1; j++)
            {
                if(!(renders[j].sprite == boom))        // 별의 경우는 이동 X
                {
                    renders[j].sprite = renders[j + 1].sprite;
                    renders[j + 1].sprite = GetNewSprite(x, ySize - 1);
                }
            }

            if(renders.Count == 1)          // 맨위 터질경우 채워주는 역할
            {
                renders[0].sprite = GetNewSprite(x, ySize - 1);
            }
        }

        isShifting = false;
    }

    private Sprite GetNewSprite(int x, int y)
    {
        List<Sprite> possibleCharacters = new List<Sprite>();
        possibleCharacters.AddRange(characters);

        if (x > 0)
        {
            possibleCharacters.Remove(tiles[x - 1, y].GetComponent<SpriteRenderer>().sprite);
        }

        if(x < xSize - 1)
        {
            possibleCharacters.Remove(tiles[x + 1, y].GetComponent<SpriteRenderer>().sprite);
        }

        if(y > 0)
        {
            possibleCharacters.Remove(tiles[x, y - 1].GetComponent<SpriteRenderer>().sprite);
        }

        return possibleCharacters[Random.Range(0, possibleCharacters.Count)];
    }

    private bool checkAllTiles()
    {
        bool isMatched = false;
        bool temp = false;

        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                temp = M3S.IsMatch(tiles[i, j]);

                if (temp)
                    isMatched = true;
            }
        }

        return isMatched;
    }

    public void changeBoom(GameObject obj)
    {
        obj.GetComponent<SpriteRenderer>().sprite = boom;
    }
}