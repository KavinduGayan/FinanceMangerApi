using FinanceManagerApi.Models;

namespace FinanceManagerApi.Service
{

    public class TransactionService
    {
        private static int transId = 0;
        private static List<Transaction> transactionsList = new List<Transaction>();//TODO
        public void SetTransaction(Transaction transaction)
        {
            /*Transaction transaction = new Transaction();
            transaction.amount = amount;
            transaction.description = description;
            transaction.transType = transType;
            transaction.recurring = recurring;
            transaction.insertedDate = DateTime.Now;
            transaction.transactionDate = transDate;*/
            transId = transId + 1;
            transaction.Id = transId;

            transactionsList.Add(transaction);
        }

        public List<Transaction> getTransactionList()
        {
            return transactionsList;
        }

        public void deleteTransactionById(int id)
        {
            if (transactionsList.Count > id)
            {
                try
                {
                    transactionsList.RemoveAt(id);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    //log.Error("Error");
                }
                catch (IndexOutOfRangeException ex)
                {
                   
                }
            }
        }

        internal void UpdateTransaction(Transaction transaction, int transactionId)
        {
            int index = 0;
            foreach (Transaction trans in transactionsList)
            {
                if (trans.Id == transactionId)
                {
                    trans.amount = transaction.amount;
                    trans.transType = transaction.transType;
                    trans.transactionDate = transaction.transactionDate;
                    trans.description = transaction.description;
                    transactionsList.Insert(index, trans);
                }
                index++;
            }
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
