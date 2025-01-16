using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using OnePiece.Models;

namespace OnePiece.ADO
{
    public class ProposalsAdo
    {
        private readonly string _connectionString;

        public ProposalsAdo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Proposal> GetAll(string searchTerm)
        {
            var results = new List<Proposal>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var sql = @"SELECT p.* 
                            FROM Proposal p
                            LEFT JOIN Treasure t ON p.ProposedTreasureID = t.TreasureID";

                // Filtre si searchTerm
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    sql += " WHERE t.Denomination LIKE @searchTerm";
                }

                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var proposal = new Proposal
                            {
                                ProposalID = (int)reader["ProposalID"],
                                ProposedTreasureID = (int)reader["ProposedTreasureID"],
                                ProposingPirateID = (int)reader["ProposingPirateID"],
                                RequestingPirateID = (int)reader["RequestingPirateID"]
                            };
                            results.Add(proposal);
                        }
                    }
                }
            }
            return results;
        }
    }
}
