using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Addressbook_Web_Tests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generation
{
    class Program
    {
        static void Main(string[] args)
        {
            // System.Console.Out.Write("Hello, world!");

            string datatype = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            

            if (datatype == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }

                if (format == "excel")
                {
                    WriteGroupsToEXCELFile(groups, filename);
                }

                else
                {
                    StreamWriter writer = new StreamWriter(filename);


                    if (format == "csv")
                    {
                        WriteGroupsToCSVFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteGroupsToXMLFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        WriteGroupsToJSONFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }

                    writer.Close();
                }
            }
            else if (datatype == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();

                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(15), TestBase.GenerateRandomString(15))
                    {
                        Address = TestBase.GenerateRandomString(30),
                        HomePhone = TestBase.GenerateRandomString(30),
                        Email = TestBase.GenerateRandomString(30)
                    });
                }

                StreamWriter writer = new StreamWriter(filename);

                if (format == "xml")
                {
                    WriteContactsToXMLFile(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteContactsToJSONFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }

                writer.Close();
            }
            else
            {
                System.Console.Out.Write("Only data for groups or contacts can be generated, please check you input and try again.");
            }
        }

        private static void WriteContactsToJSONFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        private static void WriteContactsToXMLFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteGroupsToEXCELFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            //            sheet.Cells[1, 1] = "test";

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;

            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            wb.Close();
            app.Visible = false;
//            app.Quit();

        }

        static void WriteGroupsToCSVFile (List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));

            }

        }
        static void WriteGroupsToXMLFile (List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);

        }
        static void WriteGroupsToJSONFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups,Newtonsoft.Json.Formatting.Indented));
        }

    }
}
