using System;
using System.Collections;

namespace DAL
{
    public class DataBridge
    {
		#region data members
        private System.Data.Common.DbConnection mSqlConnection = null;
        private string mLastError = string.Empty;
		private string mConnectionString = string.Empty;

        private string mProvider = string.Empty;
		public const string MSSQLProvider = "MSSQL";
		public const string PGSQLProvider = "PGSQL";
        
        private string mLimitStringMSSQL = string.Empty;
        private string mLimitStringPGSQL = string.Empty;

        static readonly int SqlCommandTimeoutSeconds = 600;
		#endregion data members

		public DataBridge(string connectionString, string provider)
        {
            mConnectionString = connectionString;

            mProvider = provider;
            switch (mProvider)
            {
                case "System.Data.SqlClient":
                    mProvider = MSSQLProvider;
					mLimitStringMSSQL = " TOP 1 ";
                    break;

                case "Npgsql":
                    mProvider = PGSQLProvider;
					mLimitStringPGSQL = " LIMIT 1 ";
                    break;

                default:
                    mProvider = MSSQLProvider;
                    break;
            }
        }

		~DataBridge()
		{
			try 
			{
				Disconnect();
			}
			catch(Exception ex)
			{
			}
		}
        
		public string LimitStringMSSQL
        {
            get { return mLimitStringMSSQL; }
        }

        public string LimitStringPGSQL
        {
            get { return mLimitStringPGSQL; }
        }

        public string LastError
        {
            get
            {
                return mLastError;
            }
        }

        public string Provider
        {
            get
            {
                return mProvider;
            }
        }

        public string ConcatinateSimbol
        {
            get
            {
                string concatSimbol = string.Empty;

                switch (mProvider)
                {
                    case MSSQLProvider:
                        concatSimbol = " + ";
                        break;

                    case PGSQLProvider:
                        concatSimbol = " || ";
                        break;

                    default:
                        concatSimbol = " + ";
                        break;
                }

                return concatSimbol;
            }

        }

        public string BoolString(bool boolValue)
        { 
            string boolString = !mProvider.Equals(PGSQLProvider) ? Convert.ToInt32(boolValue).ToString() : boolValue.ToString();

            return boolString;
        }

        private bool Connect()
        {
			bool result = false;

            mLastError = string.Empty;

			try
			{
				if (mSqlConnection == null)
				{
					switch (mProvider)
					{
						case MSSQLProvider:
							mSqlConnection = new System.Data.SqlClient.SqlConnection(mConnectionString);
							break;

						case PGSQLProvider:
							mSqlConnection = new Npgsql.NpgsqlConnection(mConnectionString);
							break;

						default:
							mSqlConnection = new Npgsql.NpgsqlConnection(mConnectionString);
							break;

					}
				}

				if (mSqlConnection.State != System.Data.ConnectionState.Open)
				{
					mSqlConnection.Open();
				}

				if (mSqlConnection.State == System.Data.ConnectionState.Open)
				{
					result = true;
				}
			}
			catch (Exception e)
			{
				mLastError = "Exception connecting to DB in Connect()." + e.Message;
				Disconnect();

				throw e;
			}
			finally 
			{ }

            return result;
        }

        private void Disconnect()
        {
            if (mSqlConnection.State == System.Data.ConnectionState.Open)
            {
                mSqlConnection.Close();
            }
        }

        /// <summary>
        /// Creates adapter with a select command.
        /// </summary>
        /// <param name="selectCommand"></param>
        /// <returns></returns>
        private System.Data.Common.DbDataAdapter CreateSelectAdapter(System.Data.Common.DbCommand selectCommand)
        {
            System.Data.Common.DbDataAdapter adapter = null;

            switch (mProvider)
            {
                case MSSQLProvider:
                    adapter = new System.Data.SqlClient.SqlDataAdapter();
                    break;

                case PGSQLProvider:
                    adapter = new Npgsql.NpgsqlDataAdapter();
                    break;

                default:
                    adapter = new System.Data.SqlClient.SqlDataAdapter();
                    break;
            }

			if (selectCommand != null)
			{
				adapter.SelectCommand = selectCommand;
				adapter.SelectCommand.CommandTimeout = DataBridge.SqlCommandTimeoutSeconds;
			}

            return adapter;
        }

        public System.Data.DataTable ExecuteQuery(string queryString)
        {
			System.Data.DataTable toReturn = new System.Data.DataTable();
			mLastError = string.Empty;

            Connect();

			try
			{
				System.Data.Common.DbCommand command = mSqlConnection.CreateCommand();
				command.CommandTimeout = DataBridge.SqlCommandTimeoutSeconds;
				command.CommandText = queryString;

				System.Data.Common.DbDataAdapter adapter = this.CreateSelectAdapter(command);
				adapter.Fill(toReturn);
			}
			catch (Exception e)
			{
				toReturn = null;
				mLastError = "Query exception. " + e.Message;
			}
			finally
			{
				Disconnect();
			}
            return toReturn;
        }

        public System.Data.DataTable ExecuteQuery(string queryString, Hashtable parameters)
        {
			System.Data.DataTable toReturn = new System.Data.DataTable();
			mLastError = string.Empty;

            Connect();
            
            try
            {
                System.Data.Common.DbCommand command = mSqlConnection.CreateCommand();
                command.CommandTimeout = DataBridge.SqlCommandTimeoutSeconds;

                command.CommandText = queryString;

                foreach (string parameterName in parameters.Keys)
                {
                    object parameterValue = parameters[parameterName];
                    System.Data.Common.DbParameter aParameter = command.CreateParameter();
                    aParameter.ParameterName = parameterName;
                    aParameter.Value = parameterValue;
                    command.Parameters.Add(aParameter);
                }

                System.Data.Common.DbDataAdapter adapter = this.CreateSelectAdapter(command);
                adapter.Fill(toReturn);
            }
            catch (Exception e)
            {
                toReturn = null;
                mLastError = "Query exception. " + e.Message;
            }
			finally
			{
				Disconnect();
			}

            return toReturn;
        }

        public object ExecuteScalarQuery(string scalarQuery)
        {
			object result = null;
			mLastError = string.Empty;

            Connect();
            
            try
            {
                System.Data.Common.DbCommand command = mSqlConnection.CreateCommand();
                command.CommandTimeout = DataBridge.SqlCommandTimeoutSeconds;
                command.CommandText = scalarQuery;

                result = command.ExecuteScalar();
            }
            catch (Exception e)
            {
                mLastError = "Scalar query exception. " + e.Message;
            }
			finally
			{
				Disconnect();
			}

            return result;
        }

        public object ExecuteScalarQuery(string scalarQuery, Hashtable parameters)
        {
            object result = null;
			mLastError = string.Empty;

            Connect();
            
            try
            {
                System.Data.Common.DbCommand command = mSqlConnection.CreateCommand();
                command.CommandTimeout = DataBridge.SqlCommandTimeoutSeconds;
                command.CommandText = scalarQuery;

                foreach (string parameterName in parameters.Keys)
                {
                    object parameterValue = parameters[parameterName];
                    System.Data.Common.DbParameter aParameter = command.CreateParameter();
                    aParameter.ParameterName = parameterName;
                    aParameter.Value = parameterValue;
                    command.Parameters.Add(aParameter);
                }

                result = command.ExecuteScalar();
            }
            catch (Exception e)
            {
                mLastError = "Scalar query exception. " + e.Message;
            }
			finally
			{
				Disconnect();
			}

            return result;
        }

        public bool ExecuteNonQuery(string nonQuery)
        {
			bool result = false;
			mLastError = string.Empty;

			Connect();
            
            System.Data.Common.DbTransaction transaction = mSqlConnection.BeginTransaction();
            try
            {
                System.Data.Common.DbCommand command = mSqlConnection.CreateCommand();
                command.CommandTimeout = DataBridge.SqlCommandTimeoutSeconds;
                
				command.Transaction = transaction;
                command.CommandText = nonQuery;

                int rowsAffected = command.ExecuteNonQuery();
				rowsAffected = Math.Max(rowsAffected, 0);
                if (rowsAffected > 0)
                {
                    result = true;
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                mLastError = "Non-query exception. " + e.Message;
                transaction.Rollback();
            }
			finally
			{
				Disconnect();
			}

            return result;
        }

        public bool ExecuteNonQuery(string nonQuery, Hashtable parameters)
        {
			bool result = false;
			mLastError = string.Empty;
            
			Connect();

            System.Data.Common.DbTransaction transaction = mSqlConnection.BeginTransaction();
            try
            {
                System.Data.Common.DbCommand command = mSqlConnection.CreateCommand();
                command.CommandTimeout = DataBridge.SqlCommandTimeoutSeconds;
                
				command.Transaction = transaction;
                command.CommandText = nonQuery;

                foreach (string parameterName in parameters.Keys)
                {
                    object parameterValue = parameters[parameterName];
                    System.Data.Common.DbParameter aParameter = command.CreateParameter();
                    aParameter.ParameterName = parameterName;
                    aParameter.Value = parameterValue;
                    command.Parameters.Add(aParameter);
                }

                int rowsAffected = command.ExecuteNonQuery();
				rowsAffected = Math.Max(rowsAffected, 0);
                if (rowsAffected > 0)
                {
                    result = true;
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                mLastError = "Non-query with parameters execution exception. " + e.Message;
                transaction.Rollback();
            }
			finally
			{
				Disconnect();
			}

            return result;
        }

        /// <summary>
        /// Executes a batch of queries. All the queries are executed within one (the same) transaction which is commited 
        /// after last query is executed. If an exception is caught during execution, it is reported in mLast error, 
        /// and the transaction is rolled back. 
        /// </summary>
        /// <param name="insertQueryBatch">
        /// An array of queries. 
        /// </param>
        /// <returns>
        /// Total number of affected rows.
        /// </returns>
        public int ExecuteNonQueryBatch(string[] insertQueryBatch)
        {
			int rowsAffected = 0;
			mLastError = string.Empty;

            Connect();
            
            System.Data.Common.DbTransaction transaction = mSqlConnection.BeginTransaction();
            try
            {
                for (int i = 0; i < insertQueryBatch.Length; i++)
                {
                    string nonQuery = insertQueryBatch[i];

                    if (!string.IsNullOrEmpty(nonQuery))
                    {
						System.Data.Common.DbCommand command = mSqlConnection.CreateCommand();
						command.CommandTimeout = DataBridge.SqlCommandTimeoutSeconds;

						command.Transaction = transaction;
                        command.CommandText = nonQuery;

						int rowsAffectedNow = command.ExecuteNonQuery();
						rowsAffectedNow = Math.Max(rowsAffectedNow, 0);
						rowsAffected += rowsAffectedNow;
                    }
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                mLastError = "Non-query batch execution exception. " + e.Message;
                transaction.Rollback();
                rowsAffected = 0;
            }
			finally
			{
				Disconnect();
			}

            return rowsAffected;
        }

        /// <summary>
        /// Executes a batch of queries. All the queries are executed within one (the same) transaction which is commited 
        /// after last query is executed. If an exception is caught during execution, it is reported in mLast error, 
        /// and the transaction is rolled back. 
        /// </summary>
        /// <param name="insertQueryBatch">
        /// An array of queries. 
        /// </param>
        /// <param name="parametersArray">
        /// Ann array of parameters. Each index paratemers hashtable correcponds to same index query.
        /// </param>
        /// <returns>
        /// Total number of affected rows.
        /// <returns></returns>
        public int ExecuteNonQueryBatch(string[] insertQueryBatch, Hashtable[] parametersArray)
        {
			int rowsAffected = 0;
			mLastError = string.Empty;

            Connect();

            System.Data.Common.DbTransaction transaction = mSqlConnection.BeginTransaction();
            try
            {
                for (int i = 0; i < insertQueryBatch.Length; i++)
                {
                    string nonQuery = insertQueryBatch[i];

                    if (!string.IsNullOrEmpty(nonQuery))
                    {
						System.Data.Common.DbCommand command = mSqlConnection.CreateCommand();
						command.CommandTimeout = DataBridge.SqlCommandTimeoutSeconds;

						command.Transaction = transaction;
                        command.CommandText = nonQuery;

                        if (parametersArray != null && parametersArray.Length > i)
                        {
                            Hashtable parameters = parametersArray[i];
                            if (parameters != null)
                            {
                                foreach (string parameterName in parameters.Keys)
                                {
                                    object parameterValue = parameters[parameterName];
                                    System.Data.Common.DbParameter aParameter = command.CreateParameter();
                                    aParameter.ParameterName = parameterName;
                                    aParameter.Value = parameterValue;
                                    command.Parameters.Add(aParameter);
                                }
                            }
                        }

						int rowsAffectedNow = command.ExecuteNonQuery();
						rowsAffectedNow = Math.Max(rowsAffectedNow, 0);
						rowsAffected += rowsAffectedNow;
                    }
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                mLastError = "Non-query batch with parameters execution exception. " + e.Message;
                transaction.Rollback();
                rowsAffected = 0;
            }
			finally
			{
				Disconnect();
			}

            return rowsAffected;
        }
    }
}
