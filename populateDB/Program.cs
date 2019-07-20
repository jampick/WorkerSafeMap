using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using populateDB.model;
using System.IO;
using ExcelDataReader;
using System.Data;
using System.Diagnostics;

namespace populateDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading data\n");
            Console.WriteLine();

            string tableName = "incidents";

            // Create or reference an existing table
            CloudTable table = Common.CreateTable(tableName);

            try
            {
                //read rows from workbook
                DataTable dt = readExcel();
                foreach (DataRow dr in dt.Rows)
                {
                    //Console.WriteLine("COL0: " + dr["Column0"].ToString());
                    InsertData(table, dr);
                }

            }
            finally
            {
                // Delete the table
                // await table.DeleteIfExistsAsync();
            }
            //Console.Read();
        }

        private static DataTable readExcel()
        {
            
            string filePath = "C:\\Users\\jampi\\source\\repos\\WorkSafeMap\\data\\worker_safety_incidents.xlsx";
            Console.WriteLine("Reading Excel: " + filePath );
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);
                            //Console.WriteLine(reader[5].ToString());
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    var result = reader.AsDataSet();

                    // The result of each spreadsheet is in result.Tables
                    DataTable dt = result.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        //Console.WriteLine(dr["Column0"].ToString());
                    }
                    return result.Tables[0];
                }
            }
            
        }

        private static void InsertData(CloudTable table, DataRow dr)
        {
            // Create an instance of a customer entity. See the Model\CustomerEntity.cs for a description of the entity.
            try
            {
                IncidentEntity customer = new IncidentEntity("injury", dr["Column0"].ToString())
                {
                    ID = dr["Column0"].ToString(),
                    UPA = dr["Column1"].ToString(),
                    EventDate = Convert.ToDateTime(dr["Column2"].ToString()),
                    //EventDate = Convert.ToDateTime("4/1/2000"),
                    Employer = dr["Column3"].ToString(),
                    Address1 = dr["Column4"].ToString(),
                    Address2 = dr["Column5"].ToString(),
                    City = dr["Column6"].ToString(),
                    State = dr["Column7"].ToString(),
                    Zip = dr["Column8"].ToString(),
                    Latitude = dr["Column9"].ToString(),
                    Longitude = dr["Column10"].ToString(),
                    PrimaryNAICS = dr["Column11"].ToString(),
                    Hospitalized = dr["Column12"].ToString(),
                    Amputation = dr["Column13"].ToString(),
                    Inspection = dr["Column14"].ToString(),
                    FinalNarrative = dr["Column15"].ToString(),
                    Nature = dr["Column16"].ToString(),
                    NatureTitle = dr["Column17"].ToString(),
                    PartofBody = dr["Column18"].ToString(),
                    PartofBodyTitle = dr["Column19"].ToString(),
                    Event = dr["Column20"].ToString(),
                    EventTitle = dr["Column21"].ToString(),
                    Source = dr["Column22"].ToString(),
                    SourceTitle = dr["Column23"].ToString(),
                    SecondarySource = dr["Column24"].ToString(),
                    SecondarySourceTitle = dr["Column25"].ToString()
                };

                // insert the entity
                Console.Write(".");
                customer = Utils.InsertOrMergeEntity(table, customer);

            }
            catch (Exception e)
            {
                Debug.WriteLine("ERROR: ROW: " + dr["Column0"].ToString());
                Debug.WriteLine("ERROR: " + e.Message);
            }


            /*            
            // Demonstrate how to Update the entity by changing the phone number
            Console.WriteLine("Update an existing Entity using the InsertOrMerge Upsert Operation.");
            customer.PhoneNumber = "425-555-0105";
            await SamplesUtils.InsertOrMergeEntityAsync(table, customer);
            Console.WriteLine();

            // Demonstrate how to Read the updated entity using a point query 
            Console.WriteLine("Reading the updated Entity.");
            customer = await SamplesUtils.RetrieveEntityUsingPointQueryAsync(table, "Harp", "Walter");
            Console.WriteLine();

            // Demonstrate how to Delete an entity
            //Console.WriteLine("Delete the entity. ");
            //await SamplesUtils.DeleteEntityAsync(table, customer);
            //Console.WriteLine();
            */
        }
    }
}
