using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka1
{
    class Biblioteka
    {
        public string nazivBiblioteke;
        public string adresaBiblioteke;
        public List<Knjiga> knjige = new List<Knjiga>();
        public List<ClanBibl> clanovi = new List<ClanBibl>();

        public Biblioteka(string naziv, string adresa)
        {
            this.nazivBiblioteke = naziv;
            this.adresaBiblioteke = adresa;
            List<Knjiga> knjige = new List<Knjiga>();
        }

        public void AddBook(Knjiga knkig)
        {
            knjige.Add(knkig);
        }
        public void Ispisi()
        {
            foreach (Knjiga knjig in knjige)
            {

                    Console.WriteLine("Autor knjige je {0} naslov knjige je {1} i knjiga je izdata godine {2} i dostupnost knjige je {3}", knjig.autor, knjig.naslov, knjig.godinaIzdavanja,knjig.dustupnost) ;
              
            }
        }
        public void  Pozajmljivanje(string naslovKnjig)
        {
            foreach(Knjiga knjig in knjige)
            {
               
                if(naslovKnjig==knjig.naslov && knjig.dustupnost == true)
                {
                    Console.WriteLine("Uspesno ste podigli knjigu {0}",knjig.naslov);
                    knjig.dustupnost = false;
                }
                else if (naslovKnjig==knjig.naslov && knjig.dustupnost == false)
                {
                    Console.WriteLine("Knjiga {0} nije dostupna",knjig.naslov);
                }
              
            }
        }
        public void VracanjeKnjige(string naslovKnjige)
        {
            foreach(Knjiga knjig in knjige)
            {
                if (naslovKnjige == knjig.naslov && knjig.dustupnost == false)
                {
                    Console.WriteLine("Uspesno ste vratili knjigu");
                    knjig.dustupnost = true;
                    break;
                }
                else if (naslovKnjige == knjig.naslov && knjig.dustupnost == true)
                {
                    Console.WriteLine("Ova knjiga vec postoji u biblioteci i ne mozete je vratiti posto nije pozajmljena");
                    break;
                }
                else if (naslovKnjige != knjig.naslov)
                {
                    Console.WriteLine("Ova knjiga ne postoji u biblioteci i takvu je ne mozete vratiti");
                    break;
                }
            }
        }
        public void IspisInformacijaIzBiblioteke()
        {
            Console.WriteLine("Biblioteka-{0} adresa biblioteke je-{1}",nazivBiblioteke,adresaBiblioteke);
            foreach(Knjiga knjig in knjige)
            {
                Console.WriteLine("Autor={0} naslov={1} izdanje godine={2} dostupnost knjige={3}", knjig.autor, knjig.naslov, knjig.godinaIzdavanja,knjig.dustupnost);
            }

        }
        public void DodajClana(ClanBibl cln)
        {
            clanovi.Add(cln);
        }
        public void IspisiClanove()
        {
            foreach(ClanBibl cln in clanovi)
            {
                Console.WriteLine("Ime={0}***jmbg={1}",cln.ime,cln.brLicne);
            }
        }
    }
   public class Knjiga
    {
        public string naslov;
        public string autor;
        public int godinaIzdavanja;
        public bool dustupnost;

        public Knjiga(string naslov, string autor, int godina, bool dostupnost)
        {
            this.naslov = naslov;
            this.autor = autor;
            this.godinaIzdavanja = godina;
            this.dustupnost = dostupnost;
        }
    }
    class ClanBibl
    {
       public string ime;
       public int brLicne;
        public ClanBibl(string ime,int brLicne)
        {
            this.ime = ime;
            this.brLicne = brLicne;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Knjiga knjiga1 = new Knjiga("Rrrr", "Ppp", 2015, true);
            Knjiga knjiga2 = new Knjiga("Mmmm", "Ttt", 1999, true);
            Knjiga knjiga3 = new Knjiga("SSSS", "Eee", 2020, true);
            Biblioteka bibl = new Biblioteka("Gradska", "Trg srpskih ");
            Biblioteka bibl2 = new Biblioteka("Centralna", "Mikro");
            bibl.AddBook(knjiga1);
            bibl.AddBook(knjiga2);
            bibl.AddBook(knjiga3);         
            bibl.Pozajmljivanje("Rrrr");
            bibl.Pozajmljivanje("Mmmm");           
            bibl.VracanjeKnjige("Rrrr");
            bibl.IspisInformacijaIzBiblioteke();
            bibl2.AddBook(new Knjiga("Harry", "Nemam pojma", 1992, true));
            bibl2.AddBook(new Knjiga("Gospodar", "Isto pojma", 2000, true));
            bibl2.AddBook(new Knjiga("Mali princ", "Nemam pojma", 1995, true));           
            bibl2.IspisInformacijaIzBiblioteke();
            bibl2.Pozajmljivanje("Harry");
            bibl2.IspisInformacijaIzBiblioteke();
            bibl2.VracanjeKnjige("Kkkk");
            bibl2.DodajClana(new ClanBibl("Joca", 07129958));
            bibl2.DodajClana(new ClanBibl("Goca", 66623123));
            bibl2.DodajClana(new ClanBibl("Gomboca", 123214565));
            bibl2.IspisiClanove();
            Console.ReadLine();
        }
    }
}
