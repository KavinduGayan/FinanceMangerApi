using FinanceManagerApi.Models;

namespace FinanceManagerApi.Service
{

    public class TransactionService
    {
        private static int transId = 0;
        private static List<Transaction> transactionsList = new List<Transaction>();//TODO
        public void SetTransaction(Transaction transaction)
        {
            transId = transId + 1;
            transaction.Id = transId;

            transactionsList.Add(transaction);
        }

        public List<Transaction> GetTransactionList()
        {
            return transactionsList;
        }

        public void DeleteTransactionById(int id)
        {

            try
            {
                transactionsList.Remove(FindByTransactionId(id));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }

        internal void UpdateTransaction(Transaction transaction, int transactionId)
        {
            DeleteTransactionById(transactionId);
            transactionsList.Add(transaction);
        }

        internal Transaction FindByTransactionId(int transactionId)
        {
            foreach (Transaction transaction in transactionsList)
            {
                if (transaction.Id == transactionId)
                {
                    return transaction;
                }
            }
            return null;
        }
    }
}
