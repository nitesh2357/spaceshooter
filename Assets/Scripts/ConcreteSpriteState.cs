using UnityEngine;
using System.Collections;

public class ConcreteSpriteState: SpriteState {

    public void change(PlayerScript p)
    {
        (p.GetComponent<SpriteRenderer>()).color = Color.gray;
        p.speed = new Vector2(5, 5);
    }
}
