using UnityEngine;
using System.Collections;

public abstract class HealthSubject {

    public abstract void attach(HealthObserver obj);
    public abstract void detach(HealthObserver obj);
    public abstract void notifyObservers();
}
