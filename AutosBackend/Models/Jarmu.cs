namespace AutosBackend
{
    public class Jarmu
    {
        //egy adatt�rol� egy setter �s egy getter met�dussal <=> TULAJDONS�G/PROPERTY
        // <summary>
        // public DateTime Date { get; set; }
        // </summary>
        public int Id { get; set; }

        // <summary>
        // public int TemperatureC { get; set; }
        // </summary>
        public string? Rendszam { get; set; }

        // <summary>
        // public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        // </summary>
        public string? Marka { get; set; }

        //public string? Summary { get; set; }
        public int Ar { get; set; }
    }
}