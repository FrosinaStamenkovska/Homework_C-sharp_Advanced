
namespace Models
{
    public class DataBase<T> where T : Shape
    {
        public List<T> _data { get; set; }

        public DataBase() 
        {
            _data = new List<T>();
        }

        public void Add(T item)
        {
            _data.Add(item);
        }

        public void PrintArea()
        {
            foreach(T item in _data)
            {
                item.GetArea();
            }
        }
        public void PrintPerimeter()
        {
            foreach (T item in _data)
            {
                item.GetPerimeter();
            }
        }
    }
}
