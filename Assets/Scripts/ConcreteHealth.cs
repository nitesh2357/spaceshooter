using UnityEngine;
using System.Collections;

public class ConcreteHealth : HealthSubject {


    private string subjectState;
    private ArrayList observers = new ArrayList();

    public override void attach(HealthObserver obj)
    {
        observers.Add(obj);
    }

    public override void detach(HealthObserver obj)
    {
        observers.Remove(obj);
    }

    public override void notifyObservers()
    {

        HealthObserver obj;
        if (observers != null)
            for (int i = 0; i < observers.Count; i++)
            {
                obj = (HealthObserver)observers[i];
                obj.update_observer();
            }
    }




    public string getState()
    {
        return subjectState;
    }
    public void setState(string status)
    {
        //Debug.Log ("In ConcreteAlphaState::setState");
        subjectState = status;
        notifyObservers();
    }
}
