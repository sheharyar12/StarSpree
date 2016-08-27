using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int starHealth;
	public int starCurrentHealth;
	public int maxStarHealth;


	public int startHealth;
	public int healthPerHeart;
	
	private int maxHealth;
	private int currentHealth;
	
	public Texture[] heartImages;
	public GUITexture heartGUI;
	
	private ArrayList hearts = new ArrayList();
	
	// Spacing:
	public float maxHeartsOnRow;
	private float spacingX;
	private float spacingY;
	
	
	void Start () {
		spacingX = heartGUI.pixelInset.width;
		spacingY = -heartGUI.pixelInset.height;
		starHealth = 4;
		starCurrentHealth = 4;
		//AddHearts(startHealth/healthPerHeart);
		Transform newHeart = ((GameObject)Instantiate(heartGUI.gameObject,this.transform.position,Quaternion.identity)).transform;

		newHeart.parent = transform;

		//using internet source for Floor function
		int y = (int)(Mathf.FloorToInt(hearts.Count / maxHeartsOnRow));
		int x = (int)(hearts.Count - y * maxHeartsOnRow);
		
		newHeart.GetComponent<GUITexture>().pixelInset = new Rect(x * spacingX,y * spacingY,175,43);
		newHeart.GetComponent<GUITexture>().texture = heartImages[0];
		hearts.Add(newHeart);
		UpdateHearts();
	}




	public void modifyHealth(int amount) {
		starCurrentHealth -= amount;
		UpdateHearts();
	}

	public void addHealth() {
		starCurrentHealth++;
		UpdateHearts();
	}

	void UpdateHearts() {


		foreach(Transform heart in hearts)
		{
			if (starCurrentHealth == 4) 
			{
				heart.GetComponent<GUITexture>().texture = heartImages [4];
				audio.Play ();
			}
			if (starCurrentHealth == 3) 
			{
				heart.GetComponent<GUITexture>().texture = heartImages [3];
				audio.Play ();
			}
			if (starCurrentHealth == 2) 
			{
				heart.GetComponent<GUITexture>().texture = heartImages [2];
				audio.Play ();
			}
			if (starCurrentHealth == 1) 
			{
				heart.GetComponent<GUITexture>().texture = heartImages [1];
				audio.Play ();
			}
			if (starCurrentHealth == 0) 
			{
				heart.GetComponent<GUITexture>().texture = heartImages [0];
				audio.Play ();
			}

		}
	}
}
