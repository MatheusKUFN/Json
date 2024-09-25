using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScrJSON : MonoBehaviour
{
    //public Text nome;
    //public Text senha;
    public int coleta = 0;
    public GameObject coletaverus;
    public bool teste;
    //public GameObject coletavel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coletavel"))
        {

            coleta++;

            //other.transform.position = new Vector3(0, 0, 0);

        }
    }
    
    public void gravar()
    {
        ClassUserSave user = new ClassUserSave();

        user.login = "Arquivo";
        //user.senha = senha.text;

        user.x = this.gameObject.transform.position.x;
        user.y = this.gameObject.transform.position.y;
        user.z = this.gameObject.transform.position.z;
        //GameObject Vector3 = user.coletavel;
        user.pontos = coleta;

        //print("Login: " + user.login);
        //print("Senha: " + user.senha);
        print("X: " + user.x);
        print("Y: " + user.y);
        print("Z: " + user.z);
        print("Pontos: " + user.pontos);

        string json = "";

        string filePath = Path.Combine(Application.streamingAssetsPath, "salvar_J.json");

        Debug.Log(filePath);

        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        if (!File.Exists(filePath))
        {
            json = JsonUtility.ToJson(user, true);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
            {
                file.WriteLine(json);
                //file.WriteLine(user);
            }
        }
        else
        {
            print("Usuário já existe");
            File.Delete(filePath);
            json = JsonUtility.ToJson(user, true);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
            {
                file.WriteLine(json);
                //file.WriteLine(user);
            }
        }
    }

    public void ler()
    {

        string json = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/salvar_J.json");

        ClassUserSave user = JsonUtility.FromJson<ClassUserSave>(json);

        this.gameObject.transform.position = new Vector3(user.x, user.y, user.z);
        coleta = user.pontos;



    }


    public void lerDiretorio()
    {
        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        foreach (FileInfo file in di.GetFiles())
        {
            print(file.Name);
        }
    }

    public void apagar()
    {
        //File.Delete(Application.streamingAssetsPath + "/" + nome.text + ".json");
    }



    private void Update()
    {
        //inimigo();
        coletaverus.SetActive(teste);


        if (Input.GetKey("o"))
        {
            print("O = Gravar");
            gravar();
        }

        if (Input.GetKey("p"))
        {
            print("P = Ler");
            ler();
        }
        //if (Input.GetKeyDown("i"))
        //{
        //    teste = !teste;
            
        //}
        if (coleta != 0)
        {
            teste = false;
        }
        else
        {
            teste = true;
        }
        
    }
}