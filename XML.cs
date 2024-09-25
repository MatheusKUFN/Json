using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class XML : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI login;
    public TextMeshProUGUI password;
    
    public int coleta = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coletavel"))
        {

            coleta++;

            //other.transform.position = new Vector3(0,0,0);

        }
    }
     public float x;
    public float y;
    public float z;
    public void gravar()
    {
        
        string filepath = Path.Combine(Application.streamingAssetsPath, "Save.XML");

        //criar meu save
        Salvar info = new Salvar();

        info.y = this.gameObject.transform.position.y;
        info.x = this.gameObject.transform.position.x;
        info.z = this.gameObject.transform.position.z;
        info.pontos = coleta;


        if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }

        if (!File.Exists(filepath))
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Salvar));
            StreamWriter streamWriter= new StreamWriter(filepath);
            serializer.Serialize(streamWriter.BaseStream, info);
            streamWriter.Close();

        }
        else
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Salvar));
            //StreamReader reader = new StreamReader(filepath);
            //Salvar listaDesserializada = (Salvar) xmlSerializer.Deserialize(reader.BaseStream);
            //reader.Close();

            //listaDesserializada.Add(Salvar);

            //foreach (Usuario item in listaDesserializada)
            //{

            //    if(usuario.login == item.login)
            //    {

            //        print("O nome " + usuario.login + " ja existe, coloque outro nome.");
            //        return;

            //    }

            //}

            StreamWriter writer = new StreamWriter(filepath);
            xmlSerializer.Serialize(writer.BaseStream, info);
            writer.Close();

            print("--------------------- GRAVADO ---------------------");

        }

    }

    public void excluir()
    {

        File.Delete(Path.Combine(Application.streamingAssetsPath + "Save.XML"));

    }

    public void ler()
    {
        

        string filePath = Path.Combine(Application.streamingAssetsPath, "Save.XML");

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Salvar));
        StreamReader reader = new StreamReader(filePath);
        Salvar info = (Salvar)xmlSerializer.Deserialize(reader.BaseStream);

        this.gameObject.transform.position = new Vector3(info.x, info.y, info.z);

        reader.Close();

        //this.gameObject.transform.rotation = new Vector3(info.x, info.y, info.z);

        

        print("--------------------- LIDO ---------------------");

        //foreach (Usuario item in usuarios)
        //{

        //    print(item.login);

        //}


    }

    private void Update()
    {

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

    }

}
