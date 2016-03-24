using UnityEngine;
using System.Collections;

public class ConcreteSpriteState1 : SpriteState {

    public void change(PlayerScript p)
    {
        (p.GetComponent<SpriteRenderer>()).color = Color.blue;
        p.speed = new Vector2(10,10);
    }
}
