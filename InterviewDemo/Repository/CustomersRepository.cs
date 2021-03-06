﻿using InterviewDemo.Models;
using InterviewDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using InterviewDemo.Help;
namespace InterviewDemo.Repository
{
    public class CustomersRepository
    {
        public IEnumerable<CustomerModel> GetAll()
        {
            string sql = string.Empty;
            sql = @"
                        SELECT id
                          ,firstname
                          ,lastname
                          ,age
                          ,birthday
                          ,email
                          ,createdate
                          ,updatedate
                        FROM Customers  ";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString.DemoDB))
                {
                    return conn.Query<CustomerModel>(sql);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerModel GetOneById(int Id)
        {
            string sql = string.Empty;

            sql = @"
                        SELECT id
                          ,firstname
                          ,lastname
                          ,age
                          ,birthday
                          ,email
                          ,createdate
                          ,updatedate
                        FROM Customers
                        WHERE id = @id ";

            DynamicParameters param = new DynamicParameters();
            param.Add("id", Id);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString.DemoDB))
                {
                    return conn.Query<CustomerModel>(sql, param).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Insert(InsertCustomerViewModel data)
        {
            bool result = true;
            string sql = string.Empty;

            sql = @"INSERT INTO Customers
                   (firstname
                   ,lastname
                   ,age
                   ,birthday
                   ,email
                   ,createdate
                   ,updatedate)
                    VALUES
                    (@firstname, @lastname, @age, @birthday, @email, GETDATE(), null)";

            DynamicParameters param = new DynamicParameters();
            param.Add("firstname", data.firstname);
            param.Add("lastname", data.lastname);
            param.Add("age", data.age);
            param.Add("birthday", data.birthday);
            param.Add("email", data.email);
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString.DemoDB))
                {
                    conn.Execute(sql, param);
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public bool Update(UpdateCustomerViewModel data)
        {
            bool result = true;
            string sql = string.Empty;

            sql = @"UPDATE Customers
                   SET 
                    firstname = @firstname,
                    lastname = @lastname,
                    age = @age,
                    birthday = @birthday,
                    email = @email,
                    updatedate = GETDATE() 
                    WHERE id = @id ";

            DynamicParameters param = new DynamicParameters();
            param.Add("firstname", data.firstname);
            param.Add("lastname", data.lastname);
            param.Add("age", data.age);
            param.Add("birthday", data.birthday);
            param.Add("email", data.email);
            param.Add("id", data.id);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString.DemoDB))
                {
                    conn.Execute(sql, param);
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public bool Delete(int Id)
        {
            bool result = true;
            string sql = string.Empty;

            sql = @" DELETE FROM Customers WHERE id = @Id";

            DynamicParameters param = new DynamicParameters();
            param.Add("id", Id);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString.DemoDB))
                {
                    conn.Execute(sql, param);
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}