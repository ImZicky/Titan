namespace Titan.Models
{
    public class Cor: BaseModel
    {
        public Cor()
        {
        }

        public Cor(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }


    }
}