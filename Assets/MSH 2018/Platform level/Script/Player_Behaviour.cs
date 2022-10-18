using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : MonoBehaviour {

	//Bloquer les mouvements du joueur pendant les cinématique QTE

	public float speed;
	public Camera mainCamera;

	private Rigidbody2D rb2d;
	private Animator animator;
	private SpriteRenderer spRend;
	private bool isQTETriggered;
	private int QTEEnumerator;
	private bool[] animStep;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		spRend = GetComponent<SpriteRenderer> ();
		isQTETriggered = false;
		QTEEnumerator = 0;
		animStep = new bool[] {true,true,true,true,true,true,true,true,true,true};
	}

	void FixedUpdate () {
		//Controle par le joueur
		if (isQTETriggered == false){
			float moveHorizontal = Input.GetAxis ("Horizontal");
			Vector2 movement = new Vector2 (moveHorizontal, 0);
			rb2d.velocity = movement * speed;	
		}
	}

	void Update () {
		//Gestion des animations
		if (Input.GetKey("right")) {
			animator.SetBool ("IsWalking", true);
			spRend.flipX = true;
		} else if (Input.GetKey("left")) {
			animator.SetBool ("IsWalking", true);
			spRend.flipX = false;
		} else {
			animator.SetBool ("IsWalking", false);
		}

		//Gestion de la "mort"
		if(transform.position.y < -6){ //OOB
			transform.position = new Vector3 (-23.17f,-1,0);
			rb2d.gravityScale = 32;
			if(transform.rotation != Quaternion.identity){
				transform.rotation = Quaternion.identity;
			}
		}

		//Gestion des cinématiques QTE
		if (isQTETriggered) {
			switch (QTEEnumerator) {
			case 1:
				if (transform.position != new Vector3 (-19.97f, -2.5f, 0) && animStep[0]) {
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-19.97f, -2.5f, 0), 8 * Time.deltaTime);
				} else if (transform.position != new Vector3 (-19.16f, -3, 0) && animStep[1]){
					animStep[0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-19.16f, -3, 0), 8 * Time.deltaTime);
				} else {
					isQTETriggered = false;
					rb2d.gravityScale = 32;
					QTEEnumerator = 0;
					mainCamera.orthographicSize = 5;
					animStep = new bool[] {true,true,true,true,true,true,true,true,true,true};
				}
				break;
			case 2:
				if (transform.position != new Vector3 (-19.16f, -3, 0) && animStep [0]) {
					transform.position = new Vector3 (-19.16f, -3, 0);
				} else if (transform.position != new Vector3 (-19, 1.3f, 0) && animStep [1]) {
					animStep [0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-19, 1.3f, 0), 4 * Time.deltaTime);
				} else if(transform.rotation != Quaternion.identity && animStep [2]){
					animStep[1] = false;
					transform.rotation = Quaternion.identity;
				} else {
					isQTETriggered = false;
					rb2d.gravityScale = 10;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				if (transform.position != new Vector3 (-19, 1.3f, 0) && animStep [1]) {
					transform.Rotate (new Vector3(0,0,720)*Time.deltaTime);
				}
				break;
			case 3:
				if (transform.position != new Vector3 (-19, 1.3f, 0) && animStep [0]) {
					transform.position = new Vector3 (-19, 1.3f, 0);
				} else if (transform.position != new Vector3 (-17.55f, -1.5f, 0) && animStep [1]) {
					animStep [0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-17.55f, -1.5f, 0), 9 * Time.deltaTime);
				} else {
					isQTETriggered = false;
					rb2d.gravityScale = 32;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				break;
			case 4:
				if (transform.position != new Vector3 (-17.6f, -1.45f, 0) && animStep [0]) {
					transform.position = new Vector3 (-17.6f, -1.45f, 0);
				} else if (transform.position != new Vector3 (-16.9f, 1.4f, 0) && animStep [1]) {
					animStep [0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-16.9f, 1.4f, 0), 9 * Time.deltaTime);
				} else if (transform.rotation.eulerAngles != new Vector3 (0,0,200) && animStep [2]) {
					animStep [1] = false;
					transform.Rotate (new Vector3(0,0,200));
				} else if (transform.position != new Vector3 (-15, -3.8f, 0) && animStep [3]) {
					animStep [2] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-15, -3.8f, 0), 15 * Time.deltaTime);
				} else if (transform.rotation != Quaternion.identity && animStep [4]) {
					animStep [3] = false;
					transform.rotation = Quaternion.identity;
				} else {	
					isQTETriggered = false;
					rb2d.gravityScale = 32;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				break;
			case 5:
				if (transform.position != new Vector3 (-13.63f, -3.8f, 0) && animStep [0]) {
					transform.position = new Vector3 (-13.63f, -3.8f, 0);
				} else if (transform.position != new Vector3 (-13.1f, -0.45f, 0) && animStep [1]) {
					animStep [0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-13.1f, -0.45f, 0), 5 * Time.deltaTime);
				} else {	
					isQTETriggered = false;
					rb2d.gravityScale = 25;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				break;
			case 6:
				if (transform.position != new Vector3 (-13.2f, -1.29f, 0) && animStep [0]) {
					transform.position = new Vector3 (-13.2f, -1.29f, 0);
				} else if (transform.position != new Vector3 (-12.41f, 2.65f, 0) && animStep [1]) {
					animStep [0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-12.41f, 2.65f, 0), 10 * Time.deltaTime);
				} else if (transform.position != new Vector3 (-10.9f, 0.4f, 0) && animStep [2]) {
					animStep [1] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-10.9f, 0.4f, 0), 7 * Time.deltaTime);
				} else {	
					isQTETriggered = false;
					rb2d.gravityScale = 10;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				break;
			case 7:
				if (transform.position != new Vector3 (-11.08f, 0.22f, 0) && animStep [0]) {
					transform.position = new Vector3 (-11.08f, 0.22f, 0);
				} else if (transform.position != new Vector3 (-9.69f, 0.16f, 0) && animStep [1]) {
					animStep [0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-9.69f, 0.16f, 0), 8 * Time.deltaTime);
				} else if (transform.position != new Vector3 (-9.69f, -3.43f, 0) && animStep [2]) {
					animStep [1] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-9.69f, -3.43f, 0), 8 * Time.deltaTime);
				} else if (transform.position != new Vector3 (-8.53f,-2.53f, 0) && animStep [3]) {
					animStep [2] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-8.53f,-2.53f, 0), 8 * Time.deltaTime);
				} else {	
					isQTETriggered = false;
					rb2d.gravityScale = 10;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				break;
			case 8:
				if (transform.position != new Vector3 (-8.55f, -2.88f, 0) && animStep [0]) {
					transform.position = new Vector3 (-8.55f, -2.88f, 0);
				} else if (transform.position != new Vector3 (-7.88f, -2.05f, 0) && animStep [1]) {
					animStep [0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-7.88f, -2.05f, 0), 8 * Time.deltaTime);
				} else if (transform.rotation.eulerAngles != new Vector3 (0,0,41) && animStep [2]) {
					animStep [1] = false;
					transform.Rotate (new Vector3(0,0,41));
				} else if (transform.position != new Vector3 (-6.59f, -1.89f, 0) && animStep [3]) {
					animStep [2] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-6.59f, -1.89f, 0), 4 * Time.deltaTime);
				} else {	
					isQTETriggered = false;
					rb2d.gravityScale = 10;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				break;
			case 9:
				if (transform.position != new Vector3 (-6.4f, -2.7f, 0) && animStep [0]) {
					transform.position = new Vector3 (-6.4f, -2.7f, 0);
				} else if (transform.position != new Vector3 (-7.05f, -0.59f, 0) && animStep [1]) {
					animStep [0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-7.05f, -0.59f, 0), 7 * Time.deltaTime);
				} else if (transform.position != new Vector3 (-5.65f, -0.62f, 0) && animStep [2]) {
					animStep [1] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-5.65f, -0.62f, 0), 7 * Time.deltaTime);
				} else if (transform.rotation != Quaternion.identity && animStep [3]){
					animStep [2] = false;
					transform.rotation = Quaternion.identity;
				} else {	
					isQTETriggered = false;
					rb2d.gravityScale = 32;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				if (transform.rotation.eulerAngles != new Vector3 (0,0,-41) && animStep [1] && animStep[0] == false) {
					transform.Rotate (new Vector3(0,0,-41));
				}
				break;
			case 10:
				if (transform.position != new Vector3 (-1.68f, -3.84f, 0) && animStep [0]) {
					transform.position = new Vector3 (-1.68f, -3.84f, 0);
				} else if (transform.rotation.eulerAngles != new Vector3 (0, 0, 270) && animStep [1]) {
					animStep [0] = false;
					transform.Rotate (new Vector3(0,0,270));
				} else if (transform.position != new Vector3 (4.88f, -4.12f, 0) && animStep [2]) {
					animStep [1] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (4.88f, -4.12f, 0), 13 * Time.deltaTime);
				} else if (transform.rotation != Quaternion.identity && animStep [3]){
					animStep [2] = false;
					transform.rotation = Quaternion.identity;
				} else {	
					isQTETriggered = false;
					rb2d.gravityScale = 32;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				break;
			case 11:
				if (transform.position != new Vector3 (5.24f, -3.93f, 0) && animStep [0]) {
					transform.position = new Vector3 (5.24f, -3.93f, 0);
				} else if (transform.position != new Vector3 (5.42f, -2, 0) && animStep [1]) {
					animStep [0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (5.42f, -2, 0), 9 * Time.deltaTime);
				} else if (transform.position != new Vector3 (7, -1.55f, 0) && animStep [2]) {
					animStep [1] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (7, -1.55f, 0), 9 * Time.deltaTime);
				} else {	
					isQTETriggered = false;
					rb2d.gravityScale = 10;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				break;
			case 12:
				if (transform.position != new Vector3 (7, -2.34f, 0) && animStep [0]) {
					transform.position = new Vector3 (7, -2.34f, 0);
				} else if (transform.position != new Vector3 (8.78f, 0.34f, 0) && animStep [1]) {
					animStep [0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (8.78f, 0.34f, 0), 9 * Time.deltaTime);
				} else if (transform.position != new Vector3 (10.24f, -0.74f, 0) && animStep [2]) {
					animStep [1] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (10.24f, -0.74f, 0), 9 * Time.deltaTime);
				} else if (transform.position != new Vector3 (13, 0.25f, 0) && animStep [3]) {
					animStep [2] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (13, 0.25f, 0), 9 * Time.deltaTime);
				} else {	
					isQTETriggered = false;
					rb2d.gravityScale = 32;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				break;
			case 13:
				if (transform.position != new Vector3 (12.93f, 0.15f, 0) && animStep [0]) {
					transform.position = new Vector3 (12.93f, 0.15f, 0);
				} else if (transform.position != new Vector3 (12.93f, 2.2f, 0) && animStep [1]) {
					animStep [0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (12.93f, 2.2f, 0), 9 * Time.deltaTime);
				} else if (transform.position != new Vector3 (14.7f, 1.79f, 0) && animStep [2]) {
					animStep [1] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (14.7f, 1.79f, 0), 9 * Time.deltaTime);
				} else {	
					isQTETriggered = false;
					rb2d.gravityScale = 32;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				break;
			case 14:
				if (transform.position != new Vector3 (14.8f, 1.85f, 0) && animStep [0]) {
					transform.position = new Vector3 (14.8f, 1.85f, 0);
				} else if (transform.position != new Vector3 (16.2f, 1.9f, 0) && animStep [1]) {
					animStep [0] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (16.2f, 1.9f, 0), 9 * Time.deltaTime);
				} else if (transform.rotation.eulerAngles != new Vector3 (0, 0, 175) && animStep [2]) {
					animStep [1] = false;
					transform.Rotate (new Vector3(0,0,175));
				} else if (transform.position != new Vector3 (15.38f, -3.71f, 0) && animStep [3]) {
					animStep [2] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (15.38f, -3.71f, 0), 12 * Time.deltaTime);
				} else if (transform.rotation != Quaternion.identity && animStep [4]) {
					animStep [3] = false;
					transform.rotation = Quaternion.identity;
				} else if (transform.rotation.eulerAngles != new Vector3 (0, 0, 315) && animStep [5]) {
					animStep [4] = false;
					transform.Rotate (new Vector3(0, 0, -45));
				} else if (transform.position != new Vector3 (23.63f, -2, 0) && animStep [6]) {
					animStep [5] = false;
					transform.position = Vector3.MoveTowards (transform.position, new Vector3 (23.63f, -2, 0), 12 * Time.deltaTime);
				} else if (transform.rotation != Quaternion.identity && animStep [7]) {
					animStep [6] = false;
					transform.rotation = Quaternion.identity;
				} else {	
					isQTETriggered = false;
					rb2d.gravityScale = 32;
					QTEEnumerator = 0;
					animStep = new bool[] { true, true, true, true, true, true, true, true, true, true };
				}
				break;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.gameObject.CompareTag("Ennemy") && isQTETriggered == false){
			transform.position = new Vector3 (-23.17f,-1,0);
			rb2d.gravityScale = 32;
			if(transform.rotation != Quaternion.identity){
				transform.rotation = Quaternion.identity;
			}
		} else if (other.gameObject.CompareTag("Ennemy") && isQTETriggered) {
			other.transform.position = new Vector3 (0, 11, 0);
		} else if (other.gameObject.CompareTag("LevelEnd")){
			//Switch scene
		}
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.CompareTag ("QTE")) {
			other.gameObject.GetComponent<SpriteRenderer> ().color = new Vector4(0.23f,0,1,0.5f);
			other.gameObject.transform.GetChild(0).GetComponent<TextMesh>().color = new Vector4(1,1,1,1);
		}
		if (other.gameObject.CompareTag ("QTE") && isQTETriggered == false) {
			switch(other.gameObject.name){
			case "Trigger (1)":
				if(Input.GetKeyDown("q")){
					InitQTE (1, 4.95f);
				}
				break;
			case "Trigger (2)":
				if(Input.GetKeyDown("f")){
					InitQTE (2, 5);
				}
				break;
			case "Trigger (3)":
				if(Input.GetKeyDown("n")){
					InitQTE (3, 5);
				}
				break;
			case "Trigger (4)":
				if(Input.GetKeyDown("y")){
					InitQTE (4, 5);
				}
				break;
			case "Trigger (5)":
				if(Input.GetKeyDown("l")){
					InitQTE (5, 5);
				}
				break;
			case "Trigger (6)":
				if(Input.GetKeyDown("w")){
					InitQTE (6, 5);
				}
				break;
			case "Trigger (7)":
				if(Input.GetKeyDown("a")){
					InitQTE (7, 5);
				}
				break;
			case "Trigger (8)":
				if(Input.GetKeyDown("a")){
					InitQTE (8, 5);
				}
				break;
			case "Trigger (9)":
				if(Input.GetKeyDown("c")){
					InitQTE (9, 5);
				}
				break;
			case "Trigger (10)":
				if(Input.GetKeyDown("k")){
					InitQTE (10, 5);
				}
				break;
			case "Trigger (11)":
				if(Input.GetKeyDown("x")){
					InitQTE (11, 5);
				}
				break;
			case "Trigger (12)":
				if(Input.GetKeyDown("k")){
					InitQTE (12, 5);
				}
				break;
			case "Trigger (13)":
				if(Input.GetKeyDown("f")){
					InitQTE (13, 5);
				}
				break;
			case "Trigger (14)":
				if(Input.GetKeyDown("w")){
					InitQTE (14, 5);
				}
				break;
			}
		}
	}

	void InitQTE (int QTEEnum, float camSize) {
		QTEEnumerator = QTEEnum;
		mainCamera.orthographicSize = camSize;
		isQTETriggered = true;
		rb2d.gravityScale = 0;
	}

	void OnTriggerExit2D (Collider2D other){
		if(other.gameObject.CompareTag("QTE")){
			other.gameObject.GetComponent<SpriteRenderer> ().color = new Vector4(0.23f,0,1,0);
			other.gameObject.transform.GetChild(0).GetComponent<TextMesh>().color = new Vector4(1,1,1,0);
		}
	}

}
