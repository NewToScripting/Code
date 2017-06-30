using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace EventsModule
{
    public class EventSource
    {
        public EventSource()
        {
            GUID = Guid.NewGuid().ToString();
            Fields = new List<Field>();
        }

        public string Name { get; set; }
        public string GUID { get; set; }
        public bool IsActive { get; set; }
        public string FilePath { get; set; }
        public int UpdateInterval { get; set; }
        public enum SourceTypes
        {
            Fixed, Tab, Comma, Excel, Custom
        }
        public SourceTypes SourceType { get; set; }

        public List<Field> Fields { get; set; }

        public static List<BagOfNuts> GetEventData(string inputFile, string mappingFile)
        {
            //Get the field mapping.
            var fieldContracts = GetFields(mappingFile);
            //Create a List<List<Field>> collection of collections.
            // The main collection contains our records, and the
            // sub collection contains the fields each one of our
            // records contains.
            var records = new List<BagOfNuts>();

            //Open the flat file using a StreamReader.
            using (var reader = new StreamReader(inputFile))
            {
                //Load the first line of the file.
                string line = reader.ReadLine();

                //Loop through the file until there are no lines
                // left.
                while (!String.IsNullOrEmpty(line))
                {
                    //Create out record (field collection)
                    //List<Field> record = new List<Field>();
                    var record = new BagOfNuts();

                    foreach (FieldContract fieldContract in fieldContracts)
                    {
                        switch (fieldContract.Name)
                        {
                            case ("GroupName"):
                                record.GroupName = line.Substring(fieldContract.Start, fieldContract.Length);
                                break;
                            case ("MeetingName"):
                                record.MeetingName = line.Substring(fieldContract.Start, fieldContract.Length);
                                break;
                            case ("MeetingID"):
                                record.MeetingID = line.Substring(fieldContract.Start, fieldContract.Length);
                                break;
                            case ("MeetingPostAs"):
                                record.MeetingPostAs = line.Substring(fieldContract.Start, fieldContract.Length);
                                break;
                            case ("MeetingRoomID"):
                                record.MeetingRoomID = line.Substring(fieldContract.Start, fieldContract.Length);
                                break;
                            case ("MeetingRoomName"):
                                record.MeetingRoomName = line.Substring(fieldContract.Start, fieldContract.Length);
                                break;
                            case ("MeetingType"):
                                record.MeetingType = line.Substring(fieldContract.Start, fieldContract.Length);
                                break;
                            case ("StartTime"):
                                DateTime startTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, Convert.ToInt32(line.Substring(fieldContract.Start, 2)), Convert.ToInt32(line.Substring(fieldContract.Start+2, 2)), 0);

                                record.StartTime = startTime;
                                break;
                            case ("EndTime"):
                                record.EndTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, Convert.ToInt32(line.Substring(fieldContract.Start, 2)), Convert.ToInt32(line.Substring(fieldContract.Start + 2, 2)), 0);
                                break;
                        }
                    }

                    ////Loop through the mapped fields
                    //foreach (FieldContract fieldContract in fieldContracts)
                    //{
                    //    var fileField = new Field();

                    //    //Use the mapped field's start and length
                    //    // properties to determine where in the
                    //    // line to pull our data from.
                    //    fileField.Value = 
                    //        line.Substring(fieldContract.Start, fieldContract.Length); // TODO: Check line length to make sure that the field.Length that we are trying to read is not out of range

                    //    //Set the name of the field.
                    //    fileField.Name = fieldContract.Name;

                    //    fileField.FieldType = fieldContract.FieldType;

                    //    //Add the field to our record.
                    //    record.Add(fileField);
                    //}

                    //Add the record to our record collection
                    records.Add(record);

                    //Read the next line.
                    line = reader.ReadLine();
                }
            }

            //Return all of our records.
            return records;
        }

        public static List<FieldContract> GetFields(string mappingFile)
        {
            var fieldContracts = new List<FieldContract>();
            var map = new XmlDocument();

            //Load the mapping file into the XmlDocument
            map.Load(mappingFile);

            //Load the field nodes.
            var fieldNodes = map.SelectNodes("/FileMap/Field");

            //Loop through the nodes and create a field object
            // for each one.
            if (fieldNodes != null)
                foreach (XmlNode fieldNode in fieldNodes)
                {
                    var fieldContract = new FieldContract();
                
                    //Set the field's name
                    fieldContract.Name = fieldNode.Attributes["Name"].Value;
                
                    //Set the field's length
                    fieldContract.Length = 
                        Convert.ToInt32(fieldNode.Attributes["Length"].Value);

                    //Set the field's starting position
                    fieldContract.Start =
                        Convert.ToInt32(fieldNode.Attributes["Start"].Value);

                    fieldContract.FieldType = fieldNode.Attributes["Type"].Value;

                    //Add the field to the Field list.
                    fieldContracts.Add(fieldContract);
                }

            return fieldContracts;
        }
    }


    public class FieldContract : Field
    {

        public FieldContract()
        {
            
        }

        public FieldContract(string name, int start, int length, string fieldType)
        {
            Name = name;
            Start = start;
            Length = length;
            FieldType = fieldType;
        }

        public int Start { get; set; }
        public int Length { get; set; }
        //public enum FieldTypes
        //{
        //    String, Integer, Double, DateTime, Bool, ImagePath
        //}
        //public FieldTypes FieldType { get; set; }
    }

    public class Field
    {
        public string Name { get; set; }
        public string FieldType { get; set; }
        public string Value { get; set; }
    }

}
