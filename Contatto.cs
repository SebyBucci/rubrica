using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bucci.sebastian._4i.rubricaUnoAMolti
{
    public enum TipoContatto { nessuno, Email, telefono, Web, Instagram, Facebook }
    public class Contatto
    {
        public int idPersona { get; set; }
        public TipoContatto Tipo { get; set; }
        public string Valore { get; set; }

        public Contatto()
        {
            Tipo = TipoContatto.nessuno;
        }

        public Contatto(string riga)
        {
            string[] campi = riga.Split(',');

            int id = 0;
            int.TryParse(campi[0], out id);
            idPersona = id;

            TipoContatto c;
            Enum.TryParse(campi[1], out c);
            this.Tipo = c;
            this.Valore = campi[2];
        }
        public static Contatto MakeContatto(string riga)
        {
            string[] campi = riga.Split(',');
            TipoContatto c;
            Enum.TryParse(campi[1], out c);

            switch (c)
            {
                case TipoContatto.Email:
                    return new ContattoEmail(riga);
                    break;
            }
            return new Contatto(riga);

        }



        public class ContattoInstagram : Contatto
        {
            public ContattoInstagram() { }

            public ContattoInstagram(string riga)
                : base(riga)
            { }
        }


        public class ContattoWeb : Contatto
        {
            public ContattoWeb() { }

            public ContattoWeb(string riga)
                : base(riga)
            { }
        }


        public class ContattoFacebook : Contatto
        {
            public ContattoFacebook() { }

            public ContattoFacebook(string riga)
                : base(riga)
            { }
        }


        public class Contattotelefono : Contatto
        {
            public Contattotelefono() { }

            public Contattotelefono(string riga)
                : base(riga)
            { }
        }


        public class ContattoEmail : Contatto
        {
            public ContattoEmail() { }

            public ContattoEmail(string riga)
                : base(riga)
            { }
        }


        public class Contatti : List<Contatto>
        {
            public Contatti() { }
            public Contatti(string nomeFile)
            {
                //Leggi persone..
                StreamReader fin = new StreamReader(nomeFile);
                fin.ReadLine();
                while (!fin.EndOfStream)
                    Add(new Contatto(fin.ReadLine()));

                fin.Close();
            }
        }
    }
}
