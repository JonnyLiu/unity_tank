using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
     public int Hp = 100;
	 //爆炸效果
	 public GameObject BombPre;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Bullet")
		{
			Hp -= 30;
			if (Hp<=0)
			{
				//死掉
				Instantiate(BombPre,transform.position, Quaternion.identity);
				AudioManager.Instance.PlaySound("boom");
                Destroy(gameObject);
			}else
			{
				AudioManager.Instance.PlaySound("hitWall");
			}
		}
	}
}
