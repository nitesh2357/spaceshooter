using UnityEngine;
using System.Collections;

public class UpdateScoreObserver : ConcreteObserver {
	
	//private string target_string=AlphaTargetTextManager.target_alpha_string;
	
	public UpdateScoreObserver(ConcreteScore state){
		base.state = state;
	}
	
	public override void update_observer(){

		PlayerScript.count = PlayerScript.count + 10;
	}
}
