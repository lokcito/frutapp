using System;
namespace frutappi.Models
{
    public class Toke
    {
        public string text { get; set; }
        public string info { get; set; }
        public Toke(string _text)
        {
            this.text = _text;
            this.info = "...";
        }
    }
}
