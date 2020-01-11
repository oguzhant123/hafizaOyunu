using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController3 : MonoBehaviour
{

    [SerializeField]
    private Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> oyunPuzzle = new List<Sprite>();
    //Butonlar List
    public List<Button> btns = new List<Button>();
    // TAHMİNLER
    public static bool ilkTahmin, ikinciTahmin;
    public static int sayacTahmin; //countGuesses
    public static int dogruTahmin; //countCorrectGuesses
    public static int oyunTahmin;  //gameGuesses
    private int ilkTahminIndex, ikinciTahminIndex;
    private string ilkPuzzleTahmin, ikinciPuzzleTahmin;
    public Text zamanlayiciText;
    public float geriSayim;
    public bool bitti = false;
    public Text kazandinizText;
    // TAHMİNLER
    void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/Candy");   // spriteları yükle
    }
    void Start()
    {
        //Fonksiyonları Çalıştır
        GetButtons();
        AddListeners();
        AddGamePuzzle();
        karistir(oyunPuzzle);
        oyunTahmin = oyunPuzzle.Count / 2;
        geriSayim = Time.time;
        kazandinizText.enabled = false;
        kazandinizText.text = "";

    }
    void Update()
    {
        if (bitti)
        {
            return;
        }
        float t = Time.time - geriSayim;
        string dakika = ((int)t / 60).ToString();
        string saniye = (t % 60).ToString("f2");

        zamanlayiciText.text = dakika + ":" + saniye;
    }
    public void bitis()
    {
        bitti = true;
        zamanlayiciText.color = Color.yellow;
        kazandinizText.enabled = true;
        kazandinizText.text = "KAZANDINIZ";
    }
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton"); //Etiketi ile bul

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;                 // hepsine arkaplan resmi atandı.
        }
    }
    // ÖNEMLİ
    void AddGamePuzzle()
    {
        int cifte = btns.Count;
        int index = 0;

        for (int i = 0; i < cifte; i++)
        {
            if (index == cifte / 2)
            {
                index = 0;
            }
            oyunPuzzle.Add(puzzles[index]);
            index++;
        }
    }
    void AddListeners()
    {
        foreach (Button btn in btns)
        {
            // Basılan her butonda puzzleSecim() e git.
            btn.onClick.AddListener(() => puzzleSecim());
        }
    }
    public void puzzleSecim()
    {
        if (!ilkTahmin)
        {
            ilkTahmin = true;
            ilkTahminIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            ilkPuzzleTahmin = oyunPuzzle[ilkTahminIndex].name;
            btns[ilkTahminIndex].image.sprite = oyunPuzzle[ilkTahminIndex];

        }
        else if (!ikinciTahmin)
        {
            ikinciTahmin = true;
            ikinciTahminIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            ikinciPuzzleTahmin = oyunPuzzle[ikinciTahminIndex].name;
            btns[ikinciTahminIndex].image.sprite = oyunPuzzle[ikinciTahminIndex];
            sayacTahmin++;
            StartCoroutine(kontrol());
        }
    }
    IEnumerator kontrol()
    {
        yield return new WaitForSeconds(.5f);
        if (ilkPuzzleTahmin == ikinciPuzzleTahmin)
        {
            yield return new WaitForSeconds(.5f);
            btns[ilkTahminIndex].interactable = false;
            btns[ikinciTahminIndex].interactable = false;

            btns[ilkTahminIndex].image.color = new Color(0, 0, 0, 0);
            btns[ikinciTahminIndex].image.color = new Color(0, 0, 0, 0);
            kontrolSonuc();
        }
        else
        {
            yield return new WaitForSeconds(.5f);

            btns[ilkTahminIndex].image.sprite = bgImage;
            btns[ikinciTahminIndex].image.sprite = bgImage;
        }
        yield return new WaitForSeconds(.5f);
        ilkTahmin = ikinciTahmin = false;
    }
    IEnumerator sahneDegis()
    {
        yield return new WaitForSeconds(2); //3 saniye bekle
        SceneManager.LoadScene("seviyeler");
        Debug.Log("ÇIKILDI");
    }
    public void kontrolSonuc() // TETİKLEME BÖLÜMÜ
    {
        dogruTahmin++;
        if (dogruTahmin == oyunTahmin)
        {
            Debug.Log("Oyun Bitti.");
            bitis();
            StartCoroutine(sahneDegis());
        }
    }
    void karistir(List<Sprite> list) //Spritelar Listesi
    {
        for (int i = 0; i < list.Count; i++)    //List Sayısı Kadar
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
