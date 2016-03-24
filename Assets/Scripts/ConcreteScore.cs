using UnityEngine;
using System.Collections;

public class ConcreteScore : ScoreSubject {
	
	private string subjectState;
	private ArrayList observers = new ArrayList();
	
	public override void attach(ScoreObserver obj){
		observers.Add (obj);
	}

	public override void detach(ScoreObserver obj){	
		observers.Remove (obj);
	}

 	public override void notifyObservers(){

		ScoreObserver obj;
		if(observers!=null)
		for( int i=0;i<observers.Count;i++)
		{
			obj=(ScoreObserver)observers[i];
			obj.update_observer();		
		}			
	}
	



	public string getState() {
		return subjectState ;
	}
	public void setState(string status) {
		//Debug.Log ("In ConcreteAlphaState::setState");
		subjectState = status ;
		notifyObservers();
	}

}