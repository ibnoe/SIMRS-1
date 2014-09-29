using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace SIMRS.DataAccess
{
	public class RS_RM : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlInt64		_registrasiId;
			private SqlBoolean		_flagTerakhir;
			private SqlDateTime		_tanggalMasuk, _tanggalKeluar, _createdDate, _modifiedDate, _tanggalPeriksa;
			private SqlInt32		_dokterId, _dokterIdOld, _statusRMId, _modifiedBy, _createdBy;
			private SqlString		_obat, _tindakanMedis, _keteranganStatus, _keterangan, _keluhanTambahan, _pemeriksaanFisik, _keluhanUtama, _perawat, _jamPeriksa, _penyakitSebelumnya, _penyakitKeluarga, _penyakitSekarang, _pemeriksaanLab, _diagnosa;
		#endregion

		public RS_RM()
		{
			// Nothing for now.
		}

		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_RM_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RegistrasiId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _registrasiId));
				cmdToExecute.Parameters.Add(new SqlParameter("@DokterId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _dokterId));
				cmdToExecute.Parameters.Add(new SqlParameter("@Perawat", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _perawat));
				cmdToExecute.Parameters.Add(new SqlParameter("@TanggalPeriksa", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalPeriksa));
				cmdToExecute.Parameters.Add(new SqlParameter("@JamPeriksa", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _jamPeriksa));
				cmdToExecute.Parameters.Add(new SqlParameter("@TanggalMasuk", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalMasuk));
				cmdToExecute.Parameters.Add(new SqlParameter("@TanggalKeluar", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalKeluar));
				cmdToExecute.Parameters.Add(new SqlParameter("@KeluhanUtama", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keluhanUtama));
				cmdToExecute.Parameters.Add(new SqlParameter("@KeluhanTambahan", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keluhanTambahan));
				cmdToExecute.Parameters.Add(new SqlParameter("@PemeriksaanFisik", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _pemeriksaanFisik));
				cmdToExecute.Parameters.Add(new SqlParameter("@PemeriksaanLab", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _pemeriksaanLab));
				cmdToExecute.Parameters.Add(new SqlParameter("@Diagnosa", SqlDbType.VarChar, 1000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _diagnosa));
				cmdToExecute.Parameters.Add(new SqlParameter("@PenyakitSekarang", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _penyakitSekarang));
				cmdToExecute.Parameters.Add(new SqlParameter("@PenyakitSebelumnya", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _penyakitSebelumnya));
				cmdToExecute.Parameters.Add(new SqlParameter("@PenyakitKeluarga", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _penyakitKeluarga));
				cmdToExecute.Parameters.Add(new SqlParameter("@TindakanMedis", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tindakanMedis));
				cmdToExecute.Parameters.Add(new SqlParameter("@Obat", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _obat));
				cmdToExecute.Parameters.Add(new SqlParameter("@Keterangan", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keterangan));
				cmdToExecute.Parameters.Add(new SqlParameter("@StatusRMId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _statusRMId));
				cmdToExecute.Parameters.Add(new SqlParameter("@KeteranganStatus", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keteranganStatus));
				cmdToExecute.Parameters.Add(new SqlParameter("@FlagTerakhir", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _flagTerakhir));
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
					throw new Exception("Stored Procedure 'RS_RM_Insert' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RM::Insert::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[RS_RM_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@RegistrasiId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, _registrasiId));
				cmdToExecute.Parameters.Add(new SqlParameter("@DokterId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _dokterId));
				cmdToExecute.Parameters.Add(new SqlParameter("@Perawat", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _perawat));
				cmdToExecute.Parameters.Add(new SqlParameter("@TanggalPeriksa", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalPeriksa));
				cmdToExecute.Parameters.Add(new SqlParameter("@JamPeriksa", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _jamPeriksa));
				cmdToExecute.Parameters.Add(new SqlParameter("@TanggalMasuk", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalMasuk));
				cmdToExecute.Parameters.Add(new SqlParameter("@TanggalKeluar", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tanggalKeluar));
				cmdToExecute.Parameters.Add(new SqlParameter("@KeluhanUtama", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keluhanUtama));
				cmdToExecute.Parameters.Add(new SqlParameter("@KeluhanTambahan", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keluhanTambahan));
				cmdToExecute.Parameters.Add(new SqlParameter("@PemeriksaanFisik", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _pemeriksaanFisik));
				cmdToExecute.Parameters.Add(new SqlParameter("@PemeriksaanLab", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _pemeriksaanLab));
				cmdToExecute.Parameters.Add(new SqlParameter("@Diagnosa", SqlDbType.VarChar, 1000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _diagnosa));
				cmdToExecute.Parameters.Add(new SqlParameter("@PenyakitSekarang", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _penyakitSekarang));
				cmdToExecute.Parameters.Add(new SqlParameter("@PenyakitSebelumnya", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _penyakitSebelumnya));
				cmdToExecute.Parameters.Add(new SqlParameter("@PenyakitKeluarga", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _penyakitKeluarga));
				cmdToExecute.Parameters.Add(new SqlParameter("@TindakanMedis", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _tindakanMedis));
				cmdToExecute.Parameters.Add(new SqlParameter("@Obat", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _obat));
				cmdToExecute.Parameters.Add(new SqlParameter("@Keterangan", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keterangan));
				cmdToExecute.Parameters.Add(new SqlParameter("@StatusRMId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _statusRMId));
				cmdToExecute.Parameters.Add(new SqlParameter("@KeteranganStatus", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _keteranganStatus));
				cmdToExecute.Parameters.Add(new SqlParameter("@FlagTerakhir", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _flagTerakhir));
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
					throw new Exception("Stored Procedure 'RS_RM_Update' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RM::Update::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}

		public bool UpdateAllWDokterIdLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_RM_UpdateAllWDokterIdLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@DokterId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _dokterId));
				cmdToExecute.Parameters.Add(new SqlParameter("@DokterIdOld", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _dokterIdOld));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_RM_UpdateAllWDokterIdLogic' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RM::UpdateAllWDokterIdLogic::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[RS_RM_Delete]";
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
					throw new Exception("Stored Procedure 'RS_RM_Delete' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RM::Delete::Error occured.", ex);
			}
			finally
			{
				// Close connection.
				_mainConnection.Close();
				cmdToExecute.Dispose();
			}
		}

		public bool DeleteAllWDokterIdLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_RM_DeleteAllWDokterIdLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@DokterId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _dokterId));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_RM_DeleteAllWDokterIdLogic' reported the ErrorCode: " + _errorCode);
				}

				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RM::DeleteAllWDokterIdLogic::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[RS_RM_SelectOne]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RS_RM");
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
					throw new Exception("Stored Procedure 'RS_RM_SelectOne' reported the ErrorCode: " + _errorCode);
				}

				if(toReturn.Rows.Count > 0)
				{
					_registrasiId = (Int64)toReturn.Rows[0]["RegistrasiId"];
					_dokterId = toReturn.Rows[0]["DokterId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["DokterId"];
					_perawat = toReturn.Rows[0]["Perawat"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Perawat"];
					_tanggalPeriksa = toReturn.Rows[0]["TanggalPeriksa"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["TanggalPeriksa"];
					_jamPeriksa = toReturn.Rows[0]["JamPeriksa"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["JamPeriksa"];
					_tanggalMasuk = toReturn.Rows[0]["TanggalMasuk"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["TanggalMasuk"];
					_tanggalKeluar = toReturn.Rows[0]["TanggalKeluar"] == System.DBNull.Value ? SqlDateTime.Null : (DateTime)toReturn.Rows[0]["TanggalKeluar"];
					_keluhanUtama = toReturn.Rows[0]["KeluhanUtama"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["KeluhanUtama"];
					_keluhanTambahan = toReturn.Rows[0]["KeluhanTambahan"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["KeluhanTambahan"];
					_pemeriksaanFisik = toReturn.Rows[0]["PemeriksaanFisik"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["PemeriksaanFisik"];
					_pemeriksaanLab = toReturn.Rows[0]["PemeriksaanLab"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["PemeriksaanLab"];
					_diagnosa = toReturn.Rows[0]["Diagnosa"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Diagnosa"];
					_penyakitSekarang = toReturn.Rows[0]["PenyakitSekarang"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["PenyakitSekarang"];
					_penyakitSebelumnya = toReturn.Rows[0]["PenyakitSebelumnya"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["PenyakitSebelumnya"];
					_penyakitKeluarga = toReturn.Rows[0]["PenyakitKeluarga"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["PenyakitKeluarga"];
					_tindakanMedis = toReturn.Rows[0]["TindakanMedis"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["TindakanMedis"];
					_obat = toReturn.Rows[0]["Obat"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Obat"];
					_keterangan = toReturn.Rows[0]["Keterangan"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Keterangan"];
					_statusRMId = toReturn.Rows[0]["StatusRMId"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["StatusRMId"];
					_keteranganStatus = toReturn.Rows[0]["KeteranganStatus"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["KeteranganStatus"];
					_flagTerakhir = toReturn.Rows[0]["FlagTerakhir"] == System.DBNull.Value ? SqlBoolean.Null : (bool)toReturn.Rows[0]["FlagTerakhir"];
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
				throw new Exception("RS_RM::SelectOne::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[RS_RM_SelectAll]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RS_RM");
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
					throw new Exception("Stored Procedure 'RS_RM_SelectAll' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RM::SelectAll::Error occured.", ex);
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
		/// Purpose: Select method for a foreign key. This method will Select one or more rows from the database, based on the Foreign Key 'DokterId'
		/// </summary>
		/// <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>DokterId. May be SqlInt32.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ErrorCode</LI>
		/// </UL>
		/// </remarks>
		public DataTable SelectAllWDokterIdLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[RS_RM_SelectAllWDokterIdLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("RS_RM");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@DokterId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _dokterId));
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

				// Open connection.
				_mainConnection.Open();

				// Execute query.
				adapter.Fill(toReturn);
				_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

				if(_errorCode != (int)LLBLError.AllOk)
				{
					// Throw error.
					throw new Exception("Stored Procedure 'RS_RM_SelectAllWDokterIdLogic' reported the ErrorCode: " + _errorCode);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("RS_RM::SelectAllWDokterIdLogic::Error occured.", ex);
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


		public SqlInt32 DokterId
		{
			get
			{
				return _dokterId;
			}
			set
			{
				_dokterId = value;
			}
		}
		public SqlInt32 DokterIdOld
		{
			get
			{
				return _dokterIdOld;
			}
			set
			{
				_dokterIdOld = value;
			}
		}


		public SqlString Perawat
		{
			get
			{
				return _perawat;
			}
			set
			{
				_perawat = value;
			}
		}


		public SqlDateTime TanggalPeriksa
		{
			get
			{
				return _tanggalPeriksa;
			}
			set
			{
				_tanggalPeriksa = value;
			}
		}


		public SqlString JamPeriksa
		{
			get
			{
				return _jamPeriksa;
			}
			set
			{
				_jamPeriksa = value;
			}
		}


		public SqlDateTime TanggalMasuk
		{
			get
			{
				return _tanggalMasuk;
			}
			set
			{
				_tanggalMasuk = value;
			}
		}


		public SqlDateTime TanggalKeluar
		{
			get
			{
				return _tanggalKeluar;
			}
			set
			{
				_tanggalKeluar = value;
			}
		}


		public SqlString KeluhanUtama
		{
			get
			{
				return _keluhanUtama;
			}
			set
			{
				_keluhanUtama = value;
			}
		}


		public SqlString KeluhanTambahan
		{
			get
			{
				return _keluhanTambahan;
			}
			set
			{
				_keluhanTambahan = value;
			}
		}


		public SqlString PemeriksaanFisik
		{
			get
			{
				return _pemeriksaanFisik;
			}
			set
			{
				_pemeriksaanFisik = value;
			}
		}


		public SqlString PemeriksaanLab
		{
			get
			{
				return _pemeriksaanLab;
			}
			set
			{
				_pemeriksaanLab = value;
			}
		}


		public SqlString Diagnosa
		{
			get
			{
				return _diagnosa;
			}
			set
			{
				_diagnosa = value;
			}
		}


		public SqlString PenyakitSekarang
		{
			get
			{
				return _penyakitSekarang;
			}
			set
			{
				_penyakitSekarang = value;
			}
		}


		public SqlString PenyakitSebelumnya
		{
			get
			{
				return _penyakitSebelumnya;
			}
			set
			{
				_penyakitSebelumnya = value;
			}
		}


		public SqlString PenyakitKeluarga
		{
			get
			{
				return _penyakitKeluarga;
			}
			set
			{
				_penyakitKeluarga = value;
			}
		}


		public SqlString TindakanMedis
		{
			get
			{
				return _tindakanMedis;
			}
			set
			{
				_tindakanMedis = value;
			}
		}


		public SqlString Obat
		{
			get
			{
				return _obat;
			}
			set
			{
				_obat = value;
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


		public SqlInt32 StatusRMId
		{
			get
			{
				return _statusRMId;
			}
			set
			{
				_statusRMId = value;
			}
		}


		public SqlString KeteranganStatus
		{
			get
			{
				return _keteranganStatus;
			}
			set
			{
				_keteranganStatus = value;
			}
		}


		public SqlBoolean FlagTerakhir
		{
			get
			{
				return _flagTerakhir;
			}
			set
			{
				_flagTerakhir = value;
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
		#endregion
	}
}
