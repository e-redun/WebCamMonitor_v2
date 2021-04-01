using System.Data;
using System.IO;

namespace MyLib
{
    public class XmlParser
    {
        internal string FilePath { get; set; }

        internal string TableName { get; set; }
        public DataTable GetDataTable(string FilePath, string TableName)
        {
            DataSet myDataSet = new DataSet();
            
            if (File.Exists(FilePath))
            {

                myDataSet.ReadXml(FilePath);

                DataSetParser dataSetParser = new DataSetParser();

                dataSetParser.DataSet = myDataSet;
  
                if (myDataSet.Tables[TableName] != null)
                {
                    return myDataSet.Tables[TableName];
                }
            }
            return null;
        }
    }
}