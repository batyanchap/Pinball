using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosz = -6.5f;
	//得点
	private int score = 0;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;
	//得点を表示するテキスト
	private GameObject scoreText;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		this.scoreText = GameObject.Find("ScoreText");
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if(this.transform.position.z < this.visiblePosz){
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text>().text = "Game Over";
		}
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other){
		//雲または星に衝突した場合
		if(other.gameObject.tag == "SmallStarTag"){
			this.score += 1;
			this.scoreText.GetComponent<Text>().text = "Score:"+this.score.ToString();
		}else if(other.gameObject.tag == "LargeStarTag"){
			this.score += 10;
			this.scoreText.GetComponent<Text>().text = "Score:"+this.score.ToString();
		}else if(other.gameObject.tag == "SmallCloudTag"){
			this.score += 5;
			this.scoreText.GetComponent<Text>().text = "Score:"+this.score.ToString();
		}else if(other.gameObject.tag == "LargeCloudTag"){
			this.score += 20;
			this.scoreText.GetComponent<Text>().text = "Score:"+this.score.ToString();
		}else{
			this.scoreText.GetComponent<Text>().text = "Score:"+this.score.ToString();
		}
	}
}
