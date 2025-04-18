namespace Dominio
{
    public class Aeropuerto 
    {
        public string CodigoIATA {  get; set; }
        public string Ciudad {  get; set; }
        public double CostoOperacion { get; set; }
        public double Tasa {  get; set; }

        public Aeropuerto(string codigoIATA,string ciudad,double costoOperacion ,double tasa) 
        {
            CodigoIATA = codigoIATA;
            Ciudad = ciudad;
            CostoOperacion = costoOperacion;
            Tasa = tasa;    

        }

        public override string ToString()
        {
            return $"Aeropuerto: {CodigoIATA}, Ciudad: {Ciudad}, Costo de Operación: {CostoOperacion}, Tasa: {Tasa}";
        }
    }
}
