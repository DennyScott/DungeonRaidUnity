using UnityEngine;
using System.Collections;

public class Mouse : Grunt {

    Vector3 _scale = new Vector3(1,1,1);
    private bool _clicked;
    public static int Attack;

	/// <summary>
	/// Called when the presses the mouse button down. Changes the scale
	/// of the object depending on the previous scale. I.e. large -> small, or
	/// small -> large.
	/// </summary>
    void OnMouseDown() {
        if (!_clicked) {
            _scale += new Vector3(0.5f, 0.5f, 0);
            _clicked = true;
            Attack++;
        }
        else if(_clicked) {
            _scale -= new Vector3(0.5f, 0.5f, 0);
            _clicked = false;
            Attack--;
			
        }
		
       gameObject.transform.localScale = _scale;
    }
}
