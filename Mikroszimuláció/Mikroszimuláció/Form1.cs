using Mikroszimuláció.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikroszimuláció
{
    public partial class Form1 : Form
    {
        List<Person> Population;
        List<BirthProbabilities> BirthProbabilities;
        List<DeathProbabilities> DeathProbabilities;

        Random R = new Random(1234);

        public Form1()
        {
            InitializeComponent();
            Population = GetPopulation(@"C:\Temp\nép-teszt.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");

            MessageBox.Show(Population.Count.ToString());
            MessageBox.Show(BirthProbabilities.Count.ToString());
            MessageBox.Show(DeathProbabilities.Count.ToString());
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> result = new List<Person>();
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] items = line.Split(';');
                    Person p = new Person();
                    p.BirthYear = int.Parse(items[0]);

                    /*p.Gender = items[1] == "1" ? Gender.Male : Gender.Female;
                    //ez a kettő megegyezik
                    if (items[1] == "1")
                    {
                        p.Gender = Gender.Male;
                    }
                    else
                    {
                        p.Gender = Gender.Female;
                    }*/

                    p.Gender = (Gender)Enum.Parse(typeof(Gender), items[1]);
                    p.NbrOfChildren = int.Parse(items[2]);
                    result.Add(p);
                }
            }
            return result;
        }
        public List<BirthProbabilities> GetBirthProbabilities(string csvpath)
        {
            List<BirthProbabilities> result = new List<BirthProbabilities>();
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] items = line.Split(';');
                    BirthProbabilities b = new BirthProbabilities();
                    b.Age = int.Parse(items[0]);
                    b.NbrOfChildren = int.Parse(items[1]);
                    b.P = double.Parse(items[2]);

                    result.Add(b);
                }
            }
            return result;

        }
        public List<DeathProbabilities> GetDeathProbabilities(string csvpath)
        {
            List<DeathProbabilities> result = new List<DeathProbabilities>();
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] items = line.Split(';');
                    DeathProbabilities d = new DeathProbabilities();
                    d.Gender = (Gender)Enum.Parse(typeof(Gender), items[0]);
                    d.Age = int.Parse(items[1]);
                    d.P = double.Parse(items[2]);

                    result.Add(d);
                }
            }
            return result;

        }
    }
}
