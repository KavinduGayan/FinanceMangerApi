using FinanceManagerApi.Models;

namespace FinanceManagerApi.Service
{

    public class TransactionService
    {
        private static int transId = 0;
        private static List<Transaction> transactionsList = new List<Transaction>();//TODO
        public void SetTransaction(Transaction transaction)
        {
            Thread thread = new Thread(() => AddTrans(transaction));
            thread.Start();
            
        }
        private void AddTrans(Transaction transaction)
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
            Thread thread = new Thread(() => RemoveTrans(id));
            thread.Start();

        }

        private void RemoveTrans(int id)
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
            Thread thread = Thread.CurrentThread;
            thread.Start();
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
