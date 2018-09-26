using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tuch : MonoBehaviour {


    
    public GameObject prefab_sizeup;
    public float clickrate = 0.5f;

    int click = 0;
    Text countText, messageText;
    GameObject Fox;
    GameObject Canvas;


    // Use this for initialization
    void Start() {
        click = 0;
        //click = PlayerPrefs.GetInt("ClickCount");//コメントアウトしてありますが、これが無いとセーブデータが読み込めません！
        countText = GameObject.Find("CountText").GetComponent<Text>();
        Fox = GameObject.Find("Fox");
        Canvas = GameObject.Find("Canvas");
       // messageText = GameObject.Find("MessageText").GetComponent<Text>();
        countText.text = "Count:" + click;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            if (hit)
            {
                //Debug.Log("Hit!" + hit.transform.gameObject.name);
                if (hit.transform.tag == "Fox")
                {//tagがオブジェクトをクリックしたとき.
                    Click();

                }
            }
        }

                //クリック数でメッセージが変化
                //if (click > 50)
                //{
                  //  messageText.text = "刮目せよ！このたわわに実った乳を！！世の男どもは全員ワシの虜じゃ！";
                //}
                //else if (click > 40)
                //{
                  //  messageText.text = "ほほぉ…慣れてきたのぉ？ええぞ、もっと揉むがいい";
                //}
                //else if (click > 30)
                //{
                  //  messageText.text = "んんぅ…ふ、ふん！まぁまぁじゃの！";
                //}
                //else if (click > 20)
                //{
                  //  messageText.text = "ほぉ…なかなか様になってきたではないか。よいぞ、ワシの乳は成長を続けておる！";
                //}
                //else if (click > 10)
                //{
                  //  messageText.text = "足りん。足りんぞ！もっと力を寄越せ！";
                //}
                //else if (click <= 10)
                //{
                  //  messageText.text = "何をしておる。さっさと力をよこさんか！";
                //}
            }
        
        /// クリック処理.
        void Click()
        {
            click++;
            GameObject obj = Instantiate(prefab_sizeup);
            obj.transform.position = Input.mousePosition;//objの座標をマウス位置にする.
            obj.transform.SetParent(Canvas.transform);//親をCanvasに指定する.
            obj.AddComponent<ObjectDestroy>();//ObjectDestroyコンポーネントをobjに加える.
            countText.text = "Count:" + click;//クリックUI更新.

        iTween.PunchScale(Fox, iTween.Hash(
            "x", 20f,
            "y", 20f,
            "time", 0.5
            ));

    }

        

        /// <summary>
        /// アプリケーション終了時に呼ばれる.
        /// </summary>
         void OnApplicationQuit()
        {
            PlayerPrefs.SetInt("ClickCount", click);
        }
    }


    public class ObjectDestroy : MonoBehaviour
    {

        float destroyTime = 0.5f;
        float timer;

        private void Update()
        {
            timer += Time.deltaTime;
            if (destroyTime <= timer)
            {
                Destroy(gameObject);
            }
        }



    }











