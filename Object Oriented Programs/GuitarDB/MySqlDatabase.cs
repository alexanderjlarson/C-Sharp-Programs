using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Database245
{
    /* this class serves as our glue to a backend MySql database.
     * It manages all our communication with it. */
    class MySqlDatabase
    {
        public string Server;   // server to connect to
        public string Database;  // database to connect to
        public string UID;  // user name
        public string Password;  //password
        public MySqlConnection Connection; // our conduit to the db over which data flows
        public bool ConnectionOpen; // is the connection live?
        public MySqlDatabase()
        {
            Server = Database = UID = Password = "";
            ConnectionOpen = false;
            Connection = null;
        }
        public MySqlDatabase(string server, string db, string userID, string pass) {
            Server = server;
            Database = db;
            UID = userID;
            Password = pass;
            ConnectionOpen = false;
            string conn = "SERVER=" + Server + ";DATABASE=" + Database +
                ";UID=" + UID + ";PASSWORD=" + Password + ";";
            Connection = new MySqlConnection(conn);
        }
        public bool OpenConnection(ref string errmsg)
        {
            errmsg = "";
            bool result;
            try
            {
                Connection.Open();
                result = true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        errmsg = "Could not connect.";
                        result = false;
                        break;
                    case 1045:
                        errmsg = "Username and/or password is invalid.";
                        result = false;
                        break;
                    default:
                        errmsg = GetErrorMessage(ex);
                        result = false;
                        break;
                }
            }
            ConnectionOpen = result;
            return result;
        }
        public bool CloseConnection(ref string errmsg)
        {
            bool result;
            errmsg = "";
            try
            {
                Connection.Close();
                result = true;
            }
            catch (MySqlException ex)
            {
                errmsg = GetErrorMessage(ex);
                result = false;
            }
            ConnectionOpen = false; /* even if we failed to close the connection,
                                     * the connection probably shouldn't be used
                                     * anymore, because an error occurred. */
            return result;
        }
        public string GetErrorMessage(MySqlException ex) {
            return "Error No. " + ex.Number + "; Description = " + ex.Message;
        }
        /* precondition: Connection must be open before calling this function!!!! */
        public bool Execute(string query, ref string errmsg)
        {
            MySqlCommand cmd;
            bool result;
            errmsg = "";
            try
            {
                cmd = new MySqlCommand(query, Connection);
                cmd.ExecuteNonQuery();  // query that doesn't return results
                result = true;
            }
            catch (MySqlException ex)
            {
                errmsg = GetErrorMessage(ex);
                result = false;
            }
            return result;
        }
        public MySqlDataReader Select(string query, ref string errmsg)
        {
            MySqlDataReader results;
            MySqlCommand cmd;
            try
            {
                cmd = new MySqlCommand(query, Connection);
                results = cmd.ExecuteReader();
                return results;
            }
            catch (MySqlException ex)
            {
                errmsg = ex.Message;
                return null;
            }
        }
    }
}
