using System.Runtime.InteropServices.Marshalling;
using System.Security.AccessControl;

namespace BankApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice,money,id,password;
            string name_surname;
            Bank bank = new Bank();

            Console.WriteLine("Welcome to Bank Application");
            Console.Write("Please enter id : ");
            bank.id = int.Parse(Console.ReadLine());

            Console.Write("Please enter name and surname : ");
            bank.name_surname = Console.ReadLine();

            Console.Write("Please enter password : ");
            bank.password = int.Parse(Console.ReadLine());

            bank.createAccount(bank.id, bank.name_surname, bank.password);
            Console.WriteLine("Account created successfully.");


            do
            {
                Console.WriteLine("Please log in.");

                Console.Write("Please enter id : ");
                id = int.Parse(Console.ReadLine());

                Console.Write("Please enter name and surname : ");
                name_surname = Console.ReadLine();

                Console.Write("Please enter password : ");
                password = int.Parse(Console.ReadLine());
            }
            while (!bank.logIn(id, password, name_surname));

            Account a1 = new Account();

            while (true)
            {
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Deposit");
                Console.WriteLine("2 - Withdraw");
                Console.Write("Your choice : ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 0)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Exiting the application.");
                        break;

                    case 1:
                        a1.showMoney();
                        Console.Write("Please enter want to deposit money : ");
                        money = int.Parse(Console.ReadLine());
                        a1.deposit(money);
                        a1.showMoney();
                        break;

                    case 2:
                        a1.showMoney();
                        Console.Write("Please enter want to withdraw money : ");
                        money = int.Parse(Console.ReadLine());
                        a1.withdraw(money);
                        a1.showMoney();
                        break;

                    default:
                        Console.WriteLine("Wrong choice.");
                        break;

                }
            }


        }
    }
}

public class Bank
{
    public int id, password;
    public string name_surname;

    public void createAccount(int id, string name_surname, int password)
    {
        this.id = id;
        this.name_surname = name_surname;
        this.password = password;
    }


    public bool logIn(int id,int password,string name_surname)
    {
        if(id == this.id && password == this.password && name_surname == this.name_surname)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
   
}



public class Customer
{
    public int id,password;
    public string name_surname;
}




public class Account
{
    int balance = 100;

    public void deposit(int amount)
    {
        balance = balance + amount;
    }

    public void withdraw(int amount)
    {
        if (amount <= balance)
        {
            balance = balance - amount;
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }


    public void showMoney()
    {
        Console.WriteLine("Current balance: " + balance);
    }
}


