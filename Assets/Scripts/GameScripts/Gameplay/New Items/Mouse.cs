using UnityEngine;
using System.Collections;

public class Mouse : Grunt {

    Vector3 pos;
    Vector3 scale = new Vector3(1,1,1);
    private bool clicked;
    public static int attack;

    // Use this for initialization
    void Start() {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnMouseDown() {
        if (!clicked) {
            scale += new Vector3(0.5f, 0.5f, 0);
            clicked = true;
            attack++;

            this.gameObject.transform.localScale = scale;
            Debug.Log(clicked);
            Debug.Log(attack);
        }
        else if(clicked) {
            scale -= new Vector3(0.5f, 0.5f, 0);
            clicked = false;
            attack--;

            this.gameObject.transform.localScale = scale;
            Debug.Log(clicked);
            Debug.Log(attack);
        }
    }
}
