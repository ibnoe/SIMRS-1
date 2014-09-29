using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SIMRS.DataAccess
{
	/// <summary>
	/// Purpose: Data Access class for the table 'RS_SatuanKerja'.
	/// </summary>
	public class RS_SatuanKerja : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlInt32		_idSatuanKerja;
			private SqlString		_kode, _namaSatker, _keterangan;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public RS_SatuanKerja()
		{
			// Nothing for now.
		}

        public bool IsExist()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[RS_SatuanKerja_IsExist]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@IdSatuanKerja", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _idSatuanKerja));
                cmdToExecute.Parameters.Add(new SqlParameter("@Kode", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _kode));
                cmdToExecute.Parameters.Add(new SqlParameter("@NamaSatker", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _namaSatker));
                cmdToExecute.Parameters.Add(new SqlParameter("@Keterangan", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _keterangan));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsExist", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                int IsExist = int.Parse(cmdToExecute.Parameters["@IsExist"].Value.ToString());
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'RS_SatuanKerja_IsExist' reported the ErrorCode: " + _errorCode);
                }

                return IsExist == 1;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("RS_SatuanKerja::IsExist::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
            }
        }
        
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_SatuanKerja_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@IdSatuanKerja", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _idSatuanKerja));
				cmdToExecute.Parameters.Add(new SqlParameter("@Kode", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _kode));
				cmdToExecute.Parameters.Add(new SqlParameter("@NamaSatker", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _namaSatker));
				cmdToExecute.Parameters.Add(new SqlParameter("@Keterangan", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keterangan));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_SatuanKerja_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_SatuanKerja::Insert::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}
        
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_SatuanKerja_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@IdSatuanKerja", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _idSatuanKerja));
				cmdToExecute.Parameters.Add(new SqlParameter("@Kode", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _kode));
				cmdToExecute.Parameters.Add(new SqlParameter("@NamaSatker", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _namaSatker));
				cmdToExecute.Parameters.Add(new SqlParameter("@Keterangan", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keterangan));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_SatuanKerja_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_SatuanKerja::Update::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}
        
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_SatuanKerja_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@IdSatuanKerja", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _idSatuanKerja));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_SatuanKerja_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_SatuanKerja::Delete::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}

    	public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_SatuanKerja_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RS_SatuanKerja");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@IdSatuanKerja", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _idSatuanKerja));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_SatuanKerja_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_idSatuanKerja = (Int32)toReturn.Rows[0]["IdSatuanKerja"];
					_kode = (string)toReturn.Rows[0]["Kode"];
					_namaSatker = (string)toReturn.Rows[0]["NamaSatker"];
					_keterangan = toReturn.Rows[0]["Keterangan"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Keterangan"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_SatuanKerja::SelectOne::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}
        
		public override DataTable SelectAll()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_SatuanKerja_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RS_SatuanKerja");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_SatuanKerja_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_SatuanKerja::SelectAll::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

        
        public DataTable GetList()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[RS_SatuanKerja_GetList]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("RS_SatuanKerja");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'RS_SatuanKerja_GetList' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("RS_SatuanKerja::GetList::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }


		#region Class Property Declarations
		public SqlInt32 IdSatuanKerja
		{
			get
			{
                return _idSatuanKerja;
			}
			set
			{
				SqlInt32 idTmp = (SqlInt32)value;
				if(idTmp.IsNull)
				{
                    throw new ArgumentOutOfRangeException("IdSatuanKerja", "Id can't be NULL");
				}
                _idSatuanKerja = value;
			}
		}


		public SqlString Kode
		{
			get
			{
				return _kode;
			}
			set
			{
				SqlString kodeTmp = (SqlString)value;
				if(kodeTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Kode", "Kode can't be NULL");
				}
				_kode = value;
			}
		}


		public SqlString NamaSatker
		{
			get
			{
				return _namaSatker;
			}
			set
			{
				SqlString namaSatkerTmp = (SqlString)value;
				if(namaSatkerTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("Nama", "Nama can't be NULL");
				}
				_namaSatker = value;
			}
		}

    	public SqlString Keterangan
		{
			get
			{
				return _keterangan;
			}
			set
			{
				_keterangan = value;
			}
		}

		#endregion
	}
}
