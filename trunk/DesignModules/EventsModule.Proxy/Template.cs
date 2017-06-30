using System;

namespace Inspire.Events.Proxy
{
    public class FeedTemplate
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public int? Rows { get; set; }
        public Byte[] File { get; set; }
        public Byte[] Thumb_Nail { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public FieldsEnum Fields { get; set; }

        [Flags]
        public enum FieldsEnum
        {
            None = 0,
            NameField1 = 1,
            NameField2 = 2,
            NameField3 = 4,
            NameField4 = 8,
            DescField1 = 16,
            DescField2 = 32,
            DescField3 = 64,
            DescField4 = 128,
            IntField1 = 256,
            IntField2 = 512,
            DecimalField1 = 1024,
            DecimalField2 = 2048,
            DateField1 = 4096,
            DateField2 = 8192,
            DateField3 = 16384,
            DateField4 = 32768,

            All = NameField1 | NameField2 | NameField3 | NameField4 | DescField1 | DescField2 | DescField3 | DescField4 | IntField1 | IntField2 | DecimalField1 | DecimalField2 | DateField1 | DateField2 | DateField3 | DateField4
        }

        static public FieldsEnum StringToEnum(string type)
        {
            switch (type)
            {
                case "NameField1":
                    return FieldsEnum.NameField1;
                case "NameField2":
                    return FieldsEnum.NameField2;
                case "NameField3":
                    return FieldsEnum.NameField3;
                case "NameField4":
                    return FieldsEnum.NameField4;
                case "DescField1":
                    return FieldsEnum.DescField1;
                case "DescField2":
                    return FieldsEnum.DescField2;
                case "DescField3":
                    return FieldsEnum.DescField3;
                case "DescField4":
                    return FieldsEnum.DescField4;
                case "DateField1":
                    return FieldsEnum.DateField1;
                case "DateField2":
                    return FieldsEnum.DateField2;
                case "DateField3":
                    return FieldsEnum.DateField3;
                case "DateField4":
                    return FieldsEnum.DateField4;
                case "IntField1":
                    return FieldsEnum.IntField1;
                case "IntField2":
                    return FieldsEnum.IntField2;
                case "DecimalField1":
                    return FieldsEnum.DecimalField1;
                case "DecimalField2":
                    return FieldsEnum.DecimalField2;
                case "Weekly":
                    return FieldsEnum.All;
               default:
                    return FieldsEnum.None;
            }
        }




    }

 
}
