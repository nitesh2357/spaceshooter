using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
  /// <summary>
  /// Total hitpoints : Lives of the player
  /// </summary>
  public int hp = 20;
    public Text health;

  /// <summary>
  /// Enemy or player?
  /// </summary>
  public bool isEnemy = true;
	ConcreteScore scoreObject = new ConcreteScore();
	public ScoreObserver score;

  //public Text countText;
//	private int count=0;

 

	void Awake(){
		
		score = new UpdateScoreObserver (scoreObject);
		scoreObject.attach (score);
	}
   


  /// <summary>
  /// Inflicts damage and check if the object should be destroyed
  /// </summary>
  /// <param name="damageCount"></param>
  public void Damage(int damageCount)
  {
    hp -= damageCount;

    if (hp <= 0)
    {
      // Explosion!
      SpecialEffectsHelper.Instance.Explosion(transform.position);
      SoundEffectsHelper.Instance.MakeExplosionSound();

      // Dead!
      Destroy(gameObject);
	  //PlayerScript.count = PlayerScript.count + 10;
			scoreObject.setState("updateScore");	

    }
  }




  void OnTriggerEnter2D(Collider2D otherCollider)
  {
    // Is this a shot?
    ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
    if (shot != null)
    {
      // Avoid friendly fire
      if (shot.isEnemyShot != isEnemy)
      {
        Damage(shot.damage);

        // Destroy the shot
        Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
				//count +=10;
				//SetCountText();
		//Add code for incrementing and displaying score
      }
    }
  }
}