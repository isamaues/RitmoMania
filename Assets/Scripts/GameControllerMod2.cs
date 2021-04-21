using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControllerMod2 : MonoBehaviour
{
    private static GameControllerMod2 _instance = null;
    // private float timeLevel;
    // public static bool stopTime = false ;
    //public Text timeLevel_txt;
    public GameState gameState;

    public float speed;

    public int[] caicai;

    public Color[] cor;
    public GameObject[] botoes;
    //public GameObject startButton;

    public List<int> coresSeq;
    public int idResposta, tamanhoSeq,
               rodada;

    private AudioSource fonteAudio;
    public AudioClip[] sons;
    public AudioClip[] notasPiano;
    //public AudioClip somAplausos;

    //public GameObject buttonRepetir;

    public bool verificar;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public static GameControllerMod2 Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    void Start()
    {

        InitializeIndex();

    }

    public void InitializeIndex()
    {
        fonteAudio = GetComponent<AudioSource>();
        speed = 0.5f;
        tamanhoSeq = Mathf.FloorToInt(SetConfig.Instance.SequenceSize);
        SondSelect();
    }

    void SondSelect()
    {
        int j = Mathf.FloorToInt(SetConfig.Instance.ButtonNumber);

        for (int q = 0; q < j; q++)
        {
            //sons[q] = notasPiano[q];
        }

    }


    public void StartMusic()
    {
        StartCoroutine("Sequencia", GameController.Instance.tamanhoSeq + GameController.Instance.rodada);
    }

    public void NovaRodada()
    {

        foreach (GameObject obj in botoes)
        {
            obj.SetActive(false);
        }

        coresSeq.Clear();

        //startButton.SetActive(true);
        //rodadaTxt.text = string.Format("Rodada: {0}", rodada + 1);
        //tamanhoSeqTxt.text = string.Format("Sequência: {0}", tamanhoSeq + rodada);

    }

    IEnumerator Sequencia(int qtd)
    {
        //startButton.SetActive(false);
        int c = 0;
        for (int r = qtd; r > 0; r--)
        {
            Debug.Log("r");
            Debug.Log(r);
            
            Debug.Log("qtd");
            Debug.Log(qtd);

            //Debug.Log(botoes.Length);
            //Debug.Log(Mathf.FloorToInt(SetConfig.Instance.ButtonNumber));

            yield return new WaitForSeconds(speed);
            
            
            int i = caicai[c];
            botoes[i].SetActive(true);
            fonteAudio.PlayOneShot(notasPiano[c]);
            Debug.Log("c");
            Debug.Log(c);
            Debug.Log("i");
            Debug.Log(i);
            Debug.Log("----------");
            GameController.Instance.coresSeq.Add(i);
            c += 1;

            yield return new WaitForSeconds(speed);
            botoes[i].SetActive(false);
        }

        //gameState = GameState.RESPONDER;
        //GameController.Instance.idResposta = 0;
        //buttonRepetir.SetActive(true);

    }

   
}
