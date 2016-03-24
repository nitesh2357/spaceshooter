using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// 0 - The speed of the ship
    /// </summary>
    public Vector2 speed = new Vector2(25, 25);

    // 1 - Store the movement
    private Vector2 movement;
    private Rigidbody2D rigidBodyComponent;
    private SpriteState state;
    private HealthScript playerHealth;

	//Variables taken to display Score
	public Text countText;
	public static int count;
	public Text winText;

    //for displaying health
    public Text health;
    public static int healthc;
    
    

	ConcreteScore scoreObject = new ConcreteScore();
	public ScoreObserver score;

    ConcreteHealth healthObject = new ConcreteHealth();
    public HealthObserver heal;

    
  
    //Adding a start() for initializing score
    void Start ()
	{
        playerHealth=GetComponent<HealthScript>();
		rigidBodyComponent = GetComponent<Rigidbody2D>();
		count = 0;
		SetCountText ();
       
    }

	void SetCountText ()
	{
		//countText.text = "Score: " + count.ToString ();
		if (count >= 40)
		{
			//winText.text = "You Win!";
			//Application.Quit();
		}
	}

    
    void Update()
    {
		countText.text = "Score: " + count.ToString ();
        healthc = playerHealth.hp-1;
        health.text = "Health: "+healthc.ToString ();
        Debug.Log(healthc);
        // 2 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // 3 - Movement per direction
        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

        // 5 - Shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2"); // For Mac users, ctrl + arrow is a bad idea

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(false);
                SoundEffectsHelper.Instance.MakePlayerShotSound();

            }
        }

        // 6 - Make sure we are not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        transform.position = new Vector3(
                  Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
                  Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
                  transform.position.z
                  );
    }


	void Awake(){

		score = new UpdateScoreObserver (scoreObject);
		scoreObject.attach (score);
        heal = new UpdateHealthObserver(healthObject);
        healthObject.attach(heal);
        
	}

    void FixedUpdate()
    {
        // 4 - Move the game object
        if (rigidBodyComponent == null) rigidBodyComponent = GetComponent<Rigidbody2D>();
        rigidBodyComponent.velocity = movement;
    }

    void OnDestroy()
    {
        // Check that the player is dead, as we is also callled when closing Unity
        HealthScript playerHealth = this.GetComponent<HealthScript>();
        if (playerHealth != null && playerHealth.hp <= 0)
        {
            // Game Over.
            //var gameOver = FindObjectOfType<GameOverScript>();
            //gameOver.ShowButtons();
            if (Application.loadedLevelName.Equals("Stage1"))
            {
                Application.LoadLevel("lost");
            }
            if (Application.loadedLevelName.Equals("Stage2"))
            {
                Application.LoadLevel("lost1");
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;
        
        // Collision with enemy
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            // Kill the enemy
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null){
				enemyHealth.Damage(enemyHealth.hp);
                
				//Debug.Log ("enemy died");
				//Add Score for Player if he hits the enemy
				scoreObject.setState("updatescore");
				//count = count + 10;
				//SetCountText ();
			}
				

            damagePlayer = true;
        }

        // Collision with the boss
        BossScript boss = collision.gameObject.GetComponent<BossScript>();
        if (boss != null)
        {
            // Boss lose some hp too
            HealthScript bossHealth = boss.GetComponent<HealthScript>();
			if (bossHealth != null) {
				bossHealth.Damage(5);
				//Added for Score
				count = count + 50;
				SetCountText ();
			}

            damagePlayer = true;
        }

        // Damage the player
        if (damagePlayer)
        {
            
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            playerHealth.Damage(1);//changed from1 to 3
            if (playerHealth != null&& (this.GetComponent<HealthScript>()).hp < 15)
            {
                state = new ConcreteSpriteState1();
                state.change(this);
            }
            if (playerHealth != null&&(this.GetComponent<HealthScript>()).hp < 8)
            {
                state = new ConcreteSpriteState();
                state.change(this);
            }


        }
    }
}
