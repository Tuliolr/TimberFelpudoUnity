using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Principal : MonoBehaviour {

    public GameObject jogadorFelpudo;
    public GameObject felpudoIdle;
    public GameObject felpudoBa;
    public GameObject barril;
    public GameObject inimigoLeft;
    public GameObject inimigoRight;

    float escalaJogadorHorizontal;

    private List<GameObject> listaBlocos;


    // Use this for initialization
    void Start() {
        escalaJogadorHorizontal = transform.localScale.x;

        felpudoBa.SetActive(false);
        listaBlocos = new List<GameObject>();
        CriaBarrilInicio();

        

        
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Fire1"))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                bateDireita();
            }
            else
            {
                bateEsqueda();
            }

            listaBlocos.RemoveAt(0);
            ReposicionarBlocos();
        }
    }


    void bateDireita()
    {
        felpudoIdle.SetActive(false);
        felpudoBa.SetActive(true);
        jogadorFelpudo.transform.position = new Vector2(1.1f, jogadorFelpudo.transform.position.y);
        jogadorFelpudo.transform.localScale = new Vector2(-escalaJogadorHorizontal, jogadorFelpudo.transform.localScale.y);
        Invoke("VoltaAnimacao",0.25f);
        listaBlocos[0].SendMessage("BateDireita");
    }

    void bateEsqueda()
    {
        felpudoIdle.SetActive(false);
        felpudoBa.SetActive(true);
        jogadorFelpudo.transform.position = new Vector2(-1.1f, jogadorFelpudo.transform.position.y);
        jogadorFelpudo.transform.localScale = new Vector2(escalaJogadorHorizontal, jogadorFelpudo.transform.localScale.y);
        Invoke("VoltaAnimacao",0.25f);
        listaBlocos[0].SendMessage("BateEsqueda");
    }

    void VoltaAnimacao()
    {
        felpudoIdle.SetActive(true);
        felpudoBa.SetActive(false);
    }

    GameObject CriaNovoBarril(Vector2 posicao)
    {
        GameObject novoBarril;

        if (Random.value > 0.5f || (listaBlocos.Count <=2))
        {
            novoBarril = Instantiate(barril);
        }
        else
        {
            if(Random.value > 0.5f) {
                novoBarril = Instantiate(inimigoRight);
            }
            else
            {
                novoBarril = Instantiate(inimigoLeft);
            }
           
        }

        novoBarril.transform.position = posicao;

        return novoBarril;
    }


     void CriaBarrilInicio()
    {
        for(int i=0; i<=7; i++)
        {
            GameObject objetoBarril = CriaNovoBarril(new Vector2(0,-2.01f+(i*0.99f)));
            listaBlocos.Add(objetoBarril);
        }
    }

    void ReposicionarBlocos()
    {
        GameObject objetoBarril = CriaNovoBarril(new Vector2(0, -2.01f + (7 * 0.99f)));
        listaBlocos.Add(objetoBarril);
    }
}
