using UnityEngine;
using System.Collections;

public abstract class ScoreSubject  {
	
	public abstract void attach(ScoreObserver obj);
	public abstract void detach(ScoreObserver obj);
	public abstract void notifyObservers();
}