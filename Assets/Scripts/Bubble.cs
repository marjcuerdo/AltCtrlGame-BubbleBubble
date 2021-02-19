using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
// control size of player's bubble

public class Bubble : MonoBehaviour
{

	// get size from serial reader
	public float bubbleWidth = (float)0.45;
	public float bubbleHeight = (float)0.45;

	private SpriteRenderer spriteRenderer;
	private CircleCollider2D circleCol;
	private Sprite lastSprite;

	void Start() {
		circleCol = GetComponent<CircleCollider2D>();
		spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
		UpdateColliderSize(); 
	}

    // Update is called once per frame
    void Update()
    {
    	// update size of bubble
    	Vector2 scale = new Vector2(bubbleWidth, bubbleHeight);

    	// update size of bubble collider
    	if (spriteRenderer.sprite != lastSprite) {
    		UpdateColliderSize();
    	}
    }

    private void UpdateColliderSize() {
    	Vector3 spriteHalfSize = spriteRenderer.sprite.bounds.extents;
    	circleCol.radius = spriteHalfSize.x > spriteHalfSize.y ? spriteHalfSize.x : spriteHalfSize.y;
    	lastSprite = spriteRenderer.sprite;
    }

}
