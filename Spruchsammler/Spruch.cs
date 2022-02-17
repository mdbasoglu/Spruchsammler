using System;
using System.Collections.Generic;
using System.IO;


namespace Spruchsammler
{
    class SpruchListeDatei
    {
        private string _dateiname;
        public SpruchListeDatei(string dateiname)
        {
            _dateiname = dateiname;
        }
        public List<Spruch> Laden()
        {
            List<Spruch> sprüche = new List<Spruch>();
            if (File.Exists(_dateiname))
            {
                string[] zeilen = File.ReadAllLines(_dateiname);
                foreach (string zeile in zeilen)
                {
                    string[] teile = zeile.Split(':');
                    sprüche.Add(new Spruch(teile[0], teile[1]));
                }
            }
            return sprüche;
        }
        public void Speichern(List<Spruch> sprüche)
        {
            List<string> zeilen = new List<string>();
            foreach (Spruch spruch in sprüche)
            {
                zeilen.Add($"{spruch.Text}:{spruch.Autor}");
            }
            File.WriteAllLines(_dateiname, zeilen);
        }
    }
}
