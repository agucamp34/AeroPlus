namespace Dominio
{
    public class Aeropuerto : IValidable
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

        public void Validar()
        {
            ValidarCodigoIATA(CodigoIATA);

            if (string.IsNullOrEmpty(Ciudad))
            {
                throw new Exception("La ciudad no puede estar vacía");
            }
            if (CostoOperacion <= 0)
            {
                throw new Exception("El costo de operación debe ser mayor a cero");
            }
            if (Tasa <= 0)
            {
                throw new Exception("La tasa debe ser mayor a cero");
            }
        }
        public override string ToString()
        {
            return $"Aeropuerto: {CodigoIATA}, Ciudad: {Ciudad}, Costo de Operación: {CostoOperacion}, Tasa: {Tasa}";
        }

        private void ValidarCodigoIATA(string codigoIATA)
        {
            if (string.IsNullOrEmpty(codigoIATA))
            {
                throw new Exception("El código IATA no puede estar vacío");
            }
            if (codigoIATA.Length != 3)
            {
                throw new Exception("El código IATA debe tener exactamente 3 caracteres");
            }
            if (!codigoIATA.All(char.IsLetter))
            {
                throw new Exception("El código IATA debe contener solo letras");
            }
        }
    }
}
