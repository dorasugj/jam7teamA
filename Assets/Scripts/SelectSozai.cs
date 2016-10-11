using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectSozai : MonoBehaviour {

    //素材選択時の素材を置くImage
    public GameObject SelectSozai1, SelectSozai2;

    //素材ボタン
    public GameObject Sozai1, Sozai2, Sozai3, Sozai4;

    //インフォメーション画面の素材Image
    public Image InfoSozai1, InfoSozai2;

    //確認画面
    public GameObject InfoWindow;

    //画面上部のインフォメーション
    public Text InfoTxt;

    //素材選択回数
    int SelectCount;

    //引き渡し用の素材効果情報を保存する変数
    public static float [] Sozai1Effect, Sozai2Effect;

    //素材パターンによるみそぽんの１秒毎の増加量
    float[] TimePeturn;

    //素材パターンによるみそぽんのまぜる時間(10分割)
    float [] MixPeturn;

    //みそパターン
    int MisoPeturn;

    bool MSozai1, MSozai2, MSozai3, MSozai4;

    void Start ()
    {

        SelectCount = 0;

        InfoWindow.SetActive(false);
        SelectSozai1.SetActive(false);
        SelectSozai2.SetActive(false);

        InfoTxt.text = "1種類目の素材を選んでください";

    }
	
	void Update ()
    {  
        if(SelectCount == 1)
        {
            InfoTxt.text = "2種類目の素材を選んでください";
        }
        if (SelectCount == 2)
        {
            InfoWindow.SetActive(true);
        }  
	}
    public void Sozai1Enter()
    {
        SelectCount++;

        if (SelectCount == 1)
        {
            SelectSozai1.GetComponent<Image>().sprite = Sozai1.GetComponent<Image>().sprite;
            Sozai1.SetActive(false);

            InfoSozai1.sprite = Sozai1.GetComponent<Image>().sprite;
            SelectSozai1.SetActive(true);

            MSozai1 = true;
        }
        else if(SelectCount == 2)
        {
            SelectSozai2.GetComponent<Image>().sprite = Sozai1.GetComponent<Image>().sprite;
            Sozai1.SetActive(false);

            InfoSozai2.sprite = Sozai1.GetComponent<Image>().sprite;
            SelectSozai2.SetActive(true);

            MSozai1 = true;
        }
    }

    public void Sozai2Enter()
    {
        SelectCount++;

        if (SelectCount == 1)
        {
            SelectSozai1.GetComponent<Image>().sprite = Sozai2.GetComponent<Image>().sprite;
            Sozai2.SetActive(false);

            InfoSozai1.sprite = Sozai2.GetComponent<Image>().sprite;
            SelectSozai1.SetActive(true);

            MSozai2 = true;
        }
        else if (SelectCount == 2)
        {
            SelectSozai2.GetComponent<Image>().sprite = Sozai2.GetComponent<Image>().sprite;
            Sozai2.SetActive(false);

            InfoSozai2.sprite = Sozai2.GetComponent<Image>().sprite;
            SelectSozai2.SetActive(true);

            MSozai2 = true;
        }

        Debug.Log("Sozai2");
    }

    public void Sozai3Enter()
    {
        SelectCount++;

        if (SelectCount == 1)
        {
            SelectSozai1.GetComponent<Image>().sprite = Sozai3.GetComponent<Image>().sprite;
            Sozai3.SetActive(false);

            InfoSozai1.sprite = Sozai3.GetComponent<Image>().sprite;
            SelectSozai1.SetActive(true);

            MSozai3 = true;
        }
        else if (SelectCount == 2)
        {
            SelectSozai2.GetComponent<Image>().sprite = Sozai3.GetComponent<Image>().sprite;
            Sozai3.SetActive(false);

            InfoSozai2.sprite = Sozai3.GetComponent<Image>().sprite;
            SelectSozai2.SetActive(true);

            MSozai3 = true;
        }
    }

    public void Sozai4Enter()
    {
        SelectCount++;

        if (SelectCount == 1)
        {
            SelectSozai1.GetComponent<Image>().sprite = Sozai4.GetComponent<Image>().sprite;
            Sozai4.SetActive(false);

            InfoSozai1.sprite = Sozai4.GetComponent<Image>().sprite;
            SelectSozai1.SetActive(true);

            MSozai4 = true;
        }
        else if (SelectCount == 2)
        {
            SelectSozai2.GetComponent<Image>().sprite = Sozai4.GetComponent<Image>().sprite;
            Sozai4.SetActive(false);

            InfoSozai2.sprite = Sozai4.GetComponent<Image>().sprite;
            SelectSozai2.SetActive(true);

            MSozai4 = true;
        }
    }

    public void EnterYesButton()
    {
        if(MSozai1 && MSozai2)
        {
            Singleton.Instance.MixMiso = 1.0f;
            Singleton.Instance.UpMiso = 2;
            Singleton.Instance.MisoPeturn = 0;
        }
        else if(MSozai2 && MSozai3)
        {
            Singleton.Instance.MixMiso = 2.0f;
            Singleton.Instance.UpMiso = 3;
            Singleton.Instance.MisoPeturn = 1;
        }
        else if (MSozai1 && MSozai3)
        {
            Singleton.Instance.MixMiso = 3.0f;
            Singleton.Instance.UpMiso = 5;
            Singleton.Instance.MisoPeturn = 2;
        }
        else if (MSozai4 && MSozai1)
        {
            Singleton.Instance.MixMiso = 5.0f;
            Singleton.Instance.UpMiso = 6;
            Singleton.Instance.MisoPeturn = 3;
        }
        else if (MSozai4 && MSozai2)
        {
            Singleton.Instance.MixMiso = 10.0f;
            Singleton.Instance.UpMiso = 8;
            Singleton.Instance.MisoPeturn = 4;
        }
        else if (MSozai3 && MSozai4)
        {
            Singleton.Instance.MixMiso = 10.0f;
            Singleton.Instance.UpMiso = 2;
            Singleton.Instance.MisoPeturn = 5;
        }

        Debug.Log("パターン" + Singleton.Instance.MisoPeturn);
        Debug.Log("反映時間"+Singleton.Instance.MixMiso);
        Debug.Log("定数"+Singleton.Instance.UpMiso);


        SceneManager.LoadScene("game");
    }

    public void EnterNoButton()
    {
        InfoWindow.SetActive(false);
        SelectSozai1.SetActive(false);
        SelectSozai2.SetActive(false);

        Sozai1.SetActive(true);
        Sozai2.SetActive(true);
        Sozai3.SetActive(true);
        Sozai4.SetActive(true);

        MSozai1 = false;
        MSozai2 = false;
        MSozai3 = false;
        MSozai4 = false;

        SelectSozai1.GetComponent<Image>().sprite = null;
        SelectSozai2.GetComponent<Image>().sprite = null;
        SelectCount = 0;
        InfoTxt.text = "1種類目の素材を選んでください";
    }
}
