using UnityEngine;
using System.Collections;

public class ConcreteHealthObserver : HealthObserver {

    // Use this for initialization
    protected HealthSubject state;

    public override void update_observer()
    {
        Debug.Log("update_observer level1");
    }

    public ConcreteHealthObserver() { }

    public ConcreteHealthObserver(HealthSubject theSubject)
    {
        this.state = theSubject;
    }
}
