using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	private Match3Script M3S;

	private Camera cam;

	private GameObject selectObj1;
	private GameObject selectObj2;

	private Vector2 selectObj1Pos;
	private Vector2 selectObj2Pos;

	private bool isSwap;

	void Start()
	{
		M3S = GameObject.Find("Match3Manager").GetComponent<Match3Script>();

		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
    private void OnMouseDown()
    {
		Vector3 MousePos = Input.mousePosition;
		MousePos = cam.ScreenToWorldPoint(MousePos);
		
		RaycastHit2D hit = Physics2D.Raycast(MousePos, transform.forward, 15f);

        if (hit)
        {
			selectObj1 = hit.transform.gameObject;
        }
    }

    private void OnMouseUp()			// selectObj1과 같은 obj를 hit한 경우 선택 취소
    {
		Vector3 MousePos = Input.mousePosition;
		MousePos = cam.ScreenToWorldPoint(MousePos);

		RaycastHit2D hit = Physics2D.Raycast(MousePos, transform.forward, 15f);

		if (hit)
		{
			selectObj2 = hit.transform.gameObject;
		}

		if(selectObj1 != null && selectObj2 != null)
        {
            if (IsAdjacent(selectObj1, selectObj2))
            {
				SwapTile(selectObj1, selectObj2);
            }
		}
	}

	private bool IsAdjacent(GameObject selectObj1, GameObject selectObj2)							// 인접한 타일인지 확인
    {
		Vector2 pos = new Vector2(selectObj2.transform.position.x - selectObj1.transform.position.x, selectObj2.transform.position.y - selectObj1.transform.position.y);

		if ((Mathf.Abs(pos.x) == 1 && Mathf.Abs(pos.y) == 0) || (Mathf.Abs(pos.x) == 0 && Mathf.Abs(pos.y) == 1))
			return true;

		return false;
	}

	private void SwapTile(GameObject selectObj1,GameObject selectObj2)
    {
		// 타일 스프라이트 교체
		/*
		if (selectObj1.GetComponent<SpriteRenderer>().sprite == selectObj2.GetComponent<SpriteRenderer>().sprite)
			return;

		Sprite tempSprite = selectObj1.GetComponent<SpriteRenderer>().sprite;
		selectObj1.GetComponent<SpriteRenderer>().sprite = selectObj2.GetComponent<SpriteRenderer>().sprite;
		selectObj2.GetComponent<SpriteRenderer>().sprite = tempSprite;
		*/
		// 타일 위치 교체

		isSwap = true;

		selectObj1Pos = selectObj1.transform.position;
		selectObj2Pos = selectObj2.transform.position;

		BoardManagerScript.instance.changeTiles(selectObj1, selectObj2);
	}

    private void Update()
    {
        if (isSwap)
        {
			float MovementSpeed = 3f;

			selectObj1.transform.position = Vector2.MoveTowards(selectObj1.transform.position, selectObj2Pos, MovementSpeed * Time.deltaTime);
			selectObj2.transform.position = Vector2.MoveTowards(selectObj2.transform.position, selectObj1Pos, MovementSpeed * Time.deltaTime);

			if((Vector2)selectObj1.transform.position == selectObj2Pos && (Vector2)selectObj2.transform.position == selectObj1Pos)
            {
				isSwap = false;
				M3S.IsMatch(selectObj1);
            }
		}
    }
}