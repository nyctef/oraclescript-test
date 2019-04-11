using System;
using Devart.Data.Oracle;

namespace oraclescript_test
{
    class Program
    {
        static void Main(string[] args)
        {
            // open a dummy connection to satisfy licensing requirements
            var oracleConnection = Environment.GetEnvironmentVariable("ORACLE_CONNECTION");
            var devartLicenseKey = Environment.GetEnvironmentVariable("DEVART_LICENSE_KEY");
            var connection = new OracleConnection($"{oracleConnection};License Key={devartLicenseKey}");
            connection.Open();

            var sql = @"
-- <Migration ID=""994ad00c-e81b-4e3b-aeaa-dfbb46e3704f"" />
;
CREATE TABLE talkr_cust.newtablethatnoonehasseenbefore (
  new_col CHAR(2 BYTE) NOT NULL,
  CONSTRAINT countries_pk PRIMARY KEY (new_col)
);
            ";

            var script = new OracleScript(sql);

            foreach (OracleSqlStatement statement in script.Statements)
            {
                Console.WriteLine("--------------");
                Console.WriteLine(statement.Text);
            }
        }
    }
}
