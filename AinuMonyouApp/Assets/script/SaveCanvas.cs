using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement;
using System;

public class SaveCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasObj;
    [SerializeField]
    private GameObject saveCanvasObj;
    [SerializeField]
    private GameObject saveButtonObj1;
    [SerializeField]
    private GameObject cancelButtonObj1;
    [SerializeField]
    private GameObject saveButtonObj2;
    [SerializeField]
    private GameObject cancelButtonObj2;
    [SerializeField]
    private InputField inputfield;
    [SerializeField]
    private GameObject inputfieldObj;
    [SerializeField]
    private GameObject TextObj;
    [SerializeField]
    private GameObject TextObj2;
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject notsaveButton;
    [SerializeField]
    private GameObject yesButton;
    [SerializeField]
    private GameObject noButton;

    private string path = "";
    private string fileName = "screenshot";

    [SerializeField]
    private GameObject modeManegerObj;
    private ModeManegr mm;

    void Awake()
    {
        mm = modeManegerObj.GetComponent<ModeManegr>();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkName()
    {
        fileName = inputfield.text;
        if (fileName == "")
        {
            fileName = "screenshot";
        }

        if (System.IO.File.Exists(Application.persistentDataPath + "/" + fileName + ".png"))
        {
            Debug.Log("上書き");
            inputfieldObj.SetActive(false);
            notsaveButton.SetActive(false);
            TextObj.SetActive(true);
            saveButtonObj1.SetActive(false);
            saveButtonObj2.SetActive(true);
            cancelButtonObj1.SetActive(false);
            cancelButtonObj2.SetActive(true);
        }
        else {
            screenshot();
        }

    }

    public void saveButton()
    {
        fileName = inputfield.text;
        if (fileName == ""){
            fileName = "screenshot";
        }
        screenshot();
    }

    public void cancelButton()
    {
        TextObj.SetActive(false);
        inputfieldObj.SetActive(true);
        saveButtonObj1.SetActive(true);
        saveButtonObj2.SetActive(false);
        cancelButtonObj1.SetActive(true);
        cancelButtonObj2.SetActive(false);
        notsaveButton.SetActive(true);
        inputfield.text = "";
    }

    public void notSaveButton()
    {
        inputfieldObj.SetActive(false);
        TextObj2.SetActive(true);
        saveButtonObj1.SetActive(false);
        yesButton.SetActive(true);
        cancelButtonObj1.SetActive(false);
        notsaveButton.SetActive(false);
        noButton.SetActive(true);
        text.text = "本当に保存せずに 終わりますか？";
    }

    public void YesButton()
    {
        SceneManager.LoadScene("title");
    }

    public void NoButton()
    {
        TextObj.SetActive(false);
        inputfieldObj.SetActive(true);
        saveButtonObj1.SetActive(true);
        saveButtonObj2.SetActive(false);
        cancelButtonObj1.SetActive(true);
        cancelButtonObj2.SetActive(false);
        notsaveButton.SetActive(true);
        inputfield.text = "";
        canvasObj.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        TextObj2.SetActive(false);
        saveCanvasObj.GetComponent<Canvas>().enabled = false;
        mm.IsMove = true;
    }

    void screenshot()
    {
        saveCanvasObj.GetComponent<Canvas>().enabled = false;
        Application.CaptureScreenshot(fileName + ".png");
        

        /**
        switch (Application.platform)
        {
            case RuntimePlatform.IPhonePlayer:
                path = Application.persistentDataPath + "/" + fileName + ".png";
                break;

            case RuntimePlatform.Android:
                CaptureScreen(this);
                path = Application.persistentDataPath + "/" + fileName + ".png";
                break;

            default:
                path = "/" + fileName + ".png";
                break;
        }
        **/

        Debug.Log("path:" + path);
        //saveCanvasObj.GetComponent<Canvas>().enabled = true;
        //text.text = path;
        Invoke("end", 0.5f);
    }

    void end()
    {
        inputfieldObj.SetActive(false);
        TextObj2.SetActive(true);
        saveButtonObj1.SetActive(false);
        yesButton.SetActive(true);
        cancelButtonObj1.SetActive(false);
        notsaveButton.SetActive(false);
        noButton.SetActive(true);
        TextObj.SetActive(false);
        saveButtonObj2.SetActive(false);
        cancelButtonObj2.SetActive(false);

        text.text = "終了しますか？";
        saveCanvasObj.GetComponent<Canvas>().enabled = true;
    }



    //コルーチン

    public class ScreenCapture
    {
        //--- クラス宣言 ---
        private class CaptureInfo
        {

            private string path;        // パス.
            private string id;          // 識別子( YY-MM-DD-HH-MM-SS の形式の日付文字列 ).
            private bool isFinished;    // 画像保存完了した否か.
            private byte[] byteData;        // キャプチャ画像のバイトデータ.

            public string Path { get { return this.path; } }
            public string Id { get { return this.id; } }
            public bool IsFinished { get { return this.isFinished; } }
            public byte[] ByteData { get { return this.byteData; } }

            public CaptureInfo(
                            string path,
                            string id,
                            byte[] byteData)
            {
                this.path = path;
                this.id = id;
                this.byteData = byteData;
                this.isFinished = false;
            }

            public void finish()
            {
                this.isFinished = true;
            }

        }

        //--- 定数 ---
        private const string PICTURE_EXTENSION = ".png";

        //--- 変数&プロパティ ---
        public delegate void CallBackTex2D(Texture2D tex, string filePath);   // コールバック( Texture2D ver ).
        public delegate void CallBackSprite(Sprite spr, string filePath);             // コールバック( Sprite ver ).
        private Dictionary<string, CaptureInfo> captureList;                  // キャプチャ情報リスト.


        //--- メソッド ---

        // コンストラクタ.
        public ScreenCapture()
        {
            this.captureList = new Dictionary<string, CaptureInfo>();
        }



        // スクリーンショットを撮影し,コールバクにSpriteと保存先パスを返す.
        // 保存先フォルダが存在しなければ新たに作成,フォルダの指定が無ければ[プロダクト名Images]フォルダを作成.
        // 同名ファイルがある場合に上書きするかも聞く.
        public void captureScreenshot(
                        MonoBehaviour mono,
                        CallBackSprite callback,
                        string fileName,
                        string folderName = "",
                        bool fileOverWrite = true)
        {

            mono.StartCoroutine(captureScreenshotCor(callback, fileName, folderName, fileOverWrite));
        }
        private IEnumerator captureScreenshotCor(
                        CallBackSprite callback,
                        string fileName,
                        string folderName,
                        bool fileOverWrite)
        {

            string folderPath = this.getFolderPath(folderName);
#if UNITY_IOS
                // iOSだとiCloudにバックアップを取りすぎるとリジェクトされる為,バックアップ属性指定フォルダのバックアップ属性を外す.
                Device.SetNoBackupFlag( folderName );
#endif
            fileName += PICTURE_EXTENSION;
            string filePath = folderPath + fileName;

            yield return new WaitForEndOfFrame();
            // 撮影.
            Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
            tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
            tex.Apply();

            // キャプチャ用の情報を作成.
            string captureID = this.getNowTimeString();
            CaptureInfo info = new CaptureInfo(filePath, captureID, tex.EncodeToPNG());
            this.captureList.Add(captureID, info);

            // コールバックでスプライトを先に渡す.
            Sprite spr = Sprite.Create(tex, new Rect(0, 0, Screen.width, Screen.height), Vector2.zero);
            callback(spr, filePath);

            // 別スレッドを作成しそっちで保存.
            Thread thread = new Thread(new ParameterizedThreadStart(this.saveCaptureImageThd));
            thread.Start(captureID);
            while (!this.captureList[captureID].IsFinished)
            {
                yield return new WaitForSeconds(0);
            }

            yield return null;
        }


        // スクリーンショットを撮影し,コールバックでTexture2Dとファイルパスを返す.
        public void captureScreenshot(
                        MonoBehaviour mono,
                        CallBackTex2D callback,
                        string fileName,
                        string folderPath = "",
                        bool isOverWrite = true)
        {

            mono.StartCoroutine(captureScreenshotCor(callback, fileName, folderPath, isOverWrite));
        }
        private IEnumerator captureScreenshotCor(
                        CallBackTex2D callback,
                        string fileName,
                        string folderName,
                        bool isOverWrite)
        {

            string folderPath = this.getFolderPath(folderName);
#if UNITY_IOS
                // iOSだとiCloudにバックアップを取りすぎるとリジェクトされる為,バックアップ属性指定フォルダのバックアップ属性を外す.
                Device.SetNoBackupFlag( folderName );
#endif
            fileName += PICTURE_EXTENSION;
            string filePath = folderPath + fileName;

            yield return new WaitForEndOfFrame();
            // 撮影.
            Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
            tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
            tex.Apply();

            // キャプチャ用の情報を作成.
            string captureID = this.getNowTimeString();
            CaptureInfo info = new CaptureInfo(filePath, captureID, tex.EncodeToPNG());
            this.captureList.Add(captureID, info);

            // コールバックでスプライトを先に渡す.
            callback(tex, filePath);

            // 別スレッドを作成しそっちで保存.
            Thread thread = new Thread(new ParameterizedThreadStart(this.saveCaptureImageThd));
            thread.Start(captureID);
            while (!this.captureList[captureID].IsFinished)
            {
                yield return new WaitForSeconds(0);
            }

            yield return new WaitForEndOfFrame();
        }


        // フォルダの有無をチェック.
        private string getFolderPath(
                string folderName,
                bool create = true)
        {

            // 出力パス( 指定したフォルダが無ければ作成 ).
            folderName = (folderName != "") ? folderName + "/" : Application.productName + "Images/";
            string folderPath = string.Empty;
            if (Application.platform != RuntimePlatform.WindowsEditor)
                folderPath = Application.persistentDataPath + "/" + folderName; // 最終的な保存先.
            else
                folderPath = Application.dataPath + "/" + folderName; // エディタの場合は探すのが面倒なのでプロジェクトフォルダに.

            if (!Directory.Exists(folderPath) && create)
            {
                Directory.CreateDirectory(folderPath);
            }

            return folderPath;
        }



        // 指定したパスのバイナリデータをbyte型配列で返す.
        private byte[] readBinary(
                        string path)
        {

            byte[] bytes = (File.Exists(path)) ? File.ReadAllBytes(path) : null;
            if (bytes == null)
                Debug.LogError("ファイルが存在しません.");
            return bytes;
        }


        // 指定したパス,サイズのTexture2Dを作成し,返す.
        private Texture2D readTexture2D(
                        string path,
                        int width,
                        int height)
        {

            byte[] data = this.readBinary(path);
            Texture2D tex = new Texture2D(width, height);
            tex.LoadImage(data);

            return tex;
        }


        // 指定したパス,サイズのスプライトを作成し,返す.
        private Sprite readSprite(
                        string path,
                        int width,
                        int height)
        {

            Texture2D tex = this.readTexture2D(path, width, height);
            Sprite spr = Sprite.Create(tex, new Rect(0, 0, width, height), Vector2.zero);

            return spr;
        }


        // 現在時刻のストリングを取得.
        // フォーマット : YY-MM-DD-OO-MM-SS.
        private string getNowTimeString()
        {

            string ret = DateTime.Now.Year.ToString() + "-";
            ret += DateTime.Now.Month.ToString() + "-";
            ret += DateTime.Now.Day.ToString() + "-";
            ret += DateTime.Now.Hour.ToString() + "-";
            ret += DateTime.Now.Minute.ToString() + "-";
            ret += DateTime.Now.Second.ToString();
            return ret;
        }


        // 別スレッド用メソッド.
        // 指定されたidのキャプチャ情報を保存.
        private void saveCaptureImageThd(
                        object id)
        {

            string captureID = (string)id;
            File.WriteAllBytes(this.captureList[captureID].Path, this.captureList[captureID].ByteData);
            this.captureList[captureID].finish();
        }
    }

}