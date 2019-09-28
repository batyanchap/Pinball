using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の動き
	private float defaultAngle = 20;
	//弾いた時の動き
	private float flickAngle = -20;
	//横幅の中央の座標
	private float width = Screen.width / 2;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);

	}

	// Update is called once per frame
	void Update () {

		 foreach (Touch t in Input.touches)
        {
            var id = t.fingerId;
						var pos = t.position;
						//画面左側をタッチしたとき左フリッパーを動かす
            if(t.phase == TouchPhase.Began && pos.x < width && tag == "LeftFripperTag"){
							SetAngle(this.flickAngle);
						}
						//画面右側をタッチしたとき右フリッパーを動かす
						if(t.phase == TouchPhase.Began && pos.x >= width && tag == "RightFripperTag"){
							SetAngle(this.flickAngle);
						}
						//画面から指を離したときフリッパーを元に戻す
            if(t.phase == TouchPhase.Ended && (tag == "LeftFripperTag" || tag == "RightFripperTag")){
							SetAngle(this.defaultAngle);
						}

        }

		//左矢印キーを押した時左フリッパーを動かす
		if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
			SetAngle(this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if(Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag"){
			SetAngle(this.flickAngle);
		}
		//矢印キーが離された時フリッパーを元に戻す
		if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
			SetAngle(this.defaultAngle);
		}
		if(Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag"){
			SetAngle(this.defaultAngle);
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}

}
