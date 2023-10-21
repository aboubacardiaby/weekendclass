using System.Data;

namespace NBL.BPA.DataLoader
{
    public class CsvDataManagementUtilities
    {
        public static DataSet GetDatasetFromCSVFile(string csv_file_path)
        {
            DataSet ds = new DataSet();
            DataTable csvData = new DataTable();

            try
            {

                using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    csvData.Columns.Add("path");
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        var fieldDatalist = fieldData.ToList();
                        fieldDatalist.Add(csv_file_path);
                        fieldData = fieldDatalist.ToArray();
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        if (!string.IsNullOrEmpty(fieldData[0]))
                        {
                            csvData.Rows.Add(fieldData);
                        }


                    }
                }
            }
            catch (Exception loadException)
            {
                throw loadException;
            }
            ds.Tables.Add(csvData);
            return ds;
        }
    }
}