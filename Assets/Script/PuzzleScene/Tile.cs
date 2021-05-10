using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	private static Color selectedColor = new Color(.5f, .5f, .5f, 1.0f);
	private static Tile previousSelected = null;

	private SpriteRenderer render;
	private bool isSelected = false;

	void Awake()
	{
		render = GetComponent<SpriteRenderer>();
	}

	private void Select()
	{
		isSelected = true;
		render.color = selectedColor;
		previousSelected = gameObject.GetComponent<Tile>();
	}

	private void Deselect()
	{
		isSelected = false;
		render.color = Color.white;
		previousSelected = null;
	}

	private void OnMouseDown()
	{
		if (render.sprite == null || BoardManagerScript.instance.isShifting)
		{
			return;
		}

		if (isSelected) 
		{ 
			Deselect();
		}
		else
		{
			if (previousSelected == null)
			{
				Select();
			}
			else
			{
				SwapTile(previousSelected.render);
				previousSelected.Deselect();
			}
		}
	}

	private void SwapTile(SpriteRenderer render2)
    {
		if(render.sprite == render2.sprite)
        {
			return;
        }

		Sprite tempSprite = render2.sprite;
		render2.sprite = render.sprite;
		render.sprite = tempSprite;
    }
}
