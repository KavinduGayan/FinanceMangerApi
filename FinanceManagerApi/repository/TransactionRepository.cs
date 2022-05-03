using FinanceManagerApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace FinanceManagerApi.repository
{
    public class TransactionRepository
    {
        SqlConnection conn = new SqlConnection("Data Source = localhost; Initial Catalog = FinancialManager; Integrated Security = True");


        public void InsertTransaction(Transaction trans)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into transactions(Amount, Description, TransType, Recurring, InsertedDate, TransactionDate) values('"+ trans.amount + "','"+ trans.description + "','"+ trans.transType + "','"+ trans.recurring + "','"+ trans.insertedDate + "','"+ trans.transactionDate + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateTransaction(Transaction trans)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update transactions set Amount='" + trans.amount + "', Description='" + trans.description + "',TransType='" + trans + "',Recurring='" + trans.recurring + "',InsertedDate='" + trans.insertedDate + "',TransactionDate='" + trans.transactionDate + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteTransaction(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from transactions where TransId='"+id+"'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Transaction> GetAllTransactions()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from transactions", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<Transaction> transList = new List<Transaction>();
            Transaction trans = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                trans = new Transaction();
                trans.Id = (int)dt.Rows[i]["TransId"];
                trans.amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
                trans.description = (string)dt.Rows[i]["Description"];
                trans.transType = (string)dt.Rows[i]["TransType"];
                trans.recurring = Convert.ToBoolean(dt.Rows[i]["Recurring"]);
                trans.insertedDate = Convert.ToDateTime(dt.Rows[i]["InsertedDate"]);
                trans.transactionDate = Convert.ToDateTime(dt.Rows[i]["TransactionDate"]);
                transList.Add(trans);
            }
                conn.Close();
            return transList;
        }
    }
}
