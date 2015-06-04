using UnityEngine;
using System.Collections;

public class Mouse : Grunt {

    Vector3 pos;
    Vector3 scale = new Vector3(1,1,1);
    

    // Use this for initialization
    void Start() {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnMouseDown() {
        if (clicked) {
            Debug.Log("Clicked, " + scale);

            pos += Vector3.forward;
            scale += new Vector3(0.5f, 0.5f, 0.5f);

            this.gameObject.transform.position = pos;
            this.gameObject.transform.localScale = scale;
        }


    }
}
