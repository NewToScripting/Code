namespace Inspire.Events.Proxy
{
    public class FieldContract : Field
    {

        public FieldContract()
        {
            GUID = System.Guid.NewGuid().ToString();

        }

        public FieldContract(string name, int start, int length, string fieldType)
        {
            GUID = System.Guid.NewGuid().ToString();
            Name = name;
            Start = start;
            Length = length;
            FieldType = fieldType;
        }

        public FieldContract(string groupname, string start, string length)
        {
            GUID = System.Guid.NewGuid().ToString();

            FieldType = "String";
            Name = groupname;

            int lth = 0;
            int srt = 0;

            int.TryParse(length, out lth);
            int.TryParse(start, out srt);

            Start = srt;
            Length = lth;

        }

        public int? Start { get; set; }
        public int? Length { get; set; }
        public string EventFileFormatGuid { get; set; }
        
        //public enum FieldTypes
        //{
        //    String, Integer, Double, DateTime, Bool, ImagePath
        //}
        //public FieldTypes FieldType { get; set; }
    }

    public class Field
    {
        public string GUID{ get; set; }
        public string Name { get; set; }
        public string FieldType { get; set; }
        public string Value { get; set; }
    }
}
