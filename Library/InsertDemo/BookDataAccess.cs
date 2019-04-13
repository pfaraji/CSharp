using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace InsertDemo
{
    class BookDataAccess
    {
        private readonly string connectionString;
        private SqlConnection connection;
        public BookDataAccess(string _connectionString)
        {
            connectionString = _connectionString;
        }
        public void Insert(Book book)
        {
            using (this.connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO Book VALUES(@Title,@Author,@CreatedDate,@ModifiedDate)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 50));
                    command.Parameters.Add(new SqlParameter("@Author", SqlDbType.NVarChar, 50));
                    command.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime));
                    command.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime));
                    command.Parameters["@Title"].Value = book.Title;
                    command.Parameters["@Author"].Value = book.Author;
                    command.Parameters["@CreatedDate"].Value = book.CreatedDate;
                    command.Parameters["@ModifiedDate"].Value = book.ModifiedDate;

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        // Start Function: GetAll
        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            using (this.connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Book", this.connection))
                {
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Book book = new Book()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Title = reader[1].ToString(),
                            Author = reader["Author"].ToString(),
                            CreatedDate = (DateTime)reader["CreatedDate"],
                           // ModifiedDate = (DateTime)reader["ModifiedDate"]
                        };
                        books.Add(book);
                    } 
                    command.Connection.Close();
                }
            }
            return books;
        }

        // Start Function: Delete a Book
        public void delete(int i)
        {
            using (this.connection = new SqlConnection(connectionString))
            {
                string sqlstr;
                               
                    sqlstr = "DELETE FROM Book WHERE Id=" + i + ";";

                 //   Console.WriteLine("\n Invalid ID number.");


                using (SqlCommand command = new SqlCommand(sqlstr, connection))
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                }

            }
        }
        // End Delete
        // Start Function: Get a Book
        public Book GetABook(int index)
        {
            Book TheBook = new Book();
            using (this.connection = new SqlConnection(connectionString))
            {
                string sqlstr;
                sqlstr = "Select * FROM Book WHERE Id=" + index + ";";

                using (SqlCommand command = new SqlCommand(sqlstr, this.connection))
                {
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        TheBook.Id = int.Parse(reader["Id"].ToString());
                        TheBook.Title = reader[1].ToString();
                        TheBook.Author = reader["Author"].ToString();
                        TheBook.CreatedDate = (DateTime)reader["CreatedDate"];
                        //TheBook.ModifiedDate = (DateTime)reader["ModifiedDate"];
                    }
                    else
                        return null;
                    command.Connection.Close();
                }

            }

            return TheBook;
        }

        // End Get a Book
        
            //  Start Function: Edit a Book
        public void edit (Book TheBook)
        {
            using (this.connection = new SqlConnection(connectionString))
            {
                string sqlstr;
                
                sqlstr = "Update book set Title='" + TheBook.Title + "' , Author = '"+ TheBook.Author +"' where Id=" +TheBook.Id;

                using (SqlCommand command = new SqlCommand(sqlstr, connection))
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();   
                    command.Connection.Close();
                }

            }
        }

    }
}


