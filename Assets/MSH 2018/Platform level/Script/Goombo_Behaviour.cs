using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goombo_Behaviour : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2d;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		if (Time.time % 4 > 2) {
			Vector2 movement = new Vector2 (1, 0);
			rb2d.velocity = movement * speed * 1.02f;
		} else {
			Vector2 movement = new Vector2 (-1, 0);
			rb2d.velocity = movement * speed;
		}
	}

}
