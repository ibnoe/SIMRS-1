using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SIMRS.DataAccess
{
	public class RS_Registrasi : DBInteractionBase
	{
		#region Class Member Declarations
            private SqlInt64        _penjaminId, _penjaminIdOld, _pasienId, _pasienIdOld, _registrasiId;
			private SqlDateTime		_tanggalRegistrasi, _createdDate, _modifiedDate, _tanggalBayar;
            private SqlInt32 _createdBy, _modifiedBy, _jenisRegistrasiId, _jenisRegistrasiIdOld, _jenisPenjaminId, _jenisPenjaminIdOld, _statusBayar;
			private SqlString		_noRegistrasi, _keterangan, _noUrut;
		#endregion

		public RS_Registrasi()
		{
			// Nothing for now.
		}

		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_Registrasi_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@PasienId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _pasienId));
				cmdToExecute.Parameters.Add(new SqlParameter("@NoRegistrasi", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _noRegistrasi));
				cmdToExecute.Parameters.Add(new SqlParameter("@JenisRegistrasiId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _jenisRegistrasiId));
				cmdToExecute.Parameters.Add(new SqlParameter("@TanggalRegistrasi", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalRegistrasi));
                cmdToExecute.Parameters.Add(new SqlParameter("@JenisPenjaminId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _jenisPenjaminId));
                cmdToExecute.Parameters.Add(new SqlParameter("@PenjaminId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, _penjaminId));
                cmdToExecute.Parameters.Add(new SqlParameter("@StatusBayar", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _statusBayar));
				cmdToExecute.Parameters.Add(new SqlParameter("@TanggalBayar", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalBayar));
				cmdToExecute.Parameters.Add(new SqlParameter("@Keterangan", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keterangan));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _createdBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@ModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _modifiedBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _modifiedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@RegistrasiId", SqlDbType.BigInt, 8, ParameterDirection.Output, true, 19, 0, "", DataRowVersion.Proposed, _registrasiId));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                cmdToExecute.Parameters.Add(new SqlParameter("@NoUrut", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _noUrut));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
                _registrasiId = (SqlInt64)cmdToExecute.Parameters["@RegistrasiId"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_Registrasi_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_Registrasi::Insert::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[RS_Registrasi_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RegistrasiId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _registrasiId));
				cmdToExecute.Parameters.Add(new SqlParameter("@PasienId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _pasienId));
				cmdToExecute.Parameters.Add(new SqlParameter("@NoRegistrasi", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _noRegistrasi));
				cmdToExecute.Parameters.Add(new SqlParameter("@JenisRegistrasiId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _jenisRegistrasiId));
				cmdToExecute.Parameters.Add(new SqlParameter("@TanggalRegistrasi", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalRegistrasi));
                cmdToExecute.Parameters.Add(new SqlParameter("@JenisPenjaminId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _jenisPenjaminId));
                cmdToExecute.Parameters.Add(new SqlParameter("@PenjaminId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, _penjaminId));
                cmdToExecute.Parameters.Add(new SqlParameter("@StatusBayar", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _statusBayar));
				cmdToExecute.Parameters.Add(new SqlParameter("@TanggalBayar", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalBayar));
				cmdToExecute.Parameters.Add(new SqlParameter("@Keterangan", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keterangan));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _createdBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@ModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _modifiedBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _modifiedDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_Registrasi_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_Registrasi::Update::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}

		/// <summary>
		/// Purpose: Delete method. This method will Delete one existing row in the database, based on the Primary Key.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>RegistrasiId</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_Registrasi_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RegistrasiId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _registrasiId));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_Registrasi_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_Registrasi::Delete::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Select method. This method will Select one existing row from the database, based on the Primary Key.
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>RegistrasiId</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		///		 <LI>RegistrasiId</LI>
		///		 <LI>PasienId</LI>
		///		 <LI>NoRegistrasi</LI>
		///		 <LI>JenisRegistrasiId</LI>
		///		 <LI>TanggalRegistrasi</LI>
        ///		 <LI>JenisPenjaminId</LI>
        ///		 <LI>PenjaminId</LI>
        ///		 <LI>StatusBayar</LI>
		///		 <LI>TanggalBayar</LI>
		///		 <LI>Keterangan</LI>
		///		 <LI>CreatedBy</LI>
		///		 <LI>CreatedDate</LI>
		///		 <LI>ModifiedBy</LI>
		///		 <LI>ModifiedDate</LI>
		/// </UL>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
        /// 
		public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_Registrasi_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RS_Registrasi");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RegistrasiId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _registrasiId));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_Registrasi_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_registrasiId = (Int64)toReturn.Rows[0]["RegistrasiId"];
					_pasienId = (Int64)toReturn.Rows[0]["PasienId"];
					_noRegistrasi = toReturn.Rows[0]["NoRegistrasi"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["NoRegistrasi"];
					_jenisRegistrasiId = toReturn.Rows[0]["JenisRegistrasiId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["JenisRegistrasiId"];
					_tanggalRegistrasi = toReturn.Rows[0]["TanggalRegistrasi"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["TanggalRegistrasi"];
                    _jenisPenjaminId = toReturn.Rows[0]["JenisPenjaminId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["JenisPenjaminId"];
                    _penjaminId = toReturn.Rows[0]["PenjaminId"] == System.DBNull.Value ? SqlInt64.Null : (Int64)toReturn.Rows[0]["PenjaminId"];
                    _statusBayar = toReturn.Rows[0]["StatusBayar"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["StatusBayar"];
					_tanggalBayar = toReturn.Rows[0]["TanggalBayar"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["TanggalBayar"];
					_keterangan = toReturn.Rows[0]["Keterangan"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Keterangan"];
					_createdBy = toReturn.Rows[0]["CreatedBy"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["CreatedBy"];
					_createdDate = toReturn.Rows[0]["CreatedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["CreatedDate"];
					_modifiedBy = toReturn.Rows[0]["ModifiedBy"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["ModifiedBy"];
					_modifiedDate = toReturn.Rows[0]["ModifiedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["ModifiedDate"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_Registrasi::SelectOne::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}


        public DataTable SelectOne_ByPasienId()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[RS_Registrasi_SelectOne_ByPasienId]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("RS_Registrasi");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@PasienId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _pasienId));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'RS_Registrasi_SelectOne_ByPasienId' reported the ErrorCode: " + _errorCode);
                }

                if (toReturn.Rows.Count > 0)
                {
                    _registrasiId = (Int64)toReturn.Rows[0]["RegistrasiId"];
                    _pasienId = (Int64)toReturn.Rows[0]["PasienId"];
                    _noRegistrasi = toReturn.Rows[0]["NoRegistrasi"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["NoRegistrasi"];
                    _jenisRegistrasiId = toReturn.Rows[0]["JenisRegistrasiId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["JenisRegistrasiId"];
                    _tanggalRegistrasi = toReturn.Rows[0]["TanggalRegistrasi"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["TanggalRegistrasi"];
                    _jenisPenjaminId = toReturn.Rows[0]["JenisPenjaminId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["JenisPenjaminId"];
                    _penjaminId = toReturn.Rows[0]["PenjaminId"] == System.DBNull.Value ? SqlInt64.Null : (Int64)toReturn.Rows[0]["PenjaminId"];
                    _statusBayar = toReturn.Rows[0]["StatusBayar"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["StatusBayar"];
                    _tanggalBayar = toReturn.Rows[0]["TanggalBayar"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["TanggalBayar"];
                    _keterangan = toReturn.Rows[0]["Keterangan"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Keterangan"];
                    _createdBy = toReturn.Rows[0]["CreatedBy"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["CreatedBy"];
                    _createdDate = toReturn.Rows[0]["CreatedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["CreatedDate"];
                    _modifiedBy = toReturn.Rows[0]["ModifiedBy"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["ModifiedBy"];
                    _modifiedDate = toReturn.Rows[0]["ModifiedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["ModifiedDate"];
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("RS_Registrasi::SelectOne_ByPasienId::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

		/// <summary>
		/// Purpose: SelectAll method. This method will Select all rows from the table.
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override DataTable SelectAll()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_Registrasi_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RS_Registrasi");
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
					throw new Exception("Stored Procedure 'RS_Registrasi_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_Registrasi::SelectAll::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Select method for a foreign key. This method will Select one or more rows from the database, based on the Foreign Key 'PasienId'
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>PasienId</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public DataTable SelectAllWPasienIdLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_Registrasi_SelectAllWPasienIdLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RS_Registrasi");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@PasienId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _pasienId));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 19, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_Registrasi_SelectAllWPasienIdLogic' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_Registrasi::SelectAllWPasienIdLogic::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Select method for a foreign key. This method will Select one or more rows from the database, based on the Foreign Key 'JenisRegistrasiId'
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>JenisRegistrasiId. May be SqlInt32.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public DataTable SelectAllWJenisRegistrasiIdLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_Registrasi_SelectAllWJenisRegistrasiIdLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RS_Registrasi");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@JenisRegistrasiId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _jenisRegistrasiId));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_Registrasi_SelectAllWJenisRegistrasiIdLogic' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_Registrasi::SelectAllWJenisRegistrasiIdLogic::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
				adapter.Dispose();
			}
		}

        public DataTable SelectAsalPasien()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[RS_Registrasi_SelectAsalPasien]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("RS_Registrasi");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@RegistrasiId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _registrasiId));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                adapter.Fill(toReturn);
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'RS_Registrasi_SelectAsalPasien' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("RS_Registrasi::SelectAsalPasien::Error occured.", ex);
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
		public SqlInt64 RegistrasiId
		{
			get
			{
				return _registrasiId;
			}
			set
			{
				SqlInt64 registrasiIdTmp = (SqlInt64)value;
				if(registrasiIdTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("RegistrasiId", "RegistrasiId can't be NULL");
				}
				_registrasiId = value;
			}
		}


		public SqlInt64 PasienId
		{
			get
			{
				return _pasienId;
			}
			set
			{
				SqlInt64 pasienIdTmp = (SqlInt64)value;
				if(pasienIdTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("PasienId", "PasienId can't be NULL");
				}
				_pasienId = value;
			}
		}
		public SqlInt64 PasienIdOld
		{
			get
			{
				return _pasienIdOld;
			}
			set
			{
				SqlInt64 pasienIdOldTmp = (SqlInt64)value;
				if(pasienIdOldTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("PasienIdOld", "PasienIdOld can't be NULL");
				}
				_pasienIdOld = value;
			}
		}


		public SqlString NoRegistrasi
		{
			get
			{
				return _noRegistrasi;
			}
			set
			{
				_noRegistrasi = value;
			}
		}


		public SqlInt32 JenisRegistrasiId
		{
			get
			{
				return _jenisRegistrasiId;
			}
			set
			{
				_jenisRegistrasiId = value;
			}
		}
		public SqlInt32 JenisRegistrasiIdOld
		{
			get
			{
				return _jenisRegistrasiIdOld;
			}
			set
			{
				_jenisRegistrasiIdOld = value;
			}
		}


		public SqlDateTime TanggalRegistrasi
		{
			get
			{
				return _tanggalRegistrasi;
			}
			set
			{
				_tanggalRegistrasi = value;
			}
		}

        public SqlInt32 JenisPenjaminId
        {
            get
            {
                return _jenisPenjaminId;
            }
            set
            {
                _jenisPenjaminId = value;
            }
        }
        public SqlInt32 JenisPenjaminIdOld
        {
            get
            {
                return _jenisPenjaminIdOld;
            }
            set
            {
                _jenisPenjaminIdOld = value;
            }
        }


        public SqlInt64 PenjaminId
        {
            get
            {
                return _penjaminId;
            }
            set
            {
                _penjaminId = value;
            }
        }
        public SqlInt64 PenjaminIdOld
        {
            get
            {
                return _penjaminIdOld;
            }
            set
            {
                _penjaminIdOld = value;
            }
        }

		public SqlInt32 StatusBayar
		{
			get
			{
				return _statusBayar;
			}
			set
			{
				_statusBayar = value;
			}
		}


		public SqlDateTime TanggalBayar
		{
			get
			{
				return _tanggalBayar;
			}
			set
			{
				_tanggalBayar = value;
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


		public SqlInt32 CreatedBy
		{
			get
			{
				return _createdBy;
			}
			set
			{
				_createdBy = value;
			}
		}


		public SqlDateTime CreatedDate
		{
			get
			{
				return _createdDate;
			}
			set
			{
				_createdDate = value;
			}
		}


		public SqlInt32 ModifiedBy
		{
			get
			{
				return _modifiedBy;
			}
			set
			{
				_modifiedBy = value;
			}
		}


		public SqlDateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				_modifiedDate = value;
			}
		}

        public SqlString NoUrut
        {
            get
            {
                return _noUrut;
            }
            set
            {
                _noUrut = value;
            }
        }

		#endregion
	}
}
