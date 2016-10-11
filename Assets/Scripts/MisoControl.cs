using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MisoControl : MonoBehaviour
{
    [SerializeField, Header("飛ばす味噌")]
    private GameObject miso;
    [SerializeField, Header("飛ばし始めの位置")]
    private Transform fireTrans;
    [SerializeField]
    private AnalogClock clock;

    [SerializeField, Header("ゲーム内で進んだ時間")]
    private Text inGameTimeText;
    private int inGameTimeCount = 0;
    //[SerializeField, Header("リアルで進んだ時間")]
    //private Text inRealTimeText;
    [SerializeField, Header("現在の味噌の増加量")]
    private Text misoPlusNumber;
    [SerializeField, Header("味噌を増やせる時間")]
    private float gameTime = 10.0f;
    [Space(10)]
    //下3つは組み合わせによって決まる
    //1秒毎に最低限増える値
    //public int basePlusAmount;
    //混ぜたことによるボーナスの補正値
    public int bonusPlusAmount;
    //増やす時間の10秒を何分割するか
    public float splitCount;

    //何秒ごとにリセットするか
    //splitCountで決まる
    private float resetInterval;
    //何回リセットされたか
    private int resetCount = 0;
    //何秒たったかを整数で
    private int secondCount = 0;
    //混ぜた移動量の合計
    private float totalDistance = 0.0f;
    [SerializeField, Header("移動量から増加量にするときの補正")]
    private float distanceMagnification;
    //前フレームのマウス位置
    private Vector2 beforePos;

    //クリック判定用
    [SerializeField, Header("押してから離すまでの最大時間")]
    private float clickCheckInterval = 0.25f;
    private float clickTime = -1.0f;

    //経過時間
    private float timer = 0.0f;
    //味噌の数
    private int misoCount = 0;
    //時間が流れているかどうか
    private bool isPlaying = false;


    [SerializeField, Header("みそポンの画像集")]
    private Sprite[] misopons;
    private int misopon = 0;

    // Use this for initialization
    void Start()
    {

        bonusPlusAmount = (int)Singleton.Instance.UpMiso;
        splitCount = Singleton.Instance.MixMiso;
        misopon = (int)Singleton.Instance.MisoPeturn;
        miso.GetComponent<SpriteRenderer>().sprite = misopons[misopon];
        resetInterval = 10.0f / splitCount;
    }

    // Update is called once per frame
    void Update()
    {


        if (isPlaying)
        {
            Control();
        }


    }

    //時間や増加量などをテキストに表示
    void TextUpdate()
    {
        inGameTimeText.text = inGameTimeCount.ToString()+"時間";
        //inRealTimeText.text = timer.ToString();
        float bonus = bonusPlusAmount * totalDistance * distanceMagnification;
        int plus = bonusPlusAmount + (int)bonus;
        misoPlusNumber.text = plus.ToString();
    }

    //マウス操作や時間の処理
    void Control()
    {
        timer += Time.deltaTime;
        TextUpdate();
        //混ぜたボーナスを一定間隔ごとにリセット
        if (timer > resetInterval * (resetCount + 1))
            ResetMix();

        //1秒ごとにクリックと同じことをする(味噌を増やす)
        if (timer > 1.0f * (1.0f + secondCount))
        {
            OneSecond();
            secondCount++;
        }
            

        if (timer > gameTime)
        {
            isPlaying = false;
            clock.CountStop();

            Debug.Log(misoCount);
            Singleton.Instance.misocount = misoCount;
            SceneManager.LoadScene("Result");

        }
        if (Input.GetMouseButtonDown(0))
        {
            clickTime = Time.time;
            beforePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        }
        if (Input.GetMouseButton(0))
        {
            Vector2 nowPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var vec2 = nowPos - beforePos;
            totalDistance += vec2.magnitude;
            beforePos = nowPos;
        }
        //クリックしたかどうか
        if (Input.GetMouseButtonUp(0) && clickCheckInterval > Time.time - clickTime)
        {
            OneSecond();
        }
        //スペースを押した(クリックと同じ処理)
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            OneSecond();
        }



    }
    //混ぜたボーナスをリセット
    void ResetMix()
    {
        resetCount++;
        totalDistance = 0.0f;

    }
    //1秒経った処理
    void OneSecond()
    {
        inGameTimeCount++;
        //味噌を増やす
        float bonus = bonusPlusAmount * totalDistance * distanceMagnification;
        int plus = bonusPlusAmount+(int)bonus;
        misoCount += plus;
        for (int i = 0; i < plus; i++)
        {
            Instantiate(miso, fireTrans.position, Quaternion.identity);

        }
    }

    public void GameStart()
    {
        isPlaying = true;
        clock.CountStart();
    }
}
