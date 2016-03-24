using UnityEngine;
using System.Collections;

public class UpdateHealthObserver : ConcreteHealthObserver {

    // Use this for initialization
    public UpdateHealthObserver(ConcreteHealth state)
    {
        base.state = state;
    }

    public override void update_observer()
    {
        PlayerScript p = new PlayerScript();
       PlayerScript.healthc = PlayerScript.healthc;
    }
}
