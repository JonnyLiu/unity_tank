using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
     
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2f);
		//添加一个力
		GetComponent<Rigidbody>().AddForce(transform.forward * 4000);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//碰撞调用
	private void OnCollisionEnter(Collision collision) 
	{
		Destroy(gameObject);
	}
}
