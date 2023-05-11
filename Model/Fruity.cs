namespace FruityAPI.Model
{
   
    public class FruityBody
    {

        public string fruitFamily { get; set; } = "Rosaceae";
    }
    public class FruityResponse
    {
        public string name { get; set; }
        public int id { get; set; }
        public string family { get; set; }
        public string order { get; set; }
        public string genus { get; set; }
        public Nutritions nutritions { get; set; }
    }
    public class Nutritions
    {
        public int calories { get; set; }
        public double fat { get; set; }
        public double sugar { get; set; }
        public double carbohydrates { get; set; }
        public double protein { get; set; }
    }

    
}
