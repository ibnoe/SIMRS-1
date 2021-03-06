///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'RS_RIDeposit'
// Generated by LLBLGen v1.21.2003.712 Final on: 15 January 2008, 23:49:17
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SIMRS.DataAccess
{
	/// <summary>
	/// Purpose: Data Access class for the table 'RS_RIDeposit'.
	/// </summary>
	public class RS_RIDeposit : RS_RIKuitansi
	{
		#region Class Member Declarations
			private SqlInt64		_rawatInapId, _rIDepositId;
            private SqlDateTime     _modifiedDate, _createdDate, _tanggalTransaksi, _tanggalBayar;
			private SqlInt32		_createdBy, _modifiedBy, _statusBayar;
			private SqlMoney		_deposit;
			private SqlString		_keterangan;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public RS_RIDeposit()
		{
			// Nothing for now.
		}


		/// <summary>
		/// Purpose: Insert method. This method will insert one new row into the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>RawatInapId</LI>
		///		 <LI>TanggalTransaksi. May be SqlDateTime.Null</LI>
		///		 <LI>Deposit. May be SqlMoney.Null</LI>
		///		 <LI>Keterangan. May be SqlString.Null</LI>
		///		 <LI>CreatedBy</LI>
		///		 <LI>CreatedDate</LI>
		///		 <LI>ModifiedBy. May be SqlInt32.Null</LI>
		///		 <LI>ModifiedDate. May be SqlDateTime.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>RIDepositId</LI>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_RIDeposit_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RawatInapId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _rawatInapId));
				cmdToExecute.Parameters.Add(new SqlParameter("@TanggalTransaksi", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalTransaksi));
				cmdToExecute.Parameters.Add(new SqlParameter("@Deposit", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, _deposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@StatusBayar", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _statusBayar));
                cmdToExecute.Parameters.Add(new SqlParameter("@TanggalBayar", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalBayar));
                cmdToExecute.Parameters.Add(new SqlParameter("@Keterangan", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keterangan));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@ModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _modifiedBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _modifiedDate));
				cmdToExecute.Parameters.Add(new SqlParameter("@RIDepositId", SqlDbType.BigInt, 8, ParameterDirection.Output, true, 19, 0, "", DataRowVersion.Proposed, _rIDepositId));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_rIDepositId = (SqlInt64)cmdToExecute.Parameters["@RIDepositId"].Value;
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_RIDeposit_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RIDeposit::Insert::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}

        public bool Bayar()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[RS_RIDeposit_Bayar]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@RawatInapId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _rawatInapId));
                cmdToExecute.Parameters.Add(new SqlParameter("@NomorKuitansi", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, NomorKuitansi));
                cmdToExecute.Parameters.Add(new SqlParameter("@DiterimaDari", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DiterimaDari));
                cmdToExecute.Parameters.Add(new SqlParameter("@JumlahBiaya", SqlDbType.Money, 8, ParameterDirection.Input, false, 19, 4, "", DataRowVersion.Proposed, JumlahBiaya));
                cmdToExecute.Parameters.Add(new SqlParameter("@JumlahBiayaText", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, JumlahBiayaText));
                cmdToExecute.Parameters.Add(new SqlParameter("@TanggalBayar", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalBayar));
                cmdToExecute.Parameters.Add(new SqlParameter("@Keterangan", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keterangan));
                cmdToExecute.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, CreatedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CreatedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@ModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ModifiedBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ModifiedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@RIDepositId", SqlDbType.BigInt, 8, ParameterDirection.Output, true, 19, 0, "", DataRowVersion.Proposed, _rIDepositId));
                cmdToExecute.Parameters.Add(new SqlParameter("@KuitansiId", SqlDbType.BigInt, 8, ParameterDirection.Output, true, 19, 0, "", DataRowVersion.Proposed, KuitansiId));
                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                // Open connection.
                _mainConnection.Open();

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                KuitansiId = (SqlInt64)cmdToExecute.Parameters["@KuitansiId"].Value;
                _rIDepositId = (SqlInt64)cmdToExecute.Parameters["@RIDepositId"].Value;
                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'RS_RIDeposit_Bayar' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("RS_RIDeposit::Bayar::Error occured.", ex);
            }
            finally
            {
                // Close connection.
                _mainConnection.Close();
                cmdToExecute.Dispose();
            }
        }

		/// <summary>
		/// Purpose: Update method. This method will Update one existing row in the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>RIDepositId</LI>
		///		 <LI>RawatInapId</LI>
		///		 <LI>TanggalTransaksi. May be SqlDateTime.Null</LI>
		///		 <LI>Deposit. May be SqlMoney.Null</LI>
		///		 <LI>Keterangan. May be SqlString.Null</LI>
		///		 <LI>CreatedBy</LI>
		///		 <LI>CreatedDate</LI>
		///		 <LI>ModifiedBy. May be SqlInt32.Null</LI>
		///		 <LI>ModifiedDate. May be SqlDateTime.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_RIDeposit_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RIDepositId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _rIDepositId));
				cmdToExecute.Parameters.Add(new SqlParameter("@RawatInapId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _rawatInapId));
				cmdToExecute.Parameters.Add(new SqlParameter("@TanggalTransaksi", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalTransaksi));
				cmdToExecute.Parameters.Add(new SqlParameter("@Deposit", SqlDbType.Money, 8, ParameterDirection.Input, true, 19, 4, "", DataRowVersion.Proposed, _deposit));
                cmdToExecute.Parameters.Add(new SqlParameter("@StatusBayar", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _statusBayar));
                cmdToExecute.Parameters.Add(new SqlParameter("@TanggalBayar", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalBayar));
                cmdToExecute.Parameters.Add(new SqlParameter("@Keterangan", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keterangan));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _createdBy));
				cmdToExecute.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _createdDate));
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
					throw new Exception("Stored Procedure 'RS_RIDeposit_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RIDeposit::Update::Error occured.", ex);
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
		///		 <LI>RIDepositId</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_RIDeposit_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RIDepositId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _rIDepositId));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_RIDeposit_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RIDeposit::Delete::Error occured.", ex);
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
		///		 <LI>RIDepositId</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		///		 <LI>RIDepositId</LI>
		///		 <LI>RawatInapId</LI>
		///		 <LI>TanggalTransaksi</LI>
		///		 <LI>Deposit</LI>
		///		 <LI>Keterangan</LI>
		///		 <LI>CreatedBy</LI>
		///		 <LI>CreatedDate</LI>
		///		 <LI>ModifiedBy</LI>
		///		 <LI>ModifiedDate</LI>
		/// </UL>
		/// Will fill all properties corresponding with a field in the table with the value of the row selected.
		/// </remarks>
		public override DataTable SelectOne()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_RIDeposit_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RS_RIDeposit");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RIDepositId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _rIDepositId));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_RIDeposit_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_rIDepositId = (Int64)toReturn.Rows[0]["RIDepositId"];
					_rawatInapId = (Int64)toReturn.Rows[0]["RawatInapId"];
                    KuitansiId = (Int64)toReturn.Rows[0]["KuitansiId"];
                    NomorKuitansi = toReturn.Rows[0]["NomorKuitansi"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["NomorKuitansi"];
                    DiterimaDari = toReturn.Rows[0]["DiterimaDari"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["DiterimaDari"];
                    JumlahBiaya = (Decimal)toReturn.Rows[0]["JumlahBiaya"];
                    JumlahBiayaText = toReturn.Rows[0]["JumlahBiayaText"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["JumlahBiayaText"];
                    TanggalBayar = toReturn.Rows[0]["TanggalBayar"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["TanggalBayar"];
					
                    _tanggalTransaksi = toReturn.Rows[0]["TanggalTransaksi"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["TanggalTransaksi"];
					_deposit = toReturn.Rows[0]["Deposit"] == System.DBNull.Value ? SqlMoney.Null : (Decimal)toReturn.Rows[0]["Deposit"];
                    _statusBayar = (Int32)toReturn.Rows[0]["StatusBayar"];
                    _tanggalBayar = toReturn.Rows[0]["TanggalBayar"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["TanggalBayar"];
                    _keterangan = toReturn.Rows[0]["Keterangan"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Keterangan"];
					_createdBy = (Int32)toReturn.Rows[0]["CreatedBy"];
					_createdDate = (DateTime)toReturn.Rows[0]["CreatedDate"];
					_modifiedBy = toReturn.Rows[0]["ModifiedBy"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["ModifiedBy"];
					_modifiedDate = toReturn.Rows[0]["ModifiedDate"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["ModifiedDate"];
				}
				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RIDeposit::SelectOne::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[RS_RIDeposit_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RS_RIDeposit");
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
					throw new Exception("Stored Procedure 'RS_RIDeposit_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RIDeposit::SelectAll::Error occured.", ex);
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
		/// Purpose: Select method for a foreign key. This method will Select one or more rows from the database, based on the Foreign Key 'RawatInapId'
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>RawatInapId</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public DataTable GetAllWRawatInapIdLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_RIDeposit_SelectAllWRawatInapIdLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RS_RIDeposit");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RawatInapId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _rawatInapId));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 19, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_RIDeposit_SelectAllWRawatInapIdLogic' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RIDeposit::SelectAllWRawatInapIdLogic::Error occured.", ex);
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
		public SqlInt64 RIDepositId
		{
			get
			{
				return _rIDepositId;
			}
			set
			{
				SqlInt64 rIDepositIdTmp = (SqlInt64)value;
				if(rIDepositIdTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("RIDepositId", "RIDepositId can't be NULL");
				}
				_rIDepositId = value;
			}
		}


        //public SqlInt64 RawatInapId
        //{
        //    get
        //    {
        //        return _rawatInapId;
        //    }
        //    set
        //    {
        //        SqlInt64 rawatInapIdTmp = (SqlInt64)value;
        //        if(rawatInapIdTmp.IsNull)
        //        {
        //            throw new ArgumentOutOfRangeException("RawatInapId", "RawatInapId can't be NULL");
        //        }
        //        _rawatInapId = value;
        //    }
        //}
        //public SqlInt64 RawatInapIdOld
        //{
        //    get
        //    {
        //        return _rawatInapIdOld;
        //    }
        //    set
        //    {
        //        SqlInt64 rawatInapIdOldTmp = (SqlInt64)value;
        //        if(rawatInapIdOldTmp.IsNull)
        //        {
        //            throw new ArgumentOutOfRangeException("RawatInapIdOld", "RawatInapIdOld can't be NULL");
        //        }
        //        _rawatInapIdOld = value;
        //    }
        //}


		public SqlDateTime TanggalTransaksi
		{
			get
			{
				return _tanggalTransaksi;
			}
			set
			{
				_tanggalTransaksi = value;
			}
		}


		public SqlMoney Deposit
		{
			get
			{
				return _deposit;
			}
			set
			{
				_deposit = value;
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


        //public SqlDateTime TanggalBayar
        //{
        //    get
        //    {
        //        return _tanggalBayar;
        //    }
        //    set
        //    {
        //        _tanggalBayar = value;
        //    }
        //}

        //public SqlString Keterangan
        //{
        //    get
        //    {
        //        return _keterangan;
        //    }
        //    set
        //    {
        //        _keterangan = value;
        //    }
        //}


        //public SqlInt32 CreatedBy
        //{
        //    get
        //    {
        //        return _createdBy;
        //    }
        //    set
        //    {
        //        SqlInt32 createdByTmp = (SqlInt32)value;
        //        if(createdByTmp.IsNull)
        //        {
        //            throw new ArgumentOutOfRangeException("CreatedBy", "CreatedBy can't be NULL");
        //        }
        //        _createdBy = value;
        //    }
        //}


        //public SqlDateTime CreatedDate
        //{
        //    get
        //    {
        //        return _createdDate;
        //    }
        //    set
        //    {
        //        SqlDateTime createdDateTmp = (SqlDateTime)value;
        //        if(createdDateTmp.IsNull)
        //        {
        //            throw new ArgumentOutOfRangeException("CreatedDate", "CreatedDate can't be NULL");
        //        }
        //        _createdDate = value;
        //    }
        //}


        //public SqlInt32 ModifiedBy
        //{
        //    get
        //    {
        //        return _modifiedBy;
        //    }
        //    set
        //    {
        //        _modifiedBy = value;
        //    }
        //}


        //public SqlDateTime ModifiedDate
        //{
        //    get
        //    {
        //        return _modifiedDate;
        //    }
        //    set
        //    {
        //        _modifiedDate = value;
        //    }
        //}
		#endregion
	}
}
