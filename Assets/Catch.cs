using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catch : MonoBehaviour
{

    public Text Result;    //結果を格納するテキスト
    public int Input;     //idを入力するインプットフィールド
    public int num;

    public string ServerAddress = "localhost/selecttest.php";  //selecttest.phpを指定　今回のアドレスはlocalhost

    //SendSignalボタンを押した時に実行されるメソッド
    public void SendSignal_Button_Push()
    {
        StartCoroutine("Access");   //Accessコルーチンの開始
    }

    private IEnumerator Access()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        dic.Add("id", ""+Input);  //インプットフィールドからidの取得);
        //複数phpに送信したいデータがある場合は今回の場合dic.Add("hoge", value)のように足していけばよい

        StartCoroutine(Post(ServerAddress, dic));  // POST

        yield return 0;
    }

    private IEnumerator Post(string url, Dictionary<string, string> post)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, string> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }
        WWW www = new WWW(url, form);

        yield return StartCoroutine(CheckTimeOut(www, 3f)); //TimeOutSecond = 3s;

        if (www.error != null)
        {
            Debug.Log("HttpPost NG: " + www.error);
            //そもそも接続ができていないとき

        }
        else if (www.isDone)
        {
            //送られてきたデータをテキストに反映
            Result.GetComponent<Text>().text = www.text;
            JsonUtility.FromJson<Data>(www.text);
            Debug.Log(Data.intValue);
        }
    }

    private IEnumerator CheckTimeOut(WWW www, float timeout)
    {
        float requestTime = Time.time;

        while (!www.isDone)
        {
            if (Time.time - requestTime < timeout)
                yield return null;
            else
            {
                Debug.Log("TimeOut");  //タイムアウト
                //タイムアウト処理
                //
                //
                break;
            }
        }
        yield return null;
    }
}
/*
[Serializable]
public class Data
{
    public int intValue;
    Debug.Log("");
}
*/