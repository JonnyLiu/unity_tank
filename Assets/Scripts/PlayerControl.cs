using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
     
	 private Rigidbody rBody;
	 //移动速度
	 private float Speed = 4;
	 //旋转速度
	 private float RotateSpeed = 20;

	 //炮台
	 public Transform TurretTrans;

	 //炮台旋转速度
	 public float TurretSpeed = 30;

	 //子弹预设体
	 public GameObject BulletPre;
	 //开火点
	 public Transform FireTrans;

    //计时器
	 private float timer;
	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody>();

		// 鼠标隐藏
		Cursor.visible = false;
		//锁定鼠标
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		//控制移动
		//获取垂直轴 ws  0没动 1w -1s
		float vertical = Input.GetAxis("Vertical");
		if (vertical != 0)
		{
			//给坦克一个速度  方向 * 正负 * 速度
			rBody.velocity = transform.forward * vertical*Speed;
			//播放移动音乐
			AudioManager.Instance.PlayMusic("move");
		}else
		{
			AudioManager.Instance.StopMusic();
		}
		//控制转向
		//获取水平轴 
		float horizontal = Input.GetAxis("Horizontal");
		if(horizontal !=0)
		{
			if (vertical < 0)
			{
				horizontal = -horizontal;
			}
              //旋转
			  transform.eulerAngles += Vector3.up * horizontal * RotateSpeed * Time.deltaTime;
		}

		//控制炮台旋转
		float Rotate = Input.GetAxis("Mouse X");
		if (Rotate !=0)
		{
			TurretTrans.localEulerAngles += Vector3.up * Rotate * TurretSpeed * Time.deltaTime;
		}


        timer += Time.deltaTime;
		//开火
		if (Input.GetMouseButtonDown(0) && timer > 0.5f)
		{
			timer = 0;
			Instantiate(BulletPre, FireTrans.position, FireTrans.rotation);
			AudioManager.Instance.PlaySound("bullet");
		}
	}
}
