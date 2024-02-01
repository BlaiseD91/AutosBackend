namespace AutosBackend.Models
{
    public class Adatbazis<Tipus> //<> generikus megfogalmazás, a típus helyére bármilyen változótípus bekerüölhet
    {
        Tipus[] adatok = new Tipus[10];
        int mutato = -1;
        public Tipus[] AddIde()
        {
            return adatok;
        }

        public void TeddBele(Tipus jarmu)
        {
            if (mutato < adatok.Length - 1)
            {
                adatok[mutato] = jarmu;
                mutato++;
            }
        }
    }
}
