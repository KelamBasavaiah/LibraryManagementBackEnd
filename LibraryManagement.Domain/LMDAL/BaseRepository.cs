using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.LMDAL
{
    internal abstract class BaseRepository
    {
        protected static async Task<T> ExecuteReader<T>(string storedProc,Func<SqlDataReader, Task<T>> mapper,Action<SqlParameterCollection> stroredProcParams = null)
        {
            return await ProcessCommandAsync(storedProc, stroredProcParams,
                async command =>
                {
                    using (var reader =
                        await command.ExecuteReaderAsync())
                    {
                        return await mapper(reader);
                    }
                });
        }

      

        private static async Task<T> ProcessCommandAsync<T>(string storedProc,
                                                            Action<SqlParameterCollection> stroredProcParams, Func<SqlCommand, Task<T>> processCommand)
        {


            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conBook"].ConnectionString))
            {
                //await connection.OpenAsync().ConfigureAwait(false);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = storedProc;
                    command.CommandType = CommandType.StoredProcedure;

                    if (stroredProcParams != null)
                    {
                        stroredProcParams(command.Parameters);
                    }
                

                    try
                    {
                        return await processCommand(command);
                    }
                    catch (SqlException ex)
                    {
                        throw ;
                    }
                }
            }
        }
    }
}
