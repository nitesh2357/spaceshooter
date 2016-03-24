using UnityEngine;
using System.Collections;


public class ConcreteObserver : ScoreObserver {
	
	
	protected ScoreSubject state;
	
	public override void update_observer(){
		Debug.Log ("update_observer level1");
	}
	
	public ConcreteObserver(){}
	
	public ConcreteObserver( ScoreSubject theSubject )
	{
		this.state = theSubject ;
	}
}