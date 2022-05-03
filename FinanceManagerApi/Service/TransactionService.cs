using FinanceManagerApi.Models;
using FinanceManagerApi.repository;
using System.Data.SqlClient;

namespace FinanceManagerApi.Service
{

    public class TransactionService
    {
         public void SetTransaction(Transaction transaction)
        {
            Thread thread = new Thread(() => AddTrans(transaction));
            thread.Start();
            
        }
        private void AddTrans(Transaction transaction)
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            transactionRepository.InsertTransaction(transaction);
        }


        public List<Transaction> GetTransactionList()
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            return transactionRepository.GetAllTransactions();
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
                TransactionRepository transactionRepository = new TransactionRepository();
                transactionRepository.DeleteTransaction(id);
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
            TransactionRepository transactionRepository = new TransactionRepository();
            transactionRepository.UpdateTransaction(transaction);
        }

        internal Transaction FindByTransactionId(int transactionId)
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            List<Transaction> transactionsList = transactionRepository.GetAllTransactions();
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
