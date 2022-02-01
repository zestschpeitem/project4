using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class script_homework : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private bool boolperemen; // bool peremennaia
    [SerializeField] private int intperemen; // int peremennaia
    [SerializeField] private float floatperemen; // float peremennaia
    [SerializeField] private int[] intmassiv; //int massiv
    [SerializeField] private float[] floatmassiv; // float massiv
    [SerializeField] private int dlinamassiva;

    public struct peremens_and_massivs
    {
        public int intperemen;
        public float floatperemen;
        public int[] intmassiv;
        public float[] floatmassiv;
        public bool boolperemen;
        public int dlinamassiva;
    }

    public bool Task1_sozdanie_bool_peremen()
    {
        return boolperemen;
    }


    public int Task2_sozdanie_dlina_massiva()
    {
        return dlinamassiva;
    }


    public int int_nachalnoe_znachenie()
    {
        return intperemen;
    }


    public float float_nachalnoe_znachenie()
    {
        return floatperemen;
    }


    public int[] Int_Task3(int Task2_sozdanie_dlina_massiva, int int_nachalnoe_znachenie)
    {
        int[] intmassiv = new int[dlinamassiva];

        intmassiv[0] = int_nachalnoe_znachenie;
        for (int i = 1; i < Task2_sozdanie_dlina_massiva; i++)
        {
            intmassiv[i] = (int)Mathf.Pow(intmassiv[i - 1], 2);
        }

        return intmassiv;
    }


    public float[] Float_Task3(int Task2_sozdanie_dlina_massiva, float float_nachalnoe_znachenie)
    {
        float[] floatmassiv = new float[dlinamassiva];

        floatmassiv[0] = float_nachalnoe_znachenie;
        for (int i = 1; i < Task2_sozdanie_dlina_massiva; i++)
        {
            floatmassiv[i] = Mathf.Pow(floatmassiv[i - 1], 2);
        }

        return floatmassiv;
    }


    public int[] Int_Task4(int[] intmassiv)
    {

        for (int i = 0; i < Task2_sozdanie_dlina_massiva(); i++)
        {
            intmassiv[i] = intmassiv[i] - 5;
        }

        return intmassiv;
    }


    public float[] Float_Task4(float[] floatmassiv)
    {

        for (int i = 0; i < Task2_sozdanie_dlina_massiva(); i++)
        {
            floatmassiv[i] = floatmassiv[i] - 5.0f;
        }

        return floatmassiv;
    }


    public int izmenenie_Int(int value)
    {
        value += 1;
        return value;
    }


    public float izmenenie_Float(float value)
    {
        value += 2.0f;
        return value;
    }


    public void Task5_Int()
    {
        int intperemen = izmenenie_Int(int_nachalnoe_znachenie());
        Int_Task3(Task2_sozdanie_dlina_massiva(), intperemen);
        Int_Task4(intmassiv);

    }


    public void Task5_Float()
    {
        float floatperemen = izmenenie_Float(float_nachalnoe_znachenie());
        Float_Task3(Task2_sozdanie_dlina_massiva(), floatperemen);
        Float_Task4(floatmassiv);
    }


    public void Task5()
    {
        if (Task1_sozdanie_bool_peremen())
        {
            Task5_Int();
        }
        else
        {
            Task5_Float();
        }
    }


    public void Task6()
    {
        if (Task1_sozdanie_bool_peremen())
        {
            Task6_Int();
        }
        else
        {
            Task6_Float();
        }
    }


    public void Task6_Int()
    {
        int a = int_nachalnoe_znachenie();
        IntRef(ref a);

        int[] intmassiv = Int_Task3(Task2_sozdanie_dlina_massiva(), a);
        intmassiv = Int_Task4(intmassiv);

    }


    public void Task6_Float()
    {
        float a = float_nachalnoe_znachenie();
        FloatRef(ref a);

        float[] floatmassiv = Float_Task3(Task2_sozdanie_dlina_massiva(), a);
        floatmassiv = Float_Task4(floatmassiv);

    }

    public void IntRef(ref int value)
    {
        value += 4;
    }


    public void FloatRef(ref float value)
    {
        value += 3.0f;
    }



    public void Task7()
    {
        if (Task1_sozdanie_bool_peremen())
        {
            Task7_Int();
        }
        else
        {
            Task7_Float();
        }
    }


    public void Task7_Int()
    {
        int a = int_nachalnoe_znachenie();
        IntOut(out a);
        int[] intmassiv = Int_Task3(Task2_sozdanie_dlina_massiva(), a);
        intmassiv = Int_Task4(intmassiv);

    }


    public void Task7_Float()
    {
        float a = float_nachalnoe_znachenie();
        FloatOut(out a);
        float[] floatmassiv = Float_Task3(Task2_sozdanie_dlina_massiva(), a);
        floatmassiv = Float_Task4(floatmassiv);

    }


    public void IntOut(out int value)
    {
        value = 10;
    }


    public void FloatOut(out float value)
    {
        value = 6.0f;
    }



    //task8 запись в файл
    public void SaveFile()
    {
        StreamWriter sw = new StreamWriter("test.txt");
        sw.Write("intperemen = ");
        sw.WriteLine(intperemen);
        sw.Write("floatperemen = ");
        sw.WriteLine(floatperemen);
        sw.Write("boolperemen = ");
        sw.WriteLine(boolperemen);
        sw.Write("dlinamassiva = ");
        sw.WriteLine(dlinamassiva);
        sw.Write("intmassiv = ");
        sw.WriteLine(intmassiv);
        sw.Write("floatmassiv = ");
        sw.WriteLine(floatmassiv);
        sw.Close();
        StreamReader sr = new StreamReader("test.txt");
        sr.Close();
    }


    [SerializeField] private string path;
    public void Save(peremens_and_massivs saveState)
    {
        var currentDir = path;//Directory.GetCurrentDirectory();

        path = Path.Combine(currentDir, "Saves/Save.txt");

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            binaryFormatter.Serialize(stream, saveState);
        }
    }


    public void LoadeFromBinaryFormat()
    {
        peremens_and_massivs dataFromLoadBinery = new peremens_and_massivs();

        var currentDir = path;//Directory.GetCurrentDirectory();

        var pathDir = Path.Combine(currentDir, "Saves");

        DirectoryInfo dir = new DirectoryInfo(pathDir);
        if (!dir.Exists)
        {
            Debug.Log("Folder not found!");
        }

        path = Path.Combine(currentDir, "Saves/Save.txt");

        FileInfo loadFile = new FileInfo(path);
        BinaryFormatter binFormat = new BinaryFormatter();

        if (loadFile.Exists)
        {
            using (FileStream loadFileStream = new FileStream(loadFile.FullName, FileMode.OpenOrCreate))
            {
                dataFromLoadBinery = (peremens_and_massivs)binFormat.Deserialize(loadFileStream);
            }
            Debug.Log("Binary data load Done!");
        }
        else
        {
            Debug.Log("Error loading binary data!");
        }
    }

}
